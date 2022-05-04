var style = '<style type="text/css">.unmute {display: none;width: auto;height: auto;position: absolute;top: 10px;left: 50px;background-color: #fffdfd;padding: 2px;border: 1px solid gray;font-size: 14px;font-weight: bold;z-index: 999999999;}</style>';
var jsro = null;
var iframe = null;

xtag.register('vui-iframe', {
    'content': style + '<iframe src=""><iframe>',
    'lifecycle': {
        'inserted': function () {
            iframe = this.querySelector("iframe");
            startJsRO(this.id);
        }
    }
});

function startJsRO(controlId) {
    jsro = new Thinfinity.JsRO();

    // -- Properties
    jsro.on('model:' + controlId + '.src', 'changed', function (src) {
        if (src.value != '') iframe.src = src.value;
    });

    jsro.on('model:' + controlId + '.color', 'changed', function (color) {
        console.log(`new assigned color: ${color.value}`);
    });
}