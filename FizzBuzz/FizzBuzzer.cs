using System.Globalization;

namespace FizzBuzz
{
    public class FizzBuzzer
    {
        private const int FizzDivisor = 3;
        private const int BuzzDivisor = 5;

        public string Translate(int number)
        {
            if (number.DivisibleBy(FizzDivisor) && number.DivisibleBy(BuzzDivisor))
            {
                return "FizzBuzz";
            }

            if (number.DivisibleBy(BuzzDivisor))
            {
                return "Buzz";
            }

            if (number.DivisibleBy(FizzDivisor))
            {
                return "Fizz";
            }

            return number.ToString(CultureInfo.InvariantCulture);
        }
    }

    public static class Divisible
    {
        public static bool DivisibleBy(this int number, int divisor)
        {
            return number % divisor == 0;
        }
    }
}