using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        Contact[] contacts = Manager.LoadFromFile(@"C://Users/bramboom/Desktop/json.txt");
        

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Contact");
        }

        private void EditContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit Contact");
        }

        private void RemoveContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Remove Contact");
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InsertToListBox();
        }

        //private void SurnameListBox_Click(object sender, EventArgs e)
        //{
        //    int index = surnameListBox.SelectedIndex;
        //    surnameTextbox.Text = contacts[index].Surname;
        //    nameTextBox.Text = contacts[index].Name;
        //    dateBox.Text = contacts[index].Date;
        //    phoneBox.Text = contacts[index].PhoneNumber;
        //    vkBox.Text = contacts[index].IDVKontakte;
        //    mailBox.Text = contacts[index].Mail;
        //}

       



        private void InsertToListBox()
        {
            for (int index = 0; index < contacts.Length; index++)
            {
                Console.WriteLine(contacts[index].Surname);
                surnameListBox.Items.Insert(index, contacts[index].Surname);
            }
        }

        private void surnameListBox_Click(object sender, EventArgs e)
        {
            int index = surnameListBox.SelectedIndex;
            if (index != -1)
            {
                surnameTextBox.Text = contacts[index].Surname;
                nameTextBox.Text = contacts[index].Name;
                dateBox.Text = contacts[index].Date;
                phoneTextBox.Text = contacts[index].PhoneNumber;
                vkTextBox.Text = contacts[index].IDVKontakte;
                mailTextBox.Text = contacts[index].Mail;
            }

        }
    }
}
