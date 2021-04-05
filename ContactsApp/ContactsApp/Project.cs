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

        /// <summary>
        /// Выполняет поиск контакта по строке 
        /// </summary>
        /// <param name="searchString">поисковая строка </param>
        /// <returns>Список найденых контактов</returns>
        public List<Contact> SearchContactByString(string searchString)
        {
            List<Contact> viewContacts = new List<Contact>();
            if (searchString == "")
            {
                viewContacts = Contacts;
                return viewContacts;
            }
            for (int index = 0; index < Contacts.Count; index++)
            {
                if (Contacts[index].Surname.Contains(searchString))
                {
                    viewContacts.Add(Contacts[index]);
                }
            }
            return viewContacts;
        }
    }
}