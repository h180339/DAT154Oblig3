<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Oblig_3_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:50px">
        <asp:Label ID="sign_in_label" runat="server" Text="Sign in :"></asp:Label>
    </div>
    <div style="margin-top:10px">
        <asp:Label ID="username_label" runat="server" Text="Username : "></asp:Label>
        <asp:TextBox ID="username_textbox" runat="server"></asp:TextBox>
    </div>
    <div style="margin-top:20px">
        <asp:Label ID="password_label" runat="server" Text="Password : "></asp:Label>
        <asp:TextBox ID="password_textbox" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Log in" style="margin-left:10px"/>
    </div>
    <div style="margin-top:20px">
        <asp:Label ID="Label1" runat="server" Text="If you are not a user, please register : "></asp:Label>
        <asp:Button ID="register_button" runat="server" Text="Register" OnClick="Button1_Click" />
    </div>
    <p></p>
    <p></p>
</asp:Content>



