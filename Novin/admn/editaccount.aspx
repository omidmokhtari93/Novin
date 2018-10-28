<%@ Page Title="" Language="C#" MasterPageFile="~/admn/admaster.Master" AutoEventWireup="true" CodeBehind="editaccount.aspx.cs" Inherits="Novin.admn.editaccount" %>


<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <style>
        .editbody{width: 50%;margin: auto;text-align: right;}
    </style>
    <div class="editbody">
        <div class="row">
            <div class="col-lg-12">
                نام و نام خانوادگی
                <input type="text" class="form-control" dir="rtl" tabindex="1" required id="txtName" runat="server" ClientIDMode="Static"/>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                تکرار رمز عبور
                <input type="text" class="form-control text-center" tabindex="4" required id="txtRepPass" runat="server" ClientIDMode="Static"/>
            </div>
            <div class="col-lg-4">
                رمز عبور
                <input type="text" class="form-control text-center" tabindex="3" required id="txtPass" runat="server" ClientIDMode="Static"/>
            </div>
            <div class="col-lg-4">
                نام کاربری
                <input type="text" class="form-control text-center" tabindex="2" required id="txtUserName" runat="server" ClientIDMode="Static"/>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                تلفن
                <input type="text" class="form-control" tabindex="6" required id="txtTell" runat="server" ClientIDMode="Static"/>
            </div>
            <div class="col-lg-6">
                ایمیل
                <input type="text" class="form-control" tabindex="5" required id="txtEmail" runat="server" ClientIDMode="Static"/>
            </div>
        </div>
        <div style="padding: 15px; text-align: left;">
            <button runat="server" id="sabt" OnServerClick="sabt_OnServerClick">ثبت</button>
        </div>
    </div>
</asp:Content>
