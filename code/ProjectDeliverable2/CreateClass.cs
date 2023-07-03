using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDeliverable2
{
    public partial class CreateClass : Form
    {
        public CreateClass()
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
        /// Create a new class with the input on the Class pannel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateClass_Click(object sender, EventArgs e)
        {

            String location = textBoxLocation.Text;
            String startTime = textBoxStartTime.Text;
            String endTime = textBoxEndTime.Text;
            String courseID = textBoxCourseID.Text.PadRight(5);

            if (SQL.verifyDateTime(startTime) == false || SQL.verifyDateTime(endTime) == false || 
                SQL.verifyAlphaNumberic(location) == false || SQL.verifyCourseID(courseID) == false)
            {
                MessageBox.Show("Invalid Input. Try:\nlocation: Room I\nStart/End Time: YYYY-MM-DD HH:MM:SS\nCousrID FA105");
                return;
            }

            SQL sqlInstance = SQL.Instance;
            int createdClassID = sqlInstance.createClass(location, startTime, endTime, courseID);
            if(createdClassID == 0)
            {
                // insert success
                Console.WriteLine("Successfully inserted class");
                MessageBox.Show("Successfully inserted class");
            }
            else
            {
                // failed insert
                MessageBox.Show("Failed to insert Class");
                MessageBox.Show("Failed to insert class");
            }
        }

        /// <summary>
        /// Assign an insrtuctor to a class using the input from the instructor pannel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAssignInstructor_Click(object sender, EventArgs e)
        {
            //Get an verify the ClassID and Email input
            String iEmail = textBoxiEmail.Text;
            int iClassID = 0;
            if(SQL.verifyEamil(iEmail) == false)
            {
                MessageBox.Show("ERROR the email is formatted incorrectly");
                return;
            }
            try
            {
                iClassID = int.Parse(textBoxiClassID.Text);
                if(iClassID < 1)
                {
                    MessageBox.Show("ERROR Class ID must be 1 or larger");
                    return;
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("ERROR Class ID is not a number");
                return;
            }

            //Insert a new Teaches row
            SQL sQL= SQL.Instance;
            int returnValue = sQL.insertTeaches(iEmail, iClassID);

            if(returnValue != 0)
            {
                MessageBox.Show("ERROR Cannot assign instructor. Make sure they are qualified and are not assigned to another class at that time");
                return;
            }
        }
    }
}
