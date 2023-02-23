$(document).ready(function () {
    $('#loginForm').validate(
        {
            rules: {
                UserName: {
                    required: true,
                },
                Password: {
                    required: true,
                    minlength: 6
                }
            },
            messages: {
                UserName: {
                    required: "Nhập tên đăng nhập"
                },
                Password: {
                    required: "Nhập mật khẩu",
                    minlength: "Mật khẩu ít nhất 6 ký tự"
                }
            },
        }
    );
});

