using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {
        /// <summary>
        /// Создает контакт
        /// </summary>
        /// <returns>контакт</returns>
        private Contact expectedContact()
        {
            Contact expected = new Contact();
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedBirthday = DateTime.Now;
            var expectedEmail = "mailName@mail.com";
            var expectedVKontakte = "id5555";
            expected = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVKontakte, expectedEmail);
            return expected;
        }

        [TestCase("TestTestTestTestTestTestTestTestTestTestTestTestTest", 
            "Должно возникать исключение, если фамилия - превышает 50 символов",
            TestName = "Присвоение фамилии, содержащей больше 50 символов")]
        [TestCase("1",
            "Должно возникать исключение, если фамилия содержит цифры",
            TestName = "Присвоение фамилии, содержащей цифры")]
        public void TestSurnameSet_IncorrectValue_ArgumentException(string wrongSurname, string message)
        {
            //Arrange
            Contact contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    //Act
                    contact.Surname = wrongSurname;
                },
                message);
        }
        
        [Test(Description = "Позитивный тест сеттера Surname")]
        public void TestSurnameSet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            Contact contact = new Contact();
            var expected = "Smit";
            contact.Surname = expected;

            //Act
            var actual = contact.Surname;

            //Assert
            Assert.AreEqual(expected, actual,
                "При присвоении Surname корректного " +
                "значения не должно возьникать ошибки");
        }

        [TestCase("TestTestTestTestTestTestTestTestTestTestTestTestTest",
            "Должно возникать исключение, если имя - превышает 50 символов",
            TestName = "Присвоение имени, содержащего больше 50 символов")]
        [TestCase("1",
            "Должно возникать исключение, если имя содержит цифры",
            TestName = "Присвоение имени, содержащего цифры")]
        public void TestNameSet_IncorrectValue_ArgumentException(string wrongName, string message)
        {
            //Arrange
            Contact contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    //Act
                    contact.Name = wrongName;
                },
                message);
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void TestNameSet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            Contact contact = new Contact();
            var expected = "Smit";
            contact.Name = expected;

            //Act
            var actual = contact.Name;

            //Assert
            Assert.AreEqual(expected, actual,
                "При присвоении Name корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Негативный тест для сеттера Birthday")]
        public void TestBirthdaySet_InCorrectValueMore_ArgumentException()
        {
            //Arrange
            Contact contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    //Act
                    contact.Birthday = new DateTime(2999, 1, 1);
                },
                "При присвоении Birthday корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Негативный тест для сеттера Birthday")]
        public void TestBirthdaySet_InCorrectValueLess_ArgumentException()
        {
            //Arrange
            Contact contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    //Act
                    contact.Birthday = new DateTime(1899, 1, 1);
                },
                "При присвоении Birthday корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест для сеттера Birthday")]
        public void TestBirthdaySet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            Contact contact = new Contact();
            var expected = DateTime.Now;
            contact.Birthday = expected;

            //Act
            var actual = contact.Birthday;

            //Assert
            Assert.AreEqual(expected, actual,
                "При присвоении Birthday корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест сеттера PhoneNumber")]
        public void TestPhoneNumberSet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            Contact contact = new Contact();
            PhoneNumber phone = new PhoneNumber();
            var expeted = phone;
            contact.PhoneNumber = expeted;

            //Act
            var actual = contact.PhoneNumber;

            //Assert
            Assert.AreEqual(expeted, actual,
                "При присвоении PhoneNumber корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Негативный тест сеттера EMail")]
        public void TestEmailSet_IncorrectValue_ArgumentException()
        {
            //Arrange
            Contact contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => {
                    //Act
                    contact.EMail = 
                    "test-test-test-test-test"
                    + "test-test-test-test-test"
                    + "test-test-test-test-test";
                },
                "При присвоении EMail корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест сеттера EMail")]
        public void TestEmailSet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            Contact contact = new Contact();
            var expected = "aaa";
            contact.EMail = expected;

            //Act
            var actual = contact.EMail;

            //Assert
            Assert.AreEqual(expected, actual,
                "При присвоении EMail корректного " +
                "значения не должно возьникать ошибки");
        }

        [TestCase("aaa",
            "Должно возникать исключение, если поле VKontakte не содержит 'id'",
            TestName = "Присвоение id, которое не содержит 'id'")]
        [TestCase("id-test-test-test-test",
            "Должно возникать исключение, если VKontakte больше 15",
            TestName = "Присвоение VKontakte, у которого больше 15 символов")]
        public void TestVKSet_IncorrectValue_ArgumentException(string wrongVkontacte, string message)
        {
            //Arrange
            Contact contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    //Act
                    contact.IdVkontakte = wrongVkontacte;
                },
                message);
        }

        [Test(Description = "Позитивный тест сеттера VKontakte")]
        public void TestVKSet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            Contact contact = new Contact();
            var expected = "ids";
            contact.IdVkontakte = expected;

            //Act
            var actual = contact.IdVkontakte;

            //Assert
            Assert.AreEqual(expected, actual,
                "При присвоении VKontakte корректного " +
                "значения не должно возьникать ошибки");
        }

        [Test(Description = "Позитивный тест конструктора класса Contact")]
        public void TestContactConstructor_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            var expected = expectedContact();

            //Act
            var actual = new Contact();
            actual.Surname = expected.Surname;
            actual.Name = expected.Name;
            actual.Birthday = expected.Birthday;
            actual.PhoneNumber = expected.PhoneNumber;
            actual.IdVkontakte = expected.IdVkontakte;
            actual.EMail = expected.EMail;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест клонирования контакта")]
        public void TestClone_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            var expected = expectedContact();

            //Act
            Contact actual = (Contact) expected.Clone();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
