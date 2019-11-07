using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMC.Validation.NANP;

namespace TelephoneValidationLib.Tests
{
    [TestClass]
    public class ValidTests
    {
        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid10DigitNumberTest()
        {
            Assert.IsTrue(Telephone.IsValid("7183771107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid11DigitNumberTest()
        {
            Assert.IsTrue(Telephone.IsValid("17183771107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid10DigitNumberWithHypensTest()
        {
            Assert.IsTrue(Telephone.IsValid("718-377-1107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid11DigitNumberWithHypensTest()
        {
            Assert.IsTrue(Telephone.IsValid("1-718-377-1107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid10DigitNumberWithParenthesesHypensTest()
        {
            Assert.IsTrue(Telephone.IsValid("(718) 377-1107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid11DigitNumberWithParenthesesHypensTest()
        {
            Assert.IsTrue(Telephone.IsValid("1 (718) 377-1107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid10DigitNumberWithUnderscoresTest()
        {
            Assert.IsTrue(Telephone.IsValid("718_377_1107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid11DigitNumberWithUnderscoresTest()
        {
            Assert.IsTrue(Telephone.IsValid("1_718_377_1107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid10DigitNumberWithParenthesesUnderscoresTest()
        {
            Assert.IsTrue(Telephone.IsValid("(718) 377_1107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid11DigitNumberWithParenthesesUnderscoresTest()
        {
            Assert.IsTrue(Telephone.IsValid("+1 (718) 377_1107", out _));
        }

        [TestMethod]
        [TestCategory("Valid Number")]
        public void Valid555NumbersTest()
        {
            for (var number = 0; number <= 99; number++)
            {
                var telephoneNumber = $"718-555-{number.ToString().PadLeft(4, '0')}";
                Assert.IsTrue(Telephone.IsValid(telephoneNumber, out var _), $"Assert failed for number {telephoneNumber}.");
            }

            for (var number = 200; number <= 9999; number++)
            {
                if (number == 1212 || number == 4334) continue;
                var telephoneNumber = $"718-555-{number.ToString().PadLeft(4, '0')}";
                Assert.IsTrue(Telephone.IsValid(telephoneNumber, out var _), $"Assert failed for number {telephoneNumber}.");
            }
        }
    }
}