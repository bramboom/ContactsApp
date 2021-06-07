using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        /// <summary>
        /// path to the file from which the assembly is loaded
        /// </summary>
        private static readonly string LocalPath =
            Assembly.GetExecutingAssembly().Location;

        /// <summary>
        /// the path to the file where the assembly is stored
        /// </summary>
        private static readonly string PathDirectoryName =
            Path.GetDirectoryName(LocalPath);

        /// <summary>
        ///  path to the correct file
        /// </summary>
        private readonly string _projectFileName =
            PathDirectoryName + @"\TestContactsData";

        /// <summary>
        /// creates an instance of the project class with two objects of the Contacts class
        /// </summary>
        /// <returns>Object Project class</returns>
        public Project CreateProject()
        {
            Project project = new Project();
            PhoneNumber phoneOne = new PhoneNumber();
            phoneOne.Number = 71234565432;
            Contact contactOne = new Contact(
                "Kolesnicov", "Alexey",
                new DateTime(1999, 12, 2),
                phoneOne, "id465ge",
                "bramboom1@yandex.ru");
            project.Contacts.Add(contactOne);

            PhoneNumber phoneTwo = new PhoneNumber();
            phoneTwo.Number = 71234567810;
            Contact contact = new Contact(
                "Fisher", "Bob",
                new DateTime(2000, 4, 5),
                phoneTwo, "id1234fish",
                "fisher@gmail.com");
            project.Contacts.Add(contact);
            return project;
        }

        [TestCase("/CorrectVoidContactsData.notes",
            TestName = "Checking the unloading of an incorrect object")]
        [TestCase("2/contacts.json",
            TestName = "Checking unloading on the wrong path")]
        public void TestProgectManager_LoadFromFile_FileLoadedNull(string filename)
        {
            //Arrange
            var expectedProject = new Project();

            //Act
            var actualProject =
                ProjectManager.LoadFromFile(
                    _projectFileName,
                    filename);

            //Assert
            Assert.AreEqual(
                expectedProject.Contacts.Count,
                actualProject.Contacts.Count);
        }

        [Test(Description = "Checking the unloading of the correct value")]
        public void TestProjectManager_LoadFromFile_FileLoadedCorrectly()
        {
            //Arrange
            var expectedProject = CreateProject();

            //Act
            var actualProject =
                ProjectManager.LoadFromFile(
                    _projectFileName,
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

        [Test(Description = "Checking whether the correct object is saved")]
        public void ProjectManager_SaveCorrectionData_FileSavedCorrectly()
        {
            //SetUp
            var expectedProject = CreateProject();

            //Testing
            ProjectManager.SaveToFile(
                expectedProject, 
                _projectFileName, 
                @"\CorrectContactsDataTwo.notes");

            //Assert
            var actual =
                File.ReadAllText(_projectFileName + @"\CorrectContactsDataTwo.notes");
            var expected =
                File.ReadAllText(_projectFileName + @"\CorrectContactsData.notes");
            Assert.AreEqual(expected, actual);

        }
    }
}
