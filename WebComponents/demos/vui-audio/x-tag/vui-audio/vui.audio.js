var jsro = null;
var xaudio = null;

xtag.register('vui-audio', {
    'content':'<div><audio></audio></div>',
    'lifecycle': {
        'inserted': function () {
            xaudio = this.querySelector("audio");
            startJsRO(this.id);
        }
    }
});

function startJsRO(controlId) {
    jsro = new Thinfinity.JsRO();
    // -- Properties
    jsro.on('model:*','created', function (e) {
        if (agentInfo.isSafari) {
            jsro.model[controlId]['slider'] = false;
        }
    });

    jsro.on('model:' + controlId + '.src', 'changed', function (src) {
        if (src.value != '') {
            xaudio.innerHTML = '';
            var source = document.createElement('source');
            source.src = src.value;
            xaudio.appendChild(source);
            xaudio.load();
            xaudio.currentTime = 0;
        }
    });
    // -- Events
    jsro.on(controlId, "play", function () {
        xaudio.play();
    });
    jsro.on(controlId, "pause", function () {
        xaudio.pause();
    });
    jsro.on(controlId, "stop", function () {
        xaudio.pause();
        xaudio.currentTime = 0.0;
    });
    jsro.on(controlId, "move", function (value) {
        xaudio.currentTime = value;
    });

    // -- Audio Events;
    // -- ====================================================================
    // -- Duration change
    xaudio.ondurationchange = function (e) {
        jsro.model[controlId]['position'] = 0.0;
        jsro.model[controlId]['length'] = xaudio.duration;
        //            jsro.model[controlId]['state'] = 'Ready';
    };
    // -- Video is ended.
    xaudio.onended = function (e) {
        jsro.model[controlId]['state'] = 'Ended';
    };
    // -- Has been paused.
    xaudio.onpause = function (e) {
        jsro.model[controlId]['state'] = 'Paused';
    };
    // -- Started is not longer paused.
    xaudio.onplay = function (e) {
        jsro.model[controlId]['state'] = 'Playing';
    };
    // -- Playing after having been paused or stopped.
    xaudio.onplaying = function (e) {
        jsro.model[controlId]['state'] = 'Playing';
    };
    // -- Playback position change
    xaudio.ontimeupdate = function (e) {
        jsro.model[controlId]['position'] = xaudio.currentTime;
    };
    // -- Not getting media data
    xaudio.onsuspend = function (e) {
        // jsro.model[controlId]['state'] = 'Suspended';
    };
    //-- Delayed pending
    xaudio.onwaiting = function (e) {
        jsro.model[controlId]['state'] = 'Waiting...';
    };
    // -- Load Start
    xaudio.onloadstart = function (e) {
        jsro.model[controlId]['state'] = 'Loading...';
    };
    // -- First frame of the media has finished loading.
    xaudio.onloadeddata = function (e) {
        jsro.model[controlId]['state'] = 'Ready';
        jsro.model[controlId]['duration'] = xaudio.duration;
    };
    // -- Error.
    xaudio.onerror = function (e) {
        function getErrorName(code) {
            for (var attrib in xaudio.error) {
                if (xaudio.error[attrib] == code) {
                    return attrib;
                }
            }
        };
        var errorName = getErrorName(xaudio.error.code)
        jsro.model[controlId]['state'] = 'Error - ' + errorName;
    }
};