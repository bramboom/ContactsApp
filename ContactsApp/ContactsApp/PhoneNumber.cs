using System;

namespace ContactsApp
{
    /// <summary>
    /// содержит номер телефона
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        private long _number;

        /// <summary>
        ///возвращает и задает значение номера телефона
        /// </summary>
        public long Number
        {
            get
            {
                return _number;
            }
            set
            {
                if(value.ToString().Length != 11)
                {
                    throw new ArgumentException("Number must have 11 symbols!");
                }

                if(!value.ToString().StartsWith("7"))
                {
                    throw new ArgumentException("First numeral must be 7!");
                }

                _number = value;
            }
        }
    }
}
