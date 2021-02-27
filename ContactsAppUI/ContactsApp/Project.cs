using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, содержащий список контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов
        /// </summary>
        private Contact[] _contacts { get; set; }

        /// <summary>
        /// Свойства поля _contacts
        /// </summary>
        public Contact[] Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
            }
        }

        /// <summary>
        /// Метод создает запись одного контакта
        /// </summary>
        /// <param name="value">объект класса Contact</param>
        public void Initialization(Contact value)
        {
            _contacts = new Contact[1];
            _contacts[0] = new Contact(value.Surname, value.Name, value.Date, value.PhoneNumber, value.IDVKontakte,
                value.Mail);
        }

        public void AddContact(Contact value)
        {
            int len = _contacts.Length;
            Contact[] newContacts = new Contact[len + 1];
            for (int index = 0; index < _contacts.Length; index++)
            {
                newContacts[index] = new Contact(_contacts[index].Surname, _contacts[index].Name, 
                    _contacts[index].Date, _contacts[index].PhoneNumber, 
                    _contacts[index].IDVKontakte, _contacts[index].Mail);
            }

            newContacts[_contacts.Length] = new Contact(value.Surname, value.Name, value.Date, value.PhoneNumber, value.IDVKontakte,
                value.Mail);

            _contacts = null;

            _contacts = newContacts;
        }

        public void DeleteContacts()
        {
            _contacts = null;
        }

        public void Show()
        {
            for (int index = 0; index < _contacts.Length; index++)
            {
                Console.WriteLine(_contacts[index].Surname);
                Console.WriteLine(_contacts[index].Name);
                Console.WriteLine(_contacts[index].Date);
                Console.WriteLine(_contacts[index].PhoneNumber);
                Console.WriteLine(_contacts[index].Mail);
                Console.WriteLine(_contacts[index].IDVKontakte);
            }
        }
    }
}
