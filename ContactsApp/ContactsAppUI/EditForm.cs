using System;
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
                _contact = new Contact(value.Surname, value.Name, value.Birthday, value.PhoneNumber, value.IdVkontakte,
                    value.EMail);
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
                MessageBox.Show("incorrect surname!");
            }
            else if ((nameTextBox.BackColor == Color.DarkSalmon) || (nameTextBox.Text == ""))
            {
                MessageBox.Show("Incorrect name!", "Error");
            }
            else if (myDateTimePicker.BackColor == Color.DarkSalmon)
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
                MessageBox.Show("Incorrect vk.com!");
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
            myDateTimePicker.BackColor = Color.White;
            try
            {
                _contact.Birthday = myDateTimePicker.Value;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                myDateTimePicker.BackColor = Color.DarkSalmon;
                myDateTimePicker.Invalidate();


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
                myDateTimePicker.Value = _contact.Birthday;
                phoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
                mailTextBox.Text = _contact.EMail;
                vkTextBox.Text = _contact.IdVkontakte;
            }
            else
            {
                _contact = new Contact();
                _contact.Birthday = DateTime.Now;
                myDateTimePicker.Value = DateTime.Now;
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
