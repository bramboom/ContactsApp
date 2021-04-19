using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class PhoneNumberTest
    {
        public PhoneNumber _phone;

        public void InitPhone()
        {
            _phone = new PhoneNumber();
        }

        [TestCase(81234567890, 
            "Должно возникать исключение, когда номер начинается не с 7", 
            TestName = "Добавление номера, не содержащего цифру 7 в начале")]
        [TestCase(723456789, 
            "Должно возникать исключение, если номер не содержит 11 цифр", 
            TestName = "Добавление ноера, не содержащего 11 цифр")]
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

        [Test(Description = "Позитивный тест сеттера Number")]
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
                "При возвращении Number корректного " +
                "значения не должно возникать ошибки");
        }
    }
}
