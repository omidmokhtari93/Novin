<%@ Page Title="" Language="C#" MasterPageFile="main.Master" AutoEventWireup="true" CodeBehind="customers.aspx.cs" Inherits="Novin.customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .customerLogin{margin-left: 250px;width: 100%;margin-bottom: 20px;}
        #pnlregister{ display: none;}
        #pnllogin{ width: 40%!important;margin: auto;}
        .cusloginforms{ display: block;width: 100%;padding-bottom: 50px;}
    </style>
    <div class="headermenu customerLogin" >
        <ul>
            <li id="login"><img src="/images/loginicon.png"/>ورود</li>
            <li id="register"><img src="/images/lock.png"/>عضویت</li>
        </ul>
    </div>
    <div class="cusloginforms">
        <div id="pnllogin">
            <div>
                <img src="/images/login.png" class="loginImage"/>
                <label style="display: block;">ورود به حساب کاربری</label>
                <br/>
                <input class="form-control text-right" id="UserName" required placeholder="نام کاربری"/>
                <br/>
                <input class="form-control text-right" type="password" required id="Password" placeholder="رمز عبور"/>    
                <br/>
                <button class="greenButton"type="button" style="width: 100%; position: relative;" onclick="login(this);" id="btnLogin">
                    <img id="imgLoading" src="/images/loading.gif"/>
                    ورود
                </button>
            </div>
        </div>
        <div id="pnlregister">
            456
        </div>
    </div>
    <script>
        var $login = $('#login');
        var $register = $('#register');
        $login.on('click', function() {
            $('#pnllogin').fadeIn();
            $('#pnlregister').hide();
        });
        $register.on('click', function () {
            $('#pnlregister').fadeIn();
            $('#pnllogin').hide();
        });
    </script>
</asp:Content>

