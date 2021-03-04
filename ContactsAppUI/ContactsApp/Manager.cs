using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /// Метод сериализирует объект Project в файл
        /// </summary>
        /// <param name="value">сериализируемый объект</param>
        public static void SafeToFile(Contact[] value)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"json.txt"))
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
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(@"json.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                contact = (Contact[]) serializer.Deserialize<Contact[]>(reader);
            }
            return contact;
        }
    }
}
