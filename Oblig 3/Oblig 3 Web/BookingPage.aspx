﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingPage.aspx.cs" Inherits="Oblig_3_Web.BookingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div style="display:inline-block">
            <asp:Label ID="Label1" runat="server" Text="Check in: "></asp:Label>
            <asp:Calendar ID="start_date_calendar" runat="server"></asp:Calendar>
        </div>
        <div style="display:inline-block; margin:20px" >
            <asp:Label ID="Label2" runat="server" Text="Check out : "></asp:Label>
            <asp:Calendar ID="end_date_calendar" runat="server"></asp:Calendar>

        </div>
        <p>Quality:
        <asp:DropDownList ID="qualityDropdown" runat="server">
                  <asp:ListItem Selected="True" Value="Low"> Low </asp:ListItem>
                  <asp:ListItem Value="Medium"> Medium </asp:ListItem>
                  <asp:ListItem Value="High"> High </asp:ListItem>
                  <asp:ListItem Value="Economy"> Economy </asp:ListItem>
                  <asp:ListItem Value="Suite"> Suite </asp:ListItem>
        </asp:DropDownList>
        Number of beds:
            <asp:DropDownList  ID="numberOfBedsDropdown" runat="server">
                  <asp:ListItem Selected="True" Value="1"> 1</asp:ListItem>
                  <asp:ListItem Value="2"> 2 </asp:ListItem>
                  <asp:ListItem Value="3"> 3 </asp:ListItem>
                  <asp:ListItem Value="4"> 4 </asp:ListItem>
                  <asp:ListItem Value="5"> 5 </asp:ListItem>
        </asp:DropDownList></p>
        <asp:Button ID="search_button" runat="server" Text="Search" OnClick="searchForRooms" />
        <div>
            <asp:Literal ID="searchError" runat="server"></asp:Literal>
            <asp:DataGrid runat="server" ID="myDataGrid" AutoGenerateColumns="false" OnItemCommand="myDataGrid_ItemCommand">
                <Columns>    
                    <asp:BoundColumn DataField="Id" Visible="false"/>
                    <asp:BoundColumn DataField="numberOfBeds" HeaderText="Number of beds"/>
                    <asp:BoundColumn DataField="roomSize" HeaderText="Room size"/>
                    <asp:BoundColumn DataField="quality" HeaderText="Room quality"/>
                    <asp:ButtonColumn ButtonType="LinkButton" Text="Book this room"/>
                </Columns>
            </asp:DataGrid>
        </div>
    </form>
</body>
</html>
