using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {
        /// <summary>
        /// Create contact
        /// </summary>
        /// <returns>contact</returns>
        private Contact expectedContact()
        {
            Contact expected;
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
            "exception should be thrown if the last name is more than 50 characters",
            TestName = "Assigning a surname with more than 50 characters")]
        [TestCase("1",
            "exception should be thrown if the last name contains numbers",
            TestName = "Assigning a surname containing numbers")]
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
        
        [Test(Description = "Surname Setter Positive Test")]
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
                "When assigning a correct Surname " +
                "values ​​should not be error");
        }

        [TestCase("TestTestTestTestTestTestTestTestTestTestTestTestTest",
            "exception should be thrown if the name is more than 50 characters",
            TestName = "Assigning a name with more than 50 characters")]
        [TestCase("1",
            "An exception should be thrown if the name contains numbers",
            TestName = "Assigning a name containing numbers")]
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

        [Test(Description = "Name setter positive test")]
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
                "If the Name is assigned correctly " +
                "values ​​should not be error");
        }

        [Test(Description = "Negative test for Birthday setter")]
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
                "When assigning a correct Birthday " +
                "values ​​should not be error");
        }

        [Test(Description = "Negative test for Birthday setter")]
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
                "When assigning a correct Birthday " +
                "values ​​should not be error");
        }

        [Test(Description = "Positive test for the Birthday setter")]
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
                "When assigning a correct Birthday " +
                "values ​​should not be error");
        }

        [Test(Description = "Positive test of the PhoneNumber setter")]
        public void TestPhoneNumberSet_CorrectValue_ReturnCorrectValue()
        {
            //Arrange
            Contact contact = new Contact();
            PhoneNumber phone = new PhoneNumber();
            var expected = phone;
            contact.PhoneNumber = expected;

            //Act
            var actual = contact.PhoneNumber;

            //Assert
            Assert.AreEqual(expected, actual,
                "When assigning a correct PhoneNumber " +
                "values ​​should not be error");
        }

        [Test(Description = "EMail setter negative test")]
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
                "When assigning a correct EMail " +
                "values ​​should not be error");
        }

        [Test(Description = "EMail setter positive test")]
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
                "When assigning a correct EMail " +
                "values ​​should not be error");
        }

        [TestCase("aaa",
            "An exception should be thrown if the VKontakte field does not contain 'id'",
            TestName = "An id assignment that does not contain an 'id'")]
        [TestCase("id-test-test-test-test",
            "An exception should be thrown if VKontakte is greater than 15",
            TestName = "Assigning a VKontakte that has more than 15 characters")]
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

        [Test(Description = "VKontakte setter positive test")]
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
                "When assigning a correct VKontakte " +
                "values ​​should not be error");
        }

        [Test(Description = "Positive test of the constructor of the Contact class")]
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

        [Test(Description = "Positive contact cloning test")]
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
