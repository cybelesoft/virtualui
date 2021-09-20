var jsro = null;
function startJsRO(controlId) {
    jsro = new Thinfinity.JsRO();
    console.log("jsRO start. " + controlId);

    // -- Events
    jsro.on(controlId, "sendToWeb", function (msg) {
        var txtArea = document.getElementById("msgList");
        txtArea.value += 'App says: ' + msg + '\r\n';
    });
}

function btnclick1() {
    var inputVal = document.getElementById("inputText").value;
    jsro.model.wc1.sendMessage(inputVal)
}

xtag.register('x-wc1', {
    'content': '<div style="width:100%;height:100%;border:0;background-color: white;position: absolute; overflow:hidden;"><div style="padding:10px"><h3>Web component</h3><div id="id1"><b>Enter message</b><br></div><input type="text" placeholder="type a msg..." id="inputText" value="Hi App!"><button type="button" onclick="btnclick1()">Send to app</button><br><textarea id="msgList" rows="6" cols="40"></textarea></div></div>',
    'lifecycle': {
        'inserted': function () {
            console.log("inserted");
            startJsRO(this.id)
        }
    }
});
