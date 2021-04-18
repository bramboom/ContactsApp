using System;
using System.Collections.Generic;

namespace ContactsApp
{
    /// <summary>
    ///содержит список контактов
    /// </summary>
    public class Project: IEquatable<Project>
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

        public bool Equals(Project other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Contacts, other.Contacts);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Project) obj);
        }

        public override int GetHashCode()
        {
            return (Contacts != null ? Contacts.GetHashCode() : 0);
        }
    }
}