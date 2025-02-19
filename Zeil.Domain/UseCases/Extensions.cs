using System.Collections.Generic;

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

    public static int ToNumber(this List<int> digits)
    {
        int number = 0;
        foreach (var digit in digits)
        {
            number = number * 10 + digit;
        }
        return number;
    }
}
