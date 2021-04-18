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
            var fullPath = path + filename;
            var folder = System.IO.Path.GetDirectoryName(fullPath);

            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(fullPath))
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

            var fullPath = path + filename;
            var folder = System.IO.Path.GetDirectoryName(fullPath);

            if (System.IO.Directory.Exists(folder))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(fullPath))
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

