helper.dom.ready(function () {

		var jsro = new Thinfinity.JsRO();
		var ro = null;
		
		jsro.on('model:ro', 'created', function () {
			ro = jsro.model.ro;
		});
		
		// Handles ro.Events['playBeep'] .
		jsro.on('ro', 'playBeep', function () {
		
			var beepsound = new Audio("http://127.0.0.1:6080/"+ ro.myBeepURL );

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
    });
	
