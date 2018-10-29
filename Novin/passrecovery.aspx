<%@ Page Title="" Language="C#" MasterPageFile="~/admn/admaster.Master" AutoEventWireup="true" CodeBehind="passrecovery.aspx.cs" Inherits="Novin.passrecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headermenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <style>
        .forgetPassArea{width: 100%; text-align: right;padding: 10px 0;font-weight: 800;}
    </style>
    <div class="loginBody" id="messagearea">
        <img src="images/lock.png" class="loginImage"/>
        <label style="display: block;">بازیابی رمز عبور</label>
        <br/>
        <input class="form-control text-right" id="txtPhone" required placeholder="شماره همراه "/>
        <br/>
        <button class="greenButton"type="button" style="width: 100%; position: relative;" onclick="SendMessage(this);" id="btnLogin">
            <img id="imgLoading" src="images/loading.gif"/>
            ارسال رمز عبور
        </button>
        <div class="forgetPassArea">
            <a href="adminn.aspx">بازگشت</a>
        </div>
    </div>
    <script>
        function SendMessage(btn) {
            var txt = $('#txtPhone');
            if (CheckRequiredFields('messagearea')) {
                ElementRedalert(txt,'right center', 'لطفا شماره تلفن همرا خود را وارد کنید');
                return;
            }
            var e = {
                url: 'SendMessage',
                param: { phone: txt.val() },
                func: status
            };
            AjaxCall(e);
            function status(e) {
                var d = JSON.parse(e.d);
                if (d.flag === 0) {
                    ElementRedalert(txt, 'right center', d.message);
                } else {
                    ElementGreenalert(btn, 'bottom center', d.message);
                    txt.val('');
                }
            }
        }
    </script>
</asp:Content>
