namespace ProjectDeliverable2
{
    partial class StudentSearch
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
            this.buttonReturn = new System.Windows.Forms.Button();
            this.textBoxStudentEmail = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.panelRegisterStudent = new System.Windows.Forms.Panel();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFistName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMark = new System.Windows.Forms.Panel();
            this.buttonMark = new System.Windows.Forms.Button();
            this.textBoxMark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxClassID = new System.Windows.Forms.TextBox();
            this.panelRegisterStudent.SuspendLayout();
            this.panelMark.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(391, 319);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(75, 23);
            this.buttonReturn.TabIndex = 0;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // textBoxStudentEmail
            // 
            this.textBoxStudentEmail.Location = new System.Drawing.Point(156, 24);
            this.textBoxStudentEmail.Name = "textBoxStudentEmail";
            this.textBoxStudentEmail.Size = new System.Drawing.Size(224, 20);
            this.textBoxStudentEmail.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(34, 21);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelDisplay
            // 
            this.labelDisplay.AutoSize = true;
            this.labelDisplay.Location = new System.Drawing.Point(153, 8);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(135, 13);
            this.labelDisplay.TabIndex = 3;
            this.labelDisplay.Text = "Search for student by email";
            // 
            // panelRegisterStudent
            // 
            this.panelRegisterStudent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelRegisterStudent.Controls.Add(this.buttonRegister);
            this.panelRegisterStudent.Controls.Add(this.textBoxPhone);
            this.panelRegisterStudent.Controls.Add(this.textBoxLastName);
            this.panelRegisterStudent.Controls.Add(this.label5);
            this.panelRegisterStudent.Controls.Add(this.label4);
            this.panelRegisterStudent.Controls.Add(this.label3);
            this.panelRegisterStudent.Controls.Add(this.textBoxFistName);
            this.panelRegisterStudent.Controls.Add(this.label2);
            this.panelRegisterStudent.Location = new System.Drawing.Point(34, 69);
            this.panelRegisterStudent.Name = "panelRegisterStudent";
            this.panelRegisterStudent.Size = new System.Drawing.Size(432, 127);
            this.panelRegisterStudent.TabIndex = 4;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(353, 94);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(75, 23);
            this.buttonRegister.TabIndex = 7;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Visible = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(122, 96);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.ReadOnly = true;
            this.textBoxPhone.Size = new System.Drawing.Size(224, 20);
            this.textBoxPhone.TabIndex = 6;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(122, 69);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.ReadOnly = true;
            this.textBoxLastName.Size = new System.Drawing.Size(224, 20);
            this.textBoxLastName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "First Name";
            // 
            // textBoxFistName
            // 
            this.textBoxFistName.Location = new System.Drawing.Point(122, 42);
            this.textBoxFistName.Name = "textBoxFistName";
            this.textBoxFistName.ReadOnly = true;
            this.textBoxFistName.Size = new System.Drawing.Size(224, 20);
            this.textBoxFistName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Student details";
            // 
            // panelMark
            // 
            this.panelMark.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMark.Controls.Add(this.textBoxClassID);
            this.panelMark.Controls.Add(this.label8);
            this.panelMark.Controls.Add(this.label6);
            this.panelMark.Controls.Add(this.buttonMark);
            this.panelMark.Controls.Add(this.textBoxMark);
            this.panelMark.Controls.Add(this.label7);
            this.panelMark.Location = new System.Drawing.Point(34, 202);
            this.panelMark.Name = "panelMark";
            this.panelMark.Size = new System.Drawing.Size(432, 111);
            this.panelMark.TabIndex = 5;
            // 
            // buttonMark
            // 
            this.buttonMark.Location = new System.Drawing.Point(354, 76);
            this.buttonMark.Name = "buttonMark";
            this.buttonMark.Size = new System.Drawing.Size(75, 23);
            this.buttonMark.TabIndex = 3;
            this.buttonMark.Text = "Mark";
            this.buttonMark.UseVisualStyleBackColor = true;
            this.buttonMark.Visible = false;
            this.buttonMark.Click += new System.EventHandler(this.buttonMark_Click);
            // 
            // textBoxMark
            // 
            this.textBoxMark.Location = new System.Drawing.Point(122, 49);
            this.textBoxMark.Name = "textBoxMark";
            this.textBoxMark.ReadOnly = true;
            this.textBoxMark.Size = new System.Drawing.Size(224, 20);
            this.textBoxMark.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mark";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Assign Mark";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Class ID";
            // 
            // textBoxClassID
            // 
            this.textBoxClassID.Location = new System.Drawing.Point(122, 78);
            this.textBoxClassID.Name = "textBoxClassID";
            this.textBoxClassID.ReadOnly = true;
            this.textBoxClassID.Size = new System.Drawing.Size(224, 20);
            this.textBoxClassID.TabIndex = 6;
            // 
            // StudentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 354);
            this.Controls.Add(this.panelMark);
            this.Controls.Add(this.panelRegisterStudent);
            this.Controls.Add(this.labelDisplay);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxStudentEmail);
            this.Controls.Add(this.buttonReturn);
            this.Name = "StudentSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentSearch";
            this.panelRegisterStudent.ResumeLayout(false);
            this.panelRegisterStudent.PerformLayout();
            this.panelMark.ResumeLayout(false);
            this.panelMark.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.TextBox textBoxStudentEmail;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.Panel panelRegisterStudent;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFistName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelMark;
        private System.Windows.Forms.TextBox textBoxMark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonMark;
        private System.Windows.Forms.TextBox textBoxClassID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}