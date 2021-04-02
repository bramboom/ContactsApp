
namespace ContactsAppUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.vkTextBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.mailLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.vkLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.surnameListBox = new System.Windows.Forms.ListBox();
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(932, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.editContactToolStripMenuItem,
            this.removeContactToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.AddContact_Click);
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.editContactToolStripMenuItem.Text = "Edit Contact";
            this.editContactToolStripMenuItem.Click += new System.EventHandler(this.EditContact_Click);
            // 
            // removeContactToolStripMenuItem
            // 
            this.removeContactToolStripMenuItem.Name = "removeContactToolStripMenuItem";
            this.removeContactToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.removeContactToolStripMenuItem.Text = "Remove Contact";
            this.removeContactToolStripMenuItem.Click += new System.EventHandler(this.RemoveContact_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.About_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.ForeColor = System.Drawing.SystemColors.Control;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.Location = new System.Drawing.Point(9, 484);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(32, 32);
            this.AddButton.TabIndex = 1;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddContact_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.ForeColor = System.Drawing.SystemColors.Control;
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.Location = new System.Drawing.Point(41, 484);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(32, 32);
            this.editButton.TabIndex = 2;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditContact_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(73, 484);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(32, 32);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.RemoveContact_Click);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.phoneTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.phoneTextBox.Location = new System.Drawing.Point(68, 89);
            this.phoneTextBox.MaximumSize = new System.Drawing.Size(2000, 22);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.ReadOnly = true;
            this.phoneTextBox.Size = new System.Drawing.Size(536, 22);
            this.phoneTextBox.TabIndex = 4;
            // 
            // mailTextBox
            // 
            this.mailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mailTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mailTextBox.Location = new System.Drawing.Point(68, 117);
            this.mailTextBox.MaximumSize = new System.Drawing.Size(2000, 22);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.ReadOnly = true;
            this.mailTextBox.Size = new System.Drawing.Size(536, 22);
            this.mailTextBox.TabIndex = 5;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nameTextBox.Location = new System.Drawing.Point(68, 33);
            this.nameTextBox.MaximumSize = new System.Drawing.Size(2000, 22);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(536, 22);
            this.nameTextBox.TabIndex = 6;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.surnameTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.surnameTextBox.Location = new System.Drawing.Point(68, 5);
            this.surnameTextBox.MaximumSize = new System.Drawing.Size(2000, 22);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.ReadOnly = true;
            this.surnameTextBox.Size = new System.Drawing.Size(536, 22);
            this.surnameTextBox.TabIndex = 7;
            // 
            // vkTextBox
            // 
            this.vkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vkTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vkTextBox.Location = new System.Drawing.Point(68, 145);
            this.vkTextBox.MaximumSize = new System.Drawing.Size(2000, 22);
            this.vkTextBox.MinimumSize = new System.Drawing.Size(536, 22);
            this.vkTextBox.Name = "vkTextBox";
            this.vkTextBox.ReadOnly = true;
            this.vkTextBox.Size = new System.Drawing.Size(536, 22);
            this.vkTextBox.TabIndex = 8;
            // 
            // dateBox
            // 
            this.dateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBox.CustomFormat = "dd.MM.yyyy";
            this.dateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateBox.Location = new System.Drawing.Point(68, 61);
            this.dateBox.MaxDate = new System.DateTime(9000, 2, 26, 0, 0, 0, 0);
            this.dateBox.MaximumSize = new System.Drawing.Size(120, 22);
            this.dateBox.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(120, 22);
            this.dateBox.TabIndex = 9;
            this.dateBox.TabStop = false;
            this.dateBox.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dateBox.ValueChanged += new System.EventHandler(this.DateBox_ValueChanged);
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.surnameLabel.Location = new System.Drawing.Point(-3, 8);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(69, 17);
            this.surnameLabel.TabIndex = 10;
            this.surnameLabel.Text = "Surname:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nameLabel.Location = new System.Drawing.Point(16, 36);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 17);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Name:";
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mailLabel.Location = new System.Drawing.Point(19, 120);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(46, 17);
            this.mailLabel.TabIndex = 12;
            this.mailLabel.Text = "EMail:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateLabel.Location = new System.Drawing.Point(2, 63);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(64, 17);
            this.dateLabel.TabIndex = 13;
            this.dateLabel.Text = "Birthday:";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.phoneLabel.Location = new System.Drawing.Point(12, 92);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(53, 17);
            this.phoneLabel.TabIndex = 14;
            this.phoneLabel.Text = "Phone:";
            // 
            // vkLabel
            // 
            this.vkLabel.AutoSize = true;
            this.vkLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.vkLabel.Location = new System.Drawing.Point(7, 148);
            this.vkLabel.Name = "vkLabel";
            this.vkLabel.Size = new System.Drawing.Size(56, 17);
            this.vkLabel.TabIndex = 15;
            this.vkLabel.Text = "vk.com:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Find:";
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(46, 32);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(262, 22);
            this.textBoxFind.TabIndex = 17;
            this.textBoxFind.TextChanged += new System.EventHandler(this.TextBoxFind_Changer);
            // 
            // surnameListBox
            // 
            this.surnameListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.surnameListBox.FormattingEnabled = true;
            this.surnameListBox.ItemHeight = 16;
            this.surnameListBox.Location = new System.Drawing.Point(9, 60);
            this.surnameListBox.MaximumSize = new System.Drawing.Size(300, 1000);
            this.surnameListBox.Name = "surnameListBox";
            this.surnameListBox.Size = new System.Drawing.Size(300, 420);
            this.surnameListBox.TabIndex = 18;
            this.surnameListBox.Click += new System.EventHandler(this.surnameListBox_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.phoneTextBox);
            this.panel.Controls.Add(this.mailTextBox);
            this.panel.Controls.Add(this.nameTextBox);
            this.panel.Controls.Add(this.surnameTextBox);
            this.panel.Controls.Add(this.vkLabel);
            this.panel.Controls.Add(this.vkTextBox);
            this.panel.Controls.Add(this.phoneLabel);
            this.panel.Controls.Add(this.dateBox);
            this.panel.Controls.Add(this.dateLabel);
            this.panel.Controls.Add(this.surnameLabel);
            this.panel.Controls.Add(this.mailLabel);
            this.panel.Controls.Add(this.nameLabel);
            this.panel.Location = new System.Drawing.Point(314, 31);
            this.panel.MaximumSize = new System.Drawing.Size(2000, 250);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(606, 178);
            this.panel.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(932, 523);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.surnameListBox);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(950, 570);
            this.Name = "MainForm";
            this.Text = "ContactsApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox vkTextBox;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label vkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.ListBox surnameListBox;
        private System.Windows.Forms.Panel panel;
    }
}