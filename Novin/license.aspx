<%@ Page Title="" Language="C#" MasterPageFile="~/admn/admaster.Master" AutoEventWireup="true" CodeBehind="license.aspx.cs" Inherits="Novin.license" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headermenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div style="width: 50%; margin: auto;">
        <div style="display: block; text-align: center; text-align: center; font-family: tahoma;">
            License End Date : 
            <asp:Label runat="server" ID="lbl" style="display: inline-block; padding: 10px;"></asp:Label>
        </div>
        <div class="row" style="margin: 0;">
            <div class="col-lg-2">
                <asp:Button runat="server" ID="exit" OnClick="exit_OnClick" Text="خروج" style="width: 100%; height: 45px;"/>
            </div>
            <div class="col-lg-2">
                <asp:Button runat="server" Text="ثبت" OnClick="OnClick" style="width: 100%; height: 45px;" />        
            </div>
            <div class="col-lg-8">
                <input id="txt" class="form-control text-center" readonly autocomplete="off" type="text" style="cursor: pointer;" runat="server" ClientIDMode="Static"/> 
            </div>
        </div>  
    </div>
   
    <script>
        $(document).ready(function () {
            var customOptions = {
                placeholder: "روز / ماه / سال"
                , twodigit: true
                , closeAfterSelect: true
                , nextButtonIcon: "fa fa-arrow-circle-right"
                , previousButtonIcon: "fa fa-arrow-circle-left"
                , buttonsColor: "blue"
                , forceFarsiDigits: true
                , markToday: true
                , markHolidays: true
                , highlightSelectedDay: true
                , sync: true
                , gotoToday: true
            }
            kamaDatepicker('txt', customOptions);
        });
    </script>
</asp:Content>
