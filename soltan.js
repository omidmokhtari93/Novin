$(function () {
    var paymentSelect = false;
    $(document).on('click', function (e) {
        if (!$(e.target).closest(".page-content").length) {
            if ($("div").hasClass("icon")) {
                if ($('.go-next:contains("ادامه فرایند خرید")').length && !$('.b-name').length) {
                    citySelection();
                } else if ($('.go-next:contains("ثبت اطلاعات")').length) {
                    fillInputs(e);
                } else if ($('.go-next:contains("مرحله بعد")').length && $('img[title="Mellat"]').length) {
                    if (!paymentSelect) {
                        paymentSelect = true;
                        $('img[title="Mellat"]').click();
                        setTimeout(() => {
                            $('.go-next:contains("مرحله بعد")').click();
                        }, 100);
                    }
                }
            }
        }
    });

    function citySelection() {
        setTimeout(() => {
            $('.ui-select-option__basic')[29].click();
        }, 10);
        setTimeout(() => {
            $('.ui-select__options:eq(1)').find('li')[29].click();
        }, 50);
        setTimeout(() => {
            $('.ui-select__options:eq(2)').find('li')[0].click();
            setTimeout(() => {
                $('div.ui-checkbox__label-text:contains("خودروساز-گارانتی بدنه پایه")').click();
                $('div.ui-checkbox__label-text:contains("شرایط توافقنامه را می‌پذیرم.")').click();
                setTimeout(() => {
                    $('.go-next:contains("ادامه فرایند خرید")').click();
                }, 100);
            }, 100);
        }, 400);
    }

    function fillInputs(e) {
        if ($(e.target).is('.input') || $(e.target).is('.icon')) {
            return;
        }
        if ($('[name=first_name]').val() == '') {
            $('[name=first_name]').sendkeys('محمد');
        }
        setTimeout(() => {
            if ($('[name=last_name]').val() == '') {
                $('[name=last_name]').sendkeys('سلطاندوست');
            }
        }, 15);
        setTimeout(() => {
            if ($('[name=fathers_name]').val() == '') {
                $('[name=fathers_name]').sendkeys('اسماعیل');
            }
        }, 30);
        setTimeout(() => {
            if ($('[name=national_code]').val() == '') {
                $('[name=national_code]').sendkeys('0919634451');
            }
        }, 45);
        setTimeout(() => {
            if ($('[name=identity_code]').val() == '') {
                $('[name=identity_code]').sendkeys('60');
            }
        }, 60);
        setTimeout(() => {
            if ($('[name=identity_serial]').val() == '') {
                $('[name=identity_serial]').sendkeys('618374');
            }
        }, 75);
        setTimeout(() => {
            if ($('[name=birth_date_dd]').val() == '') {
                $('[name=birth_date_dd]').sendkeys('11');
            }
        }, 90);
        setTimeout(() => {
            if ($('[name=birth_date_mm]').val() == '') {
                $('[name=birth_date_mm]').sendkeys('10');
            }
        }, 105);
        setTimeout(() => {
            if ($('[name=birth_date_yy]').val() == '') {
                $('[name=birth_date_yy]').sendkeys('62');
            }
        }, 120);
        setTimeout(() => {
            if ($('[name=issuance_date_dd]').val() == '') {
                $('[name=issuance_date_dd]').sendkeys('11');
            }
        }, 135);
        setTimeout(() => {
            if ($('[name=issuance_date_mm]').val() == '') {
                $('[name=issuance_date_mm]').sendkeys('10');
            }
        }, 150);
        setTimeout(() => {
            if ($('[name=issuance_date_yy]').val() == '') {
                $('[name=issuance_date_yy]').sendkeys('62');
            }
        }, 165);
        setTimeout(() => {
            if ($('[name=issuance_place_province]').val() == null) {
                var issuance_place_province = document.querySelector("[name=issuance_place_province]");
                issuance_place_province.value = "31";
                issuance_place_province.dispatchEvent(new Event("change"));
            }
        }, 180);
        setTimeout(() => {
            if ($('[name=issuance_place_city]').val() == null) {
                var issuance_place_city = document.querySelector("[name=issuance_place_city]");
                issuance_place_city.value = "829170";
                issuance_place_city.dispatchEvent(new Event("change"));
            }
        }, 195);
        setTimeout(() => {
            if ($('[name=sex]').val() == null) {
                var sex = document.querySelector("[name=sex]");
                sex.value = "true";
                sex.dispatchEvent(new Event("change"));
            }
        }, 210);
        setTimeout(() => {
            if ($('[name=occupation]').val() == null) {
                var occupation = document.querySelector("[name=occupation]");
                occupation.value = "3";
                occupation.dispatchEvent(new Event("change"));
            }
        }, 225);
        setTimeout(() => {
            if ($('[name=ashnaei]').val() == null) {
                var ashnaei = document.querySelector("[name=ashnaei]");
                ashnaei.value = "7";
                ashnaei.dispatchEvent(new Event("change"));
            }
        }, 240);
        setTimeout(() => {
            if ($('[name=address_province]').val() == null) {
                var address_province = document.querySelector("[name=address_province]");
                address_province.value = "31";
                address_province.dispatchEvent(new Event("change"));
            }
        }, 255);
        setTimeout(() => {
            if ($('[name=address_city]').val() == null) {
                var address_city = document.querySelector("[name=address_city]");
                address_city.value = "829170";
                address_city.dispatchEvent(new Event("change"));
            }
        }, 270);
        setTimeout(() => {
            if ($('[name=street]').val() == '') {
                $('[name=street]').sendkeys('روستای روشناوند');
            }
        }, 285);
        setTimeout(() => {
            if ($('[name=bystreet]').val() == '') {
                $('[name=bystreet]').sendkeys('خیابان امام رضا');
            }
        }, 300);
        setTimeout(() => {
            if ($('[name=alley]').val() == '') {
                $('[name=alley]').sendkeys('کوچه 2');
            }
        }, 315);
        setTimeout(() => {
            if ($('[name=no]').val() == '') {
                $('[name=no]').sendkeys('2');
            }
        }, 330);
        setTimeout(() => {
            if ($('[name=postal_code]').val() == '') {
                $('[name=postal_code]').sendkeys('9691635358');
            }
        }, 345);
        setTimeout(() => {
            if ($('[name=mobile_number]').val() == '') {
                $('[name=mobile_number]').sendkeys('09120531463');
            }
        }, 360);
        setTimeout(() => {
            if ($('[name=phone_number]').val() == '') {
                $('[name=phone_number]').sendkeys('05157473522');
            }
        }, 375);
        setTimeout(() => {
            if ($('[name=email]').val() == '') {
                $('[name=email]').sendkeys('info@bornatek.ir');
            }
        }, 390);
        setTimeout(() => {
            if ($('[name=captcha]').val() == '') {
                $('[name=captcha]').sendkeys('4458');
            }
        }, 405);
        setTimeout(() => {
            $('.go-next:contains("ثبت اطلاعات")').click();
        }, 420);
    }
});
