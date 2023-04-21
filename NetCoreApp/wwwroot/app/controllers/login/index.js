var loginController = function () {
    this.initialize = function () {        
    
        $(function () {
            $.validator.setDefaults({
                submitHandler: function () {                   
                    login();
                }
            });
            $('#frmLogin').validate({
                rules: {
                    username: {
                        required: true,
                        minlength: 5
                    },
                    password: {
                        required: true,
                        minlength: 6
                    },                    
                },
                messages: {
                    username: {
                        required: "Hãy nhập tên đăng nhập",
                        minlength: "Tên đăng nhập không được nhỏ hơn 5 ký tự"
                    },
                    password: {
                        required: "Hãy nhập mật khẩu",
                        minlength: "Mật khẩu không được nhỏ hơn 6 ký tự"
                    },                    
                },
                errorElement: 'span',
                errorPlacement: function (error, element) {
                    error.addClass('invalid-feedback');
                    element.closest('.input-group').append(error);
                },
                highlight: function (element, errorClass, validClass) {
                    $(element).addClass('is-invalid');
                },
                unhighlight: function (element, errorClass, validClass) {
                    $(element).removeClass('is-invalid');
                }
            });
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
                    $('p.login-box-msg').html('Tên đăng nhập hoặc mật khẩu không đúng!');
                }
            }
        })
    }
}