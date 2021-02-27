
namespace ContactsAppUI
{
    partial class About
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
            this.nameProgram = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Git = new System.Windows.Forms.Label();
            this.linkOnMail = new System.Windows.Forms.LinkLabel();
            this.linkOnGit = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // nameProgram
            // 
            this.nameProgram.AutoSize = true;
            this.nameProgram.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameProgram.Location = new System.Drawing.Point(36, 84);
            this.nameProgram.Name = "nameProgram";
            this.nameProgram.Size = new System.Drawing.Size(242, 45);
            this.nameProgram.TabIndex = 0;
            this.nameProgram.Text = "ContactsApp";
            // 
            // author
            // 
            this.author.AutoSize = true;
            this.author.Location = new System.Drawing.Point(41, 180);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(171, 17);
            this.author.TabIndex = 1;
            this.author.Text = "Author: Alexey Kolesnikov";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(41, 129);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(55, 17);
            this.version.TabIndex = 2;
            this.version.Text = "v. 1.0.0";
            // 
            // mail
            // 
            this.mail.AutoSize = true;
            this.mail.Location = new System.Drawing.Point(41, 240);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(133, 17);
            this.mail.TabIndex = 3;
            this.mail.Text = "e-mail for feedback:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "2021 Alexey Kolesnikov ©";
            // 
            // Git
            // 
            this.Git.AutoSize = true;
            this.Git.Location = new System.Drawing.Point(41, 266);
            this.Git.Name = "Git";
            this.Git.Size = new System.Drawing.Size(60, 17);
            this.Git.TabIndex = 5;
            this.Git.Text = "Git Hub:";
            // 
            // linkOnMail
            // 
            this.linkOnMail.AutoSize = true;
            this.linkOnMail.Location = new System.Drawing.Point(180, 240);
            this.linkOnMail.Name = "linkOnMail";
            this.linkOnMail.Size = new System.Drawing.Size(159, 17);
            this.linkOnMail.TabIndex = 6;
            this.linkOnMail.TabStop = true;
            this.linkOnMail.Text = "bramboom1@yandex.ru";
            // 
            // linkOnGit
            // 
            this.linkOnGit.AutoSize = true;
            this.linkOnGit.Location = new System.Drawing.Point(107, 266);
            this.linkOnGit.Name = "linkOnGit";
            this.linkOnGit.Size = new System.Drawing.Size(275, 17);
            this.linkOnGit.TabIndex = 7;
            this.linkOnGit.TabStop = true;
            this.linkOnGit.Text = "https://github.com/bramboom/ContactsApp";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 513);
            this.Controls.Add(this.linkOnGit);
            this.Controls.Add(this.linkOnMail);
            this.Controls.Add(this.Git);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.version);
            this.Controls.Add(this.author);
            this.Controls.Add(this.nameProgram);
            this.MaximumSize = new System.Drawing.Size(730, 560);
            this.MinimumSize = new System.Drawing.Size(730, 560);
            this.Name = "About";
            this.ShowIcon = false;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameProgram;
        private System.Windows.Forms.Label author;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Git;
        private System.Windows.Forms.LinkLabel linkOnMail;
        private System.Windows.Forms.LinkLabel linkOnGit;
    }
}