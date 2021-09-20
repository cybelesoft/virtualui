var msgObject = null;

// SendMessage button click:
function sendMessageToApp() {
  var msgText = document.getElementById("messageText").value;
  // Execute "sendMessage" method on application:
  msgObject.sendMessage(msgText);
  document.getElementById("messageLog").innerHTML += "<p><b>Sent:</b>\t" + msgText + "</p>";
}

helper.dom.ready(function () {
  var jsro = new Thinfinity.JsRO();

  jsro.on('model:msgObject', 'created', function (obj) {
      // Get reference to Remote Object
      msgObject = jsro.model.msgObject;
  });

  // Handler for "message" event, fired from application:
  jsro.on('msgObject', 'message', function (msgText) {
    document.getElementById("messageLog").innerHTML += "<p><b>Recv:</b>\t" + msgText + "</p>";
  });
});