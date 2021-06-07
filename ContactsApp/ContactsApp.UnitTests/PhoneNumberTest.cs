using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class PhoneNumberTest
    {
        /// <summary>
        /// instance of the PhoneNumber class
        /// </summary>
        public PhoneNumber _phone;

        /// <summary>
        /// initializes the _phone field
        /// </summary>
        public void InitPhone()
        {
            _phone = new PhoneNumber();
        }

        [TestCase(81234567890,
            "Exception should be thrown when the number does not start with 7", 
            TestName = "Adding a number that does not contain a 7 at the beginning")]
        [TestCase(723456789,
            "An exception should be thrown if the number does not contain 11 digits", 
            TestName = "Adding a noer with no 11 digits")]
        public void TestNumberSet_IncorrectValue_ArgumentException(long wrongNumber, string message)
        {
            //Arrange
            InitPhone();

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    //Act
                    _phone.Number = wrongNumber;
                }, 
                message);
        }

        [Test(Description = "Number setter positive test")]
        public void TestNumberSet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            InitPhone();
            var expected = 71234567890;
            _phone.Number = expected;

            //Act
            var actual = _phone.Number;

            //Assert
            Assert.AreEqual(expected, actual,
                "Returning a valid Number " +
                "values ​​should not be error");
        }
    }
}
