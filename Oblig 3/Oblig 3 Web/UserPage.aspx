<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Oblig_3_Web.UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin:5px">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">My reservations</asp:LinkButton>
        </div>
        <div style="margin:5px">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">New reservation</asp:LinkButton>
        </div>
    </form>
</body>
</html>
