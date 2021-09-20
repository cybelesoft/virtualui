xtag.register('vui-webcam', {
    'content': '<div style="width:100%;height:100%"></div>',
    'lifecycle': {
        'inserted': function () {
            var controlId = this.id;
            var ro = null;
            var jsro = new Thinfinity.JsRO();
            var cameradiv = this.children[0];

            jsro.on('model:' + controlId, 'created', function (obj) {
                ro = jsro.model[controlId];
            });

            jsro.on(controlId, "attach", function (w, h) {
                Webcam.set({
                    width: w,
                    height: h,
                    image_format: 'jpeg',
                    jpeg_quality: 90
                });

                Webcam.attach(cameradiv);
            });

            jsro.on(controlId, "freeze", function () {
                Webcam.freeze();
            });
            jsro.on(controlId, "unfreeze", function () {
                Webcam.unfreeze();
            });
            jsro.on(controlId, "save", function (imgtype) {
                Webcam.snap(function (data_uri) {
                    ro.data = data_uri;
                });
            });
        }
    }
});