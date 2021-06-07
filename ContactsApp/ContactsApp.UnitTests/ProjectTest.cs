using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectTest
    {
        /// <summary>
        /// stores an instance of the Project class
        /// </summary>
        public Project _project;

        /// <summary>
        /// initializes the _project field
        /// </summary>
        public void InitProject()
        {
            _project = new Project();
        }

        [Test(Description = "positive setter test Contact")]
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
                    "List setter returns invalid Surname");
                Assert.AreEqual(expectedName, actualName,
                    "List setter returns invalid Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "List setter returns invalid Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "List setter returns invalid PhoneNumber");
                Assert.AreEqual(expectedVK, actualVK,
                    "List setter returns invalid VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "List setter returns invalid Email");
            });
        }

        [TestCase("S", 
            TestName= "Search by string contained in each object")]
        [TestCase("", 
            TestName = "Search for an empty string")]
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
                    "The method found an invalid Surname");
                Assert.AreEqual(expectedName, actualName,
                    "The method found an invalid Name");
                Assert.AreEqual(expectedBirthday, actualBirthday,
                    "The method found an invalid Birthday");
                Assert.AreEqual(expectedNumber, actualNumber,
                    "The method found an invalid PhoneNumber");
                Assert.AreEqual(expectedVK, actualVK,
                    "The method found an invalid VKontakte");
                Assert.AreEqual(expectedEmail, actualEmail,
                    "The method found an invalid Email");
            });
        }

        [Test(Description = "Search for a string that is not contained in any of the objects")]
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
            Assert.IsNotNull(viewContact, "The list must be empty");
        }

        [Test(Description = "Search for contacts by birthday")]
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

        [Test(Description = "Search if there are no birthday people")]
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
            Assert.IsNotNull(actualSurnames, "The list must be empty");
        }
    }
}
