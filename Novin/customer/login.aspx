<%@ Page Title="" Language="C#" MasterPageFile="main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Novin.customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <style>
        #pnlregister{ display: none;}
        #pnllogin{ width: 40%!important;margin: auto;}
        .cusloginforms{ display: block;width: 100%;}
        .forgetPassArea{width: 100%; text-align: right;padding: 10px 0;font-weight: 800;}
    </style>
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
                <div class="forgetPassArea">
                    <a href="recovery.aspx"><span class="fa fa-lock"></span> رمز عبورم را فراموش کرده ام</a>
                </div>
            </div>
        </div>
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
            var data = {
                url: 'CusAuthenticate',
                param: { username: usernamee, password: passwordd },
                func: auth
            };
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

