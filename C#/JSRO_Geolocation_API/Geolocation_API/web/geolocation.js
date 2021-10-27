helper.dom.ready(function () {

	var jsro = new Thinfinity.JsRO();
	var ro = null;

	jsro.on('model:ro', 'created', function () {
		ro = jsro.model.ro;
	});

	jsro.on('ro', 'getGeoLocation', function () {

	getGeoLocation();

});


function getGeoLocation(){

		var options = {
			enableHighAccuracy: true,
			timeout: 5000,
			maximumAge: 0
		};

		function success(pos) {
			var crd = pos.coords;
			
			ro.latitude = crd.latitude;
			ro.longitude = crd.longitude;
			ro.accuracy = crd.accuracy;

		}

		function error(err) {
		  console.warn("ERROR(${err.code}): ${err.message}");
		}

		navigator.geolocation.getCurrentPosition(success, error, options);

	}
});