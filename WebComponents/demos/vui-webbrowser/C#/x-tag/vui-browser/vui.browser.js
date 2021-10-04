xtag.register('vui-browser', {
  'content': '<iframe style="width:100%;height:100%;border:0;background-color: white"/>',
  'lifecycle': {
    'inserted': function(){
        var controlId = this.id;
        var iframe = this.querySelector("iframe")
        var jsro = new Thinfinity.JsRO();
        var ro = null;
        jsro.on('model:'+controlId, 'created', function (obj) {
            ro = jsro.model[controlId];
        });

        // -- Properties            
        jsro.on('model:' + controlId + '.url', 'changed', function (value) {
        });
        // -- Events
        jsro.on(controlId, "go", function (url) {
            iframe.src = url;
        });
    
        // -- iframe Events;
        // -- ====================================================================
        // -- Duration change
        iframe.onload = function (e) {
//            ro.url = e;
            ro.loadEnd(iframe.src);
        };
    }
  }
});   