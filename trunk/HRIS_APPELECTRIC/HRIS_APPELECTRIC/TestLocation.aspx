<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestLocation.aspx.cs" Inherits="HRIS_APPELECTRIC.TestLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvLocation" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="IPAddress" HeaderText="IP Address" />
        <asp:BoundField DataField="CountryName" HeaderText="Country" />
        <asp:BoundField DataField="CityName" HeaderText="City" />
        <asp:BoundField DataField="RegionName" HeaderText="Region" />
        <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
        <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
        <asp:BoundField DataField="Longitude" HeaderText="Latitude" />
        <asp:BoundField DataField="Timezone" HeaderText="Timezone" />
    </Columns>
</asp:GridView>
        </div>
    </form>
</body>
</html>
