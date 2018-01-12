
function changeStatusSuccess(statusID) {
    //lấy ra id đang click
    var btn = $('#status_' + statusID);
    //lấy ra class của id
    var currentClass = btn.attr('class');
    //kiểm tra class
    if (currentClass === 'label label-success') {
        //thay đổi text
        btn.text('Khóa');
        //thay đổi class
        btn.attr('class', 'label label-danger');
    } else {
        btn.text('Kích hoạt');
        btn.attr('class', 'label label-success');
    }
}



