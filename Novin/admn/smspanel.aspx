<%@ Page Title="" Language="C#" MasterPageFile="~/admn/admaster.Master" AutoEventWireup="true" CodeBehind="smspanel.aspx.cs" Inherits="Novin.admn.smspanel" %>


<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <style>
        .smsbody{width: 60%;margin: auto;text-align: right;}
         .smsbody input[type="text"]{ font-family: tahoma!important;font-size: 10pt;font-weight: 800;}
    </style>
    <div class="smsbody">
        <div class="row">
            <div class="col-lg-3">
                رمز عبور
                <input type="text" class="form-control text-center" tabindex="4" required id="txtpass" runat="server" ClientIDMode="Static"/>
            </div>
            <div class="col-lg-3">
                نام کاربری
                <input type="text" class="form-control text-center" tabindex="3" required id="txtusername" runat="server" ClientIDMode="Static"/>
            </div>
            <div class="col-lg-6">
                آدرس پنل
                <input type="text" class="form-control text-center" tabindex="2" required id="txtaddress" runat="server" ClientIDMode="Static"/>
            </div>
        </div>
        <div style="padding: 15px; text-align: left;">
            <button runat="server" id="sabt" OnServerClick="sabt_OnServerClick">ثبت</button>
        </div>
    </div>
</asp:Content>
