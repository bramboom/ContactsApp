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
            //Console.WriteLine("_____Class_PhoneNumber_____");
            //PhoneNumber number = new PhoneNumber();
            //number.SetPhoneNumber("79080216986");
            //Console.WriteLine(number.GetPhoneNumber());
            //Console.WriteLine("                 ");
            //Console.WriteLine("_____Class_Contact_____");
            //Contact contact = new Contact("Kolesnikov", "Alexey",
            //    "02.12.1999", "79080216986", "id901239", "bramboom1@yandex.ru");

            //Console.WriteLine(contact.Surname);
            //Console.WriteLine(contact.Name);
            //Console.WriteLine(contact.Date);
            //Console.WriteLine(contact.PhoneNumber);
            //Console.WriteLine(contact.IDVKontakte);
            //Console.WriteLine(contact.Mail);

            //contact.Surname = "kolesnic";
            //contact.Name = "alex";
            //contact.Date = "01.01.2000";
            //contact.PhoneNumber = "79098765432";
            //contact.IDVKontakte = "id12345";
            //contact.Mail = "kkkkkkk@mail.ru";

            //Console.WriteLine(contact.Surname);
            //Console.WriteLine(contact.Name);
            //Console.WriteLine(contact.Date);
            //Console.WriteLine(contact.PhoneNumber);
            //Console.WriteLine(contact.IDVKontakte);
            //Console.WriteLine(contact.Mail);

            //Console.WriteLine("CLone contact______________________");
            //var contact2 = contact.Clone();

            //Console.WriteLine(contact2.ToString());

            //Console.WriteLine("_____Class_Project_____");

            
            //Project project = new Project();
            //project.Initialization(contact);
            

            //project.Show();

            //project.AddContact(contact);
            //project.AddContact(contact);

            //project.Show();

            //Console.WriteLine("_____________________");

            //project.DeleteNode(2);

            //project.Show();

            //Manager.SafeToFile(project.Contacts);
            //project.DeleteContacts();
            //project.Contacts = Manager.LoadFromFile();
            
            //project.Show();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
