<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BucketList_ASP._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Latest compiled and minified CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Latest compiled JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>BucketList</title>
</head>
<body class="container">
    <form id="form1" runat="server">
        <h1>Login</h1>
        <div class="row">
            <div class="col-sm-3"></div>

            <div class="bg-dark text-light container-fluid col-sm-6">
                <br />
                <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
                <br />
                <asp:TextBox ID="txtName" runat="server" placeholder="Username" required CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                <br />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" required CssClass="form-control"></asp:TextBox>
                <br />
                <br />
                <div class="d-grid">
                    <asp:Button ID="btnLogin" CssClass="btn btn-info btn-block text-light" runat="server" Text="Log in" OnClick="btnLogin_Click" />
                </div>
                <br />
            </div>
            <div class="col-sm-3"></div>
        </div>
    </form>
</body>
</html>
