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
       private Project project = new Project();
       private int[] indexOfContact;

        

        public MainForm()
        {
            InitializeComponent();
            project.Contacts = Manager.LoadFromFile();
            InitializeInbexOfContact();
        }

        private void InitializeInbexOfContact()
        {
            indexOfContact = new int[project.Contacts.Length];
            for (int index = 0; index < project.Contacts.Length; index++)
            {
                indexOfContact[index] = index;
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
                if (project.Contacts == null)
                {
                    project.Initialization(edit.Contact);
                }
                else
                {
                    project.AddContact(edit.Contact);
                }
                
            }
            Manager.SafeToFile(project.Contacts);
            project.DeleteContacts();
            project.Contacts = Manager.LoadFromFile();
            InitializeInbexOfContact();
            textBoxFind.Clear();
            InsertToListBox();
        }

        private void EditContact_Click(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedItem != null)
            {
                int index = indexOfContact[surnameListBox.SelectedIndex];
                EditForm edit = new EditForm();
                edit.Contact = (Contact) project.Contacts[index].Clone();
                edit.ShowDialog();
                if (edit.DialogResult == DialogResult.OK)
                {
                    project.Contacts[index] = null;
                    project.Contacts[index] = (Contact) edit.Contact.Clone();
                }
                Manager.SafeToFile(project.Contacts);
                textBoxFind.Clear();
                InitializeInbexOfContact();
                InsertToListBox();
            }
            else
            {
                MessageBox.Show("Select contact!");
            }
            
        }

        private void RemoveContact_Click(object sender, EventArgs e)
        {
            Contact[] contacts = project.Contacts;
            int index = indexOfContact[surnameListBox.SelectedIndex];

            DialogResult result = MessageBox.Show(
                $"Do you really want to remove this contact: {contacts[index].Surname}",
                "Remove Contact",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                project.DeleteNode(index);
            }
            Manager.SafeToFile(project.Contacts);
            textBoxFind.Clear();
            InsertToListBox();
        }

        private void About_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (project.Contacts != null)
            {
                InsertToListBox();
            }
        }

        private void InsertToListBox()
        {
            surnameListBox.Items.Clear();
            surnameTextBox.Clear();
            nameTextBox.Clear();
            dateBox.Text = DateTime.Now.ToString();
            phoneTextBox.Clear();
            mailTextBox.Clear();
            vkTextBox.Clear();

            if (project.Contacts != null)
            {
                for (int index = 0; index < project.Contacts.Length; index++)
                {
                    surnameListBox.Items.Insert(index, project.Contacts[index].Surname);
                }
            }
           
        }

        private void surnameListBox_Click(object sender, EventArgs e)
        {
            int index = indexOfContact[surnameListBox.SelectedIndex];
            if (index != -1)
            {
                surnameTextBox.Text = project.Contacts[index].Surname;
                nameTextBox.Text = project.Contacts[index].Name;
                dateBox.Text = project.Contacts[index].Date;
                phoneTextBox.Text = project.Contacts[index].PhoneNumber;
                vkTextBox.Text = project.Contacts[index].IDVKontakte;
                mailTextBox.Text = project.Contacts[index].Mail;
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
            indexOfContact = null;
            indexOfContact = new int[project.Contacts.Length];

            if (strFind != "")
            {
                int count = 0;
                Project newProject = new Project();
                for (int index = 0; index < project.Contacts.Length; index++)
                {
                    if (project.Contacts[index].Surname.Contains(strFind))
                    {
                        indexOfContact[count] = index;
                        count++;
                        if (newProject.Contacts != null)
                        {
                            newProject.AddContact(project.Contacts[index]);
                        }
                        else
                        {
                            newProject.Initialization(project.Contacts[index]);
                        }
                        
                    }
                }
                //InitializeInbexOfContact();
                project.DeleteContacts();
                project.Contacts = newProject.Contacts;
            }

            InsertToListBox();
            project.DeleteContacts();
            project.Contacts = Manager.LoadFromFile();
        }

        private void DateBox_ValueChanged(object sender, EventArgs e)
        {
            if (surnameListBox.SelectedIndex != -1)
            {
                dateBox.Text = project.Contacts[surnameListBox.SelectedIndex].Date;
            }
            else
            {
                dateBox.Text = DateTime.Now.ToString();
            }
        }

        
    }
}
