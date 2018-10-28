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