<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Novin.admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        
    </style>
    <div class="loginBody">
        <img src="images/login.png" class="loginImage"/>
        <label style="display: block;">ورود به حساب کاربری</label>
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
    <script>
        function login(btn) {
            var $btn = $('#imgLoading');
            $btn.show();
            if (CheckRequiredFields()) {
                ElementRedalert(btn, 'bottom center', 'لطفا فیلدهای خالی را تکمیل کنید');
                $btn.hide();
                return;
            }
            var usernamee = $('#UserName').val();
            var passwordd = $('#Password').val();
            var data = [];
            data.push({
                url: 'WebService.asmx/Authentication',
                param: [{ username: usernamee, password: passwordd }],
                func:auth
            });
            AjaxCall(data);
            function auth(e) {
                var d = JSON.parse(e.d);
                if (d.flag === 0) {
                    ElementRedalert(btn, 'bottom center', d.message);
                } else {
                    window.location.replace(d.message);
                }
                $btn.hide();
            }
        }
    </script>
</asp:Content>
