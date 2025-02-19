namespace Zeil.Domain.Utils;

public static class Extensions
{
    public static List<int> ToDigitList(this long number)
    {
        var digits = new List<int>();
        while (number > 0)
        {
            digits.Add((int)(number % 10));
            number /= 10;
        }
        digits.Reverse();
        return digits;
    }
}