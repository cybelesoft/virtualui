// Shows JQuery UI dialog with msg as message
function showModalDlg(msg) {
    $('<div></div>').dialog({
        modal: true,
        title: "JQuery UI Dialog",
        open: function () {
            var markup = msg;
            $(this).html(markup);
        },
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    })
};
var controlId = 'dlg';
jsro = new Thinfinity.JsRO();
console.log("jsRO start. " + controlId);
jsro.on(controlId, "showModalDlg", function (msg) {
    showModalDlg(msg);
});



