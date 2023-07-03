using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace ProjectDeliverable2
{
    public partial class StudentSearch : Form
    {
        public StudentSearch()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            //Return to the main form and close this form
            Hide();
            Main formMain = new Main();
            formMain.ShowDialog();
            Close();
        }

        /// <summary>
        /// Search for the student's data from the customers table and display it in the textboxes.
        /// If the student doesn't have data give the opton to register the student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            studentSearch();
        }

        /// <summary>
        /// Search for the student's data from the customers table and display it in the textboxes.
        /// If the student doesn't have data give the opton to register the student.
        /// </summary>
        private void studentSearch()
        {
            //Clear input
            clearInput();

            //verify iput email
            String studentEmail = textBoxStudentEmail.Text;
            if (SQL.verifyEamil(studentEmail) == false)
            {
                MessageBox.Show("Search error: Please enter a valid email");
                return;
            }

            //Search for student data via procedure using the email
            SQL sQL = SQL.Instance;
            String[] details = sQL.getStudentDetails(studentEmail);

            //IF no student data was found allow the user to register the student
            if (details == null || details.Length < 2)
            {
                Console.WriteLine("No student data found");
                labelDisplay.Text = "No student found, you can register them below";
                labelDisplay.ForeColor = Color.Red;

                // Allow user to enter student details
                textBoxFistName.ReadOnly = false;
                textBoxLastName.ReadOnly = false;
                textBoxPhone.ReadOnly = false;
                buttonRegister.Enabled = true;
                buttonRegister.Visible = true;

                // Don't allow student to change mark
                textBoxClassID.ReadOnly = true;
                textBoxMark.ReadOnly = true;
                buttonMark.Enabled = false;
                buttonMark.Visible = false;
                return;
            }
            //ELSE remove the ability to register the student
            else
            {
                labelDisplay.Text = "Student found";
                labelDisplay.ForeColor = Color.Green;

                // Don't allow the user to enter student details
                textBoxFistName.ReadOnly = true;
                textBoxLastName.ReadOnly = true;
                textBoxPhone.ReadOnly = true;
                buttonRegister.Enabled = false;
                buttonRegister.Visible = false;

                // Allow the user to enter a mark
                textBoxClassID.ReadOnly = false;
                textBoxMark.ReadOnly = false;
                buttonMark.Enabled = true;
                buttonMark.Visible = true;
            }

            //Display the student data in the text boxes
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i] != null)
                {
                    if (i == 0)
                    {
                        textBoxFistName.Text = details[i];
                    }
                    else if (i == 1)
                    {
                        textBoxLastName.Text = details[i];
                    }
                    else if (i == 2)
                    {
                        textBoxPhone.Text = details[i];
                    }
                }
            }
        }

        /// <summary>
        /// Register the student using the details in the text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Get the data needed to register the student
            String email = textBoxStudentEmail.Text;
            String fname = textBoxFistName.Text;
            String lname = textBoxLastName.Text;
            String phone = textBoxPhone.Text;

            //validate input
            if(SQL.verifyEamil(email) == false || SQL.verifyName(fname) == false || 
                SQL.verifyName(lname) == false || SQL.verifyPhone(phone) == false)
            {
                MessageBox.Show("Invalid details have been entered");
                return;
            }

            // Use a stored procedure to register the student
            SQL sQL = SQL.Instance;
            int result = sQL.registerStudent(email, fname, lname, phone);

            // IF success then search for the student to confirm it worked
            if(result == 0)
            {
                studentSearch();
            }
            else
            {
                MessageBox.Show("Failed to register student");
            }

        }

        private void clearInput()
        {
            textBoxFistName.Clear();
            textBoxLastName.Clear();
            textBoxPhone.Clear();
            textBoxClassID.Clear();
            textBoxMark.Clear();
        }

        private void buttonMark_Click(object sender, EventArgs e)
        {
            String cEmail = textBoxStudentEmail.Text.Trim();
            decimal mark;
            int classID;
            try
            {
                mark = decimal.Parse(textBoxMark.Text.Trim());
                classID = int.Parse(textBoxClassID.Text.Trim());
            }
            catch(FormatException)
            {
                MessageBox.Show("Invalid Class ID or Mark");
                return;
            }

            if (SQL.verifyEamil(cEmail) == false || SQL.verifyMark(mark) == false || classID < 1)
            {
                MessageBox.Show("Invalid input");
                return;
            }

            // Use a stored procedure to register the student
            SQL sQL = SQL.Instance;
            int result = sQL.recordAttendance(cEmail, classID, mark);

            // IF success then
            if (result == 0)
            {
                MessageBox.Show("Assigned Mark to student");
                textBoxClassID.ReadOnly = true;
                textBoxMark.ReadOnly = true;
                buttonMark.Visible = false;
            }
            else
            {
                MessageBox.Show("Failed record attendance of student");
            }

        }
    }
}
