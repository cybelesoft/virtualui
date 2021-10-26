helper.dom.ready(function () {
    virtualUI.onReceiveMessage = function (message) {        
		if (message) {		
			message = JSON.parse(message);
            switch (message.Action) {
                case 'copy':				
                    navigator.clipboard.writeText(message.Text).then((response)=>{}).catch((error)=>{});				
                    break;
            }
        }
    };
});
