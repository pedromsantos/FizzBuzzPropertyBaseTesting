using FsCheck;
using FsCheck.Fluent;

namespace FizzBuzzTests
{
    public class NumberGenerator
    {
        public Gen<int> Numbers { get; private set; }

        public NumberGenerator()
        {
            Numbers = Any.OfType<int>();
        }

        public NumberGenerator PositiveNumbers()
        {
            Numbers = Numbers.Where(n => n > 0);
            return this;
        }

        public NumberGenerator Exluding(int exclude)
        {
            Numbers = Numbers.Where(n => n != 0);
            return this;
        }

        public NumberGenerator DivisibleBy(int divisor)
        {
            Numbers = Numbers.Where(n => n % divisor == 0);
            return this;
        }

        public NumberGenerator NotDivisibleBy(int divisor)
        {
            Numbers = Numbers.Where(n => n % divisor != 0);
            return this;
        }
    }
}