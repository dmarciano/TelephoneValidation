using System;
using System.Text.RegularExpressions;

namespace SMC.Validation.NANP
{
    /// <summary>
    /// Provides telephone number validation against the North American Number Plan (NANP) requirements.
    /// </summary>
    public static class Telephone
    {
        /// <summary>
        /// Validates a telephone number.
        /// </summary>
        /// <param name="number">The telephone number to validate.</param>
        /// <returns>A <see cref="Tuple{T1, T2}"/> with a <see cref="bool"/> for the first item (indicating if the validate was successfull) and 
        /// an <see cref="Exception"/> for the second item which includes why the validation failed (if applicable).</returns>
        /// <exception cref="InvalidLengthException">The phone number does not have the correct number of digits.</exception>
        /// <exception cref="InvalidNumberException">The phone number has an invalid country code.</exception>
        /// <exception cref="AreaCodeException">The area code (NAP) is not valid.</exception>
        /// <exception cref="CentralOfficeCodeException">The central office (CO) code is not valid.</exception>
        /// <exception cref="ValidationException">The phone number is not valid due an issues between parts of the number.</exception>
        /// <remarks>When available, the specific documentation section which caused the validation to fail will be available in the exceptions <code>Reference</code> property.</remarks>
        public static bool IsValid(string number, out Exception exception)
        {
            var strippedNumber = Regex.Replace(number, "[^0-9]", string.Empty);
            if (strippedNumber.Length < 10 || strippedNumber.Length > 11)
            {
                exception = new InvalidLengthException($"The telephone number must either 10 or 11 digits long (Actual digits found: {strippedNumber.Length}).");
                return false;
            }

            if (strippedNumber.Length == 11)
            {
                if (strippedNumber[0] != '1')
                {
                    exception = new InvalidNumberException($"Invalid country code found.  Expected '1' but found '{strippedNumber[0]}'.");
                    return false;
                }
                else
                {
                    strippedNumber = strippedNumber.Substring(1);
                }
            }
            
            var NPA = strippedNumber.Substring(0, 3);   // The Number Plan Area Code (NPA or Area Code) - First 3 digits
            var NXX = strippedNumber.Substring(3, 3);   // The Exchange or Central Office (CO) code - Middle 3 digits
            var XXXX = strippedNumber.Substring(6, 4);  // The Subscriber Number - Last 4 digits

            #region Area Code
            if (NPA.Equals("000"))
            {
                exception = new AreaCodeException("The value '000' is not a valid area code.", "ATIS-0300055 2.5");
                return false;
            }

            if (NPA[0].Equals('1'))
            {
                exception = new AreaCodeException("Area codes cannot start with the number '1'.", "ATIS-0300055 2.5");
                return false;
            }

            if (NPA[1].Equals('1') && NPA[2].Equals('1'))
            {
                exception = new AreaCodeException($"The area code {NPA} provided is a Easily Recognizable Code (ERC) and not a valid area codes.", "ATIS-0300055 4.2.1");
                return false;
            }

            if (NPA[1].Equals('9'))
            {
                exception = new AreaCodeException("The number '9' cannot be the second digit of an area code; these are reserved expansion codes.", "ATIS-0300055 4.1.2");
                return false;
            }

            if((NPA[0].Equals('3') && NPA[1].Equals('7')) || (NPA[0].Equals('9') && NPA[1].Equals('6')))
            {
                exception = new AreaCodeException($"Area codes cannot start with the numbers '{NPA.Substring(0, 2)}'.", "ATIS-0300055 4.3");
                return false;
            }

            if (NPA.Equals("950"))
            {
                exception = new AreaCodeException($"Area code 950 is not valid.", "ATIS-0300055 4.2.2");
                return false;
            }

            if (NPA.Equals("555"))
            {
                exception = new AreaCodeException($"Area code 555 is not valid.", "ATIS-0300055 4.2.3");
                return false;
            }
            #endregion

            #region Exchange Code
            if (NXX[0].Equals('1'))
            {
                exception = new CentralOfficeCodeException("Exchange codes cannot start with the number '1'.", "ATIS-0300119");
                return false;
            }

            if (NXX[1].Equals('1') && NXX[2].Equals('1'))
            {
                exception = new CentralOfficeCodeException($"The central office code {NXX} provided is a Easily Recognizable Code (ERC) and not a valid central office codes code.", "ATIS-0300119 7.3.6");
                return false;
            }

            if (NXX.Equals("700"))
            {
                exception = new CentralOfficeCodeException($"The central office code {NXX} provided is not a valid central office codes code.", "ATIS-0300119 7.3.7b");
                return false;
            }

            if (NXX.Equals("950"))
            {
                exception = new CentralOfficeCodeException($"The central office code {NXX} provided is not a valid central office codes code.", "ATIS-0300119 7.3.7c");
                return false;
            }

            if (NXX.Equals("958") || NXX.Equals("959"))
            {
                exception = new CentralOfficeCodeException($"The central office code {NXX} provided is not a valid central office codes code.", "ATIS-0300119 7.3.7d");
                return false;
            }
            #endregion

            #region Other
            if (NXX.Equals("555"))
            {
                var iXXXX = int.Parse(XXXX);
                if(iXXXX >= 100 && iXXXX<= 199)
                {
                    exception = new ValidationException($"Phone numbers with '555' and a subscriber number between 0100 through 0199 are fictitious, non-working numbers for use by the entertainment and advertising industries.", "ATIS-0300115 6.0");
                    return false;
                }
                else if(iXXXX.Equals(1212))
                {
                    exception = new ValidationException("The phone number 555-1212 is reserved for Directory Assistance National use.");
                    return false;
                }
                else if (iXXXX.Equals(4334))
                {
                    exception = new ValidationException("The phone number 555-4334 is Assigned National use.");
                    return false;
                }
            }
            #endregion

            exception = null;
            return true;
        }
    }
}