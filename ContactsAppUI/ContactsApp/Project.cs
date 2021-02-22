using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    class Project
    {
        private Contact[] _contacts;
        private int _lenght = 0;

        public void SetContact(Contact contact)
        {
            _lenght++;
            Contact[] contacts = new Contact[_lenght];
            for (int index = 0; index < _lenght - 1; index++)
            {
                contacts[index] = _contacts[index];
            }

            contacts[_lenght - 1] = contact;

            _contacts = null;

            _contacts = contacts;
        }

        public Contact[] GetContacts()
        {
            return _contacts;
        }
    }
}
