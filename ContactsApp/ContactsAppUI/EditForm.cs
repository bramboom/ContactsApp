﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class EditForm : Form
    {
        /// <summary>
        /// объект класса Contact, который нужно изменить или добавить
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// свойство поля _contact
        /// </summary>
        public Contact Contact
        {
            get { return _contact;}
            set
            {
                _contact = new Contact(value.Surname, value.Name, 
                    value.Birthday, value.PhoneNumber, 
                    value.IdVkontakte, value.EMail);
            }
        }

     

        public EditForm()
        {
            InitializeComponent();
        }
        
        private void OkButton_Click(object sender, EventArgs e)
        {
            string inputError = "";

            if ((surnameTextBox.BackColor == Color.DarkSalmon) || (surnameTextBox.Text == ""))
            {
                inputError = inputError + "incorrect surname!\n";
            }

            if ((nameTextBox.BackColor == Color.DarkSalmon) || (nameTextBox.Text == ""))
            {
                inputError = inputError + "incorrect name!\n";
            }

            if (_dateTimePicker.BackColor == Color.DarkSalmon)
            {
                inputError = inputError + "incorrect date!\n";
            }

            if ((phoneTextBox.BackColor == Color.DarkSalmon) || (phoneTextBox.Text == ""))
            {
                inputError = inputError + "incorrect phone!\n";
            }

            if ((mailTextBox.BackColor == Color.DarkSalmon) || (mailTextBox.Text == ""))
            {
                inputError = inputError + "incorrect e-mail!\n";
            }

            if ((vkTextBox.BackColor == Color.DarkSalmon) || (vkTextBox.Text == ""))
            {
                inputError = inputError + "incorrect vk.com!";
            }

            if (inputError != "")
            {
                MessageBox.Show(inputError, "Error");
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
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
            _dateTimePicker.BackColor = Color.White;
            try
            {
                _contact.Birthday = _dateTimePicker.Value;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                _dateTimePicker.BackColor = Color.DarkSalmon;
                _dateTimePicker.Invalidate();


            }
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            phoneTextBox.BackColor = Color.White;
            if ((phoneTextBox.Text.All(char.IsDigit)) && (phoneTextBox.Text != ""))
            {
                try
                {
                    PhoneNumber value = new PhoneNumber();
                    value.Number = long.Parse(phoneTextBox.Text);
                    _contact.PhoneNumber = value;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception);
                    phoneTextBox.BackColor = Color.DarkSalmon;
                }
            }
            else
            {
                phoneTextBox.BackColor = Color.DarkSalmon;
            }
        }

        private void mailTextBox_TextChanged(object sender, EventArgs e)
        {
            mailTextBox.BackColor = Color.White;
            try
            {
                _contact.EMail = mailTextBox.Text;
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
                _contact.IdVkontakte = vkTextBox.Text;
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
            if (_contact != null)
            {
                surnameTextBox.Text = _contact.Surname;
                nameTextBox.Text = _contact.Name;
                _dateTimePicker.Value = _contact.Birthday;
                phoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
                mailTextBox.Text = _contact.EMail;
                vkTextBox.Text = _contact.IdVkontakte;
            }
            else
            {
                _contact = new Contact();
                _contact.Birthday = DateTime.Now;
                _dateTimePicker.Value = DateTime.Now;
            }
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
