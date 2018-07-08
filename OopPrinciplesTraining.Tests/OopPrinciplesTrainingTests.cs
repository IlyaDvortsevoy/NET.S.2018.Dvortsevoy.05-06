using System;
using NUnit.Framework;

namespace OopPrinciplesTraining.Tests
{
    [TestFixture]
    public class OopPrinciplesTrainingTests
    {
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]
        public int ToDecimal_returns_proper_integer_number(
            string numberString,
            int radix)
        {
            return numberString.ToDecimal(radix);
        }

        [TestCase("011111111111111111111111111111111111111111111111", 2)]
        [TestCase("21783127831287883734423", 10)]
        [TestCase("FFFFFFFFFFFFFFFFFFFFFFEEEEEEEEEEEEEE", 16)]
        [TestCase("444444444444444444444444444444444444444444444", 5)]
        public void ToDecimal_throws_OverflowException(
            string numberString,
            int radix)
        {
            Assert.That(
                () => numberString.ToDecimal(radix),
                Throws.TypeOf<OverflowException>());
        }

        [TestCase("1213123", 1)]
        [TestCase("FFFCB54", 0)]
        [TestCase("2132425", 17)]
        [TestCase("1100011101", 22)]
        public void ToDecimal_throws_ArgumentOutOfRangeException(
            string numberString,
            int radix)
        {
            Assert.That(
                () => numberString.ToDecimal(radix),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase("23464576", 2)]
        [TestCase("FaB234", 2)]
        [TestCase("Yt235hJ", 16)]
        [TestCase("AB23F0", 10)]
        public void ToDecimal_throws_ArgumentException(
            string numberString,
            int radix)
        {
            Assert.That(
                () => numberString.ToDecimal(radix),
                Throws.TypeOf<ArgumentException>());
        }

        [TestCase(null, 5)]
        [TestCase(null, 2)]
        [TestCase(null, 16)]
        public void ToDecimal_throws_ArgumentNullException(
            string numberString,
            int radix)
        {
            Assert.That(
                () => numberString.ToDecimal(radix),
                Throws.TypeOf<ArgumentNullException>());
        }
    }
}