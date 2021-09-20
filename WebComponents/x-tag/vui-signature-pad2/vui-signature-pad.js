    var SignatureControl = function () {
        var _ref = this;
        var _canvas = null;
        var _interval = null;
        var _ro = null;
        var _jsro = null;
        var _signaturePad = null;
        var _ready = false;

        function checkCanvasSize() {
            var bounding = _canvas.getBoundingClientRect();
            if (_canvas.width == 0 || _canvas.height == 0) {
                _canvas.width = bounding.width;
                _canvas.height = bounding.height;
            } else if (_canvas.width != bounding.width || _canvas.height != bounding.height) {
                // -- Copy image data to allow to redraw after resize;
                var context = _canvas.getContext("2d");
                var imagedata = context.getImageData(0, 0, _canvas.width, _canvas.height);
                _canvas.width = bounding.width;
                _canvas.height = bounding.height;
                context.putImageData(imagedata, 0, 0);
            }
        };
        function start(signaturepadPanel) {
            _controlID = signaturepadPanel.id;
            _canvas = signaturepadPanel.querySelector("canvas");
            if (_interval) stop();
            _interval = setInterval(checkCanvasSize, 250);
            _signaturePad = new SignaturePad(_canvas, { 'minWidth': 0.5, 'maxWidth': 1.5 });

            _jsro = new Thinfinity.JsRO();
            _jsro.on('model:' + _controlID, 'created', function (obj) {
                _ro = _jsro.model[_controlID];
            });

            _jsro.on(_controlID, "clear", function () {
                _signaturePad.clear();
            });
            _jsro.on(_controlID, "save", function (imgtype) {
                if (_signaturePad.isEmpty()) {
                    alert("Please provide signature first.");
                } else {
					// this method will be attended from FSignPadRO.Methods.Add('updateSignature') (vui.signature.pad.pas)
                    _ro.updateSignature(_signaturePad.toDataURL("image/" + imgtype, 1.0));
                }
            });

            _ready = true;
        }
        function stop() {
            window.clearInterval(_interval);
            _interval = null;
            _signaturePad.off();
            _signaturePad = null;
            _jsro.dispose();
            _jsro = null;
        }

        function getReady() { return _ready; }

        Object.defineProperty(_ref, "start", { "value": start });
        Object.defineProperty(_ref, "ready", { "get": getReady });
    };

    var sc = new SignatureControl();

    xtag.register('vui-signature-pad', {
        'content': '<div style="background-color:white;width:100%;height:100%"><canvas style="width:100%;height:100%"></canvas></div>',
        'lifecycle': {
            'created': function () {
                var signaturePanel = this;
                window.setTimeout(function () {
                    sc.start(signaturePanel);
                }, 200);
            }
        }
    });