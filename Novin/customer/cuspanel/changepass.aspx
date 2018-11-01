<%@ Page Title="" Language="C#" MasterPageFile="~/customer/main.Master" AutoEventWireup="true" CodeBehind="changepass.aspx.cs" Inherits="Novin.customer.cuspanel.changepass" %>


<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="sidemenu" runat="server">
    <div id="MenuItems"></div>
    <script>
        $(function() {
            $("#MenuItems").load("../contents/cusmenu.html");
        });
    </script> 
</asp:Content>
