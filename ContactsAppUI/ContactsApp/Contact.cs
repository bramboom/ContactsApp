﻿using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс, содержащий информацию о контакте
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия контакта
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя контакта
        /// </summary>
        private string _name;

        /// <summary>
        /// День рождения контакта
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// Номер телефона
        /// </summary>
        private PhoneNumber _phoneNumber;

        /// <summary>
        /// ID ВКонтакте
        /// </summary>
        private string _idVKontakte;

        /// <summary>
        /// Адрес почты
        /// </summary>
        private string _eMail;

        /// <summary>
        /// метод возвращает и задает значение фамилии
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = NameVerification(value, "Surname");
            }
        }

        /// <summary>
        /// метод возвращает и задает значение имени
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = NameVerification(value, "Name");
            }
        }

        /// <summary>
        /// метод возвращает и задает значение дня рождения
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                if(value > DateTime.Now)
                {
                    throw new ArgumentException("Birthday should be less than now date ");
                }

                if (value.Year < 1900)
                {
                    throw new ArgumentException("Birthday year should be more 1900");
                }
                _birthday = value;
            }
        }

        /// <summary>
        /// метод возвращает и задает значение номера телефона
        /// </summary>
        public PhoneNumber PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
            }
        }

        /// <summary>
        /// метод возвращает и задает значение id Вконтакте
        /// </summary>
        public string IdVkontakte
        {
            get { return _idVKontakte; }
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("idVKontakte must have less 15 symbols!");
                }

                if (!value.StartsWith("id"))
                {
                    throw new ArgumentException("idVkontakte should start 'id'");
                }

                _idVKontakte = value;
            }
        }

        /// <summary>
        /// метод возвращает и задает значение электронной почты
        /// </summary>
        public string EMail
        {
            get { return _eMail; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("EMail must have less 50 symbols!");
                }

                _eMail = value;
            }
        }

        /// <summary>
        /// Создание пустого объекта
        /// </summary>
        public Contact()
        {

        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="surname">Инициализирует поле _surname</param>
        /// <param name="name">Инициализирует поле _name</param>
        /// <param name="birthday">Инициализирует поле _birthday</param>
        /// <param name="phoneNumber">Инициализирует поле _phoneNumber</param>
        /// <param name="idVKontakte">Инициализирует поле _idVKontakte</param>
        /// <param name="eMail">Инициализирует поле _eMail</param>
        public Contact(string surname, string name, DateTime birthday, 
            PhoneNumber phoneNumber, string idVKontakte, string eMail)
        {
            Surname = surname;
            Name = name;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
            IdVkontakte = idVKontakte;
            EMail = eMail;
        }

        /// <summary>
        /// Метод копирует объект
        /// </summary>
        /// <returns>Копию объекта</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// проверяет строку с именем или фамилией
        /// </summary>
        /// <param name="value">строка которую проверяем</param>
        /// <param name="name">строка с названием метода, в котором вызывается проверка</param>
        /// <returns>проверенная строка</returns>
        private string NameVerification(string value, string name)
        {
            if (value.Length > 50)
            {
                throw new ArgumentException($"{name} must have less 50 symbols!");
            }

            for (int index = 0; index < value.Length; index++)
            {
                if (!char.IsLetter(value[index]))
                {
                    throw new ArgumentException($"{name} must consist of a..z");
                }
            }

            if (value != "")
            {
                string newValue = value.ToUpper()[0] + value.Substring(1);
                return newValue;
            }

            return value;
        }
    }
}