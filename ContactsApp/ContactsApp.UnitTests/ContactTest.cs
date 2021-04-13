using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {
        public Contact contact = new Contact();

        [TestCase("TestTestTestTestTestTestTestTestTestTestTestTestTest", 
            "Должно возникать исключение, если фамилия - превышает 50 символов",
            TestName = "Присвоение фамилии, содержащей больше 50 символов")]
        [TestCase("1",
            "Должно возникать исключение, если фамилия содержит цифры",
            TestName = "Присвоение фамилии, содержащей цифры")]
        public void TestSurname_Set_IncorrectValue(string wrongSurname, string message)
        {
            Contact contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Surname = wrongSurname; },
                message);
        }
        
        [Test(Description = "Позитивный тест сеттера Surname")]
        public void TestSurname_Set_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = "Smit";
            contact.Surname = expected;
            var actual = contact.Surname;
            Assert.AreEqual(expected, actual,
                "При присвоении Surname корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера Surname")]
        public void TestSurname_Get_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = "Smit";
            contact.Surname = expected;
            var actual = contact.Surname;
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
            Contact contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Name = wrongName; },
                message);
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void TestName_Set_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = "Smit";
            contact.Name = expected;
            var actual = contact.Name;
            Assert.AreEqual(expected, actual,
                "При присвоении Name корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void TestName_Get_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = "Smit";
            contact.Name = expected;
            var actual = contact.Name;
            Assert.AreEqual(expected, actual,
                "Геттер Name возвращает неправильное имя");
        }

        [Test(Description = "Негативный тест для сеттера Birthday")]
        public void TestBirthday_Set_InCorrectValueMore()
        {
            Contact contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Birthday = new DateTime(2999, 1, 1); },
                "При присвоении Birthday корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Негативный тест для сеттера Birthday")]
        public void TestBirthday_Set_InCorrectValueLess()
        {
            Contact contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Birthday = new DateTime(1899, 1, 1); },
                "При присвоении Birthday корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест для сеттера Birthday")]
        public void TestBirthday_Set_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = DateTime.Now;
            contact.Birthday = expected;
            var actual = contact.Birthday;
            Assert.AreEqual(expected, actual,
                "При присвоении Birthday корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера Birthday")]
        public void TestBirthday_Get_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = DateTime.Now;
            contact.Birthday = expected;
            var actual = contact.Birthday;
            Assert.AreEqual(expected, actual, 
                "Геттер Birthday возвращает неправильное значение");
        }

        [Test(Description = "Позитивный тест сеттера PhoneNumber")]
        public void TestPhoneNumber_Set_CorrectValue()
        {
            Contact contact = new Contact();
            PhoneNumber phone = new PhoneNumber();
            var expeted = phone;
            contact.PhoneNumber = expeted;
            var actual = contact.PhoneNumber;
            Assert.AreEqual(expeted, actual,
                "При присвоении PhoneNumber корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера PhoneNumber")]
        public void TestPhoneNumber_Get_CorrectValue()
        {
            Contact contact = new Contact();
            PhoneNumber phone = new PhoneNumber();
            var expeted = phone;
            contact.PhoneNumber = expeted;
            var actual = contact.PhoneNumber;
            Assert.AreEqual(expeted, actual, 
                "Геттер PhoneNumber возвращает неправильное значение");
        }

        [Test(Description = "Негативный тест сеттера EMail")]
        public void TestEmail_Set_IncorrectValue()
        {
            Contact contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.EMail = 
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
            Contact contact = new Contact();
            var expected = "aaa";
            contact.EMail = expected;
            var actual = contact.EMail;
            Assert.AreEqual(expected, actual,
                "При присвоении EMail корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера EMail")]
        public void TestEmail_Get_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = "aaa";
            contact.EMail = expected;
            var actual = contact.EMail;
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
            Contact contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.IdVkontakte = wrongVkontacte; },
                message);
        }

        [Test(Description = "Позитивный тест сеттера VKontakte")]
        public void TestVK_Set_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = "ids";
            contact.IdVkontakte = expected;
            var actual = contact.IdVkontakte;
            Assert.AreEqual(expected, actual,
                "При присвоении VKontakte корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест геттера VKontakte")]
        public void TestVK_Get_CorrectValue()
        {
            Contact contact = new Contact();
            var expected = "ids";
            contact.IdVkontakte = expected;
            var actual = contact.IdVkontakte;
            Assert.AreEqual(expected, actual,
                "Геттер VKontakte возвращает неправильное значение");
        }

        [Test(Description = "Позитивный тест конструктора класса Contact")]
        public void TestContact_Constructor_CorrectValue()
        {
            Contact contact = new Contact();
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedBirthday = DateTime.Now;
            var expectedEmail = "mailName@mail.com";
            var expectedVKontakte = "id555555555";
            contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVKontakte, expectedEmail);

            var actualSurname = contact.Surname;
            var actualName = contact.Name;
            var actualBirthday = contact.Birthday;
            var actualNumber = contact.PhoneNumber;
            var actualVK = contact.IdVkontakte;
            var actualEmail = contact.EMail;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname, 
                    "Конструктор внес неверное значение Surname");
                Assert.AreEqual(expectedName, actualName,
                    "Конструктор внес неверное значение Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "Конструктор внес неверное значение Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "Конструктор внес неверное значение PhoneNumber");
                Assert.AreEqual(expectedVKontakte, actualVK,
                    "Конструктор внес неверное значение VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "Конструктор внес неверное значение EMail");
            });
        }

        [Test(Description = "Позитивный тест клонирования контакта")]
        public void TestClone_CorrectValue()
        {
            Contact contact = new Contact();
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedBirthday = DateTime.Now;
            var expectedEmail = "mailName@mail.com";
            var expectedVKontakte = "id555555555";
            contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVKontakte, expectedEmail);

            Contact cloneContact = (Contact) contact.Clone();
            var actualSurname = cloneContact.Surname;
            var actualName = cloneContact.Name;
            var actualBirthday = cloneContact.Birthday;
            var actualNumber = cloneContact.PhoneNumber;
            var actualVK = cloneContact.IdVkontakte;
            var actualEmail = cloneContact.EMail;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname,
                    "Клонировано неверное значение Surname");
                Assert.AreEqual(expectedName, actualName,
                    "Клонировано неверное значение Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "Клонировано неверное значение Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "Клонировано неверное значение PhoneNumber");
                Assert.AreEqual(expectedVKontakte, actualVK,
                    "Клонировано неверное значение VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "Клонировано неверное значение EMail");
            });
        }
    }
}
