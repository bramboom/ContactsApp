using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        [TestCase("TestContactsData/CorrectContactsData.notes", 
            TestName = "Проверка выгрузки корректного значения")]
        [TestCase("TestContactsData/CorrectVoidContactsData.notes", 
            TestName = "Проверка выгрузки пустого обьекта")]
        [TestCase("contacts", 
            TestName = "Проверка выгрузки по неправильному пути")]
        public void TestLoadFromFile_CorrectValue(string filename)
        {
            Project project =
                ProjectManager.LoadFromFile("", filename);
        }

        [Test(Description = "Проверка выгрузки с неправильным объектом")]
        public void TestLoadFromFile_IncorrectValue()
        {
            Project project =
                ProjectManager.LoadFromFile("",
                    @"TestContactsData\CorrectContactsData.notes");
        }

        [Test(Description = "")]
        public void TestSaveToFile_CorrectValue()
        {
            var expected = 
                ProjectManager.LoadFromFile("",
                    "TestContactsData/IncorrectContactsData.notes");
            ProjectManager.SaveToFile(expected,"",
                "TestContactsData/IncorrectContactsData.notes");
            var actual =
                ProjectManager.LoadFromFile("",
                    "TestContactsData/IncorrectContactsData.notes");
            Assert.AreEqual(expected, actual, "");
        }

        [Test(Description = "")]
        public void TestSaveToFile_IncorrectValue()
        {
            var expected =
                ProjectManager.LoadFromFile("", "contacts");
            ProjectManager.SaveToFile(expected, "", "contacts");
            var actual =
                ProjectManager.LoadFromFile("", "contacts");
            Assert.AreEqual(expected, actual, "");
        }
    }
}
