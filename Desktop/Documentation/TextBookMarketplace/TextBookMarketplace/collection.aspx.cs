using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;

namespace TextBookMarketplace
{
    public partial class collection : System.Web.UI.Page
    {
        string connString = "Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;";
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432;User Id=postgres;Password=password;Database=BookStore;");
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        //String filePath = @"C:\Users\Wilson\Desktop\textbookImages\";
        String filePath = @"~\images\textbookImages\";
        String[] fileNArray;
        Boolean endOfPage = false;
        int numPhotos = 0;
        int offSetNum = 0;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                Session["offSetNum"] = "0";
                if (Int32.Parse(Session["offSetNum"].ToString()) <= 8)
                {
                    leftArrowTest.Enabled = false;
                }
                else
                {
                    leftArrowTest.Enabled = true;
                }
            } else
            {
                /*
                if (Int32.Parse(Session["offSetNum"].ToString()) <= 8)
                {
                    int val = Int32.Parse(Session["offSetNum"].ToString());
                    leftArrowTest.Enabled = false;
                } else
                {
                    leftArrowTest.Enabled = true;
                }
                */
            }

            /*
            if (Int32.Parse(Session["offSetNum"].ToString()) != 0)
            {
                leftArrowTest.Enabled = true;
            } else
            {
                leftArrowTest.Enabled = false;
            }
            */

            /*
            pageNumber.InnerText = "testing";
            pageNumber.Disabled = true;
            pageNumber. = "background-color:#ddd";
            */
            pageNumLabel.Text = "...";
            pageNumLabel.BackColor = System.Drawing.Color.LightGray;
            pageNumLabel.BorderColor = System.Drawing.Color.LightGray;

            //refreshDropDownList();
            refreshImageList();

        }

        protected void refreshImageList()
        {
            //used to re-load images based on either clicking left or right arrow
            //-9 for back arrow, +9 for forward arrow; if position < 9, make left arrow unclickable; if dt.Rows.Count 
            //if (given number from string (NOT TOTAL ROW NUMBER)) % 9 != 0), make right arrow unclickable

            String LocalPhotoId, LocalTitle, LocalFilename, LocalAuthor, LocalUser, LocalPrice, LocalDate, LocalCollege, LocalDescription;

            //String stmt = "SELECT photoid, title, filename FROM photo limit 9 offset " + offSetNum.ToString();
            String stmt = "SELECT photoid, title, filename, author, \"user\".username, price, \"dateSubmitted\", college, description FROM photo left join \"user\" ON \"user\".userid = photo.userid ORDER BY photoid DESC limit 9 offset " + Session["offSetNum"].ToString();

            int counter = 0;


            String[] photoIdArray = new string[9];
            String[] titleArray = new string[9];
            fileNArray = new String[9];
            String[] authorArray = new string[9];
            String[] userArray = new string[9];
            String[] priceArray = new string[9];
            String[] dateArray = new string[9];
            String[] collegeArray = new string[9];
            String[] descArray = new string[9];

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

                        if (dt.Rows.Count != 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (counter > 8)
                                {
                                    counter = 0;
                                    Array.Clear(photoIdArray, 0, photoIdArray.Length);
                                    Array.Clear(titleArray, 0, titleArray.Length);
                                    Array.Clear(fileNArray, 0, fileNArray.Length);
                                    Array.Clear(authorArray, 0, authorArray.Length);
                                    Array.Clear(userArray, 0, userArray.Length);
                                    Array.Clear(priceArray, 0, priceArray.Length);
                                    Array.Clear(dateArray, 0, dateArray.Length);
                                    Array.Clear(collegeArray, 0, collegeArray.Length);
                                    Array.Clear(descArray, 0, descArray.Length);
                                }
                                LocalPhotoId = "";
                                LocalTitle = "";
                                LocalFilename = "";
                                LocalAuthor = "";
                                LocalUser = "";
                                LocalPrice = "";
                                LocalDate = "";
                                LocalCollege = "";
                                LocalDescription = "";

                                foreach (DataColumn col in dt.Columns)
                                {
                                    switch (col.Caption)
                                    {
                                        case "photoid":
                                            LocalPhotoId = row[col].ToString();
                                            break;
                                        case "title":
                                            LocalTitle = row[col].ToString();
                                            break;
                                        case "filename":
                                            LocalFilename = row[col].ToString();
                                            break;
                                        case "author":
                                            LocalAuthor = "Author: " + row[col].ToString();
                                            break;
                                        case "username":
                                            LocalUser = "User: " + row[col].ToString();
                                            break;
                                        case "price":
                                            LocalPrice = row[col].ToString();
                                            if (LocalPrice.Contains(".")) {
                                                LocalPrice = "Price: $" + string.Format("{0:G29}", decimal.Parse(LocalPrice));
                                            }
                                            else
                                            {
                                                if (!String.IsNullOrEmpty(LocalPrice))
                                                {
                                                    LocalPrice = "Price: $" + LocalPrice;
                                                } else
                                                {
                                                    LocalPrice = "Price: $0";
                                                }
                                            }
                                            break;
                                        case "dateSubmitted":
                                            LocalDate = "Date Posted: " + row[col].ToString();
                                            break;
                                        case "college":
                                            LocalCollege = "University: " + row[col].ToString();
                                            break;
                                        case "description":
                                            LocalDescription = "Description: " + row[col].ToString();
                                            break;
                                        default: break;
                                    }
                                }

                                photoIdArray[counter] = LocalPhotoId;
                                titleArray[counter] = LocalTitle;
                                fileNArray[counter] = LocalFilename;
                                authorArray[counter] = LocalAuthor;
                                userArray[counter] = LocalUser;
                                priceArray[counter] = LocalPrice;
                                dateArray[counter] = LocalDate;
                                collegeArray[counter] = LocalCollege;
                                descArray[counter] = LocalDescription;

                                counter++;
                            }

                            imageDisplayTitle1.Text = titleArray[0];
                            imageDisplayTitle2.Text = titleArray[1];
                            imageDisplayTitle3.Text = titleArray[2];
                            imageDisplayTitle4.Text = titleArray[3];
                            imageDisplayTitle5.Text = titleArray[4];
                            imageDisplayTitle6.Text = titleArray[5];
                            imageDisplayTitle7.Text = titleArray[6];
                            imageDisplayTitle8.Text = titleArray[7];
                            imageDisplayTitle9.Text = titleArray[8];

                            imageDisplay1Price.Text = priceArray[0];
                            imageDisplay2Price.Text = priceArray[1];
                            imageDisplay3Price.Text = priceArray[2];
                            imageDisplay4Price.Text = priceArray[3];
                            imageDisplay5Price.Text = priceArray[4];
                            imageDisplay6Price.Text = priceArray[5];
                            imageDisplay7Price.Text = priceArray[6];
                            imageDisplay8Price.Text = priceArray[7];
                            imageDisplay9Price.Text = priceArray[8];

                            imageDisplay1Description.Text = descArray[0];
                            imageDisplay2Description.Text = descArray[1];
                            imageDisplay3Description.Text = descArray[2];
                            imageDisplay4Description.Text = descArray[3];
                            imageDisplay5Description.Text = descArray[4];
                            imageDisplay6Description.Text = descArray[5];
                            imageDisplay7Description.Text = descArray[6];
                            imageDisplay8Description.Text = descArray[7];
                            imageDisplay9Description.Text = descArray[8];

                            imageDisplay1Date.Text = dateArray[0];
                            imageDisplay2Date.Text = dateArray[1];
                            imageDisplay3Date.Text = dateArray[2];
                            imageDisplay4Date.Text = dateArray[3];
                            imageDisplay5Date.Text = dateArray[4];
                            imageDisplay6Date.Text = dateArray[5];
                            imageDisplay7Date.Text = dateArray[6];
                            imageDisplay8Date.Text = dateArray[7];
                            imageDisplay9Date.Text = dateArray[8];

                            imageDisplay1College.Text = collegeArray[0];
                            imageDisplay2College.Text = collegeArray[1];
                            imageDisplay3College.Text = collegeArray[2];
                            imageDisplay4College.Text = collegeArray[3];
                            imageDisplay5College.Text = collegeArray[4];
                            imageDisplay6College.Text = collegeArray[5];
                            imageDisplay7College.Text = collegeArray[6];
                            imageDisplay8College.Text = collegeArray[7];
                            imageDisplay9College.Text = collegeArray[8];

                            imageDisplay1User.Text = userArray[0];
                            imageDisplay2User.Text = userArray[1];
                            imageDisplay3User.Text = userArray[2];
                            imageDisplay4User.Text = userArray[3];
                            imageDisplay5User.Text = userArray[4];
                            imageDisplay6User.Text = userArray[5];
                            imageDisplay7User.Text = userArray[6];
                            imageDisplay8User.Text = userArray[7];
                            imageDisplay9User.Text = userArray[8];

                            imageDisplay1Author.Text = authorArray[0];
                            imageDisplay2Author.Text = authorArray[1];
                            imageDisplay3Author.Text = authorArray[2];
                            imageDisplay4Author.Text = authorArray[3];
                            imageDisplay5Author.Text = authorArray[4];
                            imageDisplay6Author.Text = authorArray[5];
                            imageDisplay7Author.Text = authorArray[6];
                            imageDisplay8Author.Text = authorArray[7];
                            imageDisplay9Author.Text = authorArray[8];

                            for (int k = 0; k < 9; k++)
                            {
                                displayImage(k);
                            }
                            /*
                                String image1 = filePath + fileNArray[0].ToString();
                                String image2 = filePath + fileNArray[1].ToString();
                                String image3 = filePath + fileNArray[2].ToString();
                                String image4 = filePath + fileNArray[3].ToString();
                                String image5 = filePath + fileNArray[4].ToString();
                                String image6 = filePath + fileNArray[5].ToString();
                                String image7 = filePath + fileNArray[6].ToString();
                                String image8 = filePath + fileNArray[7].ToString();
                                String image9 = filePath + fileNArray[8].ToString();

                                ImageDisplay1.ImageUrl = image1;
                                ImageDisplay2.ImageUrl = image2;
                                ImageDisplay3.ImageUrl = image3;
                                ImageDisplay4.ImageUrl = image4;
                                ImageDisplay5.ImageUrl = image5;
                                ImageDisplay6.ImageUrl = image6;
                                ImageDisplay7.ImageUrl = image7;
                                ImageDisplay8.ImageUrl = image8;
                                ImageDisplay9.ImageUrl = image9;
                                */
                        }
                        dt.Clear();
                        nsda.Dispose();
                    }
                    catch (NpgsqlException ex)
                    {

                    }
                }
                conn2.Close();
            }
            CloseConn();
            
        }

        public void displayImage(int pos)
        {
            try
            {
                String title;
                String desc;
                String image = filePath + fileNArray[pos].ToString();
                switch (pos)
                {
                    case 0:
                        ImageDisplay1.ImageUrl = image;
                        break;
                    case 1:
                        ImageDisplay2.ImageUrl = image;
                        break;
                    case 2:
                        ImageDisplay3.ImageUrl = image;
                        break;
                    case 3:
                        ImageDisplay4.ImageUrl = image;
                        break;
                    case 4:
                        ImageDisplay5.ImageUrl = image;
                        break;
                    case 5:
                        ImageDisplay6.ImageUrl = image;
                        break;
                    case 6:
                        ImageDisplay7.ImageUrl = image;
                        break;
                    case 7:
                        ImageDisplay8.ImageUrl = image;
                        break;
                    case 8:
                        ImageDisplay9.ImageUrl = image;
                        break;
                    default: break;
                }
                rightArrowTest.Enabled = true;
            }
            catch (Exception err)
            {
                endOfPage = true;
                rightArrowTest.Enabled = false;
                //rightArrowTest.Style = "background-color:#ddd";
                //rightArrowTest.BackColor = System.Drawing.Color.LightGray;

                //String image = @"C: \Users\Wilson\Desktop\placeHolderImage.png";
                switch (pos)
                {
                    case 0:
                        ImageDisplay1.ImageUrl = "";
                        break;
                    case 1:
                        ImageDisplay2.ImageUrl = "";
                        break;
                    case 2:
                        ImageDisplay3.ImageUrl = "";
                        break;
                    case 3:
                        ImageDisplay4.ImageUrl = "";
                        break;
                    case 4:
                        ImageDisplay5.ImageUrl = "";
                        break;
                    case 5:
                        ImageDisplay6.ImageUrl = "";
                        break;
                    case 6:
                        ImageDisplay7.ImageUrl = "";
                        break;
                    case 7:
                        ImageDisplay8.ImageUrl = "";
                        break;
                    case 8:
                        ImageDisplay9.ImageUrl = "";
                        break;
                    default: break;
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


        protected void imageDisplayTitle1_Click(object sender, EventArgs e)
        {

        }

        protected void imageDisplayTitle9_Click(object sender, EventArgs e)
        {

        }

        protected void imageDisplayTitle8_Click(object sender, EventArgs e)
        {

        }

        protected void imageDisplayTitle7_Click(object sender, EventArgs e)
        {

        }

        protected void imageDisplayTitle6_Click(object sender, EventArgs e)
        {

        }

        protected void imageDisplayTitle5_Click(object sender, EventArgs e)
        {

        }

        protected void imageDisplayTitle4_Click(object sender, EventArgs e)
        {

        }

        protected void imageDisplayTitle3_Click(object sender, EventArgs e)
        {

        }

        protected void imageDisplayTitle2_Click(object sender, EventArgs e)
        {

        }

        protected void leftArrowTest_Click(object sender, EventArgs e)
        {
            if (int.Parse(Session["offSetNum"].ToString()) > 0)
            {
                Session["offSetNum"] = (int.Parse(Session["offSetNum"].ToString()) - 9) + "";
                refreshImageList();
            } else
            {
                //set arrow to null
                //leftArrowTest.Enabled = false;
                if (Int32.Parse(Session["offSetNum"].ToString()) <= 8)
                {
                    int val = Int32.Parse(Session["offSetNum"].ToString());
                    leftArrowTest.Enabled = false;
                }
                else
                {
                    leftArrowTest.Enabled = true;
                }
            }
        }

        protected void rightArrowTest_Click(object sender, EventArgs e)
        {
            /*
            if (Int32.Parse(Session["offSetNum"].ToString()) <= numPhotos)
            {
            */
                Session["offSetNum"] = (int.Parse(Session["offSetNum"].ToString()) + 9) + "";
            if (Int32.Parse(Session["offSetNum"].ToString()) <= 8)
            {
                int val = Int32.Parse(Session["offSetNum"].ToString());
                leftArrowTest.Enabled = false;
            }
            else
            {
                leftArrowTest.Enabled = true;
            }
            //offSetNum = 9;
            //offSetNum = offSetNum + 9;
            refreshImageList();
            /*
            } else
            {

            }
            */
        }

        protected void signOffBtn_Click(object sender, EventArgs e)
        {
            Session["lUsername"] = null;
            Response.Redirect("~/Default.aspx");
        }

        protected void lastPageCheck()
        {
            string stmt = "SELECT count(photoid) FROM photo";

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
                        NpgsqlDataReader reader = comm2.ExecuteReader();
                        if (dt.Rows.Count != 0)
                        {
                            
                            while(reader.Read())
                            {
                                numPhotos = Int32.Parse(reader[0].ToString());
                            }
                            
                        }
                        else {
                            
                        }
                        //comm2.ExecuteNonQuery();
                    } catch (NpgsqlException ex)
                    {

                    }
                    comm2.Dispose();
                }
                conn2.Close();
            }
            CloseConn();
        }

        protected void schoolDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /*
        protected void refreshDropDownList()
        {
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
                    }
                    catch (Exception err)
                    {

                    }
                }
            }
        }
        */
    }
}