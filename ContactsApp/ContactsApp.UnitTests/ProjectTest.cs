using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectTest
    {
        private Project _project;
        [SetUp]
        public void InitProject()
        {
            _project = new Project();
        }

        [Test(Description = "позитивный тест сеттера Contact")]
        public void TestContact_Set_CorrectValue()
        {
            var surname = "Smit";
            var name = "Smit";
            var birthday = new DateTime(2000 - 01 - 01);
            var phoneNumber = new PhoneNumber();
            phoneNumber.Number = 71234567890;
            var vKontakte = "id55555";
            var email = "mailname@mail.com";
            var contact = new Contact(
                surname, name,
                birthday, phoneNumber,
                vKontakte, email);

            Assert.Throws<ArgumentException>(
                () => { _project.Contacts.Add(contact); },
                "");
        }

        [Test(Description = "Позитивный тест геттера Contact")]
        public void TestContacts_Get_CorrectValue()
        {
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedBirthday = new DateTime(2000 - 01 - 01);
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedVK = "id555555";
            var expectedEmail = "mailName@mail.com";
            var contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVK, expectedEmail);

            _project.Contacts.Add(contact);
            var actualSurname = _project.Contacts[0].Surname;
            var actualName = _project.Contacts[0].Name;
            var actualBirthday = _project.Contacts[0].Birthday;
            var actualNumber = _project.Contacts[0].PhoneNumber;
            var actualVK = _project.Contacts[0].IdVkontakte;
            var actualEmail = _project.Contacts[0].EMail;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname, 
                    "Конструктор содержит неверное значение Surname");
                Assert.AreEqual(expectedName, actualName,
                    "Конструктор содержит неверное значение Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "Конструктор содержит неверное значение Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "Конструктор содержит неверное значение PhoneNumber");
                Assert.AreEqual(expectedVK, actualVK,
                    "Конструктор содержит неверное значение VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "Конструктор содержит неверное значение Email");
            });
        }

        [TestCase("Smit",
            "Не должно возникать искльчение, если возвращает тотже список", 
            TestName="Поиск по строке которая содержится в каждом объекте")]
        [TestCase("",
            "Не должно возникать исключенеи, если возвращает тотже список", 
            TestName = "Поиск по пустой строке")]
        public void TestSearchContactByString_CorrectValue(string searchString, string message)
        {
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedBirthday = new DateTime(2000 - 01 - 01);
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedVK = "id555555";
            var expectedEmail = "mailName@mail.com";
            var contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVK, expectedEmail);

            _project.Contacts.Add(contact);
            var viewContact = 
                _project.SearchContactByString(searchString);
            var actualSurname = viewContact[0].Surname;
            var actualName = viewContact[0].Name;
            var actualBirthday = viewContact[0].Birthday;
            var actualNumber = viewContact[0].PhoneNumber;
            var actualVK = viewContact[0].IdVkontakte;
            var actualEmail = viewContact[0].EMail;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname,
                    "Конструктор содержит неверное значение Surname");
                Assert.AreEqual(expectedName, actualName,
                    "Конструктор содержит неверное значение Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "Конструктор содержит неверное значение Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "Конструктор содержит неверное значение PhoneNumber");
                Assert.AreEqual(expectedVK, actualVK,
                    "Конструктор содержит неверное значение VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "Конструктор содержит неверное значение Email");
            });
        }

        [Test(Description = "")]
        public void TestSearchByString_CorrectValue()
        {
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedBirthday = new DateTime(2000 - 01 - 01);
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedVK = "id555555";
            var expectedEmail = "mailName@mail.com";
            var contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVK, expectedEmail);
            var searchString = "fff";

            _project.Contacts.Add(contact);
            var viewContact =
                _project.SearchContactByString(searchString);
            var actualSurname = viewContact[0].Surname;
            var actualName = viewContact[0].Name;
            var actualBirthday = viewContact[0].Birthday;
            var actualNumber = viewContact[0].PhoneNumber;
            var actualVK = viewContact[0].IdVkontakte;
            var actualEmail = viewContact[0].EMail;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname,
                    "Конструктор содержит неверное значение Surname");
                Assert.AreEqual(expectedName, actualName,
                    "Конструктор содержит неверное значение Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "Конструктор содержит неверное значение Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "Конструктор содержит неверное значение PhoneNumber");
                Assert.AreEqual(expectedVK, actualVK,
                    "Конструктор содержит неверное значение VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "Конструктор содержит неверное значение Email");
            });
        }
    }
}
