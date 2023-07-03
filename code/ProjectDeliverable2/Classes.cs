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
    public partial class Classes : Form
    {

        public Classes()
        {
            InitializeComponent();
            showClasses();
        }

        /// <summary>
        /// Return to the main form when returning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            //Return to the main form and close this form
            Hide();
            Main formMain = new Main();
            formMain.ShowDialog();
            Close();
        }

        /// <summary>
        /// Request the class data from the server with the applied filter and display it on the ListBoxDisplay
        /// </summary>
        private void showClasses()
        {
            listBoxDisplay.Items.Clear();

            SQL sqlInstance = SQL.Instance;
            int filterIndex = comboBoxFilter.SelectedIndex;

            //If the user hadn't selected a value set default to upcoming classes
            if(filterIndex == -1)
            {
                filterIndex = 0;
            }

            // A list to store multiple rows with each row being a String array of the seperate columns
            List<String[]> rowList = null;

            // Get the data from the classes table where the user selected the filter index
            rowList = sqlInstance.selectAll(filterIndex);
            if(rowList == null )
            {
                Console.Error.WriteLine("Classes.showClasses(): ERROR RowList returned null");
                return;
            }

            //listbox header
            listBoxDisplay.Items.Add("Class ID".PadRight(10) + "Course ID".PadRight(11) + "Course Name".PadRight(30) + "Start Time".PadRight(25) + "End Time".PadRight(25) + "Location".PadRight(11) + "Instructor Name");

            //Display the classes on the listBoxDisplay
            for(int j = 0; j < rowList.Count; j++)
            {
                String classRow = "";
                for (int i = 0; i < rowList[j].Length; i++)
                {
                    //determine how much padding we need
                    int padding = 25;
                    if(i == 0)
                    {
                        padding = 10;
                    }
                    else if(i == 1 || i == 5)
                    {
                        padding = 11;
                    }
                    else if(i == 2)
                    {
                        padding = 30;
                    }
                    else if(i == 6 || i == 7)
                    {
                        padding = 15;
                    }
                    classRow += (rowList[j][i]).PadRight(padding);
                }
                Console.WriteLine("Adding to listBoxDisplay: " + classRow);
                listBoxDisplay.Items.Add(classRow);
            }
        }

        /// <summary>
        /// If the user has changed the filter update the listBoxDisplay with the filtered classes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            showClasses();
        }
    }
}
