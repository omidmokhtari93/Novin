<%@ Page Title="" Language="C#" MasterPageFile="~/admn/admaster.Master" AutoEventWireup="true" CodeBehind="passrecovery.aspx.cs" Inherits="Novin.passrecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headermenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <style>
        .forgetPassArea{width: 100%; text-align: right;padding: 10px 0;font-weight: 800;}
        #imgLoading{ left: 110px;}
    </style>
    <div class="loginBody" id="messagearea">
        <img src="images/lock.png" class="loginImage"/>
        <label style="display: block;">بازیابی رمز عبور</label>
        <br/>
        <label style="display: block; text-align: right; padding: 5px 0;">
            .لطفا شماره تلفن همراه خود را بدون صفر اول وارد نمایید
            <span class="fa fa-circle" style="color: orange;"></span>
        </label>
        <input class="form-control text-center" id="txtPhone" required placeholder="شماره همراه "/>
        <br/>
        <button class="greenButton"type="button" style="width: 100%; position: relative;" onclick="SendMessage(this);" id="btnLogin">
            <img id="imgLoading" src="images/loading.gif"/>
            ارسال رمز عبور
        </button>
        <div class="forgetPassArea" style="text-align: left;">
            <a href="adminn.aspx">بازگشت</a>
        </div>
    </div>
    <script src="Scripts/admin.js"></script>
</asp:Content>
