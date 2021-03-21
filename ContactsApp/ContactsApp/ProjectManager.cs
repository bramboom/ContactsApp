using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    ///сериализация объекта Project
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// хранит путь до файла
        /// </summary>
        public static readonly string Path =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ContactsApp";

        /// <summary>
        ///хранит имя файла
        /// </summary>
        public static readonly string FileName = "/ContactsApp.notes";

        /// <summary>
        /// сериализирует объект Project в файл
        /// </summary>
        /// <param name="project">сериализируемый объект</param>
        /// <param name="fileName">путь к файлу</param>
        public static void SaveToFile(Project project, string fileName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(fileName);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(fileName + FileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// десериализирует объект Project из файла
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        /// <returns>десериализированный объект</returns>
        public static Project LoadFromFile(string fileName)
        {
            Project project = new Project();
            if (File.Exists(fileName + FileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(fileName + FileName))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    project = serializer.Deserialize<Project>(reader);
                }

                if (project == null)
                {
                    return new Project();
                }
            }
            return project;
        }
    }
}

