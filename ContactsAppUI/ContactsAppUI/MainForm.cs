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
        Project project = new Project();
        //private Contact[] contacts;
        

        public MainForm()
        {
            InitializeComponent();
            project.Contacts = Manager.LoadFromFile(@"C://Users/bramboom/Desktop/json.txt");
            //contacts = project.Contacts;
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
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Contact[] contacts = project.Contacts;
            InsertToListBox();
            surnameTextBox.Text = contacts[0].Surname;
            nameTextBox.Text = contacts[0].Name;
            dateBox.Text = contacts[0].Date;
            phoneTextBox.Text = contacts[0].PhoneNumber;
            vkTextBox.Text = contacts[0].IDVKontakte;
            mailTextBox.Text = contacts[0].Mail;
            surnameListBox.SetSelected(0,true);
        }

        

       



        private void InsertToListBox()
        {
            Contact[] contacts = project.Contacts;
            surnameListBox.Items.Clear();
            surnameTextBox.Clear();
            nameTextBox.Clear();
            dateBox.Text = DateTime.Now.ToString();
            phoneTextBox.Clear();
            mailTextBox.Clear();
            vkTextBox.Clear();

            if (contacts != null)
            {
                for (int index = 0; index < contacts.Length; index++)
                {
                    surnameListBox.Items.Insert(index, contacts[index].Surname);
                }
            }
           
        }

        private void surnameListBox_Click(object sender, EventArgs e)
        {
            Contact[] contacts = project.Contacts;
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
            Contact[] contacts = Manager.LoadFromFile(@"C://Users/bramboom/Desctop/json.txt");

            if (strFind != "")
            {
                Project newProject = new Project();
                for (int index = 0; index < contacts.Length; index++)
                {
                    if (contacts[index].Surname.Contains(strFind))
                    {
                        if (newProject.Contacts != null)
                        {
                            newProject.AddContact(contacts[index]);
                        }
                        else
                        {
                            newProject.Initialization(contacts[index]);
                        }
                        
                    }
                }
                project.DeleteContacts();
                project.Contacts = newProject.Contacts;
            }
            else
            {
                Project newProject = new Project();
                for (int index = 0; index < contacts.Length; index++)
                {
                    if (newProject.Contacts != null)
                    {
                        newProject.AddContact(contacts[index]);
                    }
                    else
                    {
                        newProject.Initialization(contacts[0]);
                    }
                }
                project.DeleteContacts();
                project.Contacts = newProject.Contacts;
            }

            InsertToListBox();
        }

        private void DateBox_ValueChanged(object sender, EventArgs e)
        {
            Contact[] contacts = project.Contacts;
            if (surnameListBox.SelectedIndex != -1)
            {
                dateBox.Text = contacts[surnameListBox.SelectedIndex].Date;
            }
        }

        
    }
}
