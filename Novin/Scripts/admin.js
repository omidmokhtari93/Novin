$(document).on('keypress', function(e) {
    if (e.which == 13) {
        login();
    }
});

function login() {
    var btn = $('.greenButton');
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
        url: 'Authentication',
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

function SendMessage(btn) {
    var txt = $('#txtPhone');
    var load = $('#imgLoading');
    load.show();
    if (CheckRequiredFields('messagearea')) {
        ElementRedalert(txt, 'right center', 'لطفا شماره تلفن همرا خود را وارد کنید');
        load.hide();
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
        load.hide();
    }
}