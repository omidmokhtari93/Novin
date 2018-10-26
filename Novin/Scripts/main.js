function redalert(ele, txt) {
    var element;
    if (typeof ele == "string") {element = $("#" + ele);} else {element = ele;}
    $(element).addClass('errorborder');
    setTimeout(function () { $(element).removeClass("errorborder"); }, 4000);
    $.notify(txt, { globalPosition: 'top left' });
}

function CheckRequiredFields() {
    var flag = false;
    var elements = $('input[required]');
    for (var i = 0; i < elements.length; i++) {
        if ($(elements[i]).val() === '') {
            $(elements[i]).addClass('errorborder');
            flag = true;
        }
    }
    setTimeout(function () { $(elements).removeClass("errorborder"); }, 4000);
    return flag;
}

function greenalert(ele, txt) {
    var element;
    if (typeof ele == "string") { element = $("#" + ele); } else { element = ele; }
    $(element).css('background-color', 'lightgreen');
    setTimeout(function () { $(element).removeAttr('style'); }, 4000);
    $.notify(txt, { className: 'success', clickToHide: false, autoHide: true, position: 'top left' });
}

function ElementRedalert(ele, pos, txt) {
    var element;
    if (typeof ele == "string") { element = $("#" + ele); } else { element = ele; }
    $(element).notify(txt, { position: pos, className: "error" });
}

function ElementGreenalert(ele, pos, txt) {
    var element;
    if (typeof ele == "string") { element = $("#" + ele); } else { element = ele; }
    $(element).notify(txt, { position: pos, className: "success" });
}

function ClearFields(div) {
    $('#' + div).find('input:text').val('');
    $('#' + div).find('textarea').val('');
    $('#' + div).find('input').val('');
    $('#' + div).find("select").prop('selectedIndex', 0);
}

function checkPastDate(ele) {
    var date = $('#' + ele).val();
    if (date === '') {return false;}
    var todayGregorain = new Date();
    var todayJalali = GtoJ(todayGregorain.getFullYear(), todayGregorain.getMonth() + 1, todayGregorain.getDate());
    var today = todayJalali[0] + '/' + todayJalali[1] + '/' + todayJalali[2];
    var todayArray = today.split('/');
    if (todayArray[1].length === 1) { todayArray[1] = '0' + todayArray[1]; }
    if (todayArray[2].length === 1) { todayArray[2] = '0' + todayArray[2]; }
    var selectedDayArr = date.split('/');
    if (selectedDayArr[1].length === 1) { selectedDayArr[1] = '0' + selectedDayArr[1]; }
    if (selectedDayArr[2].length === 1) { selectedDayArr[2] = '0' + selectedDayArr[2]; }
    today = todayArray[0] + '/' + todayArray[1] + '/' + todayArray[2];
    var selectedDate = selectedDayArr[0] + '/' + selectedDayArr[1] + '/' + selectedDayArr[2];
    if (selectedDate > today) {
        return true;
    } else {
        return false;
    }
}

function CheckPastTime(sDate, sTime, eDate, eTime) {
    var sDateArr = sDate.split('/');
    var eDateArr = eDate.split('/');
    var validStartTimeDate = new Date(JtoG(sDateArr[0], sDateArr[1], sDateArr[2], true) + ' ' + sTime);
    var validSEndTimeDate = new Date(JtoG(eDateArr[0], eDateArr[1], eDateArr[2], true) + ' ' + eTime);
    if (validStartTimeDate < validSEndTimeDate) { return true; } else { return false; }
}
/* jalali to gregorian  */
function JtoG(year, month, day, f) {
    function div(x, y) { return Math.floor(x / y); }
    $g_days_in_month = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
    $j_days_in_month = new Array(31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29);
    $jy = year - 979; $jm = month - 1; $jd = day - 1;
    $j_day_no = 365 * $jy + div($jy, 33) * 8 + div($jy % 33 + 3, 4);
    for ($i = 0; $i < $jm; ++$i)$j_day_no += $j_days_in_month[$i];
    $j_day_no += $jd; $g_day_no = $j_day_no + 79; $gy = 1600 + 400 * div($g_day_no, 146097);
    $g_day_no = $g_day_no % 146097; $leap = true; if ($g_day_no >= 36525) {
        $g_day_no--; $gy += 100 * div($g_day_no, 36524); $g_day_no = $g_day_no % 36524;
        if ($g_day_no >= 365) $g_day_no++; else $leap = false;
    } $gy += 4 * div($g_day_no, 1461); $g_day_no %= 1461; if ($g_day_no >= 366) {
        $leap = false;
        $g_day_no--; $gy += div($g_day_no, 365); $g_day_no = $g_day_no % 365;
    } for ($i = 0; $g_day_no >= $g_days_in_month[$i] + ($i == 1 && $leap); $i++)
        $g_day_no -= $g_days_in_month[$i] + ($i == 1 && $leap); $gm = $i + 1; $gd = $g_day_no + 1; if (!f || f == undefined) return { y: $gy, m: $gm, d: $gd }
    else return $gy + '/' + $gm + '/' + $gd;
}

//gregorian to jalali
function GtoJ(a, r, s) {
    a = parseInt(a), r = parseInt(r), s = parseInt(s);
    for (var n = a - 1600, e = r - 1, t = s - 1, p = 365 * n + parseInt((n + 3) / 4) - parseInt((n + 99) / 100) + parseInt((n + 399) / 400), I = 0; e > I; ++I) p += gorgian_days[I];
    e > 1 && (n % 4 == 0 && n % 100 != 0 || n % 400 == 0) && ++p, p += t; var v = p - 79, d = parseInt(v / 12053);
    v %= 12053; var o = 979 + 33 * d + 4 * parseInt(v / 1461); v %= 1461, v >= 366 && (o += parseInt((v - 1) / 365), v = (v - 1) % 365);
    for (var I = 0; 11 > I && v >= jalali_days[I]; ++I) v -= jalali_days[I]; var y = I + 1, _ = v + 1; return [o, y, _]
} var gorgian_days = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31], jalali_days = [31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29];

function AjaxCall(e) {
    $.ajax({
        type: "POST",
        url: 'WebService.asmx/' + e.url,
        data: JSON.stringify(e.param),
        contentType: "application/json;",
        dataType: "json",
        success: e.func,
        error: function () {
            redalert('n','خطا در ارسال اطلاعات');
        }
    });
}

function TableToJson(ele) {
    var element;
    if (typeof ele == "string") { element = $("#" + ele); } else { element = ele; }
    var myRows = {};
    $(element).find('tr').each(function (index) {
        var $cells = $(this).find("td");
        myRows[index] = {};
        $cells.each(function (cellIndex) {
            myRows[index][cellIndex] = $(this).html();
        });
    });
    return myRows;
}