using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, содержащий информацию о контакте
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Фамилия контакта
        /// </summary>
        private string _surname { get; set; }

        /// <summary>
        /// Имя контакта
        /// </summary>
        private string _name { get; set; }

        /// <summary>
        /// День рождения контакта
        /// </summary>
        private string _date { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        private string _phoneNumber { get; set; }

        /// <summary>
        /// ID ВКонтакте
        /// </summary>
        private string _idVKontakte { get; set; }

        /// <summary>
        /// Адрес почты
        /// </summary>
        private string _mail { get; set; }

        /// <summary>
        /// Свойства поля _surname
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Surname must have less 50 symbols!");
                }

                for (int index = 1; index < value.Length; index++)
                {
                    if ((value[index] > 'z') || (value[index] < 'a'))
                    {
                        throw new ArgumentException("Surname must consist of symbols a..z");
                    }
                }

                if ((value[0] < 'Z') && (value[0] > 'A'))
                {
                    _surname = value;
                    return;
                }

                if ((value[0] > 'z') || (value[0] < 'a'))
                {
                    throw new ArgumentException("Surname must consist of symbols a..z");
                }
                else
                {
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    _surname = myTI.ToTitleCase(value);
                }
            }
        }

        /// <summary>
        /// Свойства поля _name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Name must have less 50 symbols!");
                }

                for (int index = 1; index < value.Length; index++)
                {
                    if ((value[index] > 'z') || (value[index] < 'a'))
                    {
                        throw new ArgumentException("Name must consist of a..z");
                    }
                }

                if ((value[0] <= 'Z') && (value[0] >= 'A'))
                {
                    _name = value;
                    return;
                }

                if ((value[0] > 'z') || (value[0] < 'a'))
                {
                    throw new ArgumentException("Name must consist of a..z");
                }
                else
                {
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    _name = myTI.ToTitleCase(value);
                }
            }
        }

        /// <summary>
        /// Свойства поля _date
        /// </summary>
        public string Date
        {
            get { return _date; }
            set
            {
                string[] separators = {".", "/", "|"};
                string[] dateValue = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
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

                _date = value;
            }
        }

        /// <summary>
        /// Свойства поля _phoneNumber
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value.Length != 11)
                {
                    throw new ArgumentException("Number must have 11 symbols!");
                }

                for (int index = 0; index < value.Length; index++)
                {
                    if ((value[index] < '0') || (value[index] > '9'))
                    {
                        throw new ArgumentException("Number must be digit!");
                    }
                }

                if (value[0] != '7')
                {
                    throw new ArgumentException("First numeral must be 7!");
                }

                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Свойства поля _idVKontakte
        /// </summary>
        public string IDVKontakte
        {
            get { return _idVKontakte; }
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("idVKontakte must have less 15 symbols!");
                }

                if ((value[0] != 'i') && (value[1] != 'd'))
                {
                    throw new ArgumentException("ID must start of 'id'!");
                }

                _idVKontakte = value;
            }
        }

        /// <summary>
        /// Свойства поля _mail
        /// </summary>
        public string Mail
        {
            get { return _mail; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Mail must have less 50 symbols!");
                }

                _mail = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="surname">Инициализирует поле _surname</param>
        /// <param name="name">Инициализирует поле _name</param>
        /// <param name="date">Инициализирует поле _date</param>
        /// <param name="phoneNumber">Инициализирует поле _phoneNumber</param>
        /// <param name="idVKontakte">Инициализирует поле _idVKontakte</param>
        /// <param name="mail">Инициализирует поле _mail</param>
        public Contact(string surname, string name, string date, string phoneNumber, string idVKontakte, string mail)
        {
            Surname = surname;
            Name = name;
            Date = date;
            PhoneNumber = phoneNumber;
            IDVKontakte = idVKontakte;
            Mail = mail;
        }
    }
}