<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TextBookMarketplace.LogIn" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In - Textbook Marketplace</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.css" rel="stylesheet" />
        <!-- Custom CSS -->
    <link href="css/heroic-features.css" rel="stylesheet" />
    <link href="css/Custom-Cs.css" rel="stylesheet" />
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
                        <a href="SignUp.aspx" runat="server" id="signUpBtnTab">Register</a>
                    </li>
                    <li>
                        <a href="#" class="active" id="logInBtn" runat="server">Log In</a>
                    </li>
                    <li>
                        <asp:Button ID="signOnBtnVerify" runat="server" CssClass="btn btn-default navbar-btn btn-info" Text="Sign Out" CausesValidation="false" Visible="false"></asp:Button>
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
                <h4>Login</h4>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Username"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="UserName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="A username is required :(" ControlToValidate="UserName"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Password"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="Password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" CssClass="text-danger" runat="server" ErrorMessage="A password is required :(" ControlToValidate="Password"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="rmbrLabel" runat="server" CssClass="control-label" Text="Remember me?"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="Button1" runat="server" Text="Log In" CssClass="btn btn-default" OnClick="btLogIn_Click" />
                        <asp:LinkButton ID="SignUpBtn" runat="server" CssClass="btn btn-default" PostBackUrl="~/SignUp.aspx" CausesValidation="false">Sign Up</asp:LinkButton>
                        <asp:Label ID="verifyLabel" runat="server" CssClass="text-info"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>
            <!-- Page Center -->

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

    <!-- About Fader -->
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
	    <!-- ./About Fader -->

    <!-- jQuery -->
    <script src="js/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>