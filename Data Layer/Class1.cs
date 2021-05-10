using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace Data_Layer
{
    public class Class1
    {
    }
    public class clsCSVOperations {

        public DataTable createCSVDataSource(string filepath) {
            DataTable dtCSV = new DataTable();
            StreamReader csvStream = new StreamReader(filepath); // using a stream reader to read the CSV line by line
            List<string> dataSourceColumns = new List<string>(); // Tracking the columns into a list
            List<string[]> dataSourceRows = new List<string[]>(); // tracking the rows into a list
            
            string templine = csvStream.ReadLine(); // used to read the first line of the CSV because that is almost always the line with the columns

            
            var tempCols = templine.Split(',');// splitting by the ','
            
            
            foreach (var item in tempCols) // loop used to create each column
            {
                dtCSV.Columns.Add(item);
            }
            

            while (!csvStream.EndOfStream)
            {
                string line = csvStream.ReadLine(); // reading line by line 

                dataSourceRows.Add(Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")); // splitting using regex incase the CSV has column values that include a , and break the damn CSV

            }
            foreach (var item in dataSourceRows) // loop used to add rows to the data table
            {
                dtCSV.Rows.Add(item);
            }
            return dtCSV; // returning the datatable 

        }

    }
}
