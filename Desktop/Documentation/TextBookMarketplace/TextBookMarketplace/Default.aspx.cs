using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data;

namespace TextBookMarketplace
{
    public partial class Default : System.Web.UI.Page
    {

        string connString = "Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;";
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;");
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\Users\Wilson\Desktop\tempBook.png");

        public void OpenConn()
        {
            try
            {
                conn.Open();
            }
            catch (Exception exp)
            {
                //Label1.Text = "Error";
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
                //Label1.Text = "Error";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lUsername"] != null)
            {
                loggedInLabel.Text = "Logged in as: \"" + Session["lUsername"].ToString() + "\".";
                signInBtn.Visible = false;
                signUpbtn.Visible = false;
                LinkButton1.Visible = false;

                signOffBtn.Visible = true;
                addBookBtn.Visible = true;
                collectionBtn.Visible = true;
            }
            else
            {
                signUpbtn.Visible = true;
                signInBtn.Visible = true;
                LinkButton1.Visible = true;

                signOffBtn.Visible = false;
                addBookBtn.Visible = false;
                collectionBtn.Visible = false;
                //Response.Redirect("~/Default.aspx");
            }
        }

        /*
        protected void imageSubmit_Click(object sender, EventArgs e)
        {
            //string stmt = "INSERT INTO \"image\" (id, name, \"image\", \"day\") VALUES (@id, @name, @image, @day)";
            string stmt = "INSERT INTO imageContainer (name, image, day) VALUES (@name, @image, @day)";
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand comm2 = new NpgsqlCommand())
                {
                    comm2.Connection = conn2;
                    comm2.CommandType = CommandType.Text;
                    comm2.CommandText = stmt;

                    comm2.Parameters.AddWithValue("@name", "TESTING");
                    comm2.Parameters.AddWithValue("@image", GetBytes("Test"));
                    comm2.Parameters.AddWithValue("@day", DateTime.Today);
                    

                    try
                    {
                        conn2.Open();
                        comm2.ExecuteNonQuery();
                    }
                    catch (NpgsqlException ex)
                    {

                    }
                }
                conn2.Close();
            }
            CloseConn();
        }
        */

        protected void signOffBtn_Click(object sender, EventArgs e)
        {
            Session["lUsername"] = null;
            Response.Redirect("~/Default.aspx");
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}