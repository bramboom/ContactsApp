using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс сериализации объекта Project
    /// </summary>
    public static class Manager
    {
        /// <summary>
        /// поле, которое хранит путь к файлу
        /// </summary>
        private static string _path = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
            + "/ContactApp/ContactApp.notes";

        /// <summary>
        /// Метод сериализирует объект Project в файл
        /// </summary>
        /// <param name="value">сериализируемый объект</param>
        public static void SafeToFile(Contact[] value)
        {
            Console.WriteLine(_path);
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(_path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// Метод десериализирует объект Project из файла
        /// </summary>
        /// <returns>десериализированный объект</returns>
        public static Contact[] LoadFromFile()
        {
            Contact[] contact = null;
            if (File.Exists(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(_path))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    contact = (Contact[])serializer.Deserialize<Contact[]>(reader);
                }
            }
            return contact;
        }
    }
}
