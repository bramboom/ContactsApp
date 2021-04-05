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
        private Project _project = ProjectManager.LoadFromFile(ProjectManager.Path);

        /// <summary>
        /// Хранит список контактов для просмотра
        /// </summary>
        private Project _viewContacts = new Project();

        /// <summary>
        /// вывод всех контактов по фамилии в ListBox
        /// </summary>
        private void InsertToListBox()
        {
            for (int index = 0; index < _viewContacts.Contacts.Count; index++)
            {
                surnameListBox.Items.Insert(index, _viewContacts.Contacts[index].Surname);
            }
        }

        /// <summary>
        /// Выводит информацию о контакте по индексу
        /// </summary>
        /// <param name="index">индекс контакта</param>
        private void InputInformationOfContact(int index)
        {
            if (index != -1)
            {
                surnameTextBox.Text = _viewContacts.Contacts[index].Surname;
                nameTextBox.Text = _viewContacts.Contacts[index].Name;
                dateBox.Value = _viewContacts.Contacts[index].Birthday;
                phoneTextBox.Text = _viewContacts.Contacts[index].PhoneNumber.Number.ToString();
                vkTextBox.Text = _viewContacts.Contacts[index].IdVkontakte;
                mailTextBox.Text = _viewContacts.Contacts[index].EMail;
            }
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

        public MainForm()
        {
            InitializeComponent();
            _viewContacts.Contacts = _project.Contacts;
            if (_viewContacts.Contacts.Count > 0)
            {
                surnameListBox.SelectedItem = 0;
                InputInformationOfContact(0);
            }
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddContact_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm();
            edit.ShowDialog();
            if (edit.DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(edit.Contact);
            }
            ProjectManager.SaveToFile(_project, ProjectManager.Path);
            _viewContacts.Contacts = new List<Contact>();
            _viewContacts.Contacts = _project.SearchContactByString(textBoxFind.Text);
            surnameListBox.Items.Clear();
            InsertToListBox();
            int index = _viewContacts.Contacts.Count - 1;
            surnameListBox.SelectedItem = index;
            InputInformationOfContact(index);
        }

        private void EditContact_Click(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedItem == null)
            {
                MessageBox.Show("Select contact");
                return;
            }
            
            int index = surnameListBox.SelectedIndex;
            EditForm edit = new EditForm();
            edit.Contact = (Contact)_viewContacts.Contacts[index].Clone();
            edit.ShowDialog();
            if (edit.DialogResult == DialogResult.OK)
            {
                _project.Contacts[
                    _project.Contacts.IndexOf(
                        _viewContacts.Contacts[index])] 
                    = (Contact)edit.Contact.Clone();
            }
            ProjectManager.SaveToFile(_project, ProjectManager.Path);
            _viewContacts.Contacts = new List<Contact>();
            _viewContacts.Contacts = _project.SearchContactByString(textBoxFind.Text);
            surnameListBox.Items.Clear();
            InsertToListBox();
            InputInformationOfContact(index);
            if (_viewContacts.Contacts.Count > 0)
            {
                surnameListBox.SelectedItem = 0;
                InputInformationOfContact(0);
            }
            else
            {
                ClearInformationOfContact();
            }
        }

        private void RemoveContact_Click(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedItem == null)
            {
                MessageBox.Show("Select contact!");
                return;
            }

            int index = surnameListBox.SelectedIndex;
            DialogResult result =
                MessageBox.Show("Do you really want to remove this contact: " +
                                $"{_viewContacts.Contacts[index].Surname}",
                        "Remove Contact", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                _project.Contacts.RemoveAt(_project.Contacts.IndexOf(
                    _viewContacts.Contacts[index]));
            }
            ProjectManager.SaveToFile(_project, ProjectManager.Path);
            _viewContacts.Contacts = new List<Contact>();
            _viewContacts.Contacts = _project.SearchContactByString(textBoxFind.Text);
            surnameListBox.Items.Clear();
            InsertToListBox();
            if (_viewContacts.Contacts.Count > 0)
            {
                surnameListBox.SelectedItem = 0;
                InputInformationOfContact(0);
            }
            else
            {
                ClearInformationOfContact();
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InsertToListBox();
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
        }

        private void TextBoxFind_Changer(object sender, EventArgs e)
        {
            _viewContacts.Contacts = new List<Contact>();
            string searchString = textBoxFind.Text;
            _viewContacts.Contacts = _project.SearchContactByString(searchString);
            surnameListBox.Items.Clear();
            InsertToListBox();
            if (_viewContacts.Contacts.Count > 0)
            {
                surnameListBox.SelectedItem = 0;
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
                dateBox.Value = _viewContacts.Contacts[surnameListBox.SelectedIndex].Birthday;
            }
            else
            {
                dateBox.Value = DateTime.Now;
            }
        }
    }
}
