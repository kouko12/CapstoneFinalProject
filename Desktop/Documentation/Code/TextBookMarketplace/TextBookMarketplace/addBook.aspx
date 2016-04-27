<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addBook.aspx.cs" Inherits="TextBookMarketplace.addBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Textbook - TextBook Marketplace</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.css" rel="stylesheet" />
        <!-- Custom CSS -->
    <link href="css/heroic-features.css" rel="stylesheet" />
    <link href="css/Custom-Cs.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="dropdown.css" />
    
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
                        <a href = "#about" data-toggle="modal">About</a> <!-- Select College/Buy/Sell/Contact/About/Login/SignUp -->
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
                    <li>
                        <asp:Button ID="signOffBtn" runat="server" CssClass="btn btn-default navbar-btn btn-info" Text="Sign Out" OnClick="signOffBtn_Click" CausesValidation="false"></asp:Button>
                    </li>
                    <li>
                        <asp:Label ID="loggedInLabel" runat="server" CssClass="navbar-text"></asp:Label>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

        <!-- Page Content -->
        <div class="container">
            <!--
            <asp:Button runat="server" ID="btnPhotoPreview" Text="Preview" OnClick="btnPhotoPreview_Click" />
            <asp:Image ID="imgTestPreview" runat="server" />
            -->
                    
            <div class="form-horizontal">
                <h4>Upload textbook</h4>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label8" runat="server" CssClass="col-md-2 control-label" Text="Select a University First*" Font-Bold="true"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="schoolDropDownList" runat="server" CssClass="myselect" AutoPostBack="true">
                        </asp:DropDownList>
                        <!--<asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>-->
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Title*"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="bookTitle" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Author*"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="bookAuthor" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="ISBN"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="ISBN" CssClass="form-control" runat="server" MaxLength="13"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" CssClass="col-md-2 control-label" Text="Notes (i.e. Contact Info)"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="description" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" CssClass="col-md-2 control-label" Text="Selling Price*"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="price" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" CssClass="col-md-2 control-label" Text="Upload Textbook Photo*"></asp:Label>
                    <div class="col-md-3">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <!--<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />-->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" CssClass="text-danger" runat="server" ErrorMessage="A Title is required :(" ControlToValidate="bookTitle"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAuthor" CssClass="text-danger" runat="server" ErrorMessage="An Author is required :(" ControlToValidate="bookAuthor"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" CssClass="text-danger" runat="server" ErrorMessage="A price is required :(" ControlToValidate="price"></asp:RequiredFieldValidator>
                        <hr />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="SubmitBtn" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="SubmitBtn_Click" />
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

    <!-- About Fader -->
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
	    <!-- ./About Fader -->
		</div>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

</body>
</html>