using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMC.Validation.NANP;
using System;

namespace TelephoneValidationLib.Tests
{
    [TestClass]
    public class InvalidTests
    {

        #region General
        [TestMethod]
        [TestCategory("General Error")]
        public void NumberTooShortTest()
        {
            Assert.IsFalse(Telephone.IsValid("183771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(InvalidLengthException));
        }

        [TestMethod]
        [TestCategory("General Error")]
        public void NumberTooLongTest()
        {
            Assert.IsFalse(Telephone.IsValid("117183771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(InvalidLengthException));
        }

        [TestMethod]
        [TestCategory("General Error")]
        public void InvalidCountyCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("27183771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(InvalidNumberException));
        }

        [TestMethod]
        [TestCategory("General Error")]
        public void Invalid555NumberTest()
        {
            var telephoneNumber = string.Empty;
            Exception exception;

            for(var number = 100; number <= 199; number++)
            {
                telephoneNumber = $"718-555-{number.ToString().PadLeft(4, '0')}";
                Assert.IsFalse(Telephone.IsValid(telephoneNumber, out exception), $"Assert failed for number {telephoneNumber}.");
                Assert.IsInstanceOfType(exception, typeof(ValidationException));
            }

            telephoneNumber = "718-555-1212";
            Assert.IsFalse(Telephone.IsValid(telephoneNumber, out exception), $"Assert failed for number {telephoneNumber}.");
            Assert.IsInstanceOfType(exception, typeof(ValidationException));

            telephoneNumber = "718-555-4334";
            Assert.IsFalse(Telephone.IsValid(telephoneNumber, out exception), $"Assert failed for number {telephoneNumber}.");
            Assert.IsInstanceOfType(exception, typeof(ValidationException));
        }
        #endregion

        #region Area Code
        [TestMethod]
        [TestCategory("Area Code")]
        public void AreaCode000Test()
        {
            Assert.IsFalse(Telephone.IsValid("0003771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void AreaCodeStartingWith1Test()
        {
            Assert.IsFalse(Telephone.IsValid("1183771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void ERC211AreaCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("2113771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void ERC311AreaCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("3113771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void ERC411AreaCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("4113771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void ERCA511reaCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("5113771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void ERC611AreaCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("6113771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void ERC711AreaCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7113771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void ERC811AreaCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("8113771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void ERC911AreaCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("9113771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void AreaCodeN9XTest()
        {
            Assert.IsFalse(Telephone.IsValid("7983771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void AreaCode37XTest()
        {
            Assert.IsFalse(Telephone.IsValid("3783771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void AreaCode96Test()
        {
            Assert.IsFalse(Telephone.IsValid("9683771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void AreaCode950Test()
        {
            Assert.IsFalse(Telephone.IsValid("9503771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }

        [TestMethod]
        [TestCategory("Area Code")]
        public void AreaCode555Test()
        {
            Assert.IsFalse(Telephone.IsValid("5553771107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(AreaCodeException));
        }
        #endregion

        #region Central Office Code
        [TestMethod]
        [TestCategory("Central Office Code")]
        public void COStartingWith1Test()
        {
            Assert.IsFalse(Telephone.IsValid("7181771105", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void ERC211CentralOfficeCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7182111107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void ERC311CentralOfficeCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7183111107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void ERC411CentralOfficeCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7184111107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void ERCA511CentralOfficeCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7185111107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void ERC611CentralOfficeCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7186111107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void ERC711CentralOfficeCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7187111107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void ERC811CentralOfficeCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7188111107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void ERC911CentralOfficeCodeTest()
        {
            Assert.IsFalse(Telephone.IsValid("7189111107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void CentralOffice700Test()
        {
            Assert.IsFalse(Telephone.IsValid("7187001107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void CentralOffice950Test()
        {
            Assert.IsFalse(Telephone.IsValid("7189501107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void CentralOffice958Test()
        {
            Assert.IsFalse(Telephone.IsValid("7189581107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }

        [TestMethod]
        [TestCategory("Central Office Code")]
        public void CentralOffice959Test()
        {
            Assert.IsFalse(Telephone.IsValid("7189591107", out var ex));
            Assert.IsInstanceOfType(ex, typeof(CentralOfficeCodeException));
        }
        #endregion
    }
}