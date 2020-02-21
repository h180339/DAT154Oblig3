<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingPage.aspx.cs" Inherits="Oblig_3_Web.BookingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div style="display:inline-block">
            <asp:Label ID="Label1" runat="server" Text="Check in: "></asp:Label>
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
        <div style="display:inline-block; margin:20px" >
            <asp:Label ID="Label2" runat="server" Text="Check out : "></asp:Label>
            <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>

        </div>
        <asp:Button ID="Button1" runat="server" Text="Search" />
        <div>
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
