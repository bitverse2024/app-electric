<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestMacAddress.aspx.cs" Inherits="HRIS_APPELECTRIC.TestMacAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
         var x = document.getElementById("demo");
         function getLocation() {
             if (navigator.geolocation) {
                 navigator.geolocation.getCurrentPosition(showPosition, showError);
             }
             else { x.innerHTML = "Geolocation is not supported by this browser."; }
        }

         function showPosition(position) {

             var latlondata = position.coords.latitude + "," + position.coords.longitude;
             var latlon = "Your Latitude Position is:=" + position.coords.latitude + "," + "Your Longitude Position is:=" + position.coords.longitude;
             //document.getElementById('hfid1').value = "1";
   
             var hfid3 = document.getElementById('txtlan').value = str(latlondata);
             //alert(hfid3);//here alert is working with right value and value is show in textbox
             document.getElementById("hfid2").value = "this value also not visible in code behind ";
             document.getElementById("hfid1").value = str(latlondata);
             
            //alert(latlon)
            var img_url = "http://maps.googleapis.com/maps/api/staticmap?center="+ latlondata + "&zoom=14&size=400x300&sensor=false";
            //document.getElementById("mapholder").innerHTML = "<img src='" + img_url + "' />";
        }
        function showError(error) {
            if (error.code == 1) {
                document.getElementById('hfid3').value = "1";
                //x.innerHTML = "User denied the request for Geolocation."
            }
            else if (err.code == 2) {
                //x.innerHTML = "Location information is unavailable."
                document.getElementById('hfid3').value = "2";
            }
            else if (err.code == 3) {
                //x.innerHTML = "The request to get user location timed out."
                document.getElementById('hfid3').value = "3";
            }
            else {
                document.getElementById('hfid3').value = "4";
                //x.innerHTML = "An unknown error occurred."
            }
        }
        function str(a) {
            return a;

        }
        function call() {
            getLocation();
            showPosition(position);
            showError(error);
        }
</script>
    <div style="margin-top:10px;">
        
        <asp:Label ID="Label1" runat="server" Text="Method1: "></asp:Label>
        <asp:Label ID="lblMachineName1" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Method2: "></asp:Label>
        <asp:Label ID="lblMachineName2" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Method3: "></asp:Label>
        <asp:Label ID="lblMachineName3" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Method4: "></asp:Label>
        <asp:Label ID="lblMachineName4" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Method5: "></asp:Label>
        <asp:Label ID="lblMachineName5" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Method6: "></asp:Label>
        <asp:Label ID="lblMachineName6" runat="server"></asp:Label>
        <br />
        <asp:HiddenField ID="hfid1" runat="server" />
                                    <asp:HiddenField ID="hfid3" runat="server" />
        <asp:Label ID="lblLocation" runat="server"></asp:Label>
        <asp:Button ID="Button1" class="btn btn-block bg-gradient-primary btn-lg" runat="server" Text="Test Location"
                                        OnClick="btnTestLocation_Click" OnClientClick="call();"></asp:Button>

    </div>
</asp:Content>
