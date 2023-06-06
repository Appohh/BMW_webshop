namespace Beamer_desktop
{
    partial class Register
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtBSN = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(348, 263);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(94, 29);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(86, 47);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderText = "Firstname";
            this.txtFirstName.Size = new System.Drawing.Size(125, 27);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(86, 80);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderText = "Lastname";
            this.txtLastName.Size = new System.Drawing.Size(125, 27);
            this.txtLastName.TabIndex = 3;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Location = new System.Drawing.Point(86, 113);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.PlaceholderText = "Birthdate";
            this.txtBirthDate.Size = new System.Drawing.Size(125, 27);
            this.txtBirthDate.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(86, 146);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Size = new System.Drawing.Size(125, 27);
            this.txtEmail.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(86, 179);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "Phone";
            this.txtPhone.Size = new System.Drawing.Size(125, 27);
            this.txtPhone.TabIndex = 9;
            // 
            // txtBSN
            // 
            this.txtBSN.Location = new System.Drawing.Point(86, 212);
            this.txtBSN.Name = "txtBSN";
            this.txtBSN.PlaceholderText = "BSN";
            this.txtBSN.Size = new System.Drawing.Size(125, 27);
            this.txtBSN.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(86, 245);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(125, 27);
            this.txtPassword.TabIndex = 13;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtBSN);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtBirthDate);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnRegister);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnRegister;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtBirthDate;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtBSN;
        private TextBox txtPassword;
    }
}