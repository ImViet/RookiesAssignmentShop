$(document).ready(function () {
    console.log($("#userName").val())
    $('#registerForm').validate({
        rules: {
            UserName: {
                required: true,
                //remote: {
                //    url: "https://localhost:7150/Auth/CheckUserIsNotAvailable",
                //    type: "post",
                //    datatype: "json",
                //    // data: {
                //    //     function() {
                //    //         return $("#userName").val();
                //    //     }
                //    // },
                //},
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
                remote: "Tên đăng nhập đã được sử dụng"
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
