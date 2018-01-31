var account = {
    init: function () {
        account.registerEvents();
    },
    registerEvents: function () {
        $('.btnchangestatus').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);

            var id = btn.data('id');
            
            bootbox.confirm({
                message: btn.text() === 'Khóa' ? 'Bạn muốn kích hoạt tài khoản này?' : 'Bạn muốn khóa tài khoản này?',
                size: 'small',
                title: 'Thông báo',
                callback: function (result) {
                    if (result) {
                        $.ajax({
                            type: "POST",
                            url: '/Admin/Account/ChangeStatus',
                            data: { id: id },
                            dataType: 'json',
                            success: function (respone) {
                                if (respone === true) {
                                    btn.attr('class', 'label label-success');
                                    btn.text('Kích hoạt');
                                } else {
                                    btn.attr('class', 'label label-danger');
                                    btn.text('Khóa');
                                }
                            },
                            failure: function (respone) {
                                alert('failure');
                            },
                            error: function (respone) {
                                alert('error');
                            }
                        });
                    }
                }
            });
        });
    }
};

account.init();


















