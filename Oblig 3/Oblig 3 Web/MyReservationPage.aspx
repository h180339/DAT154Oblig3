<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyReservationPage.aspx.cs" Inherits="Oblig_3_Web.MyReservationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataGrid runat="server" ID="myDataGrid" AutoGenerateColumns="false">
                <Columns>    
                    <asp:BoundColumn DataField="startDate" HeaderText="Check in :" DataFormatString="{0:MMMM d, yyyy}"/>
                    <asp:BoundColumn DataField="endDate" HeaderText="Check out :" DataFormatString="{0:MMMM d, yyyy}"/>
                    <asp:BoundColumn DataField="HotelRoomId" HeaderText="Room number"/>
                </Columns>
            </asp:DataGrid>
        </div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">back</asp:LinkButton>
    </form>
</body>
</html>
