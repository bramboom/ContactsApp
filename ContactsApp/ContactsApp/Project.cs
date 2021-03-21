using System.Collections.Generic;

namespace ContactsApp
{
    /// <summary>
    ///содержит список контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}