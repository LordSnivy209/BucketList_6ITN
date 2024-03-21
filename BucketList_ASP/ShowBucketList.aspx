<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBucketList.aspx.cs" Inherits="BucketList_ASP.ShowBucketList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Latest compiled and minified CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Latest compiled JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

    <title>Personal list</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>
                <asp:Label ID="lblName" runat="server" Text="..."></asp:Label></h1>
            <asp:CheckBoxList ID="cbxPersonalList" runat="server" CssClass="form-control"></asp:CheckBoxList>
            <br />
            <asp:Button ID="btnUitgevoerd" runat="server" Text="Save changes" CssClass="btn btn-dark btn-block" OnClick="btnUitgevoerd_Click"/>
            <br />
            <br />
            <div class="d-grid">
                <asp:Button ID="btnToGeneralList" runat="server" Text="View all items" CssClass="btn btn-dark btn-block" OnClick="btnToGeneralList_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
