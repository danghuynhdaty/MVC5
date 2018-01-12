var account = {
    init: function () {
        account.registerEvents();
    },
    registerEvents: function () {

        $('.btnChangeStatus').off('click').on('click', function (e) {
            e.preventDefault();
            //lấy ra id từ data-id dưới html
            var btn = $(this);
            var id = btn.data('id');
            
            $.ajax({
                type: "POST",
                url: "/Admin/Account/ChangeStatus",
                data: '{ id: '+id+' }',                
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                sucess: function (reponse)
                {
                    if (reponse) {
                        btn.text('Kích hoạt');
                    } else {
                        btn.text('Khóa');
                    }
                },
                failure: function (reponse) {
                    alert('failure');
                },
                error: function (reponse) {
                    alert('error');
                }
            });

        });



    }
};

account.init();

