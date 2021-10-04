function copyToClipboard(textToCopy) {
  var tmp = document.createElement("input");
  tmp.setAttribute("value", textToCopy);
  document.body.appendChild(tmp);
  tmp.select();
  document.execCommand("copy");
  document.body.removeChild(tmp);
}

helper.dom.ready(function () {
    virtualUI.onReceiveMessage = function (message) {        
		if (message) {		
			message = JSON.parse(message);
            switch (message.Action) {
                case 'copy':				
                    copyToClipboard(message.Text);					
                    break;
            }
        }
    };
});
