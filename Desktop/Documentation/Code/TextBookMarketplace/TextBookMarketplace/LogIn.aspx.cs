using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace TextBookMarketplace
{
    public partial class LogIn : System.Web.UI.Page
    {
        string connString = "Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;";
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;");
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\Users\Wilson\Desktop\tempBook.png");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lUsername"] != null)
            {
                logInBtn.Visible = false;
                signUpBtnTab.Visible = false;
                
                addBookBtn.Visible = true;
                collectionBtn.Visible = true;
            }
            else
            {
                signUpBtnTab.Visible = true;
                logInBtn.Visible = true;
                
                addBookBtn.Visible = false;
                collectionBtn.Visible = false;
            }

            if (!IsPostBack)
            {
                if(Request.Cookies["UNAME"] != null && Request.Cookies["PWD"] != null)
                {
                    UserName.Text = Request.Cookies["UNAME"].Value;
                    Password.Attributes["value"] = Request.Cookies["PWD"].Value;
                    CheckBox1.Checked = true;
                }
            }
        }

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

        protected string generateHash(string pass)
        {
            // given, a password in a string
            //string pass = "1234abcd";
            string password = @pass;

            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               .ToLower();

            // encoded contains the hash you are wanting
            return encoded;
        }

        protected void btLogIn_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = conn.CreateCommand();

            string usr = @"""user""";
            string pwrd = @"""PASSWORD""";

            string stmt = "SELECT \"username\", \"PASSWORD\" FROM \"user\" WHERE \"username\" = @Username AND \"PASSWORD\" = @Password";

            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand comm2 = new NpgsqlCommand())
                {
                    comm2.Connection = conn2;
                    comm2.CommandType = CommandType.Text;
                    comm2.CommandText = stmt;

                    comm2.Parameters.AddWithValue("@Username", UserName.Text);
                    comm2.Parameters.AddWithValue("@Password", generateHash(Password.Text));
                    Session["lUsername"] = UserName.Text;
                    
                    try
                    {
                        conn2.Open();
                        NpgsqlDataAdapter nsda = new NpgsqlDataAdapter(comm2);
                        nsda.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            if (CheckBox1.Checked)
                            {
                                Response.Cookies["UNAME"].Value = UserName.Text;
                                Response.Cookies["PWD"].Value = Password.Text;

                                Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(15);
                            } else
                            {
                                Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);
                            }

                            verifyLabel.Text = "Successfully logged in as \"" + Session["lUsername"].ToString() + "\".";
                            //Response.Redirect("~/Default.aspx");
                            Response.Redirect("~/UserHome.aspx");

                        } else {
                            Session["lUsername"] = null;
                            lblError.Text = "Invalid username or password.";
                        }
                        //comm2.ExecuteNonQuery();
                    } catch (NpgsqlException ex)
                    {

                    }
                }
                conn2.Close();
            }
            CloseConn();
        }

        protected byte [] ImageToByteArray(System.Drawing.Image imgInput)
        {
            using (var ms = new MemoryStream())
            {
                imgInput.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

    }
}