namespace Zeil.Domain.UseCases;

public static class CreditCardUseCases
{
    public static CreditCardValidationResult LuhnCheckIsValid(CreditCard creditCard)
    {
        if (creditCard.CardNumbers.Length < 2)
        {
            return new CreditCardValidationResult(false, -1, -1, "Credit card number must have at least 2 digits.");
        }

        int sum = 0;
        int parity = creditCard.CardNumbers.Length % 2;

        for (int i = 0; i < creditCard.CardNumbers.Length - 1; i++)
        {
            if (i % 2 != parity)
            {
                sum += creditCard.CardNumbers[i];
            }
            else if (creditCard.CardNumbers[i] > 4)
            {
                sum += 2 * creditCard.CardNumbers[i] - 9;
            }
            else
            {
                sum += 2 * creditCard.CardNumbers[i];
            }
        }

        var calculatedChecksum = (10 - (sum % 10)) % 10;
        var actualChecksum = creditCard.CheckSum ?? 0;
        var valid = calculatedChecksum == actualChecksum;
        return new CreditCardValidationResult(valid, calculatedChecksum, actualChecksum, valid ? "Credit card number is valid." : "Credit card number is invalid.");
    }
}