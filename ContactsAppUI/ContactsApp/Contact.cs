using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    class Contact
    {
        private string _surname;
        private string _name;
        private string _date;
        private string _phoneNumber;
        private string _idVKontakte;
        private string _mail;
        //private DateTime _date;

        public void SetSurname(string surname)
        {
            if (surname.Length > 50)
            {
                throw new ArgumentException("Surname must have less 50 symbols!");
            }

            for (int index = 1; index < surname.Length; index++)
            {
                if ((surname[index] > 'z') || (surname[index] < 'a'))
                {
                    throw new ArgumentException("Surname must consist of symbols a..z");
                }
            }

            if ((surname[0] < 'Z') && (surname[0] > 'A'))
            {
                _surname = surname;
            }

            if ((surname[0] > 'z') || (surname[0] < 'a'))
            {
                throw new ArgumentException("Surname must consist of symbols a..z");
            }
            else
            {
                //.https://docs.microsoft.com/ru-ru/dotnet/api/system.globalization.textinfo.totitlecase?view=net-5.0
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                _surname = myTI.ToTitleCase(surname);
            }
        }

        public void SetName(string name)
        {
            if (name.Length > 50)
            {
                throw new ArgumentException("Name must have less 50 symbols!");
            }

            for (int index = 1; index < name.Length; index++)
            {
                if ((name[index] > 'z') || (name[index] < 'a'))
                {
                    throw new ArgumentException("Name must consist of a..z");
                }
            }

            if ((name[0] < 'Z') && (name[0] > 'A'))
            {
                _name = name;
            }

            if ((name[0] > 'z') || (name[0] < 'a'))
            {
                throw new ArgumentException("Name must consist of a..z");
            }
            else
            {
                //.https://docs.microsoft.com/ru-ru/dotnet/api/system.globalization.textinfo.totitlecase?view=net-5.0
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                _name = myTI.ToTitleCase(name);
            }
        }

        public void SetDate(string date)
        {
            //.https://docs.microsoft.com/ru-ru/dotnet/api/system.string.split?view=net-5.0#System_String_Split_System_String___System_StringSplitOptions_
            string[] separators = {".","/","|"};
            string[] dateValue = date.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if ((Int32.Parse(dateValue[2]) < 1900) || (Int32.Parse(dateValue[2]) > DateTime.Now.Year))
            {
                throw new ArgumentException("Year value must be less now year and more 1900!");
            }

            if ((Int32.Parse(dateValue[1]) > 12) || (Int32.Parse(dateValue[1]) < 1))
            {
                throw new ArgumentException("Mouth value must be less 12 and more 1!");
            }

            if ((Int32.Parse(dateValue[0]) > 31) || (Int32.Parse(dateValue[0]) < 1))
            {
                throw new ArgumentException("Day value must be less 31 and more 1!");
            }

            _date = date;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 11)
            {
                throw new ArgumentException("Number must have 11 symbols!");
            }

            for (int index = 0; index < phoneNumber.Length; index++)
            {
                if ((phoneNumber[index] < '0') || (phoneNumber[index] > 9))
                {
                    throw new ArgumentException("Number must be digit!");
                }
            }

            if (phoneNumber[0] != '7')
            {
                throw new ArgumentException("First numeral must be 7!");
            }

            _phoneNumber = phoneNumber;
        }

        public void SetIDVkontakte(string idVKontakte)
        {
            if (idVKontakte.Length > 15)
            {
                throw new ArgumentException("idVKontakte must have less 15 symbols!");
            }

            if ((idVKontakte[0] != 'i') && (idVKontakte[1] != 'd'))
            {
                throw new ArgumentException("ID must start of 'id'!");
            }

            _idVKontakte = idVKontakte;
        }

        public void SetMail(string mail)
        {
            if (mail.Length > 50)
            {
                throw new ArgumentException("Mail must have less 50 symbols!");
            }

            _mail = mail;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDate()
        {
            return _date;
        }

        public string GetPhoneNumber()
        {
            return _phoneNumber;
        }

        public string GetIDVKontakte()
        {
            return _idVKontakte;
        }

        public string GetMail()
        {
            return _mail;
        }

        public void Creater(string surname, string name, string date, string phoneNumber, string idVKontakte, string mail)
        {
            SetSurname(surname);
            SetName(name);
            SetDate(date);
            SetPhoneNumber(phoneNumber);
            SetIDVkontakte(idVKontakte);
            SetMail(mail);
        }
    }
}
