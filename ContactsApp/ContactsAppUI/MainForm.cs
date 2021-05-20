using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// объект класса Project
        /// </summary>
        private Project _project = 
            ProjectManager.LoadFromFile(ProjectManager.Path, ProjectManager.FileName);

        /// <summary>
        /// Хранит список контактов для просмотра
        /// </summary>
        private List<Contact> _viewContacts = new List<Contact>();

        /// <summary>
        /// вывод всех контактов по фамилии в ListBox
        /// </summary>
        private void InsertToListBox()
        {
            ContactSurnameComparer surnameComparer = new ContactSurnameComparer();
            _viewContacts.Sort(surnameComparer);

            for (int index = 0; index < _viewContacts.Count; index++)
            {
                surnameListBox.Items.Insert(index, _viewContacts[index].Surname);
            }
        }

        /// <summary>
        /// Выводит информацию о контакте по индексу
        /// </summary>
        /// <param name="index">индекс контакта</param>
        private void InputInformationOfContact(int index)
        {
            if (index == -1) return;
            var contact = _viewContacts[index];
            surnameTextBox.Text = contact.Surname;
            nameTextBox.Text = contact.Name;
            dateBox.Value = contact.Birthday;
            phoneTextBox.Text = contact.PhoneNumber.Number.ToString();
            vkTextBox.Text = contact.IdVkontakte;
            mailTextBox.Text = contact.EMail;
        }

        /// <summary>
        /// Чистит информацию во всех TextBox
        /// </summary>
        private void ClearInformationOfContact()
        {
            surnameTextBox.Text = "";
            nameTextBox.Text = "";
            dateBox.Value = DateTime.Now;
            phoneTextBox.Text = "";
            vkTextBox.Text = "";
            mailTextBox.Text = "";
        }

        /// <summary>
        /// Удаляет выбранный контакт
        /// </summary>
        private void RemoveComtact()
        {
            if (surnameListBox.SelectedItem == null)
            {
                MessageBox.Show("Select contact!");
                return;
            }
            int index = surnameListBox.SelectedIndex;
            DialogResult result =
                MessageBox.Show("Do you really want to remove this contact: " +
                                $"{_viewContacts[index].Surname}",
                    "Remove Contact", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                _project.Contacts.RemoveAt(_project.Contacts.IndexOf(
                    _viewContacts[index]));
            }
            ProjectManager.SaveToFile(_project, ProjectManager.Path, ProjectManager.FileName);
            _viewContacts = new List<Contact>();
            _viewContacts = _project.SearchContactByString(textBoxFind.Text);
            surnameListBox.Items.Clear();
            InsertToListBox();
            if (_viewContacts.Count > 0)
            {
                surnameListBox.SelectedIndex = 0;
                InputInformationOfContact(0);
            }
            else
            {
                ClearInformationOfContact();
            }
        }

        /// <summary>
        /// находит контакты у которых сегодня день рождения 
        /// </summary>
        void SearchBirthdaySurnames()
        {
            labelSurames.Text = "";
            for (int index = 0; index < _viewContacts.Count; index++)
            {
                if ((_viewContacts[index].Birthday.Month == DateTime.Now.Month)
                    && (_viewContacts[index].Birthday.Day == DateTime.Now.Day))
                {
                    if (labelSurames.Text != "")
                    {
                        labelSurames.Text = labelSurames.Text + ", ";
                    }

                    labelSurames.Text = labelSurames.Text + _viewContacts[index].Surname;
                }
            }
        }

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
            ContactForm contact = new ContactForm();
            contact.ShowDialog();
            if (contact.DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(contact.Contact);
                ProjectManager.SaveToFile(_project, ProjectManager.Path, ProjectManager.FileName);
                _viewContacts = new List<Contact>();
                _viewContacts = _project.SearchContactByString(textBoxFind.Text);
                surnameListBox.Items.Clear();
                InsertToListBox();
                int index = _viewContacts.Count - 1;
                surnameListBox.SelectedIndex = index;
                InputInformationOfContact(index);
                SearchBirthdaySurnames();
            }
        }

        private void EditContact_Click(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedItem == null)
            {
                MessageBox.Show("Select contact");
                return;
            }
            
            int index = surnameListBox.SelectedIndex;
            ContactForm contact = new ContactForm();
            contact.Contact = (Contact)_viewContacts[index].Clone();
            contact.ShowDialog();
            if (contact.DialogResult == DialogResult.OK)
            {
                var contactIndex = _project.Contacts.IndexOf(
                    _viewContacts[index]);
                _project.Contacts[contactIndex] 
                    = (Contact)contact.Contact.Clone();
            }
            ProjectManager.SaveToFile(_project, ProjectManager.Path, ProjectManager.FileName);
            _viewContacts = new List<Contact>();
            _viewContacts = _project.SearchContactByString(textBoxFind.Text);
            surnameListBox.Items.Clear();
            InsertToListBox();
            InputInformationOfContact(index);
            surnameListBox.SelectedIndex = index;
        }

        private void RemoveContact_Click(object sender, EventArgs e)
        {
            RemoveComtact();
        }

        private void About_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _viewContacts = _project.Contacts;
            InsertToListBox();
            if (_viewContacts.Count > 0)
            {
                surnameListBox.SelectedIndex = 0;
                InputInformationOfContact(0);
            }
            SearchBirthdaySurnames();
        }

        private void surnameListBox_Click(object sender, EventArgs e)
        {
            int index = surnameListBox.SelectedIndex;
            InputInformationOfContact(index);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                About aboutForm = new About();
                aboutForm.Show();
            }
            else if (e.KeyCode == Keys.F4)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                RemoveComtact();
            }
        }

        private void TextBoxFind_Changer(object sender, EventArgs e)
        {
            _viewContacts = new List<Contact>();
            string searchString = textBoxFind.Text;
            _viewContacts = _project.SearchContactByString(searchString);
            surnameListBox.Items.Clear();
            InsertToListBox();
            if (_viewContacts.Count > 0)
            {
                surnameListBox.SelectedIndex = 0;
                InputInformationOfContact(0);
            }
            else
            {
                ClearInformationOfContact();
            }
        }

        private void DateBox_ValueChanged(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedIndex != -1)
            {
                dateBox.Value = _viewContacts[surnameListBox.SelectedIndex].Birthday;
            }
            else
            {
                dateBox.Value = DateTime.Now;
            }
        }
    }
}
