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
        private Contact[] _contacts;

        /// <summary>
        /// Свойства поля _contacts
        /// </summary>
        public Contact[] Contacts
        {
            get { return _contacts; }
            set
            {
                if (value != null)
                {
                    _contacts = (Contact[])value.Clone();
                }
            }
        }

        /// <summary>
        /// Метод создает запись одного контакта
        /// </summary>
        /// <param name="value">объект класса Contact</param>
        public void Initialization(Contact value)
        {
            _contacts = new Contact[1];
            _contacts[0] = (Contact) value.Clone();
        }
        
        /// <summary>
        /// Метод добавляет объект Contact в конец
        /// </summary>
        /// <param name="value"></param>
        public void AddContact(Contact value)
        {
            int len = _contacts.Length;
            Contact[] newContacts = new Contact[len + 1];
            for (int index = 0; index < _contacts.Length; index++)
            {
                newContacts[index] = (Contact) _contacts[index].Clone();
            }

            newContacts[len] = new Contact(value.Surname, value.Name, value.Date, 
                value.PhoneNumber, value.IDVKontakte, value.Mail);

            _contacts = null;

            _contacts = (Contact[]) newContacts.Clone();
        }

        /// <summary>
        /// Метод удаляет объект
        /// </summary>
        public void DeleteContacts()
        {
            _contacts = null;
        }

        /// <summary>
        /// Удаляет один элемент из списка контактов
        /// </summary>
        /// <param name="indexDeleteElement">Индекс удаляемого контакта</param>
        public void DeleteNode(int indexDeleteElement)
        {
            if (_contacts.Length < 2)
            {
                _contacts = null;
            }
            else
            {
                int len = _contacts.Length;
                Contact[] newContacts = new Contact[len - 1];
                for (int index = 0; index < len; index++)
                {
                    if (index < indexDeleteElement)
                    {
                        newContacts[index] = (Contact)_contacts[index].Clone();
                    }
                    else if (index > indexDeleteElement)
                    {
                        newContacts[index-1] = (Contact) _contacts[index].Clone();
                    }
                }

                _contacts = null;
                _contacts = (Contact[]) newContacts.Clone();

            }
        }

        /// <summary>
        /// Выводит содержимое объекта
        /// </summary>
        public void Show()
        {
            if (_contacts == null)
            {
                return;
            }

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
