namespace Beamer_desktop
{
    partial class Content_Manager
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Cars = new System.Windows.Forms.TabPage();
            this.dtpMake = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbFuel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTopSpeed = new System.Windows.Forms.NumericUpDown();
            this.nudTime0To60 = new System.Windows.Forms.NumericUpDown();
            this.nudTorque = new System.Windows.Forms.NumericUpDown();
            this.nudHorsePower = new System.Windows.Forms.NumericUpDown();
            this.nudMilage = new System.Windows.Forms.NumericUpDown();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.txtEngine = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.txtChassisNumber = new System.Windows.Forms.TextBox();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.Accesories = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudAWeight = new System.Windows.Forms.NumericUpDown();
            this.nudAPrice = new System.Windows.Forms.NumericUpDown();
            this.txtAType = new System.Windows.Forms.TextBox();
            this.txtAImageUrl = new System.Windows.Forms.TextBox();
            this.txtADescription = new System.Windows.Forms.TextBox();
            this.txtAName = new System.Windows.Forms.TextBox();
            this.btnAddAccessory = new System.Windows.Forms.Button();
            this.Overview = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lbView = new System.Windows.Forms.ListBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Cars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime0To60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTorque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorsePower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMilage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.Accesories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAPrice)).BeginInit();
            this.Overview.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Cars);
            this.tabControl1.Controls.Add(this.Accesories);
            this.tabControl1.Controls.Add(this.Overview);
            this.tabControl1.Location = new System.Drawing.Point(31, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 388);
            this.tabControl1.TabIndex = 0;
            // 
            // Cars
            // 
            this.Cars.Controls.Add(this.label11);
            this.Cars.Controls.Add(this.dtpMake);
            this.Cars.Controls.Add(this.label8);
            this.Cars.Controls.Add(this.cbFuel);
            this.Cars.Controls.Add(this.label7);
            this.Cars.Controls.Add(this.label6);
            this.Cars.Controls.Add(this.label5);
            this.Cars.Controls.Add(this.label4);
            this.Cars.Controls.Add(this.label3);
            this.Cars.Controls.Add(this.label2);
            this.Cars.Controls.Add(this.label1);
            this.Cars.Controls.Add(this.nudTopSpeed);
            this.Cars.Controls.Add(this.nudTime0To60);
            this.Cars.Controls.Add(this.nudTorque);
            this.Cars.Controls.Add(this.nudHorsePower);
            this.Cars.Controls.Add(this.nudMilage);
            this.Cars.Controls.Add(this.nudWeight);
            this.Cars.Controls.Add(this.nudPrice);
            this.Cars.Controls.Add(this.txtEngine);
            this.Cars.Controls.Add(this.txtModel);
            this.Cars.Controls.Add(this.txtBrand);
            this.Cars.Controls.Add(this.txtPlate);
            this.Cars.Controls.Add(this.txtChassisNumber);
            this.Cars.Controls.Add(this.txtImageUrl);
            this.Cars.Controls.Add(this.txtDescription);
            this.Cars.Controls.Add(this.txtName);
            this.Cars.Controls.Add(this.btnAddCar);
            this.Cars.Location = new System.Drawing.Point(4, 29);
            this.Cars.Name = "Cars";
            this.Cars.Padding = new System.Windows.Forms.Padding(3);
            this.Cars.Size = new System.Drawing.Size(688, 355);
            this.Cars.TabIndex = 0;
            this.Cars.Text = "Cars";
            this.Cars.UseVisualStyleBackColor = true;
            this.Cars.Click += new System.EventHandler(this.Cars_Click);
            // 
            // dtpMake
            // 
            this.dtpMake.Location = new System.Drawing.Point(148, 322);
            this.dtpMake.Name = "dtpMake";
            this.dtpMake.Size = new System.Drawing.Size(235, 27);
            this.dtpMake.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(294, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 25);
            this.label8.TabIndex = 35;
            this.label8.Text = "Fuel";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbFuel
            // 
            this.cbFuel.FormattingEnabled = true;
            this.cbFuel.Items.AddRange(new object[] {
            "Petrol",
            "Diesel"});
            this.cbFuel.Location = new System.Drawing.Point(426, 75);
            this.cbFuel.Name = "cbFuel";
            this.cbFuel.Size = new System.Drawing.Size(125, 28);
            this.cbFuel.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(294, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 25);
            this.label7.TabIndex = 33;
            this.label7.Text = "Topspeed(km/h)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(294, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 25);
            this.label6.TabIndex = 32;
            this.label6.Text = "0-60(sec)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(294, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 25);
            this.label5.TabIndex = 31;
            this.label5.Text = "Torque(nm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(294, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "Horsepower(hp)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(294, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Milage(km)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(6, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Weight(kg)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Price";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudTopSpeed
            // 
            this.nudTopSpeed.Location = new System.Drawing.Point(426, 208);
            this.nudTopSpeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTopSpeed.Name = "nudTopSpeed";
            this.nudTopSpeed.Size = new System.Drawing.Size(125, 27);
            this.nudTopSpeed.TabIndex = 26;
            // 
            // nudTime0To60
            // 
            this.nudTime0To60.DecimalPlaces = 2;
            this.nudTime0To60.Location = new System.Drawing.Point(426, 175);
            this.nudTime0To60.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTime0To60.Name = "nudTime0To60";
            this.nudTime0To60.Size = new System.Drawing.Size(125, 27);
            this.nudTime0To60.TabIndex = 25;
            // 
            // nudTorque
            // 
            this.nudTorque.Location = new System.Drawing.Point(426, 142);
            this.nudTorque.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTorque.Name = "nudTorque";
            this.nudTorque.Size = new System.Drawing.Size(125, 27);
            this.nudTorque.TabIndex = 24;
            // 
            // nudHorsePower
            // 
            this.nudHorsePower.Location = new System.Drawing.Point(426, 109);
            this.nudHorsePower.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudHorsePower.Name = "nudHorsePower";
            this.nudHorsePower.Size = new System.Drawing.Size(125, 27);
            this.nudHorsePower.TabIndex = 23;
            // 
            // nudMilage
            // 
            this.nudMilage.Location = new System.Drawing.Point(426, 7);
            this.nudMilage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMilage.Name = "nudMilage";
            this.nudMilage.Size = new System.Drawing.Size(125, 27);
            this.nudMilage.TabIndex = 22;
            // 
            // nudWeight
            // 
            this.nudWeight.Location = new System.Drawing.Point(148, 139);
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(125, 27);
            this.nudWeight.TabIndex = 21;
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(148, 40);
            this.nudPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(125, 27);
            this.nudPrice.TabIndex = 20;
            // 
            // txtEngine
            // 
            this.txtEngine.Location = new System.Drawing.Point(426, 43);
            this.txtEngine.Name = "txtEngine";
            this.txtEngine.PlaceholderText = "Engine";
            this.txtEngine.Size = new System.Drawing.Size(125, 27);
            this.txtEngine.TabIndex = 12;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(148, 276);
            this.txtModel.Name = "txtModel";
            this.txtModel.PlaceholderText = "Model";
            this.txtModel.Size = new System.Drawing.Size(125, 27);
            this.txtModel.TabIndex = 9;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(148, 237);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.PlaceholderText = "Brand";
            this.txtBrand.Size = new System.Drawing.Size(125, 27);
            this.txtBrand.TabIndex = 8;
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(148, 204);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.PlaceholderText = "Plate";
            this.txtPlate.Size = new System.Drawing.Size(125, 27);
            this.txtPlate.TabIndex = 7;
            // 
            // txtChassisNumber
            // 
            this.txtChassisNumber.Location = new System.Drawing.Point(148, 171);
            this.txtChassisNumber.Name = "txtChassisNumber";
            this.txtChassisNumber.PlaceholderText = "Chassisnumber";
            this.txtChassisNumber.Size = new System.Drawing.Size(125, 27);
            this.txtChassisNumber.TabIndex = 6;
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.Location = new System.Drawing.Point(148, 105);
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.PlaceholderText = "Image URL";
            this.txtImageUrl.Size = new System.Drawing.Size(125, 27);
            this.txtImageUrl.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(148, 72);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Description";
            this.txtDescription.Size = new System.Drawing.Size(125, 27);
            this.txtDescription.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 6);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Name";
            this.txtName.Size = new System.Drawing.Size(125, 27);
            this.txtName.TabIndex = 1;
            // 
            // btnAddCar
            // 
            this.btnAddCar.Location = new System.Drawing.Point(562, 297);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(94, 29);
            this.btnAddCar.TabIndex = 0;
            this.btnAddCar.Text = "Add car";
            this.btnAddCar.UseVisualStyleBackColor = true;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // Accesories
            // 
            this.Accesories.Controls.Add(this.label9);
            this.Accesories.Controls.Add(this.label10);
            this.Accesories.Controls.Add(this.nudAWeight);
            this.Accesories.Controls.Add(this.nudAPrice);
            this.Accesories.Controls.Add(this.txtAType);
            this.Accesories.Controls.Add(this.txtAImageUrl);
            this.Accesories.Controls.Add(this.txtADescription);
            this.Accesories.Controls.Add(this.txtAName);
            this.Accesories.Controls.Add(this.btnAddAccessory);
            this.Accesories.Location = new System.Drawing.Point(4, 29);
            this.Accesories.Name = "Accesories";
            this.Accesories.Padding = new System.Windows.Forms.Padding(3);
            this.Accesories.Size = new System.Drawing.Size(688, 355);
            this.Accesories.TabIndex = 1;
            this.Accesories.Text = "Accesories";
            this.Accesories.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DarkGray;
            this.label9.Location = new System.Drawing.Point(18, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 25);
            this.label9.TabIndex = 37;
            this.label9.Text = "Weight(kg)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DarkGray;
            this.label10.Location = new System.Drawing.Point(18, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 25);
            this.label10.TabIndex = 36;
            this.label10.Text = "Price";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudAWeight
            // 
            this.nudAWeight.Location = new System.Drawing.Point(160, 144);
            this.nudAWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAWeight.Name = "nudAWeight";
            this.nudAWeight.Size = new System.Drawing.Size(125, 27);
            this.nudAWeight.TabIndex = 35;
            // 
            // nudAPrice
            // 
            this.nudAPrice.DecimalPlaces = 2;
            this.nudAPrice.Location = new System.Drawing.Point(160, 45);
            this.nudAPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAPrice.Name = "nudAPrice";
            this.nudAPrice.Size = new System.Drawing.Size(125, 27);
            this.nudAPrice.TabIndex = 34;
            // 
            // txtAType
            // 
            this.txtAType.Location = new System.Drawing.Point(160, 176);
            this.txtAType.Name = "txtAType";
            this.txtAType.PlaceholderText = "Type";
            this.txtAType.Size = new System.Drawing.Size(125, 27);
            this.txtAType.TabIndex = 32;
            // 
            // txtAImageUrl
            // 
            this.txtAImageUrl.Location = new System.Drawing.Point(160, 110);
            this.txtAImageUrl.Name = "txtAImageUrl";
            this.txtAImageUrl.PlaceholderText = "Image URL";
            this.txtAImageUrl.Size = new System.Drawing.Size(125, 27);
            this.txtAImageUrl.TabIndex = 31;
            // 
            // txtADescription
            // 
            this.txtADescription.Location = new System.Drawing.Point(160, 77);
            this.txtADescription.Name = "txtADescription";
            this.txtADescription.PlaceholderText = "Description";
            this.txtADescription.Size = new System.Drawing.Size(125, 27);
            this.txtADescription.TabIndex = 30;
            // 
            // txtAName
            // 
            this.txtAName.Location = new System.Drawing.Point(160, 11);
            this.txtAName.Name = "txtAName";
            this.txtAName.PlaceholderText = "Name";
            this.txtAName.Size = new System.Drawing.Size(125, 27);
            this.txtAName.TabIndex = 29;
            // 
            // btnAddAccessory
            // 
            this.btnAddAccessory.Location = new System.Drawing.Point(500, 299);
            this.btnAddAccessory.Name = "btnAddAccessory";
            this.btnAddAccessory.Size = new System.Drawing.Size(119, 29);
            this.btnAddAccessory.TabIndex = 1;
            this.btnAddAccessory.Text = "Add accessory";
            this.btnAddAccessory.UseVisualStyleBackColor = true;
            this.btnAddAccessory.Click += new System.EventHandler(this.btnAddAccessory_Click);
            // 
            // Overview
            // 
            this.Overview.Controls.Add(this.btnDelete);
            this.Overview.Controls.Add(this.flowLayoutPanel1);
            this.Overview.Controls.Add(this.btnLoad);
            this.Overview.Controls.Add(this.lbView);
            this.Overview.Location = new System.Drawing.Point(4, 29);
            this.Overview.Name = "Overview";
            this.Overview.Size = new System.Drawing.Size(688, 355);
            this.Overview.TabIndex = 2;
            this.Overview.Text = "Overview";
            this.Overview.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(569, 312);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanel1.Controls.Add(this.lblProductInfo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(315, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(348, 284);
            this.flowLayoutPanel1.TabIndex = 2;
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
            this.btnLoad.Location = new System.Drawing.Point(18, 312);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lbView
            // 
            this.lbView.FormattingEnabled = true;
            this.lbView.ItemHeight = 20;
            this.lbView.Location = new System.Drawing.Point(18, 17);
            this.lbView.Name = "lbView";
            this.lbView.Size = new System.Drawing.Size(259, 284);
            this.lbView.TabIndex = 0;
            this.lbView.SelectedIndexChanged += new System.EventHandler(this.lbView_SelectedIndexChanged);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.Location = new System.Drawing.Point(694, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(94, 29);
            this.btnLogout.TabIndex = 16;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DarkGray;
            this.label11.Location = new System.Drawing.Point(6, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 25);
            this.label11.TabIndex = 37;
            this.label11.Text = "Make";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Content_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Name = "Content_Manager";
            this.Text = "Content_Manager";
            this.tabControl1.ResumeLayout(false);
            this.Cars.ResumeLayout(false);
            this.Cars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime0To60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTorque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorsePower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMilage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.Accesories.ResumeLayout(false);
            this.Accesories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAPrice)).EndInit();
            this.Overview.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage Cars;
        private TextBox txtEngine;
        private TextBox txtModel;
        private TextBox txtBrand;
        private TextBox txtPlate;
        private TextBox txtChassisNumber;
        private TextBox txtImageUrl;
        private TextBox txtDescription;
        private TextBox txtName;
        private Button btnAddCar;
        private TabPage Accesories;
        private NumericUpDown nudPrice;
        private NumericUpDown nudWeight;
        private NumericUpDown nudMilage;
        private NumericUpDown nudTime0To60;
        private NumericUpDown nudTorque;
        private NumericUpDown nudHorsePower;
        private NumericUpDown nudTopSpeed;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbFuel;
        private Label label8;
        private Button btnAddAccessory;
        private Label label9;
        private Label label10;
        private NumericUpDown nudAWeight;
        private NumericUpDown nudAPrice;
        private TextBox txtAType;
        private TextBox txtAImageUrl;
        private TextBox txtADescription;
        private TextBox txtAName;
        private TabPage Overview;
        private Button btnLoad;
        private ListBox lbView;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblProductInfo;
        private Button btnDelete;
        private Button btnLogout;
        private DateTimePicker dtpMake;
        private Label label11;
    }
}