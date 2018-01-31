var content = {
    init: function() {
        content.registerEvents();
    },
    registerEvents: function () {
        $('.btnchangestatus').off('click').on('click', function (e){
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            bootbox.confirm({
                title: 'Thông báo',
                size: 'small',
                message: btn.text() == 'Khóa' ? 'Bạn muốn kích hoạt bài viết này?' : 'Bạn muốn khóa bài viết này?',
                callback: function (result) {
                    if (result) {
                        $.ajax({
                            type: "POST",
                            url: '/Admin/Content/ChangeStatus',
                            data: { id: id },
                            dataType: 'json',
                            success: function (respone) {
                                if (respone == true) {
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
                            },

                        });
                    }
                }
            });
            
        });
    }
};

content.init();