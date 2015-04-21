using FizzBuzz;
using FsCheck.Fluent;
using NUnit.Framework;
using System.Globalization;

namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzerShould
    {
        private FizzBuzzer _fizzBuzzer;
        private NumberGenerator _generate;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzzer = new FizzBuzzer();
            _generate = new NumberGenerator();

            _generate
                .PositiveNumbers()
                .Exluding(0);
        }

        [Test]
        public void TranslateNumbersNotDivisibleByThreeOrFiveToItsStringRepresentation()
        {
            var numbers = _generate
                .NotDivisibleBy(3)
                .NotDivisibleBy(5)
                .Numbers;

            Spec.For(numbers,
                n => _fizzBuzzer.Translate(n)
                    .Equals(n.ToString(CultureInfo.InvariantCulture)))
                    .QuickCheckThrowOnFailure();
        }

        [Test]
        public void TranslateNumbersDivisibleByThreeAndNotFiveToFizz()
        {
            var numbers = _generate
                .DivisibleBy(3)
                .NotDivisibleBy(5)
                .Numbers;

            Spec.For(numbers,
                n => _fizzBuzzer.Translate(n)
                    .Equals("Fizz"))
                    .QuickCheckThrowOnFailure();
        }

        [Test]
        public void TranslateNumbersDivisibleByFiveAndNotThreeToBuzz()
        {
            var numbers = _generate
                .DivisibleBy(5)
                .NotDivisibleBy(3)
                .Numbers;

            Spec.For(numbers,
                n => _fizzBuzzer.Translate(n)
                    .Equals("Buzz"))
                    .QuickCheckThrowOnFailure();
        }

        [Test]
        public void TranslateNumbersDivisibleByThreeAndFiveToBuzz()
        {
            var numbers = _generate
                .DivisibleBy(3)
                .DivisibleBy(5)
                .Numbers;

            Spec.For(numbers,
                n => _fizzBuzzer.Translate(n)
                    .Equals("FizzBuzz"))
                    .QuickCheckThrowOnFailure();
        }

    }
}
