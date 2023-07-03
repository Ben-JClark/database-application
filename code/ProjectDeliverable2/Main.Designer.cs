namespace ProjectDeliverable2
{
    partial class Main
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
            this.buttonShowClasses = new System.Windows.Forms.Button();
            this.buttonCreateClass = new System.Windows.Forms.Button();
            this.buttonStudentSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShowClasses
            // 
            this.buttonShowClasses.Location = new System.Drawing.Point(62, 91);
            this.buttonShowClasses.Name = "buttonShowClasses";
            this.buttonShowClasses.Size = new System.Drawing.Size(281, 40);
            this.buttonShowClasses.TabIndex = 0;
            this.buttonShowClasses.Text = "Show Classes";
            this.buttonShowClasses.UseVisualStyleBackColor = true;
            this.buttonShowClasses.Click += new System.EventHandler(this.buttonShowClasses_Click);
            // 
            // buttonCreateClass
            // 
            this.buttonCreateClass.Location = new System.Drawing.Point(62, 45);
            this.buttonCreateClass.Name = "buttonCreateClass";
            this.buttonCreateClass.Size = new System.Drawing.Size(281, 40);
            this.buttonCreateClass.TabIndex = 1;
            this.buttonCreateClass.Text = "Create Class";
            this.buttonCreateClass.UseVisualStyleBackColor = true;
            this.buttonCreateClass.Click += new System.EventHandler(this.buttonCreateClass_Click);
            // 
            // buttonStudentSearch
            // 
            this.buttonStudentSearch.Location = new System.Drawing.Point(61, 137);
            this.buttonStudentSearch.Name = "buttonStudentSearch";
            this.buttonStudentSearch.Size = new System.Drawing.Size(282, 40);
            this.buttonStudentSearch.TabIndex = 2;
            this.buttonStudentSearch.Text = "Student Search";
            this.buttonStudentSearch.UseVisualStyleBackColor = true;
            this.buttonStudentSearch.Click += new System.EventHandler(this.buttonStudentSearch_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 221);
            this.Controls.Add(this.buttonStudentSearch);
            this.Controls.Add(this.buttonCreateClass);
            this.Controls.Add(this.buttonShowClasses);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Prepare Aware";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShowClasses;
        private System.Windows.Forms.Button buttonCreateClass;
        private System.Windows.Forms.Button buttonStudentSearch;
    }
}

