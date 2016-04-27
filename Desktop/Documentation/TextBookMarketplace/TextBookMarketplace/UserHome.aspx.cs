using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextBookMarketplace
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lUsername"] != null)
            {
                signInBtn.Visible = false;
                signUpbtn.Visible = false;

                signOffBtn.Visible = true;
                addBookBtn.Visible = true;
                collectionBtn.Visible = true;

                lblSuccess.Text = "Successfully logged in as " + Session["lUsername"].ToString() + ".\n You will be redirected in 5 seconds.";
            } else
            {
                signUpbtn.Visible = true;
                signInBtn.Visible = true;

                signOffBtn.Visible = false;
                addBookBtn.Visible = false;
                collectionBtn.Visible = false;

                Response.Redirect("Default.aspx");
            }
        }

        protected void signOffBtn_Click(object sender, EventArgs e)
        {
            Session["lUsername"] = null;
            Response.Redirect("~/LogIn.aspx");
        }
    }
}