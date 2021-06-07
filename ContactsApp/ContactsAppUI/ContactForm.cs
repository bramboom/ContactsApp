using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// object of the Contact class to be modified or added
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// incorrect color
        /// </summary>
        private readonly Color _incorrectColor = Color.DarkSalmon;

        /// <summary>
        /// correct color
        /// </summary>
        private readonly Color _correctColor = Color.White;

        /// <summary>
        /// property _contact
        /// </summary>
        public Contact Contact
        {
            get => _contact;
            set =>
                _contact = new Contact(value.Surname, value.Name,
                    value.Birthday, value.PhoneNumber,
                    value.IdVkontakte, value.EMail);
        }

        public ContactForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string inputError = "Error list:\n";

            if ((surnameTextBox.BackColor == _incorrectColor) || (surnameTextBox.Text == ""))
            {
                inputError = inputError + "incorrect surname.\n";
            }

            if ((nameTextBox.BackColor == _incorrectColor) || (nameTextBox.Text == ""))
            {
                inputError = inputError + "incorrect name.\n";
            }

            if (_dateTimePicker.BackColor == _incorrectColor)
            {
                inputError = inputError + "incorrect date.\n";
            }

            if ((phoneTextBox.BackColor == _incorrectColor) || (phoneTextBox.Text == ""))
            {
                inputError = inputError + "incorrect phone.\n";
            }

            if ((mailTextBox.BackColor == _incorrectColor) || (mailTextBox.Text == ""))
            {
                inputError = inputError + "incorrect e-mail.\n";
            }

            if ((vkTextBox.BackColor == _incorrectColor) || (vkTextBox.Text == ""))
            {
                inputError = inputError + "incorrect vk.com.";
            }

            if (inputError != "Error list:\n")
            {
                MessageBox.Show(inputError, @"Error");
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            nameTextBox.BackColor = _correctColor;
            try
            {
                _contact.Name = nameTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                nameTextBox.BackColor = _incorrectColor;
            }
        }

        private void dateBox_ValueChanged(object sender, EventArgs e)
        {
            _dateTimePicker.BackColor = _correctColor;
            try
            {
                _contact.Birthday = _dateTimePicker.Value;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                _dateTimePicker.BackColor = _incorrectColor;
                _dateTimePicker.Invalidate();
            }
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            phoneTextBox.BackColor = _correctColor;
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
                    phoneTextBox.BackColor = _incorrectColor;
                }
            }
            else
            {
                phoneTextBox.BackColor = _incorrectColor;
            }
        }

        private void mailTextBox_TextChanged(object sender, EventArgs e)
        {
            mailTextBox.BackColor = _correctColor;
            try
            {
                _contact.EMail = mailTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                mailTextBox.BackColor = _incorrectColor;
            }
        }

        private void vkTextBox_TextChanged(object sender, EventArgs e)
        {
            vkTextBox.BackColor = _correctColor;
            try
            {
                _contact.IdVkontakte = vkTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                vkTextBox.BackColor = _incorrectColor;
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

        private void surnameTextBox_TextChanged(object sender, EventArgs e)
        {
            surnameTextBox.BackColor = _correctColor;
            try
            {
                _contact.Surname = surnameTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                surnameTextBox.BackColor = _incorrectColor;
            }
        }
    }
}