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
$(document).ready(function () {
    $('#registerForm').validate({
        rules: {
            UserName: {
                required: true,
            },
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true,
                minlength: 6,
            },
            ConfirmPassword: {
                required: true,
                equalTo: "#password"
            }
        },
        messages: {
            UserName: {
                required: "Nhập tên đăng nhập",
            },
            Email: {
                required: "Nhập email",
                email: "Không phải định dạng email"
            },
            Password: {
                required: "Nhập mật khẩu",
                minlength: "Mật khẩu ít nhất 6 ký tự"
            },
            ConfirmPassword: {
                required: "Xác nhận mật khẩu",
                equalTo: "Không trùng khớp với mật khẩu"
            }
        },
    });
});
