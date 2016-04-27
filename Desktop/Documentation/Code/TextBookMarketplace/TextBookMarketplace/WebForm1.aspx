
<!DOCTYPE html>

<!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

<meta name="viewport" content="width=device-width, initial-scale=1" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
        <!--<div class="col-sm-12">TEST
            <div class="col-sm-12">TEST</div>
        </div>-->
        <!--<div class="col-sm-12; text-center">TEST    <div class="col-sm-12; text-center">TEST</div>-->
        <div class="col-sm-12; text-center">
            <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
        <div>
    
    </div>
        <!--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>-->

    <div class="col-sm-4">TEST</div>

    <div class="container">
  <h1>Blockquotes</h1>
  <p>
      The blockquote element is used to present content from another source:</p>
  <blockquote class="blockquote-reverse">
    <p>For 50 years, WWF has been protecting the future of nature. The world's leading conservation organization, WWF works in 100 countries and is supported by 1.2 million members in the United States and close to 5 million globally.</p>
    <footer>From WWF's website</footer>
  </blockquote>
</div>
    </form>
</body>
</html>
