using System;
using System.Collections.Generic;

namespace ContactsApp
{
    /// <summary>
    /// contains a list of contacts
    /// </summary>
    public class Project: IEquatable<Project>
    {
        /// <summary>
        /// list of contacts
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Searches for a contact by string 
        /// </summary>
        /// <param name="searchString"> search bar </param>
        /// <returns> List of found contacts </returns>
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
                else if (Contacts[index].Name.Contains(searchString))
                {
                    viewContacts.Add(Contacts[index]);
                }
            }
            return viewContacts;
        }

        /// <summary>
        /// searches among the list of contacts whose contacts have a birthday today
        /// </summary>
        /// <param name="Contacts"> contact list </param>
        /// <returns> line with last names of contacts </returns>
        public string SearchSurnamesByBirthday(List<Contact> Contacts)
        {
            string surnames = "";
            for (int index = 0; index < Contacts.Count; index++)
            {
                if ((Contacts[index].Birthday.Month == DateTime.Now.Month)
                    && (Contacts[index].Birthday.Day == DateTime.Now.Day))
                {
                    if (surnames != "")
                    {
                        surnames = surnames + ", ";
                    }

                    surnames = surnames + Contacts[index].Surname;
                }
            }
            return surnames;
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