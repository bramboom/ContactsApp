using System;
using System.CodeDom;

namespace ContactsApp
{
    /// <summary>
    /// contains contact information
    /// </summary>
    public class Contact : ICloneable, IEquatable<Contact>

    {
    /// <summary>
    /// Contact surname
    /// </summary>
    private string _surname;

    /// <summary>
    /// Contact name
    /// </summary>
    private string _name;

    /// <summary>
    /// Contact birthday
    /// </summary>
    private DateTime _birthday;

    /// <summary>
    /// Contact id
    /// </summary>
    private string _idVKontakte;

    /// <summary>
    /// Contact e-mail
    /// </summary>
    private string _eMail;

    /// <summary>
    /// returns and sets the value of the surname
    /// </summary>
    public string Surname
    {
        get { return _surname; }
        set
        {
            AssertName(value, "Surname");
            _surname = ChangeRegisterOfFirstSymbol(value);
        }
    }

    /// <summary>
    /// returns and sets the value of the name
    /// </summary>
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            AssertName(value, "Name");
            _name = ChangeRegisterOfFirstSymbol(value);
        }
    }

    /// <summary>
    /// returns and sets the value of the birthday
    /// </summary>
    public DateTime Birthday
    {
        get
        {
            return _birthday;
        }
        set
        {
            if (value > DateTime.Now)
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
    /// returns and sets the value of the phone number
    /// </summary>
    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    /// <summary>
    /// returns and sets the value of the id
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
    /// returns and sets the value of the e-mail
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
    /// Creating an empty object
    /// </summary>
    public Contact()
    {

    }

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="surname">Initializes the _surname</param>
    /// <param name="name">Initializes the _name</param>
    /// <param name="birthday">Initializes the _birthday</param>
    /// <param name="phoneNumber">Initializes the phoneNumber</param>
    /// <param name="idVKontakte">Initializes the _idVKontakte</param>
    /// <param name="eMail">Initializes the eMail</param>
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
    /// Copy object
    /// </summary>
    /// <returns>Object copy</returns>
    public object Clone()
    {
        return this.MemberwiseClone();
    }

    /// <summary>
    /// checks a string with a first or last name
    /// </summary>
    /// <param name="value">string</param>
    /// <param name="nameProperty">string with the name of the method in which the check is called</param>
    /// <returns>checked string</returns>
    private void AssertName(string value, string nameProperty)
    {
        if (value.Length > 50)
        {
            throw new ArgumentException($"{nameProperty} must have less 50 symbols!");
        }

        for (int index = 0; index < value.Length; index++)
        {
            if (!char.IsLetter(value[index]))
            {
                throw new ArgumentException($"{nameProperty} must consist of a..z");
            }
        }
    }

    /// <summary>
    /// equals the first character to uppercase
    /// </summary>
    /// <param name="value">string</param>
    /// <returns>string with uppercase</returns>
    private string ChangeRegisterOfFirstSymbol(string value)
    {
        if (value != "")
        {
            string newValue = value.ToUpper()[0] + value.Substring(1);
            return newValue;
        }

        return value;
    }

    public bool Equals(Contact other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _surname == other._surname && 
               _name == other._name && 
               _birthday.Equals(other._birthday) && 
               _idVKontakte == other._idVKontakte && 
               _eMail == other._eMail && 
               Equals(PhoneNumber, other.PhoneNumber);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Contact) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (_surname != null ? _surname.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ _birthday.GetHashCode();
            hashCode = (hashCode * 397) ^ (_idVKontakte != null ? _idVKontakte.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (_eMail != null ? _eMail.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (PhoneNumber != null ? PhoneNumber.GetHashCode() : 0);
            return hashCode;
        }
    }
    }
}