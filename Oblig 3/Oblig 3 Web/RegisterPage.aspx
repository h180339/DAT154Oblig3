<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Oblig_3_Web.RegisterPage" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="username_label_register" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="username_textbox_register" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="password_label_register" runat="server" Text="Password : "></asp:Label>
            <asp:TextBox ID="password_textbox_register" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="register_button" runat="server" Text="Register" OnClick="register_button_Click" />
        </div>
        <div>

            <asp:Label ID="error_label" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>



