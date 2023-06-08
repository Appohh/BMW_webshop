namespace Beamer_desktop
{
    partial class HR
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Overview = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lbView = new System.Windows.Forms.ListBox();
            this.Register = new System.Windows.Forms.TabPage();
            this.nudRole = new System.Windows.Forms.NumericUpDown();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Overview.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.Register.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRole)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(16, 288);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(94, 29);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(16, 27);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderText = "Firstname";
            this.txtFirstName.Size = new System.Drawing.Size(125, 27);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(16, 60);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderText = "Lastname";
            this.txtLastName.Size = new System.Drawing.Size(125, 27);
            this.txtLastName.TabIndex = 3;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Location = new System.Drawing.Point(16, 93);
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.PlaceholderText = "Birthdate";
            this.txtBirthDate.Size = new System.Drawing.Size(125, 27);
            this.txtBirthDate.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(16, 126);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Size = new System.Drawing.Size(125, 27);
            this.txtEmail.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(16, 159);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "Phone";
            this.txtPhone.Size = new System.Drawing.Size(125, 27);
            this.txtPhone.TabIndex = 9;
            // 
            // txtBSN
            // 
            this.txtBSN.Location = new System.Drawing.Point(16, 192);
            this.txtBSN.Name = "txtBSN";
            this.txtBSN.PlaceholderText = "BSN";
            this.txtBSN.Size = new System.Drawing.Size(125, 27);
            this.txtBSN.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(16, 225);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(125, 27);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Overview);
            this.tabControl1.Controls.Add(this.Register);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 390);
            this.tabControl1.TabIndex = 14;
            // 
            // Overview
            // 
            this.Overview.Controls.Add(this.btnDelete);
            this.Overview.Controls.Add(this.flowLayoutPanel1);
            this.Overview.Controls.Add(this.btnLoad);
            this.Overview.Controls.Add(this.lbView);
            this.Overview.Location = new System.Drawing.Point(4, 29);
            this.Overview.Name = "Overview";
            this.Overview.Padding = new System.Windows.Forms.Padding(3);
            this.Overview.Size = new System.Drawing.Size(712, 357);
            this.Overview.TabIndex = 0;
            this.Overview.Text = "Overview";
            this.Overview.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(573, 314);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanel1.Controls.Add(this.lblProductInfo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(319, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(348, 284);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.AutoSize = true;
            this.lblProductInfo.Location = new System.Drawing.Point(3, 0);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(0, 20);
            this.lblProductInfo.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(22, 314);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lbView
            // 
            this.lbView.FormattingEnabled = true;
            this.lbView.ItemHeight = 20;
            this.lbView.Location = new System.Drawing.Point(22, 19);
            this.lbView.Name = "lbView";
            this.lbView.Size = new System.Drawing.Size(259, 284);
            this.lbView.TabIndex = 4;
            this.lbView.SelectedIndexChanged += new System.EventHandler(this.lbView_SelectedIndexChanged);
            // 
            // Register
            // 
            this.Register.Controls.Add(this.nudRole);
            this.Register.Controls.Add(this.txtLastName);
            this.Register.Controls.Add(this.txtPassword);
            this.Register.Controls.Add(this.btnRegister);
            this.Register.Controls.Add(this.txtBSN);
            this.Register.Controls.Add(this.txtFirstName);
            this.Register.Controls.Add(this.txtPhone);
            this.Register.Controls.Add(this.txtBirthDate);
            this.Register.Controls.Add(this.txtEmail);
            this.Register.Location = new System.Drawing.Point(4, 29);
            this.Register.Name = "Register";
            this.Register.Padding = new System.Windows.Forms.Padding(3);
            this.Register.Size = new System.Drawing.Size(712, 357);
            this.Register.TabIndex = 1;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            // 
            // nudRole
            // 
            this.nudRole.Location = new System.Drawing.Point(16, 258);
            this.nudRole.Name = "nudRole";
            this.nudRole.Size = new System.Drawing.Size(125, 27);
            this.nudRole.TabIndex = 14;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.Location = new System.Drawing.Point(694, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(94, 29);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // HR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Name = "HR";
            this.Text = "Human Resource";
            this.tabControl1.ResumeLayout(false);
            this.Overview.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.Register.ResumeLayout(false);
            this.Register.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRole)).EndInit();
            this.ResumeLayout(false);

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
        private TabControl tabControl1;
        private TabPage Overview;
        private TabPage Register;
        private Button btnDelete;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblProductInfo;
        private Button btnLoad;
        private ListBox lbView;
        private NumericUpDown nudRole;
        private Button btnLogout;
    }
}