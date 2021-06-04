using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectTest
    {
        /// <summary>
        /// поле хранит экземпляр класса Project
        /// </summary>
        public Project _project;
      
        /// <summary>
        /// инициализирует поле _project
        /// </summary>
        public void InitProject()
        {
            _project = new Project();
        }

        [Test(Description = "позитивный тест сеттера Contact")]
        public void TestContactSet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            InitProject();
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedBirthday = DateTime.Now;
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedVK = "id555555";
            var expectedEmail = "mailName@mail.com";
            var contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVK, expectedEmail);
            _project.Contacts.Add(contact);

            //Act
            var actualSurname = _project.Contacts[0].Surname;
            var actualName = _project.Contacts[0].Name;
            var actualBirthday = _project.Contacts[0].Birthday;
            var actualNumber = _project.Contacts[0].PhoneNumber;
            var actualVK = _project.Contacts[0].IdVkontakte;
            var actualEmail = _project.Contacts[0].EMail;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname,
                    "Cеттер списка возврашает неверное значение Surname");
                Assert.AreEqual(expectedName, actualName,
                    "Cеттер списка возврашает неверное значение Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "Cеттер списка возврашает неверное значение Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "Cеттер списка возврашает неверное значение PhoneNumber");
                Assert.AreEqual(expectedVK, actualVK,
                    "Cеттер списка возврашает неверное значение VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "Cеттер списка возврашает неверное значение Email");
            });
        }

        [TestCase("S", 
            TestName="Поиск по строке которая содержится в каждом объекте")]
        [TestCase("", 
            TestName = "Поиск по пустой строке")]
        public void TestSearchContactByString_CorrectValue_ReturnCorrectList(string searchString)
        {
            //Arrange
            InitProject();
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedBirthday = DateTime.Now;
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedVK = "id555555";
            var expectedEmail = "mailName@mail.com";
            var contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVK, expectedEmail);
            _project.Contacts.Add(contact);

            //Act
            var viewContact = 
                _project.SearchContactByString(searchString);
            var actualSurname = viewContact[0].Surname;
            var actualName = viewContact[0].Name;
            var actualBirthday = viewContact[0].Birthday;
            var actualNumber = viewContact[0].PhoneNumber;
            var actualVK = viewContact[0].IdVkontakte;
            var actualEmail = viewContact[0].EMail;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname,
                    "Метод нашел неверное значение Surname");
                Assert.AreEqual(expectedName, actualName,
                    "Метод нашел неверное значение Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "Метод нашел неверное значение Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "Метод нашел неверное значение PhoneNumber");
                Assert.AreEqual(expectedVK, actualVK,
                    "Метод нашел неверное значение VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "Метод нашел неверное значение Email");
            });
        }

        [Test(Description = "Поиск по строке которая не содержится ни в одном из объектов")]
        public void TestSearchByString_CorrectValue_ReturnEmptyList()
        {
            //Arrange
            InitProject();
            var expectedSurname = "Smit";
            var expectedName = "Smit";
            var expectedBirthday = DateTime.Now;
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

            //Act
            var viewContact =
                _project.SearchContactByString(searchString);

            //Assert
            Assert.IsNotNull(viewContact, "Список должен быть пуст");
        }

        [Test(Description = "Поиск контактов по дню рождения")]
        public void TestSearchSurnamesByBirthday_CorrectValue_ReturnCorrectList()
        {
            //Arrange
            InitProject();
            var expectedSurname = "Smit";
            var expectedName = "";
            var expectedBirthday = DateTime.Now;
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedVK = "id";
            var expectedEmail = "";
            var contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVK, expectedEmail);
            _project.Contacts.Add(contact);

            //Act
            var actualSurnames =
                _project.SearchSurnamesByBirthday(_project.Contacts);

            //Assert
            Assert.AreEqual(expectedSurname, actualSurnames,
                "Метод нашел неверное значение Surnames");
        }

        [Test(Description = "Поиск если именинников нет")]
        public void TestSearchSurnamesByBirthday_CorrectValue_ReturnEmptyList()
        {
            //Arrange
            InitProject();
            var expectedSurname = "Smit";
            var expectedName = "";
            var expectedBirthday = DateTime.Now.AddDays(-1);
            var expectedNumber = new PhoneNumber();
            expectedNumber.Number = 71234567890;
            var expectedVK = "id";
            var expectedEmail = "";
            var contact = new Contact(
                expectedSurname, expectedName,
                expectedBirthday, expectedNumber,
                expectedVK, expectedEmail);
            _project.Contacts.Add(contact);

            //Act
            var actualSurnames =
                _project.SearchSurnamesByBirthday(_project.Contacts);

            //Assert
            Assert.IsNotNull(actualSurnames, "Список должен быть пуст");
        }
    }
}
