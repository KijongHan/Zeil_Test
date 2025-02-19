using Microsoft.AspNetCore.Http.HttpResults;
using Zeil.Domain.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<ExceptionToProblemDetailsHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler(exceptionHandlerApp
    => exceptionHandlerApp.Run(async context
        => await Results.Problem()
                     .ExecuteAsync(context)));

app.MapGet("system/ping", () =>
{
    return Results.Ok("pong");
});

app.MapGet("system/exception", () =>
{
    throw new InvalidOperationException("This is an exception test");
});

app.MapPost("/creditcard/validate", (CreditCardDto card) =>
{
    var creditCard = new CreditCard(card.CardNumber);
    var validationResult = CreditCardUseCases.LuhnCheckIsValid(creditCard);

    if (!validationResult.IsValid)
    {
        return Results.Problem($"{validationResult}", statusCode: StatusCodes.Status422UnprocessableEntity);
    }
    return Results.Ok(validationResult);
});

app.Run();
