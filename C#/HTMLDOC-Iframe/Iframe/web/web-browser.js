helper.dom.ready(function () {

    var jsro = new Thinfinity.JsRO();
    var ro = null;

    jsro.on('model:browser1', 'created', function (obj) {
        ro = jsro.model.browser1;
    });

    // -- Events
    jsro.on('browser1', "go", function (url) {
        var iframevar = document.getElementById('myIframe');
        iframevar.src = ro.url;

    });
});