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
        public static void SaveToFile(Project project, string path, string filename)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path + filename);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path + filename))
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
        public static Project LoadFromFile(string path, string filename)
        {
            Project project = new Project();
            if (File.Exists(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(path + filename))
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

