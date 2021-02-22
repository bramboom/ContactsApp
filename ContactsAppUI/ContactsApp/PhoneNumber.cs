using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class PhoneNumber
    {
        private int _phoneNumber = 7;

        public void SetPhoneNumber(string phoneNumber)
        {
            if(11!=phoneNumber.Length)
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

            _phoneNumber = Int32.Parse(phoneNumber);
        }

        public int GetPhoneNumber()
        {
            return _phoneNumber;
        }
    }
}
