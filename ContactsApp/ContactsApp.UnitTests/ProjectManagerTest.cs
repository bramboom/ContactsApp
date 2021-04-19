using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        /// <summary>
        /// путь к фалу из которого загружается сборка 
        /// </summary>
        private static readonly string LocalPath =
            Assembly.GetExecutingAssembly().Location;

        /// <summary>
        /// путь  к файлу, в котором хранится сборка 
        /// </summary>
        private static readonly string PathDirectoryName =
            Path.GetDirectoryName(LocalPath);

        /// <summary>
        /// путь к правильному файлу 
        /// </summary>
        private readonly string _projectFileName =
            PathDirectoryName + @"\TestContactsData";

        /// <summary>
        /// создает экземпляр класса project с двумя оьектами класса Contacts
        /// </summary>
        /// <returns></returns>
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
            TestName = "Проверка выгрузки некорректного обьекта")]
        [TestCase("2/contacts.json",
            TestName = "Проверка выгрузки по неправильному пути")]
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

        [Test(Description = "Проверка выгрузки корректного значения")]
        public void TestProgectManager_LoadFromFile_FileLoadedCorrectly()
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

        [TestCase(@"\CorrectContactsDataTwo.notes",
            TestName = "Проверка  сохранения корректного обьекта")]
        [TestCase(@"1\CorrectContactsDataTwo.notes",
            TestName = "Проверка  сохранения корректного обьекта по некорректному пути")]
        public void ProjectManager_SaveCorrectionData_FileSavedCorrectly(string filename)
        {
            //SetUp
            var expectedProject = CreateProject();

            //Testing
            ProjectManager.SaveToFile(expectedProject, _projectFileName, filename);

            //Assert
            var actual = 
                File.ReadAllText(_projectFileName + filename);
            var expected = 
                File.ReadAllText(_projectFileName + @"\CorrectContactsData.notes");
            Assert.AreEqual(expected, actual);

        }
    }
}
