using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TextBookMarketplace
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;");
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("TEST");
            this.OpenConn();

            string sql = "SELECT * FROM namelist";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            //ds.Reset();
            //da.Fill(ds);
            //dt = ds.Tables[0];

            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            //GridView1.DataSource = dt;

            //Label1.Text = "TEST";

            CloseConn();
        }

        public void OpenConn()
        {
            try
            {
                conn.Open();
            }
            catch (Exception exp)
            {
                Label1.Text = "Error";
            }
        }

        public void CloseConn()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
                Label1.Text = "Error";
            }
        }
    }
}