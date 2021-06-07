using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    ///serializing the Project object
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// stores the path to the file
        /// </summary>
        public static readonly string Path =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ContactsApp";

        /// <summary>
        ///stores the filename
        /// </summary>
        public static readonly string FileName = "/ContactsApp.notes";

        /// <summary>
        /// serializes the Project object to a file
        /// </summary>
        /// <param name="project">serializable object</param>
        /// <param name="fileName">path to file</param>
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
        /// deserializes a Project object from a file
        /// </summary>
        /// <param name="fileName">path to file</param>
        /// <returns>deserialized object</returns>
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

