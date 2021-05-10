using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Layer;

namespace _218051864_LV_LANGA_LAb_Exercise_5
    /*LV Langa
     * 218051864
     * Student :)
     * 
     */
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsCSVOperations localCSVObject = new clsCSVOperations(); // created a local instance of the data layer class to access all of its methods
            
            fileDialogCSV.Title = "Please select a CSV file"; // making the window at the top prompt the user to select a CSV file
            fileDialogCSV.Filter = "CSV files (*.csv)|*.csv"; // making sure the user can only enter a CSV file for processing

            try// wrapped it in a try catch block to track any exceptions that get thrown
            {

            if (fileDialogCSV.ShowDialog() == DialogResult.OK) // if the user clicked okay
            {
                    dataGridView1.DataSource = localCSVObject.createCSVDataSource(fileDialogCSV.FileName); // setting the datasource for the gridview
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // throwing the exception message to the user
                
            }
        }s

        private void button2_Click(object sender, EventArgs e)
        {// code block used to exit the application
            MessageBox.Show("Goodbye and go live a transformed life :)");
            Application.Exit();
        }
    }
}
