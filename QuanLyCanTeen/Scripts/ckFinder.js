$(document).ready(function () {
    var a = CKEDITOR.replace("123");
    CKFinder.setupCKEditor(a, '@Url.Content("~/Plugins/ckfinder/');
    $("#btnSelectImage").click(function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#txtImage").val(fileUrl);
        };
        finder.popup();
    });
});
