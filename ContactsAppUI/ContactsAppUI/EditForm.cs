using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class EditForm : Form
    {
        private Contact _contact = new Contact();

        public Contact Contact
        {
            get { return _contact;}
            set
            {
                _contact = new Contact(value.Surname, value.Name, value.Date, value.PhoneNumber, value.IDVKontakte,
                    value.Mail);
            }
        }

        public EditForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if ((surnameTextBox.BackColor == Color.DarkSalmon)||(surnameTextBox.Text == ""))
            {
                MessageBox.Show("Incorrect surname!", "Error");
            }
            else if ((nameTextBox.BackColor == Color.DarkSalmon) || (nameTextBox.Text == ""))
            {
                MessageBox.Show("Incorrect name!", "Error");
            }
            else if ((dateTimePicker.BackColor == Color.DarkSalmon) || (dateTimePicker.Text == ""))
            {
                MessageBox.Show("Incorrect date!", "Error");
            }
            else if ((phoneTextBox.BackColor == Color.DarkSalmon) || (phoneTextBox.Text == ""))
            {
                MessageBox.Show("Incorrect phone!", "Error");
            }
            else if ((mailTextBox.BackColor == Color.DarkSalmon) || (mailTextBox.Text == ""))
            {
                MessageBox.Show("Incorrect e-mail!", "Error");
            }
            else if ((vkTextBox.BackColor == Color.DarkSalmon)||(vkTextBox.Text == ""))
            {
                MessageBox.Show("Incorrect vk.com!", "Error");
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            nameTextBox.BackColor = Color.White;
            try
            {
                _contact.Name = nameTextBox.Text;
            }
            catch (ArgumentException exeption)
            {
                Console.WriteLine(exeption);
                nameTextBox.BackColor = Color.DarkSalmon;
            }
        }

        private void dateBox_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker.BackColor = Color.White;
            try
            {
                _contact.Date = dateTimePicker.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                dateTimePicker.BackColor = Color.DarkSalmon;
            }
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            phoneTextBox.BackColor = Color.White;
            try
            {
                _contact.PhoneNumber = phoneTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                phoneTextBox.BackColor = Color.DarkSalmon;
            }
        }

        private void mailTextBox_TextChanged(object sender, EventArgs e)
        {
            mailTextBox.BackColor = Color.White;
            try
            {
                _contact.Mail = mailTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                mailTextBox.BackColor = Color.DarkSalmon;
            }
        }

        private void vkTextBox_TextChanged(object sender, EventArgs e)
        {
            vkTextBox.BackColor = Color.White;
            try
            {
                _contact.IDVKontakte = vkTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                vkTextBox.BackColor = Color.DarkSalmon;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            surnameTextBox.Text = _contact.Surname;
            nameTextBox.Text = _contact.Name;
            dateTimePicker.Text = _contact.Date;
            phoneTextBox.Text = _contact.PhoneNumber;
            mailTextBox.Text = _contact.Mail;
            vkTextBox.Text = _contact.IDVKontakte;
        }

        private void surnameTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void dateBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void phoneBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void mailTextBox_Leave(object sender, EventArgs e)
        {
           
        }

        private void vkTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void surnameTextBox_Changed(object sender, EventArgs e)
        {
            surnameTextBox.BackColor = Color.White;
            try
            {
                _contact.Surname = surnameTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                surnameTextBox.BackColor = Color.DarkSalmon;
            }
        }
    }
}
