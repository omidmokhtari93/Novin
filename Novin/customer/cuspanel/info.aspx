<%@ Page Title="" Language="C#" MasterPageFile="~/customer/main.Master" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="Novin.customer.info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <style>
        .medal{ width: 90px;height: 90px;}
        .yourpoints{ display: block;padding: 5px;color: #f05640;text-shadow: 0px 0px 1px #f7b44c;}
        .point{ position: absolute;top: 52px;left: 41px;font-size: 20pt;color: #ea351d;width:60px;text-align:center;text-shadow: 0px 0px 5px #fe7058;}
        .counter{}
        .img-thumbnail{ width: 100%;max-height: 130px;}
    </style>
    <div class="row">
        <div class="col-lg-2" style="padding: 0;">
            <div class="img-thumbnail">
                <label class="yourpoints">امتیاز کسب شده</label>
                <img src="/images/medal.png" class="medal"/>
                <label class="point counter">10</label>
            </div>
        </div>
        <div class="col-lg-10">
            <div class="img-thumbnail">
                <label class="counter">1000</label>
            </div>
        </div>
    </div>
    
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="sidemenu" runat="server">
    <div id="MenuItems"></div>
    <script>
        $(function() {
            $("#MenuItems").load("../contents/cusmenu.html");
            UpCounter('counter');
        });
    </script> 
</asp:Content>
