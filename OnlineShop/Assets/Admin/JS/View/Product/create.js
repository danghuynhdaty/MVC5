$(document).ready(function () {
    $('#btn-select-image').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $('#image-product').val(url);
        };
        finder.popup();
    })
})

//script cho ckeditor
var editor = CKEDITOR.replace('product-description', {
    customConfig: 'config.js',
});