function RemoveRedundantColumn() {
    if ($('#xlf').val() == '') {
        redalert('n', 'لطفا فایل اکسل را انتخاب نمایید');
        return;
    }
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

function bimeinfo() {
    if ($('#xlf').val() == '') {
        redalert('n', 'لطفا فایل اکسل را انتخاب نمایید');
        return;
    }
    var tabledata = [];
    var table = $('table')[0];
    var rows = $('table tr').length;
    for (var i = 0; i < rows; i++) {
        tabledata.push({
            IdCode: table.rows[i].cells[0].innerHTML,
            Status: table.rows[i].cells[1].innerHTML,
            Type: table.rows[i].cells[2].innerHTML,
            Person: table.rows[i].cells[3].innerHTML,
            Total: table.rows[i].cells[4].innerHTML,
            Date: table.rows[i].cells[5].innerHTML
        });
    }
    var e = {
        url: 'SaveBimeInfo',
        param: { data: tabledata },
        func: done
    }
    AjaxCall(e);
    function done() {
        table.remove();
        $('#xlf').val('');
        greenalert('n', 'با موفقیت ثبت شد');
    }
}

function cusinfo() {
    if ($('#xlf').val() == '') {
        redalert('n', 'لطفا فایل اکسل را انتخاب نمایید');
        return;
    }
    var tabledata = [];
    var table = $('table')[0];
    var rows = $('table tr').length;
    for (var i = 0; i < rows; i++) {
        tabledata.push({
            Person: table.rows[i].cells[0].innerHTML,
            PerType: table.rows[i].cells[1].innerHTML,
            OrType: table.rows[i].cells[2].innerHTML,
            EcCode: table.rows[i].cells[3].innerHTML,
            NaCode: table.rows[i].cells[4].innerHTML,
            OrCode: table.rows[i].cells[5].innerHTML,
            Province: table.rows[i].cells[6].innerHTML,
            City: table.rows[i].cells[7].innerHTML,
            Address: table.rows[i].cells[8].innerHTML
        });
    }
    var e = {
        url: 'SaveBimeInfo',
        param: { data: tabledata },
        func: done
    }
    AjaxCall(e);
    function done() {
        table.remove();
        $('#xlf').val('');
        greenalert('n', 'با موفقیت ثبت شد');
    }
}