helper.dom.ready(function () {

    var jsro = new Thinfinity.JsRO();
    var ro = null;
	
	
	//Speech Recognition setup
	var SpeechRecognition = SpeechRecognition || webkitSpeechRecognition
	var SpeechGrammarList = SpeechGrammarList || webkitSpeechGrammarList
	var SpeechRecognitionEvent = SpeechRecognitionEvent || webkitSpeechRecognitionEvent
	

	var colors = [ 'aqua' , 'azure' , 'beige', 'bisque', 'black', 'blue', 'brown', 'chocolate', 'coral', 'crimson', 'cyan', 'fuchsia', 'ghostwhite', 'gold', 'goldenrod', 'gray', 'green', 'indigo', 'ivory', 'khaki', 'lavender', 'lime', 'linen', 'magenta', 'maroon', 'moccasin', 'navy', 'olive', 'orange', 'orchid', 'peru', 'pink', 'plum', 'purple', 'red', 'salmon', 'sienna', 'silver', 'snow', 'tan', 'teal', 'thistle', 'tomato', 'turquoise', 'violet', 'white', 'yellow'];
	var grammar = '#JSGF V1.0; grammar colors; public <color> = ' + colors.join(' | ') + ' ;'

	var recognition = new SpeechRecognition();
	var speechRecognitionList = new SpeechGrammarList();
	speechRecognitionList.addFromString(grammar, 1);
	recognition.grammars = speechRecognitionList;
	recognition.continuous = false;
	recognition.lang = 'en-US';
	recognition.interimResults = false;
	recognition.maxAlternatives = 1;

	// Used when 'sendVibration' is fired
	// URL has to be added to web-headers.json
    //var beepsound = new Audio('https://thumbs.dreamstime.com/audiothumb_8978/89780862.mp3');  
    
	
	
    jsro.on('model:ro', 'created', function () {
        ro = jsro.model.ro;
    });
    
	
    // Handles ro.Events['JsROCopy']
    jsro.on('ro', 'JsROCopy', function () {
        navigator.clipboard.writeText(ro.writeText).then((response)=>{}).catch((error)=>{});
    });
    
    
	// Handles ro.Events['JsROPaste']
    jsro.on('ro', 'JsROPaste', function () {
        getClipboardContents()
    });
    
	
	// Handles ro.Events['fullscreen']
    jsro.on('ro', '', function () {
		
        let elem = document.getElementById("virtualui");
        
        if (!document.fullscreenElement) {
        elem.requestFullscreen().catch(err => {
          alert(`Error attempting to enable full-screen mode: ${err.message} (${err.name})`);
        });
      } else {
        document.exitFullscreen();
      }
    
    
    });
	
    // Handles ro.Events['sendVibration'] . VIBRATE IS ONLY FOR MOBILE DEVICES
    jsro.on('ro', 'sendVibration', function () {
    
        window.navigator.vibrate(200);
        //beepsound.play();   
        
        
        var playPromise = beepsound.play();
    
        // In browsers that don’t yet support this functionality,
        // playPromise won’t be defined.
        if (playPromise !== undefined) {
          playPromise.then(function() {
            // Automatic playback started!
          }).catch(function(error) {
            // Automatic playback failed.
            // Show a UI element to let the user manually start playback.
          });
        }
        
        
        
    
    });
    
    
    // Handles ro.Events['copyBase64Image']
    jsro.on('ro', 'copyBase64Image', function () {
    
        const contentType = ro.imageType;
        const b64Data = ro.base64image;
        const blob = b64toBlob(b64Data, contentType);
        var data = [new ClipboardItem({ [blob.type]: blob })];
        navigator.clipboard.write(data).then(
            function () {
            /* success */
            },
            function () {
            /* failure */
            }
        );
    
        
    });
	
	
	
	
		// Handles ro.Events['JsROPaste']
    jsro.on('ro', 'recognitionStart', function () {
    
        recognition.start();
    
    });
	
	

	// Handles ro.Events['readBase64Image']
    jsro.on('ro', 'readBase64Image', function () {
		
		navigator.permissions.query({ name: "clipboard-read" }).then((result) => {
		// If permission to read the clipboard is granted or if the user will
		// be prompted to allow it, we proceed.
				if (result.state == "granted" || result.state == "prompt") {
				navigator.clipboard.read().then((data) => {
					for (let i = 0; i < data.length; i++) {
						if (!data[i].types.includes("image/png")) {
							alert("Clipboard contains non-image data. Unable to access it.");
						} else {
							data[i].getType("image/png").then((blob) => {
								//imgElem.src = URL.createObjectURL(blob);
								
								var reader = new window.FileReader();
								reader.readAsDataURL(blob);
								reader.onloadend = function () {
										 base64data = reader.result;
										 base64array = base64data.split(",");
										 ro.readBase64image = base64array[1];
										 //console.log(base64data);
										 //console.log(ro.readBase64image);
									}
							});
						}
					}
			  });
			}
		});   
    });
	
	
	
	recognition.onresult = function(event) {
		ro.speechRecognition = event.results[0][0].transcript;
		console.log(event.results[0][0].transcript);
	}
	
	
	//Fires on 'JsROPaste'
    async function getClipboardContents() {
	try {
		const text = await navigator.clipboard.readText();
		ro.readText = text;
		console.log('Pasted content: ', text);
		} catch (err) {
		console.error('Failed to read clipboard contents: ', err);
		}
    }
	
	
	// Used for converting the base64 string to Blob
	const b64toBlob = (b64Data, contentType='', sliceSize=512) => {
          const byteCharacters = atob(b64Data);
          const byteArrays = [];
          for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            const slice = byteCharacters.slice(offset, offset + sliceSize);
            const byteNumbers = new Array(slice.length);
            for (let i = 0; i < slice.length; i++) {
              byteNumbers[i] = slice.charCodeAt(i);
            }
            const byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
          }
          const blob = new Blob(byteArrays, {type: contentType});
          return blob;
        }
	 
    });
	
