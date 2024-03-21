<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralList.aspx.cs" Inherits="BucketList_ASP.GeneralList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>General List</title>
    <!-- Latest compiled and minified CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Latest compiled JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="mb-3">
            <asp:ListBox ID="lbxGeneralList" runat="server" CssClass="form-control"></asp:ListBox>
             <br />
             <asp:Button ID="btnSendToPersonal" runat="server" Text="Add to Personal" OnClick="btnSendToPersonal_Click" CssClass="btn btn-success"/>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblAddItems" runat="server" Text="Wish to add items yourself? Click here:" AssociatedControlID="btnShowMenu"></asp:Label>
            <asp:Button ID="btnShowMenu" runat="server" Text="Add Items" OnClick="btnShowMenu_Click" CssClass="btn btn-primary"></asp:Button> <br />
            <asp:Button ID="btnReturn" runat="server" Text="Return to Personal List" CssClass="btn btn-info" OnClick="btnReturn_Click"></asp:Button> 
        </div>
        <div id="menu" runat="server" style="display: none;">
            <div class="mb-3">
                <asp:TextBox ID="txtNewItem" runat="server" CssClass="form-control" placeholder="Enter item name"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtItemDescription" runat="server" CssClass="form-control" placeholder="Enter item description"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" CssClass="btn btn-success"></asp:Button>
            </div>
            <div>
                <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
