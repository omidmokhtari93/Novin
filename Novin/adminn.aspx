﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admn/admaster.Master" AutoEventWireup="true" CodeBehind="adminn.aspx.cs" Inherits="Novin.adminn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headermenu" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="loginBody">
        <img src="images/login.png" class="loginImage"/>
        <label style="display: block;">ورود به حساب مدیریت</label>
        <br/>
        <input class="form-control text-right" id="UserName" required placeholder="نام کاربری"/>
        <br/>
        <input class="form-control text-right" type="password" required id="Password" placeholder="رمز عبور"/>    
        <br/>
        <button class="greenButton"type="button" style="width: 100%; position: relative;" onclick="login(this);" id="btnLogin">
            <img id="imgLoading" src="images/loading.gif"/>
            ورود
        </button>
    </div>
    <script src="Scripts/admin.js"></script>
</asp:Content>
