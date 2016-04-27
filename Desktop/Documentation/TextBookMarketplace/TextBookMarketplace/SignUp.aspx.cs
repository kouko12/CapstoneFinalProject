using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace TextBookMarketplace
{
    public partial class SignUp : System.Web.UI.Page
    {
        string connString = "Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;";
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;");
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lUsername"] != null)
            {
                signInBtn.Visible = false;
                signUpbtn.Visible = false;
                
                addBookBtn.Visible = true;
                collectionBtn.Visible = true;
            }
            else
            {
                signUpbtn.Visible = true;
                signInBtn.Visible = true;
                
                addBookBtn.Visible = false;
                collectionBtn.Visible = false;
                //Response.Redirect("~/LogIn.aspx");
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

        protected void btSignUp_Click(object sender, EventArgs e)
        {
            

            if (checkDuplicateUser())
            {
                if (tbPassword.Text.Length < 6)
                {

                }
                
                NpgsqlCommand cmd = conn.CreateCommand();
                
                string usr = @"""user""";
                string pwrd = @"""PASSWORD""";
                string nme = @"""NAME""";

                string stmt = "INSERT INTO \"user\" (username,\"PASSWORD\",email,\"NAME\",school) VALUES (@Username, @Password, @Email, @Name, @School)";
                
                using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
                {
                    using (NpgsqlCommand comm2 = new NpgsqlCommand())
                    {
                        comm2.Connection = conn2;
                        comm2.CommandType = CommandType.Text;
                        comm2.CommandText = stmt;

                        comm2.Parameters.AddWithValue("@Username", tbUsername.Text);
                        comm2.Parameters.AddWithValue("@Password", generateHash(tbPassword.Text));
                        comm2.Parameters.AddWithValue("@Email", tbEmail.Text);
                        comm2.Parameters.AddWithValue("@Name", tbName.Text);
                        comm2.Parameters.AddWithValue("@School", tbSchool.Text);
                        
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

        protected Boolean checkDuplicateUser()
        {
            string usr = @"""user""";
            string stmt = "SELECT \"username\" FROM \"user\" WHERE \"username\" = @Username";

            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand comm2 = new NpgsqlCommand())
                {
                    comm2.Connection = conn2;
                    comm2.CommandType = CommandType.Text;
                    comm2.CommandText = stmt;

                    comm2.Parameters.AddWithValue("@Username", tbUsername.Text);
                    Session["lUsername"] = tbUsername.Text;

                    try
                    {
                        conn2.Open();
                        NpgsqlDataAdapter nsda = new NpgsqlDataAdapter(comm2);
                        nsda.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {

                            verifyLabel.Text = "Successfully signed up as \"" + Session["lUsername"].ToString() + "\".  You will be re-directed to the homepage in (5) seconds.";
                            verifyLabel.Visible = true;
                            //Response.Redirect("~/UserHome.aspx");
                            Response.AddHeader("REFRESH", "5;URL=Default.aspx");
                            return true;
                        }
                        else {
                            verifyLabel.Text = "Username is already in use";
                            verifyLabel.Visible = true;
                            return false;
                            //verifyLabel.Text = "Invalid username or password.";
                        }
                        //comm2.ExecuteNonQuery();
                    }
                    catch (NpgsqlException ex)
                    {

                    }
                }
                conn2.Close();
            }

            CloseConn();
            return false;
        }
    }
}