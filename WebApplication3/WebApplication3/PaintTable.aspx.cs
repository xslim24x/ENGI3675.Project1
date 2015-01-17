using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class PaintTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=Assignment1; User Id=postgres; Password=3675;");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.\"Paints\"", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string column1 = String.Format("{0}\n", dr[0]);
                string column2 = String.Format("{0}\n", dr[1]);

                TableRow NewRow1 = new TableRow();
                TableCell NewCell1 = new TableCell();
                TableCell NewCell2 = new TableCell();

                NewRow1.Cells.Add(NewCell1);
                NewRow1.Cells.Add(NewCell2);

                Label newLable1 = new Label();
                Label newLable2 = new Label();

                newLable1.Text = column1;
                newLable2.Text = column2;

                NewCell1.Controls.Add(newLable1);
                NewCell2.Controls.Add(newLable2);

                NewRow1.Cells.Add(NewCell1);
                NewRow1.Cells.Add(NewCell2);
                
                tblPaints.Rows.Add(NewRow1);
            }

            conn.Close();
        }
    }
}