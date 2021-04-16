using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class PhoneNumberTest
    {
        public PhoneNumber _phone;

        [SetUp]
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
        public void TestNumber_Set_IncorrectValue(long wrongNumber, string message)
        {
            InitPhone();
            Assert.Throws<ArgumentException>(
                () => { _phone.Number = wrongNumber; }, 
                message);
        }

        [Test(Description = "Позитивный тест сеттера Number")]
        public void TestNumber_Set_CorrectValue()
        {
            InitPhone();
            _phone.Number = 71234567890;
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void TestNumber_Get_CorrectValue()
        {
            InitPhone();
            var expected = 71234567890;
            _phone.Number = expected;
            var actual = _phone.Number;
            Assert.AreEqual(expected, actual, 
                "При возвращении Number корректного " +
                "значения не должно возникать ошибки");
        }
    }
}
