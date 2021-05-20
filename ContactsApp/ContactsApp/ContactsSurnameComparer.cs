using System.Collections.Generic;

namespace ContactsApp
{
    public class ContactSurnameComparer : IComparer<Contact>
    {
        public int Compare(Contact first, Contact second)
        {
            string firstContact = first.Surname + first.Name;
            string secondContact = second.Surname + second.Name;

            return string.Compare(firstContact, secondContact);
        }
    }
}