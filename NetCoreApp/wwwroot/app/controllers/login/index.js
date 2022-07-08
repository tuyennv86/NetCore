var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {          
       
        $('form').form({
            inline: true,
            on: 'submit',
            fields: {
                username: {
                    identifier: 'username',
                    rules: [
                        {
                            type: 'empty',
                            prompt: 'Hãy nhập tên đăng nhập'
                        },
                        {
                            type: 'length[4]',
                            prompt: 'Tên đăng nhập không được ngắn hơn 4 ký tự'
                        }
                    ]
                },
                password: {
                    identifier: 'password',
                    rules: [
                        {
                            type: 'empty',
                            prompt: 'Hãy nhập mật khẩu'
                        },
                        {
                            type: 'length[6]',
                            prompt: 'Mật khẩu không được ngắn hơn 6 ký tự'
                        }
                    ]
                }
            },
            onSuccess: function (e) {
                e.preventDefault();
                e.stopPropagation();               
                login();
            }
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