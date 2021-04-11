using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {
        private Contact _contact;

        private PhoneNumber _phone;

        [SetUp]
        private void InitContact()
        {
            _contact = new Contact();
            _phone.Number = 71234567890;
        }

        [TestCase("TestTestTestTestTestTestTestTestTestTestTestTestTest", 
            "Должно возникать исключение, если фамилия - превышает 50 символов",
            TestName = "Присвоение фамилии, содержащей больше 50 символов")]
        [TestCase("1",
            "Должно возникать исключение, если фамилия содержит цифры",
            TestName = "Присвоение фамилии, содержащей цифры")]
        public void TestSurname_Set_IncorrectValue(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Surname = wrongSurname; },
                message);
        }
        
        [Test(Description = "Позитивный тест сеттера Surname")]
        public void TestSurname_Set_CorrectValue()
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Surname = "Smit"; },
                "При присвоении Surname корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера Surname")]
        public void TestSurname_Get_CorrectValue()
        {
            var expected = "Smit";
            _contact.Surname = expected;
            var actual = _contact.Surname;
            Assert.AreEqual(expected, actual, 
                "Геттер Surname возвращает неправильную фамилию");
        }

        [TestCase("TestTestTestTestTestTestTestTestTestTestTestTestTest",
            "Должно возникать исключение, если имя - превышает 50 символов",
            TestName = "Присвоение имени, содержащего больше 50 символов")]
        [TestCase("1",
            "Должно возникать исключение, если имя содержит цифры",
            TestName = "Присвоение имени, содержащего цифры")]
        public void TestName_Set_IncorrectValue(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Name = wrongName; },
                message);
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void TestName_Set_CorrectValue()
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Name = "Smit"; },
                "При присвоении Name корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void TestName_Get_CorrectValue()
        {
            var expected = "Smit";
            _contact.Name = expected;
            var actual = _contact.Name;
            Assert.AreEqual(expected, actual,
                "Геттер Name возвращает неправильное имя");
        }

        [TestCase("2999-01-01",
            "Должно возникать исключение, если дата превышает нынешнюю",
            TestName = "Присвоение даты, большей нынешней")]
        [TestCase("1899-01-01",
            "Должно возникать исключение, если дата меньше 1900-01-01",
            TestName = "Присвоение даты, меньшей 1900-01-01")]
        public void TestBirthday_Set_IncorrectValue(DateTime wrongBirthday, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Birthday = wrongBirthday;}, 
                message);
        }

        [Test(Description = "Позитивный тест для сеттера Birthday")]
        public void TestBirthday_Set_CorrectValue()
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Name = "2000-01-01"; },
                "При присвоении Birthday корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера Birthday")]
        public void TestBirthday_Get_CorrectValue()
        {
            var expected = DateTime.Now;
            _contact.Birthday = expected;
            var actual = _contact.Birthday;
            Assert.AreEqual(expected, actual, 
                "Геттер Birthday возвращает неправильное значение");
        }

        [Test(Description = "Позитивный тест сеттера PhoneNumber")]
        public void TestPhoneNumber_Set_CorrectValue()
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.PhoneNumber = _phone; },
                "При присвоении PhoneNumber корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера PhoneNumber")]
        public void TestPhoneNumber_Get_CorrectValue()
        {
            var expeted = _phone;
            _contact.PhoneNumber = expeted;
            var actual = _contact.PhoneNumber;
            Assert.AreEqual(expeted, actual, 
                "Геттер PhoneNumber возвращает неправильное значение");
        }

        [Test(Description = "Негативный тест сеттера EMail")]
        public void TestEmail_Set_IncorrectValue()
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.EMail = 
                    "test-test-test-test-test"
                    + "test-test-test-test-test"
                    + "test-test-test-test-test";
                },
                "При присвоении EMail корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест сеттера EMail")]
        public void TestEmail_Set_CorrectValue()
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.EMail = "aaa";},
                "При присвоении EMail корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера EMail")]
        public void TestEmail_Get_CorrectValue()
        {
            var expected = "aaa";
            _contact.EMail = expected;
            var actual = _contact.EMail;
            Assert.AreEqual(expected, actual,
                "Геттер EMail возвращает неправильное значение");
        }

        [TestCase("aaa",
            "Должно возникать исключение, если поле VKontakte не содержит 'id'",
            TestName = "Присвоение id, которое не содержит 'id'")]
        [TestCase("id-test-test-test-test",
            "Должно возникать исключение, если VKontakte больше 15",
            TestName = "Присвоение VKontakte, у которого больше 15 символов")]
        public void TestVK_Set_IncorrectValue(string wrongVkontacte, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.IdVkontakte = wrongVkontacte; },
                message);
        }

        [Test(Description = "Позитивный тест сеттера VKontakte")]
        public void TestVK_Set_CorrectValue()
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.IdVkontakte = "ids"; },
                "При присвоении VKontakte корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера VKontakte")]
        public void TestVK_Get_CorrectValue()
        {
            var expected = "ids";
            _contact.IdVkontakte = expected;
            var actual = _contact.IdVkontakte;
            Assert.AreEqual(expected, actual,
                "Геттер VKontakte возвращает неправильное значение");
        }
    }
}
