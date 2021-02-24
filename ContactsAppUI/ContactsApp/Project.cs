using System;
using System.Collections.Generic;
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
                Contact[] contacts = new Contact[_contacts.Length + 1];
                for (int index = 0; index < _contacts.Length; index++)
                {
                    contacts[index] = _contacts[index];
                }

                contacts[_contacts.Length] = value[0];

                _contacts = null;

                _contacts = contacts;
            }
        }

        /// <summary>
        /// Метод создает запись одного контакта
        /// </summary>
        /// <param name="value">объект класса Contact</param>
        public void Initialization(Contact value)
        {
            _contacts = new Contact[1];
            _contacts[0] = value;
        }
    }
}
