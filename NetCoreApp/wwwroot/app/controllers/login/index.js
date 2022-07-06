var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        //$("#idFormLogin").submit(function (event) {
        //    login();
        //});
        $("form").submit(function (event) {
            event.preventDefault();
            //var form = $(this);
            //var actionUrl = form.attr('action');
            //$.ajax({
            //    type: "POST",
            //    url: actionUrl,
            //    data: form.serialize(),
            //    success: function (res) {
            //        if (res.success) {
            //            window.location.href = "/Admin/Home/Index"
            //        } else {
            //            until.notify('Đăng nhập không thành công ', 'error');
            //        }
            //    }, error: function (status) {
            //        until.notify(status.responseText, 'error');
            //    }
            //});

            login();
            
        });
    }

    var login = function () {
        $.ajax({
            type: 'POST',
            data: {
                UserName: $("#username").val(),
                Password: $("#password").val(),
                RememberMe: $('#remember').prop('checked')
            },
            dataType: 'json',
            url: '/admin/login/authen',
            success: function (res) {
                if (res.success) {
                    window.location.href = "/Admin/Home/Index"
                } else {
                    until.notify('Đăng nhập không thành công ', 'error');
                }
            }
        })
    }
}