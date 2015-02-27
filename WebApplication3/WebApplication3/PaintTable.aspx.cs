//-----------------------------------------------------------------------
// <copyright file="PaintTable.aspx.cs" company="Assignment1">
//     Paint Tables Project
// </copyright>
//-----------------------------------------------------------------------

namespace WebApplication3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Npgsql;

    /// <summary>
    /// main class for the paint table
    /// </summary>
    public partial class PaintTable : System.Web.UI.Page
    {
        /// <summary>
        /// on page load, a connection to the database is established and the data is read and a web table is created
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        public void Page_Load(object sender, EventArgs e)
        {
            // the database connection uses integrated security using windows credentials
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=Assignment1; Integrated Security=true;");

            // opening a connection can cause errors, so we will catch any exceptions using the try/catch/finally blocks
            try
            {
                conn.Open();

                // query the database and begin reading results
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.\"Paints\"", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // iterate through rows and create asp columns for the webpage
                while (dr.Read())
                {
                    // convert pulled results to strings
                    string column1 = string.Format("{0}\n", dr[0]);
                    string column2 = string.Format("{0}\n", dr[1]);

                    // create a row for each row pulled
                    TableRow newRow1 = new TableRow();
                    TableCell newCell1 = new TableCell();
                    TableCell newCell2 = new TableCell();

                    newRow1.Cells.Add(newCell1);
                    newRow1.Cells.Add(newCell2);

                    Label newLabel1 = new Label();
                    Label newLabel2 = new Label();

                    newLabel1.Text = column1;
                    newLabel2.Text = column2;

                    // add labels to each cell and add cells to the rows
                    newCell1.Controls.Add(newLabel1);
                    newCell2.Controls.Add(newLabel2);

                    newRow1.Cells.Add(newCell1);
                    newRow1.Cells.Add(newCell2);
                
                    tblPaints.Rows.Add(newRow1);
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// for QA testing, we add our results to a dictionary for comparisons
        /// </summary>
        /// <returns>the method will return a dictionary to the calling method</returns>
        public Dictionary<string, int> DataDict()
        {
            // create the dictionary accoring to values in the database
            Dictionary<string, int> results = new Dictionary<string, int>();

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=Assignment1; Integrated Security=true;");

            try
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.\"Paints\"", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // iterate through the columns and add results to the dictionary
                while (dr.Read())
                {
                    results.Add((string)dr[0], (int)dr[1]);
                }
            }
            finally
            {
                conn.Close();
            }

            return results;
        }
    }
}