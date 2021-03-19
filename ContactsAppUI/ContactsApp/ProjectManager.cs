using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс сериализации объекта Project
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// поле, которое хранит путь к файлу
        /// </summary>
        private static string _path = "/ContactsApp/ContactsApp.notes";

        /// <summary>
        /// Метод сериализирует объект Project в файл
        /// </summary>
        /// <param name="project">сериализируемый объект</param>
        /// <param name="fileName">путь к файлу</param>
        public static void SaveToFile(Project project, string fileName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(fileName + "/ContactsApp");

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(fileName + _path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод десериализирует объект Project из файла
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        /// <returns>десериализированный объект</returns>
        public static Project LoadFromFile(string fileName)
        {
            Project project = new Project();
            if (File.Exists(fileName + _path))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(fileName + _path))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    project = serializer.Deserialize<Project>(reader);
                }
            }
            return project;
        }
    }
}
