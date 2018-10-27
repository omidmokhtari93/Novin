<%@ Page Title="" Language="C#" MasterPageFile="~/admn/admaster.Master" AutoEventWireup="true" CodeBehind="excel.aspx.cs" Inherits="Novin.admn.excel" %>

<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <link href="contents/excel.css" rel="stylesheet" />
    <div class="xlsBody">
        <select name="format" onchange="setfmt()" style="display: none;">
            <%--<option value="csv"> CSV</option>
<option value="json"> JSON</option>
<option value="form"> FORMULAE</option>--%>
            <option value="html" selected> HTML</option>
        </select>
        <div style="width: 100%; text-align: center;">
            <div style="padding: 7px; border: 2px dashed #bbb; display: inline-block; margin-bottom: 5px; text-align: right;">
                فایل را انتخاب کنید... <input type="file" name="xlfile" id="xlf"/>
            </div>
        </div>
        <div id="drop">فایل را به داخل این کادر بکشید</div>

        <%--<textarea id="b64data">... or paste a base64-encoding here</textarea>
<input type="button" id="dotext" value="Click here to process the base64 text" onclick="b64it();"/><br />--%>
        <input type="checkbox" name="useworker" checked style="display: none;"/>
        <input type="checkbox" name="userabs" checked style="display: none;"/>
        <pre id="out" style="display: none;"></pre>
        <button type="button" onclick="RemoveRedundantColumn();" style="margin: 5px;">حذف ستون های اضافی</button>
        <button type="button" style="margin: 5px;" onclick="bimeinfo();">ثبت اطلاعات بیمه گذار</button>
        <button type="button" style="margin: 5px;" onclick="cusinfo();">ثبت اطلاعات کاربری مشتریان</button>
        <div style="width: 100%; text-align: center !important;" id="outTable">
            <div id="htmlout" style="display: inline-block;"></div>
        </div>
    </div>
    
    <script src="scripts/xlsxworker.js"></script>
    <script src="scripts/shim.js"></script>
    <script src="scripts/xlsx.full.min.js"></script>
    <script src="scripts/excelimport.js"></script>
    <script src="scripts/excel.js"></script>
</asp:Content>
