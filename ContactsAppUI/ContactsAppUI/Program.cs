using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("_____Class_PhoneNumber_____");
            PhoneNumber number = new PhoneNumber();
            number.SetPhoneNumber("79080216986");
            Console.WriteLine(number.GetPhoneNumber());
            Console.WriteLine("                 ");
            Console.WriteLine("_____Class_Contact_____");
            Contact contact = new Contact("Kolesnikov","Alexey",
                "02.12.1999","79080216986","id901239","bramboom1@yandex.ru");

            Console.WriteLine(contact.Surname);
            Console.WriteLine(contact.Name);
            Console.WriteLine(contact.Date);
            Console.WriteLine(contact.PhoneNumber);
            Console.WriteLine(contact.IDVKontakte);
            Console.WriteLine(contact.Mail);

            contact.Surname = "Kolesnic";
            contact.Name = "Alex";
            contact.Date = "01.01.2000";
            contact.PhoneNumber = "79098765432";
            contact.IDVKontakte = "id12345";
            contact.Mail = "kkkkkkk@mail.ru";

            Console.WriteLine(contact.Surname);
            Console.WriteLine(contact.Name);
            Console.WriteLine(contact.Date);
            Console.WriteLine(contact.PhoneNumber);
            Console.WriteLine(contact.IDVKontakte);
            Console.WriteLine(contact.Mail);

            Console.WriteLine("_____Class_Project_____");

            Contact[] contacts = new Contact[1];
            contacts[0] = contact;
            Project project = new Project();
            project.Initialization(contact);
            project.Contacts = contacts;
            contacts = project.Contacts;

            Console.WriteLine(contacts[0].Surname);
            Console.WriteLine(contacts[0].Name);
            Console.WriteLine(contacts[0].Date);
            Console.WriteLine(contacts[0].PhoneNumber);
            Console.WriteLine(contacts[0].IDVKontakte);
            Console.WriteLine(contacts[0].Mail);

            Console.WriteLine(contacts[1].Surname);
            Console.WriteLine(contacts[1].Name);
            Console.WriteLine(contacts[1].Date);
            Console.WriteLine(contacts[1].PhoneNumber);
            Console.WriteLine(contacts[1].IDVKontakte);
            Console.WriteLine(contacts[1].Mail);

            Manager.SafeToFile(contacts, "json");
            contacts = null;
            contacts = Manager.LoadFromFile("json");
            Console.WriteLine(contacts[0].Surname);
            Console.WriteLine(contacts[0].Name);
            Console.WriteLine(contacts[0].Date);
            Console.WriteLine(contacts[0].PhoneNumber);
            Console.WriteLine(contacts[0].IDVKontakte);
            Console.WriteLine(contacts[0].Mail);

            Console.WriteLine(contacts[1].Surname);
            Console.WriteLine(contacts[1].Name);
            Console.WriteLine(contacts[1].Date);
            Console.WriteLine(contacts[1].PhoneNumber);
            Console.WriteLine(contacts[1].IDVKontakte);
            Console.WriteLine(contacts[1].Mail);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
