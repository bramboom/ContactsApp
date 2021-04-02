using System;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// объект класса Project
        /// </summary>
        private Project project = ProjectManager.LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

        /// <summary>
        /// поле содержит индекс контакта в соответствии с индексом в ListBox
        /// </summary>
        private int[] _indexOfContact;



        public MainForm()
        {
            InitializeComponent();
            InitializeInbexOfContact();
        }

        /// <summary>
        /// инициализация индексов контактов
        /// </summary>
        private void InitializeInbexOfContact()
        {
            if (project.Contacts != null)
            {
                _indexOfContact = new int[project.Contacts.Count];
                for (int index = 0; index < project.Contacts.Count; index++)
                {
                    _indexOfContact[index] = index;
                }
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
                project.Contacts.Add(edit.Contact);
            }
            ProjectManager.SaveToFile(project, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            InitializeInbexOfContact();
            textBoxFind.Clear();
            InsertToListBox();
        }

        private void EditContact_Click(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedItem != null)
            {
                int index = _indexOfContact[surnameListBox.SelectedIndex];
                EditForm edit = new EditForm();
                edit.Contact = (Contact)project.Contacts[index].Clone();
                edit.ShowDialog();
                if (edit.DialogResult == DialogResult.OK)
                {
                    project.Contacts[index] = (Contact)edit.Contact.Clone();
                }
                ProjectManager.SaveToFile(project, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                textBoxFind.Clear();
                InitializeInbexOfContact();
                InsertToListBox();
            }
            else
            {
                MessageBox.Show("Select contact");
            }

        }

        private void RemoveContact_Click(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedItem != null)
            {
                int index = _indexOfContact[surnameListBox.SelectedIndex];
                DialogResult result =
                    MessageBox.Show("Do you really want to remove this contact: " +
                                    $"{project.Contacts[index].Surname}",
                            "Remove Contact", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    project.Contacts.RemoveAt(index);
                }
                ProjectManager.SaveToFile(project, 
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                textBoxFind.Clear();
                InitializeInbexOfContact();
                InsertToListBox();
            }
            else
            {
                MessageBox.Show("Select contact!");
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

        /// <summary>
        /// вывод всех контактов по фамилии в ListBox
        /// </summary>
        private void InsertToListBox()
        {
            surnameListBox.Items.Clear();
            surnameTextBox.Clear();
            nameTextBox.Clear();
            dateBox.Value = DateTime.Now;
            phoneTextBox.Clear();
            mailTextBox.Clear();
            vkTextBox.Clear();

            if (project != null)
            {
                for (int index = 0; index < project.Contacts.Count; index++)
                {
                    surnameListBox.Items.Insert(index, project.Contacts[index].Surname);
                }
            }

        }

        private void surnameListBox_Click(object sender, EventArgs e)
        {
            int index = _indexOfContact[surnameListBox.SelectedIndex];
            if (index != -1)
            {
                surnameTextBox.Text = project.Contacts[index].Surname;
                nameTextBox.Text = project.Contacts[index].Name;
                dateBox.Value = project.Contacts[index].Birthday;
                phoneTextBox.Text = project.Contacts[index].PhoneNumber.Number.ToString();
                vkTextBox.Text = project.Contacts[index].IdVkontakte;
                mailTextBox.Text = project.Contacts[index].EMail;
            }

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
            string strFind = textBoxFind.Text;
            _indexOfContact = null;
            _indexOfContact = new int[project.Contacts.Count];

            if (strFind != "")
            {
                surnameListBox.Items.Clear();
                int count = 0;
                for (int index = 0; index < project.Contacts.Count; index++)
                {
                    if (project.Contacts[index].Surname.Contains(strFind))
                    {
                        _indexOfContact[count] = index;
                        surnameListBox.Items.Insert(count, project.Contacts[index].Surname);
                        count++;

                    }


                }
            }
            else
            {
                InitializeInbexOfContact();
                InsertToListBox();
            }
        }

        private void DateBox_ValueChanged(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedIndex != -1)
            {
                dateBox.Value = project.Contacts[surnameListBox.SelectedIndex].Birthday;
            }
            else
            {
                dateBox.Value = DateTime.Now;
            }
        }
    }
}
