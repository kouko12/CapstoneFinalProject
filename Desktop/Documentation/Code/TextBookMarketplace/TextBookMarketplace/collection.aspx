<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="collection.aspx.cs" Inherits="TextBookMarketplace.collection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Collection - TextBook Marketplace</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/bootstrap.css" rel="stylesheet" />

        <!-- Custom CSS -->
    <link href="css/heroic-features.css" rel="stylesheet">

        <!-- Custom CSS -->
    <link href="css/3-col-portfolio.css" rel="stylesheet">
</head>
<body class="body-background">
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
                <!-- Homepage Link -->
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
                    <li>
                        <asp:Button ID="signOffBtn" runat="server" CssClass="btn btn-default navbar-btn btn-info" Text="Sign Out" OnClick="signOffBtn_Click"></asp:Button>
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
        <!-- Projects Row -->
        <!--
        <div class="row">
            <div class="col-md-12">
                    <div class="form-group">
                    <asp:Label ID="Label8" runat="server" CssClass="col-md-2 control-label" Text="Select a University:" Font-Bold="true"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="schoolDropDownList" runat="server" CssClass="myselect" AutoPostBack="true" OnSelectedIndexChanged="schoolDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
            <br />
            <br />
            </div>
            </div>
        </div>
        -->
        <div class="form-horizontal">
            <h4>Book Collection</h4>
            <hr />
        </div>
        <div class="row">
            
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay1" runat="server" CssClass="img-responsive" />
                </a>
                <h3>
                    <!--<a href="#" name="imageDisplay1Title" runat="server">Project Name Test</a>-->
                    <!--<asp:Label ID="imageDisplay1Title" runat="server" Text="Project Name Test"></asp:Label>-->
                    <asp:LinkButton ID="imageDisplayTitle1" runat="server" OnClick="imageDisplayTitle1_Click"></asp:LinkButton>
                    <asp:HiddenField ID="photoIDlink1" runat="server" Visible="false" />
                </h3>
                <asp:Label ID="imageDisplay1Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay1User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay1Price" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay1Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay1College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay1Description" runat="server" ></asp:Label>
                <!--<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>-->
            </div>
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay2" runat="server" CssClass="img-responsive" />
                </a>
                <h3>
                    <asp:LinkButton ID="imageDisplayTitle2" runat="server" OnClick="imageDisplayTitle2_Click"></asp:LinkButton>
                    <asp:HiddenField ID="photoIDlink2" runat="server" Visible="false" />
                </h3>
                <asp:Label ID="imageDisplay2Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay2User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay2Price" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay2Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay2College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay2Description" runat="server" ></asp:Label>
                <!--
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                -->
            </div>
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay3" runat="server" CssClass="img-responsive" />
                </a>
                <h3>
                    <asp:LinkButton ID="imageDisplayTitle3" runat="server" OnClick="imageDisplayTitle3_Click"></asp:LinkButton>
                    <asp:HiddenField ID="photoIDlink3" runat="server" Visible="false" />
                </h3>
                <asp:Label ID="imageDisplay3Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay3User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay3Price" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay3Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay3College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay3Description" runat="server" ></asp:Label>
                <!--
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                -->
            </div>
        </div>
        <!-- /.row -->

        <!-- Projects Row -->
        <div class="row">
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay4" runat="server" CssClass="img-responsive" />
                </a>
                <h3>
                    <asp:LinkButton ID="imageDisplayTitle4" runat="server" OnClick="imageDisplayTitle4_Click"></asp:LinkButton>
                    <asp:HiddenField ID="photoIDLink4" runat="server" Visible="false" />
                </h3>
                <asp:Label ID="imageDisplay4Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay4User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay4Price" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay4Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay4College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay4Description" runat="server" ></asp:Label>
                <!--
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                -->
            </div>
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay5" runat="server" CssClass="img-responsive" />
                </a>
                <h3>
                    <asp:LinkButton ID="imageDisplayTitle5" runat="server" OnClick="imageDisplayTitle5_Click"></asp:LinkButton>
                    <asp:HiddenField ID="photoIDLink5" runat="server" Visible="false" />
                </h3>
                <asp:Label ID="imageDisplay5Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay5User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay5Price" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay5Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay5College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay5Description" runat="server" ></asp:Label>
                <!--
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                -->
            </div>
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay6" runat="server" CssClass="img-responsive" />
                    <asp:HiddenField ID="photoIDLink6" runat="server" Visible="false" />
                </a>
                <h3>
                    <asp:LinkButton ID="imageDisplayTitle6" runat="server" OnClick="imageDisplayTitle6_Click"></asp:LinkButton>
                </h3>
                <asp:Label ID="imageDisplay6Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay6User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay6Price" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay6Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay6College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay6Description" runat="server" ></asp:Label>
                <!--
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                -->
            </div>
        </div>

        <!-- Projects Row -->
        <div class="row">
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay7" runat="server" CssClass="img-responsive" />
                    <asp:HiddenField ID="photoIDLink7" runat="server" Visible="false" />
                </a>
                <h3>
                    <asp:LinkButton ID="imageDisplayTitle7" runat="server" OnClick="imageDisplayTitle7_Click"></asp:LinkButton>
                </h3>
                <asp:Label ID="imageDisplay7Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay7User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay7Price" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay7Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay7College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay7Description" runat="server" ></asp:Label>
                <!--
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                -->
            </div>
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay8" runat="server" CssClass="img-responsive" />
                </a>
                <h3>
                    <asp:LinkButton ID="imageDisplayTitle8" runat="server" OnClick="imageDisplayTitle8_Click"></asp:LinkButton>
                    <asp:HiddenField ID="photoIDLink8" runat="server" Visible="false" />
                </h3>
                <asp:Label ID="imageDisplay8Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay8User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay8Price" runat="server"></asp:Label>
                <br />
                <asp:Label ID="imageDisplay8Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay8College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay8Description" runat="server"></asp:Label>
                <!--
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                -->
            </div>
            <div class="col-md-4 portfolio-item">
                <a href="#">
                    <!--<img class="img-responsive" src="http://placehold.it/700x400" alt="">-->
                    <asp:Image ID="ImageDisplay9" runat="server" CssClass="img-responsive" />
                </a>
                <h3>
                    <asp:LinkButton ID="imageDisplayTitle9" runat="server" OnClick="imageDisplayTitle9_Click"></asp:LinkButton>
                    <asp:HiddenField ID="photoIDLink9" runat="server" Visible="false" />
                </h3>
                <asp:Label ID="imageDisplay9Author" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay9User" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay9Price" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay9Date" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay9College" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="imageDisplay9Description" runat="server" ></asp:Label>
                <!--
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae.</p>
                -->
            </div>
        </div>
        <!-- /.row -->

        <hr>

        <!-- Pagination -->
        <div class="row text-center">
            <div class="col-lg-12">
                <ul class="pagination">
                    <li>
                        <!--<a href="#" name="leftArrow" id="leftArrowClk" runat="server">&laquo;</a>-->
                        <!--<asp:HyperLink href="#" runat="server" ID="leftArrow01" Text="&laquo;" />-->
                        <asp:LinkButton runat="server" ID="leftArrowTest" OnClick="leftArrowTest_Click" Text="&laquo;" />
                    </li>
                    <li class="active">
                        <asp:Label runat="server" ID="pageNumLabel" />
                        <!--<asp:HyperLink href="#" runat="server" ID="pageNum" />-->
                        <!--<a href="#" name="page1" id="pageNumber" runat="server"></a>-->
                        
                    </li>
                    <!--
                    <li>
                        <a href="#" name="page2" runat="server">2</a>
                    </li>
                    <li>
                        <a href="#" name="page3" runat="server">3</a>
                    </li>
                    <li>
                        <a href="#" name="page4" runat="server">4</a>
                    </li>
                    <li>
                        <a href="#" name="page5" runat="server">5</a>
                    </li>
                    -->
                    <li>
                        <!--<a href="#" name="rightArrow" id="rightArrowClk" runat="server">&raquo;</a>-->
                        <asp:LinkButton runat="server" ID="rightArrowTest" OnClick="rightArrowTest_Click" Text="&raquo;" />
                    </li>
                </ul>
            </div>
        </div>
        <!-- /.row -->
        
        <hr />

        <!-- Footer -->
        <footer>
            <div class="footer-pos">
                <p class="pull-right"><a href="Back to top"></a></p>
                <p>~2016 Wilson Ho &middot; <a href="Default.aspx">Home</a></p>
            </div>
        </footer>


        </div>
        <!-- /.container -->

        <!--
        <div class="container-fluid">
            <div class="col-sm-4">
        <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-danger" />
                </div>
                <div class="col-sm-4">
        <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btn btn-danger" />
                </div>
                <div class="col-sm-4">
        <asp:Button ID="Button3" runat="server" Text="Button" CssClass="btn btn-danger" />
                </div>
            </div>-->
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

