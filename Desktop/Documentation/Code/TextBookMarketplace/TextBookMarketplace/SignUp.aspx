﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TextBookMarketplace.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up - Textbook Marketplace</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.css" rel="stylesheet" />
        <!-- Custom CSS -->
    <link href="css/heroic-features.css" rel="stylesheet" />
    <link href="css/Custom-Cs.css" rel="stylesheet" />

    <!--<link href="Content/addAsterisk.css" rel="stylesheet" type="text/css" />-->
</head>
<body>
    <form id="form1" runat="server">
            <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="Default.aspx">TB Marketplace</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li>
                        <a href = "#about" data-toggle="modal">About</a>
                    </li>
                    <li>
                        <a href = "#contact" data-toggle="modal">Contact</a>
                    </li>
                    <li>
                        <a href="addBook.aspx" id="addBookBtn" runat="server">Add Books</a>
                    </li>
                    <li>
                        <a href="collection.aspx" id="collectionBtn" runat="server">Collection</a>
                    </li>
                    <li>
                        <a href="SignUp.aspx" runat="server" id="signUpbtn">Register</a>
                    </li>
                    <li>
                        <a href="LogIn.aspx" runat="server" id="signInBtn">Log In</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

        <!-- Page Content -->
        <div class="container">
            <div class="form-horizontal">
                <h4>Sign Up</h4>
                <hr />
            </div>
            <!-- Page Center -->
            <div class="center-page">
            <!-- Sign Up -->
            <label class="col-xs-11">Username*</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="A username is required :(" ControlToValidate="tbUsername"></asp:RequiredFieldValidator>
            </div>
            <label class="col-xs-11">Password*</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" CssClass="text-danger" runat="server" ErrorMessage="A password is required :(" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
            </div>
            <label class="col-xs-11">Email*</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" CssClass="text-danger" runat="server" ErrorMessage="An email is required :(" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
            </div>
            <label class="col-xs-11">Name</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
            </div>
            <label class="col-xs-11">School*</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbSchool" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSchool" CssClass="text-danger" runat="server" ErrorMessage="A username is required :(" ControlToValidate="tbSchool"></asp:RequiredFieldValidator>
            </div>
            
            <div class="col-xs-11 space-vert">
                <asp:Button ID="btSignUp" runat="server" CssClass="btn btn-success" Text="Sign up" OnClick="btSignUp_Click" />
            </div>
                <div class="col-xs-11">
                <asp:Label ID="verifyLabel" runat="server" CssClass="text-warning" Visible="false"></asp:Label>
            </div>
        <!-- /.Page Center -->
        </div>

        <!-- Footer -->
        <footer>
            <div class="footer-pos">
                <p class="pull-right"><a href="Back to top"></a></p>
                <p>~2016 Wilson Ho &middot; <a href="Default.aspx">Home</a></p>
            </div>
        </footer>

        <!-- /.container -->
        </div>
    </form>

    <!-- Contact Fader -->
		<div class = "modal fade" id = "contact" role = "dialog">
			
			<div class = "modal-dialog">
				
				<div class = "modal-content">
					
					<div class = "modal-header">
						<h4>Contact Me</h4>
						
					</div>
					<div class = "modal-body">
						<p>e-mail: wilson.ho.12@cnu.edu</p>
					</div>
					
					<div class = "modal-footer">
						<a class = "btn btn-primary" data-dismiss = "modal">Close</a>
					</div>
				</div>
				
			</div>
	    <!-- ./Contact Fader -->
		</div>

    <!-- Contact Fader -->
		<div class = "modal fade" id = "about" role = "dialog">
			
			<div class = "modal-dialog">
				
				<div class = "modal-content">
					
					<div class = "modal-header">
						<h4>About</h4>
						
					</div>
					<div class = "modal-body">
						<p>This project aims to aid students to find or sell textbooks based on their campus selection through an online web application.  The application provides benefits such as providing sellers (students) the ability to avoid fees from other websites (i.e. Amazon, eBay) as transactions are taken place through campus grounds; based on the seller and buyer’s university.  This approach on a textbook marketplace also provides benefits such as inspection before purchase, arranged transactions based on the given buyer and seller’s email/phone number (reducing arrival time, as as transactions could take place within the same day), as well as reducing fraudulent purchases as they are taken place on or near their campus.  Overall, this web application aims to fix the current issues of major fees, late arrivals of textbooks, as well as reducing the number of scammers based on a user’s selected university.
</p>
					</div>
					
					<div class = "modal-footer">
						<a class = "btn btn-primary" data-dismiss = "modal">Close</a>
					</div>
				</div>
				
			</div>
	    <!-- ./Contact Fader -->
		</div>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>