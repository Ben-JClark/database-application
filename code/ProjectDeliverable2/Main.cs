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
    public partial class Main : Form
    {


        public Main()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Bring up a new form to show the current classes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowClasses_Click(object sender, EventArgs e)
        {
            Hide();
            Classes formClasses = new Classes();
            formClasses.ShowDialog();
            Close();
        }

        /// <summary>
        /// Bring up a new form to create a class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateClass_Click(object sender, EventArgs e)
        {
            Hide();
            CreateClass formCreateClass = new CreateClass();
            formCreateClass.ShowDialog();
            Close();
        }

        private void buttonStudentSearch_Click(object sender, EventArgs e)
        {
            Hide();
            StudentSearch searchForm = new StudentSearch();
            searchForm.ShowDialog();
            Close();
        }
    }
}
