function showModalDlg(msg) {
    require(["dijit/Dialog", "dojo/domReady!"], function (Dialog) {
        myDialog = new Dialog({
            title: "Dojo dialog",
            content: msg,
            style: "width: 300px",
            class: "claro"
        });
        myDialog.show();
    });
}

var controlId = 'dlg';
jsro = new Thinfinity.JsRO();
console.log("jsRO start. " + controlId);
jsro.on(controlId, "showModalDlg", function (msg) {
    showModalDlg(msg);
});
