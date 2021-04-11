using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class PhoneNumberTest
    {
        private PhoneNumber _phone;

        [SetUp]
        private void InitPhone()
        {
            _phone = new PhoneNumber();
        }

        [TestCase(81234567890, 
            "Должно возникать исключение, когда номер начинается не с 7", 
            TestName = "Добавление номера, не содержащего цифру 7 в начале")]
        [TestCase(723456789, 
            "Должно возникать исключение, если номер не содержит 11 цифр", 
            TestName = "Добавление ноера, не содержащего 11 цифр")]
        public void TestNumber_Set_IncorrectValue(long wrongNumber, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _phone.Number = wrongNumber; }, 
                message);
        }

        [Test(Description = "Позитивный тест сеттера Number")]
        public void TestNumber_Set_CorrectValue()
        {
            Assert.Throws<ArgumentException>(
                () => { _phone.Number = 71234567890; }, 
                "При присвоении Number корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void TestNumber_Get_CorrectValue()
        {
            var expected = 71234567890;
            _phone.Number = expected;
            var actual = _phone.Number;
            Assert.AreEqual(expected, actual, 
                "При присвоении Number корректного " +
                "значения не должно возьникать ошибки");
        }
    }
}
