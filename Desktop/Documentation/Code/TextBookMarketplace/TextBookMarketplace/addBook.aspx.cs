using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Npgsql;
using System.Data;
using System.Text;

namespace TextBookMarketplace
{
    public partial class addBook : System.Web.UI.Page
    {
        string fileName;
        //string filePath = @"C:\Users\Wilson\Desktop\testFolder\";
        //string filePath = @"~\images\outputFolder\";
        string filePath = @"~\images\textbookImages\";
        //string testPath = @"C:\Users\Wilson\Desktop\textbookImages\tradBook2.jpg";
        string fullFile;

        string connString = "Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;";
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;");
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lUsername"] != null)
            {
                loggedInLabel.Text = "Logged in as: \"" + Session["lUsername"].ToString() + "\".";
                signInBtn.Visible = false;
                signUpbtn.Visible = false;

                signOffBtn.Visible = true;
                addBookBtn.Visible = true;
                collectionBtn.Visible = true;
            }
            else
            {
                signUpbtn.Visible = true;
                signInBtn.Visible = true;

                signOffBtn.Visible = false;
                addBookBtn.Visible = false;
                collectionBtn.Visible = false;
                Response.Redirect("~/Default.aspx");
            }

            //refreshDropDownList();

            //String temp = (filePath + "tradBook2.jpg");

            //ImageTest01.Src = (filePath + "tradBook2.jpg");
            if (!IsPostBack)
            {
                refreshDropDownList();

                //Image1.ImageUrl = (Server.MapPath("~/images/") + fileName);
                //Image1.ImageUrl = (filePath + "tradBook2.jpg");
                //Image1.Visible = true;

                //imgTest.ImageUrl = (filePath + "tradBook2.jpg");
                //imgTest.ImageUrl = (temp);
                //String tempor = (filePath);
                //imgTestPreview.ImageUrl = tempor;
            } else
            {
                /*
                String file = "";
                if (FileUpload1.HasFile)
                {
                    file = FileUpload1.FileName;
                }
                String isbn = ISBN.Text;
                String author = bookAuthor.Text;
                String title = bookTitle.Text;
                String desc = description.Text;
                String pri = price.Text;
                //String collg =
                */
            }
        }

        protected void signOffBtn_Click(object sender, EventArgs e)
        {
            Session["lUsername"] = null;
            Response.Redirect("~/Default.aspx");
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (Session["lUsername"] == null)
            {
                lblError.Text = "Not logged in.";
            }
            else
            {
                /*
                String t1;
                if (FileUpload1.HasFile)
                {
                    //TODO: check if filename already exists; if so, add a counter to it

                    //fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/images/") + fileName);
                    t1 = filePath + FileUpload1.FileName;
                    FileUpload1.SaveAs(t1);
                    Session["filePath"] = t1;
                    Session["filename"] = FileUpload1.FileName;
                    //FileUpload1.PostedFile.SaveAs(fullFile);

                    //Response.Redirect(Request.Url.AbsoluteUri);
                    //Session["filePath"] = fullFile;
                }
                */

                if (FileUpload1.HasFile)
                {
                    //Session["filename"] = FileUpload1.FileName;
                    Session["rFilename"] = RandomString(6) + Path.GetExtension(FileUpload1.FileName);
                }
                    NpgsqlCommand cmd = conn.CreateCommand();
                    //might need to change SignUp.aspx's string stmt to @college instead of @school
                    string stmt = "INSERT INTO \"photo\" (userid, filename,\"dateSubmitted\",isbn,author,title,description,price,college,username) VALUES (@userid,@filename,@datesubmitted,@isbn,@author,@title,@description,@price,@college,@username)";

                    using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
                    {
                        using (NpgsqlCommand comm2 = new NpgsqlCommand())
                        {
                            comm2.Connection = conn2;
                            comm2.CommandType = CommandType.Text;
                            comm2.CommandText = stmt;

                            var dateAndTime = DateTime.Now;
                            DateTime date = dateAndTime.Date;

                            decimal priceWOdollar = 0;
                            if (price.Text.Contains("$"))
                            {
                                priceWOdollar = decimal.Parse(price.Text.Replace("$", string.Empty));
                            } else
                            {
                                priceWOdollar = decimal.Parse(price.Text);
                            }


                        //schoolDropDownList.Attributes["OnChange"] = "ChangeLabelText();";
                        //String college = hiddenText.Value;

                        //comm2.Parameters.AddWithValue("@filename", Session["filename"].ToString());

                            getUserId();

                            comm2.Parameters.AddWithValue("@userid",Int32.Parse(Session["userid"].ToString()));
                            comm2.Parameters.AddWithValue("@filename", Session["rFilename"].ToString());
                            comm2.Parameters.AddWithValue("@datesubmitted", DateTime.Now);
                            comm2.Parameters.AddWithValue("@isbn", ISBN.Text);
                            comm2.Parameters.AddWithValue("@author", bookAuthor.Text);
                            comm2.Parameters.AddWithValue("@title", bookTitle.Text);
                            comm2.Parameters.AddWithValue("@description", description.Text);
                            comm2.Parameters.AddWithValue("@price", priceWOdollar);
                            comm2.Parameters.AddWithValue("@college", schoolDropDownList.SelectedItem.Text.ToString());
                            //comm2.Parameters.AddWithValue("@college", hiddenText.ToString());
                            comm2.Parameters.AddWithValue("@username", Session["lUsername"].ToString());


                            /*
                            comm2.Parameters.AddWithValue("@filename", "tradBook1.jpg");
                            comm2.Parameters.AddWithValue("@datesubmitted", DateTime.Now);
                            comm2.Parameters.AddWithValue("@isbn", "12345");
                            comm2.Parameters.AddWithValue("@author", "1");
                            comm2.Parameters.AddWithValue("@title", "1");
                            comm2.Parameters.AddWithValue("@description", "1");
                            comm2.Parameters.AddWithValue("@price", 1);
                            //schoolDropDownList.SelectedItem.Text.ToString()
                            comm2.Parameters.AddWithValue("@college", "1");
                            comm2.Parameters.AddWithValue("@username", "1");
                            */

                            try
                            {
                                conn2.Open();
                                comm2.ExecuteNonQuery();
                                String k = "test";
                                if (FileUpload1.HasFile)
                                {
                                    //String t1 = filePath + FileUpload1.FileName;
                                    String t1 = filePath + Session["rFilename"].ToString();
                                    FileUpload1.SaveAs(Server.MapPath(t1));
                                lblError.Text = "Successfully uploaded textbook!";
                                }
                            }
                            catch (NpgsqlException ex)
                            {
                                String bw = "testing";
                            }
                        }
                        conn2.Close();
                    }
                CloseConn();
            }
        }

        protected void getUserId()
        {
            String LocalUserId;

            String stmt = "SELECT userid, username FROM \"user\" WHERE username = @username";

            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand comm2 = new NpgsqlCommand())
                {
                    comm2.Connection = conn2;
                    comm2.CommandType = CommandType.Text;
                    comm2.CommandText = stmt;

                    comm2.Parameters.AddWithValue("@username", Session["lUsername"].ToString());
                    try
                    {
                        conn2.Open();
                        NpgsqlDataAdapter nsda = new NpgsqlDataAdapter(comm2);
                        nsda.Fill(dt);

                        if (dt.Rows.Count != 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                LocalUserId = "";

                                foreach (DataColumn col in dt.Columns)
                                {
                                    switch (col.Caption)
                                    {
                                        case "userid":
                                            LocalUserId = row[col].ToString();
                                            Session["userid"] = LocalUserId;
                                            break;
                                        default: break;
                                    }
                                }
                            }
                        }
                        dt.Clear();
                        nsda.Dispose();
                    }
                    catch (Exception err)
                    {

                    }
                }
                conn2.Close();
            }
            CloseConn();
        }
                    

        private string RandomString(int Size)
        {
            Random random = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < Size; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            /*
            if (FileUpload1.HasFile)
            {
                //TODO: check if filename already exists; if so, add a counter to it

                //fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/images/") + fileName);
                String t1 = filePath + FileUpload1.FileName;
                FileUpload1.SaveAs(t1);
                Session["filePath"] = t1;
                Session["filename"] = FileUpload1.FileName;
                //FileUpload1.PostedFile.SaveAs(fullFile);
                
                //Response.Redirect(Request.Url.AbsoluteUri);
                //Session["filePath"] = fullFile;
            }
            */
        }

        protected void btnPhotoPreview_Click(object sender, EventArgs e)
        {
            //String t2 = @"C:\Users\Wilson\Desktop\testFolder\tradBook9.jpg";
            //String t4 = @Session["filePath"].ToString();
            //imgTestPreview.ImageUrl = t4;
        }

        //useful, but needs to get userid from the LogIn in order to feed from "user".userid = "photo".userid
        /*
        protected Boolean checkDuplicateFileExists()
        {
            String stmt = "SELECT \"user\".username, filename FROM \"photo\" LEFT JOIN \"user\" ON \"user\".userid = \"photo\".photoid WHERE (\"user\".username = @username AND filename = @filename)";

            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand comm2 = new NpgsqlCommand())
                {
                    comm2.Connection = conn2;
                    comm2.CommandType = CommandType.Text;
                    comm2.CommandText = stmt;

                    comm2.Parameters.AddWithValue("@username", Session["lUsername"].ToString());
                    comm2.Parameters.AddWithValue("@filename", Session["filename"].ToString());
                    try
                    {
                        conn2.Open();
                        NpgsqlDataAdapter nsda = new NpgsqlDataAdapter(comm2);
                        nsda.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            return true;
                        } else
                        {
                            lblError.Text = "File already exists; perhaps you could rename it.";
                            return false;
                        }
                    }
                    catch (Exception err)
                    {
                        
                    }
                }
            }
            return false;
        }
        */

        protected void refreshDropDownList()
        {
            String Institution_ID, Institution_Name;

            String stmt = "select distinct * from \"Accreditation\" order by \"Institution_Name\"";

            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand comm2 = new NpgsqlCommand())
                {
                    comm2.Connection = conn2;
                    comm2.CommandType = CommandType.Text;
                    comm2.CommandText = stmt;

                    try
                    {
                        conn2.Open();
                        NpgsqlDataAdapter nsda = new NpgsqlDataAdapter(comm2);
                        nsda.Fill(dt);

                        //new populator
                        schoolDropDownList.DataSource = dt;
                        schoolDropDownList.DataTextField = "Institution_Name";
                        schoolDropDownList.DataValueField = "Institution_ID";
                        schoolDropDownList.DataBind();

                        /*
                        if (dt.Rows.Count != 0)
                        {
                            Institution_ID = "";
                            Institution_Name = "";
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn col in dt.Columns)
                                {
                                    switch (col.Caption)
                                    {
                                        case "Institution_ID":
                                            Institution_ID = row[col].ToString();
                                            break;
                                        case "Institution_Name":
                                            Institution_Name = row[col].ToString();
                                            break;
                                        default: break;
                                    }
                                }
                            }
                        }
                        */
                    } catch (Exception err)
                    {

                    }
                }
            }
            //schoolDropDownList.Items.Insert(0, new ListItem("<Select School>", "0"));
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

    }
}