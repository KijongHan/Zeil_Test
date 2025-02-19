using Zeil.Domain.UseCases;

namespace Zeil.Domain.Tests;

public class LuhnCheckIsValidTests
{
    [Test]
    public void GivenSingleDigitAndValidChecksum_ShouldReturnValid()
    {
        Assert.IsTrue(CreditCardUseCases.LuhnCheckIsValid(new CreditCard([1, 8])).IsValid);
    }

    [TestCase(49927398716)]
    [TestCase(51567398716432196)]
    public void GivenValidChecksum_ShouldReturnValid(long validCardNumber)
    {
        Assert.IsTrue(CreditCardUseCases.LuhnCheckIsValid(new CreditCard(validCardNumber)).IsValid);
    }

    [Test]
    public void GivenSingleDigitCard_ShouldReturnInvalidValid()
    {
        Assert.IsFalse(CreditCardUseCases.LuhnCheckIsValid(new CreditCard(1)).IsValid);
    }

    [TestCase(49927398717)]
    [TestCase(51567398716432197)]
    public void GivenInvalidChecksum_ShouldReturnInvalid(long invalidCardNumber)
    {
        Assert.IsFalse(CreditCardUseCases.LuhnCheckIsValid(new CreditCard(invalidCardNumber)).IsValid);
    }

    [Test]
    public void WhenLuhnCheckIsValid_ShouldReturnChecksum()
    {
        var card = new CreditCard(49927398717);
        Assert.That(CreditCardUseCases.LuhnCheckIsValid(card).ActualChecksum, Is.EqualTo(7));
        Assert.That(CreditCardUseCases.LuhnCheckIsValid(card).CalculatedChecksum, Is.EqualTo(6));
    }
}
