using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс содержащий номер телефона
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        private long _phoneNumber;

        /// <summary>
        /// Метод помещает значение в поле _phoneNumber
        /// </summary>
        /// <param name="phoneNumber">Значение, введенное пользователем</param>
        public void SetPhoneNumber(string phoneNumber)
        {
            if(11!=phoneNumber.Length)
            {
                throw new ArgumentException("Number must have 11 symbols!");
            }
            
            for (int index = 0; index < phoneNumber.Length; index++)
            {
                if ((phoneNumber[index] < '0') || (phoneNumber[index] > '9'))
                {
                    throw new ArgumentException("Number must be digit!");
                }
            }

            if (phoneNumber[0] != '7')
            {
                throw new ArgumentException("First numeral must be 7!");
            }

            _phoneNumber = long.Parse(phoneNumber);
        }

        /// <summary>
        /// Метод возвращает значение поля _phoneNumber
        /// </summary>
        /// <returns>_phoneNumber</returns>
        public long GetPhoneNumber()
        {
            return _phoneNumber;
        }
    }
}
