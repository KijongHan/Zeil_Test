public class ExceptionToProblemDetailsHandler : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;
    private readonly ILogger<ExceptionToProblemDetailsHandler> _logger;

    public ExceptionToProblemDetailsHandler(IProblemDetailsService problemDetailsService, ILogger<ExceptionToProblemDetailsHandler> logger)
    {
        _problemDetailsService = problemDetailsService;
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        switch (exception)
        {
            case BadHttpRequestException:
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
                {
                    HttpContext = httpContext,
                    ProblemDetails =
                    {
                        Title = "An error occurred processing the request.",
                        Detail = $"The request format is invalid. {exception.Message}",
                        Type = exception.GetType().Name,
                    },
                    Exception = exception
                });
                return true;
            default:
                _logger.LogError(exception, "An unhandled exception has occurred while executing the request.");
                return false;
        }
    }
}