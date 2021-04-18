using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        public Project CreateProject()
        {
            Project projectOne = new Project();
            PhoneNumber phoneOne = new PhoneNumber();
            phoneOne.Number = 71234565432;
            Contact contactOne = new Contact(
                "Kolesnicov", "Alexey",
                new DateTime(1999, 12, 2),
                phoneOne, "id465ge",
                "bramboom1@yandex.ru");
            projectOne.Contacts.Add(contactOne);

            Project projectTwo = new Project();
            PhoneNumber phoneTwo = new PhoneNumber();
            phoneTwo.Number = 71234567810;
            Contact contact = new Contact(
                "Fisher", "Bob",
                new DateTime(2000, 4, 5),
                phoneTwo, "id1234fish",
                "fisher@gmail.com");
            projectTwo.Contacts.Add(contact);
            return projectTwo;
        }

        [TestCase("/CorrectVoidContactsData.notes",
            "TestContactsData",
            TestName = "Проверка выгрузки пустого обьекта")]
        [TestCase("/IncorrectContactsData.notes",
            "TestContactsData",
            TestName = "Проверка выгрузки некорректного обьекта")]
        [TestCase("contacts", "",
            TestName = "Проверка выгрузки по неправильному пути")]
        public void TestProgectManager_LoadFromFile_FileLoadedNull(string filename, string path)
        {
            //Arrange
            var expectedProject = new Project();

            //Act
            var actualProject =
                ProjectManager.LoadFromFile(
                    path,
                    filename);

            //Assert
            Assert.AreEqual(
                expectedProject.Contacts.Count,
                actualProject.Contacts.Count);
        }

        [Test(Description = "Проверка выгрузки корректного значения")]
        public void TestProgectManager_LoadFromFile_FileLoadedCorrectly()
        {
            //Arrange
            var expectedProject = CreateProject();

            //Act
            var actualProject =
                ProjectManager.LoadFromFile(
                    @"TestContactsData",
                    @"\CorrectContactsData.notes");

            //Assert
            Assert.AreEqual(
                expectedProject.Contacts.Count,
                actualProject.Contacts.Count);
            Assert.Multiple(() =>
                {
                    for (int index = 0; index < expectedProject.Contacts.Count; index++)
                    {
                        var expected = expectedProject.Contacts[index];
                        var actual = actualProject.Contacts[index];

                        Assert.AreEqual(expected, actual);
                    }
                }
            );
        }

        [TestCase(@"\CorrectContactsDataTwo.notes",
            "TestContactsData",
            TestName = "Проверка  загрузки корректного обьекта")]
        [TestCase("contacts", "1",
            TestName = "Проверка выгрузки по неправильному пути")]
        public void ProjectManager_SaveCorrectionData_FileLoadedCorrectly(string filename, string path)
        {
            //SetUp
            var expectedProject = new Project();
            expectedProject = CreateProject();

            //Testing
            ProjectManager.SaveToFile(expectedProject, path, filename);

            //Assert
            var actual = 
                File.ReadAllText(path + filename);
            var expected = 
                File.ReadAllText("TestContactsData" + @"\CorrectContactsData.notes");
            Assert.AreEqual(expected, actual);

        }
    }
}
