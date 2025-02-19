using Zeil.Domain.Utils;

public record CreditCard(int[] CardNumbers)
{
    public int? CheckSum => CardNumbers.Length > 0 ? CardNumbers[^1] : null;

    public CreditCard(long cardNumber)
        : this([.. cardNumber.ToDigitList()])
    {
    }
}
