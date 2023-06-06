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
            this.Accesories = new System.Windows.Forms.TabPage();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            this.txtChassisNumber = new System.Windows.Forms.TextBox();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtEngine = new System.Windows.Forms.TextBox();
            this.txtFuel = new System.Windows.Forms.TextBox();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.nudMilage = new System.Windows.Forms.NumericUpDown();
            this.nudHorsePower = new System.Windows.Forms.NumericUpDown();
            this.nudTorque = new System.Windows.Forms.NumericUpDown();
            this.nudTime0To60 = new System.Windows.Forms.NumericUpDown();
            this.nudTopSpeed = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.Cars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMilage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorsePower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTorque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime0To60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Cars);
            this.tabControl1.Controls.Add(this.Accesories);
            this.tabControl1.Location = new System.Drawing.Point(31, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 388);
            this.tabControl1.TabIndex = 0;
            // 
            // Cars
            // 
            this.Cars.Controls.Add(this.nudTopSpeed);
            this.Cars.Controls.Add(this.nudTime0To60);
            this.Cars.Controls.Add(this.nudTorque);
            this.Cars.Controls.Add(this.nudHorsePower);
            this.Cars.Controls.Add(this.nudMilage);
            this.Cars.Controls.Add(this.nudWeight);
            this.Cars.Controls.Add(this.nudPrice);
            this.Cars.Controls.Add(this.txtFuel);
            this.Cars.Controls.Add(this.txtEngine);
            this.Cars.Controls.Add(this.txtMake);
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
            // 
            // Accesories
            // 
            this.Accesories.Location = new System.Drawing.Point(4, 29);
            this.Accesories.Name = "Accesories";
            this.Accesories.Padding = new System.Windows.Forms.Padding(3);
            this.Accesories.Size = new System.Drawing.Size(688, 355);
            this.Accesories.TabIndex = 1;
            this.Accesories.Text = "Accesories";
            this.Accesories.UseVisualStyleBackColor = true;
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 6);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Name";
            this.txtName.Size = new System.Drawing.Size(125, 27);
            this.txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 72);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Description";
            this.txtDescription.Size = new System.Drawing.Size(125, 27);
            this.txtDescription.TabIndex = 3;
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.Location = new System.Drawing.Point(6, 105);
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.PlaceholderText = "Image URL";
            this.txtImageUrl.Size = new System.Drawing.Size(125, 27);
            this.txtImageUrl.TabIndex = 4;
            // 
            // txtChassisNumber
            // 
            this.txtChassisNumber.Location = new System.Drawing.Point(6, 171);
            this.txtChassisNumber.Name = "txtChassisNumber";
            this.txtChassisNumber.PlaceholderText = "Chassisnumber";
            this.txtChassisNumber.Size = new System.Drawing.Size(125, 27);
            this.txtChassisNumber.TabIndex = 6;
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(6, 204);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.PlaceholderText = "Plate";
            this.txtPlate.Size = new System.Drawing.Size(125, 27);
            this.txtPlate.TabIndex = 7;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(6, 237);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.PlaceholderText = "Brand";
            this.txtBrand.Size = new System.Drawing.Size(125, 27);
            this.txtBrand.TabIndex = 8;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(6, 276);
            this.txtModel.Name = "txtModel";
            this.txtModel.PlaceholderText = "Model";
            this.txtModel.Size = new System.Drawing.Size(125, 27);
            this.txtModel.TabIndex = 9;
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(6, 309);
            this.txtMake.Name = "txtMake";
            this.txtMake.PlaceholderText = "Make";
            this.txtMake.Size = new System.Drawing.Size(125, 27);
            this.txtMake.TabIndex = 10;
            // 
            // txtEngine
            // 
            this.txtEngine.Location = new System.Drawing.Point(240, 39);
            this.txtEngine.Name = "txtEngine";
            this.txtEngine.PlaceholderText = "Engine";
            this.txtEngine.Size = new System.Drawing.Size(125, 27);
            this.txtEngine.TabIndex = 12;
            // 
            // txtFuel
            // 
            this.txtFuel.Location = new System.Drawing.Point(240, 72);
            this.txtFuel.Name = "txtFuel";
            this.txtFuel.PlaceholderText = "Fuel";
            this.txtFuel.Size = new System.Drawing.Size(125, 27);
            this.txtFuel.TabIndex = 13;
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(6, 40);
            this.nudPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(125, 27);
            this.nudPrice.TabIndex = 20;
            // 
            // nudWeight
            // 
            this.nudWeight.Location = new System.Drawing.Point(6, 139);
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(125, 27);
            this.nudWeight.TabIndex = 21;
            // 
            // nudMilage
            // 
            this.nudMilage.Location = new System.Drawing.Point(240, 3);
            this.nudMilage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMilage.Name = "nudMilage";
            this.nudMilage.Size = new System.Drawing.Size(125, 27);
            this.nudMilage.TabIndex = 22;
            // 
            // nudHorsePower
            // 
            this.nudHorsePower.Location = new System.Drawing.Point(240, 105);
            this.nudHorsePower.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudHorsePower.Name = "nudHorsePower";
            this.nudHorsePower.Size = new System.Drawing.Size(125, 27);
            this.nudHorsePower.TabIndex = 23;
            // 
            // nudTorque
            // 
            this.nudTorque.Location = new System.Drawing.Point(240, 138);
            this.nudTorque.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTorque.Name = "nudTorque";
            this.nudTorque.Size = new System.Drawing.Size(125, 27);
            this.nudTorque.TabIndex = 24;
            // 
            // nudTime0To60
            // 
            this.nudTime0To60.DecimalPlaces = 2;
            this.nudTime0To60.Location = new System.Drawing.Point(240, 171);
            this.nudTime0To60.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTime0To60.Name = "nudTime0To60";
            this.nudTime0To60.Size = new System.Drawing.Size(125, 27);
            this.nudTime0To60.TabIndex = 25;
            // 
            // nudTopSpeed
            // 
            this.nudTopSpeed.Location = new System.Drawing.Point(240, 204);
            this.nudTopSpeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTopSpeed.Name = "nudTopSpeed";
            this.nudTopSpeed.Size = new System.Drawing.Size(125, 27);
            this.nudTopSpeed.TabIndex = 26;
            // 
            // Content_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Content_Manager";
            this.Text = "Content_Manager";
            this.tabControl1.ResumeLayout(false);
            this.Cars.ResumeLayout(false);
            this.Cars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMilage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorsePower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTorque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime0To60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage Cars;
        private TextBox txtFuel;
        private TextBox txtEngine;
        private TextBox txtMake;
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
    }
}