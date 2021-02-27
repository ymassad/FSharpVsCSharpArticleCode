using System;

namespace LookAndSayCSharp
{
    public static class Module1
    {
        public static string LookAndSay(string str)
        {
            if (str.Length == 0)
                return "";

            var digits = str.ToCharArray();

            char currentGroupDigit = digits[0];

            int countOfDigitsSoFar = 1;

            string result = "";

            for (int i = 1; i < digits.Length; i++)
            {
                var digit = digits[i];

                if (currentGroupDigit == digit) //Case #2.a
                {
                    countOfDigitsSoFar++;
                }
                else  //Case #2.b
                {
                    result += countOfDigitsSoFar.ToString() + currentGroupDigit;

                    currentGroupDigit = digit;

                    countOfDigitsSoFar = 1;
                }
            }

            if (countOfDigitsSoFar > 0) //handle the last group
            {
                result += countOfDigitsSoFar.ToString() + currentGroupDigit;
            }

            return result;
        }
    }
}
