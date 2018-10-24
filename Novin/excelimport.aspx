<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="excelimport.aspx.cs" Inherits="Novin.excelimport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css"/>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <script src="Scripts/kamadatepicker.js"></script>
    <link href="Content/kamadatepicker.css" rel="stylesheet" />
    <script src="Scripts/main.js"></script>
    <script src="Scripts/notify.min.js"></script>
    <title></title>
    <style>
        @font-face {
            font-family: 'yekan';
            src: url('fonts/BYekan.eot'),
                 url('fonts/BYekan.eot?#FooAnything') format('embedded-opentype');
            src: local('☺'), url('fonts/BYekan.woff') format('woff'),
                 url('fonts/BYekan.ttf') format('truetype'),
                 url('fonts/BYekan.svg') format('svg');
        }
        body{ padding: 10px 20px;}
        html * {
            direction: rtl;
            font-weight: 800;
            font-family: yekan;
        }
        body * {
            text-align: center;
        }
        table th {
            text-align: center !important;
            background-color: #0c0183;
            color: #fefefe;
            border: none !important;
        }

        table {
            font-family: yekan;
            text-align: center;
            font-size: 8pt;
            font-weight: 800;
            border: 1px solid rgb(198, 205, 213);
            border-collapse: collapse;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 0px;
            overflow: hidden;
            margin-bottom: 0 !important;
        }

        table tr th { padding: 2px 5px !important; }

        table td {
            padding: 2px 5px !important;
            vertical-align: middle !important;
            border: none !important;
            border-bottom: #c7ced6 1px solid !important;
            border-top: #c7ced6 1px solid !important;
            text-shadow: -1px 0px 1px rgba(149, 150, 150, 1);
        }

        table td a { margin-top: 5px; }

        table td span { margin-top: 5px; }

        table tr:nth-child(even) { background-color: #fefefe; }

        table tr:nth-child(odd) { background-color: #f7f6fe; }

        #drop {
            border: 2px dashed #bbb;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            padding: 25px;
            text-align: center;
            font-size: 20pt;
            color: #bbb;
        }

        #b64data { width: 100%; }

        a { text-decoration: none }
    </style>
</head>
<body>
<form id="form1" runat="server">
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
    <button type="button" onclick="GetData();" style="margin: 5px;">ثبت اطلاعات</button>
    <div style="width: 100%; text-align: center !important;" id="outTable">
        <div id="htmlout" style="display: inline-block;"></div>
    </div>
    <script src="Scripts/xlsxworker.js"></script>
    <script src="Scripts/shim.js"></script>
    <script src="Scripts/xlsx.full.min.js"></script>
    <script src="Scripts/excelimport.js"></script>
    <script>
        function GetData() {
            var checkboxes = $('#outTable').find('input:checkbox:not(:checked)');
            var indexx = [];
            for (var i = 0; i < checkboxes.length; i++) {
                indexx.push($(checkboxes[i]).parent().index());
                $(checkboxes[i]).parent().remove();
            }
            $(checkboxes).parent().remove();
            var tblRows = $('#outTable table tr').length;
            var table = $('table')[0];
            for (var k = 1; k < tblRows; k++) {
                for (var j = 0; j < indexx.length; j++) {
                    table.rows[k].cells[indexx[j]].remove();
                }
            }
            var cellsCount = $('#outTable table tr:eq(1) td').length;;
            var data = [];
            var dataa = [];
            for (var k = 1; k < tblRows; k++) {
                for (var j = 0; j < cellsCount; j++) {
                    data.push(table.rows[k].cells[j].innerHTML);
                }
                dataa.push(data);
                data = [];
            }
        }
    </script>
</form>
</body>
</html>
