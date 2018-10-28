<%@ Page Title="" Language="C#" MasterPageFile="~/customer/main.Master" AutoEventWireup="true" CodeBehind="recovery.aspx.cs" Inherits="Novin.customer.recovery" %>


<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <style>
        #pnlregister{ display: none;}
        #pnlrecovery{ width: 40%!important;margin: auto;}
        .passrecovery{ display: block;width: 100%;}
        .forgetPassArea{width: 100%; text-align: right;padding: 10px 0;font-weight: 800;}
    </style>
    <div class="passrecovery">
        <div id="pnlrecovery">
            <div>
                <img src="/images/key.png" class="loginImage"/>
                <label style="display: block;">بازیابی رمز عبور</label>
                <br/>
                <input class="form-control text-right" id="txtNaCode" autocomplete="off" required placeholder="شماره ملی"/>
                <br/>
                <input class="form-control text-right" type="password" autocomplete="off" required id="txtPhone" placeholder="شماره تلفن همراه"/>    
                <br/>
                <button class="greenButton"type="button" style="width: 100%; position: relative;">
                    <img id="imgLoading" src="/images/loading.gif"/>
                    ارسال کلمه عبور
                </button>
            </div>
        </div>
    </div>
</asp:Content>

