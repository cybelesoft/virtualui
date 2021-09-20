var style = '<style type="text/css">.unmute {display: none;width: auto;height: auto;position: absolute;top: 10px;left: 50px;background-color: #fffdfd;padding: 2px;border: 1px solid gray;font-size: 14px;font-weight: bold;z-index: 999999999;}</style>';
var jsro = null;
var video = null;
var btnUnmute = null;

xtag.register('vui-video', {
    'content': style + '<div><div id="btnUnmute" class="unmute">Unmute</div><video style="position:absolute;height:100%;width:100%;"></video></div>',
    'lifecycle': {
        'inserted': function () {
            video = this.querySelector("video");
            btnUnmute = this.querySelector("#btnUnmute");
            checkButtonUnmute();
            startJsRO(this.id);
        }
    }
});

function checkButtonUnmute() {
    if (agentInfo.isMobile) {
        video.muted = true;
        video.autoPlay = true;
        btnUnmute.addEventListener('touchstart', function () {
            video.muted = false;
            btnUnmute.parentElement.removeChild(btnUnmute);
        }, false);
    } else {
        btnUnmute.parentElement.removeChild(btnUnmute);
    }
};

function startJsRO(controlId) {
    jsro = new Thinfinity.JsRO();
    // -- Properties
    jsro.on('model:' + controlId + '.src', 'changed', function (src) {
        if (src.value != '') video.src = src.value;
    });
    // -- Events
    jsro.on(controlId, "play", function () {
        btnUnmute.style.display = 'block';
        video.play();
    });
    jsro.on(controlId, "pause", function () {
        video.pause();
    });
    jsro.on(controlId, "stop", function () {
        video.pause();
        video.currentTime = 0.0;
    });
    jsro.on(controlId, "move", function (value) {
        video.currentTime = value;
    });

    // -- Video Events;
    // -- ====================================================================
    // -- Duration change
    video.ondurationchange = function (e) {
        jsro.model[controlId]['position'] = 0.0;
        jsro.model[controlId]['length'] = video.duration;
        //            jsro.model[controlId]['state'] = 'Ready';
    };
    // -- Video is ended.
    video.onended = function (e) {
        jsro.model[controlId]['state'] = 'Ended';
    };
    // -- Has been paused.
    video.onpause = function (e) {
        jsro.model[controlId]['state'] = 'Paused';
    };
    // -- Started is not longer paused.
    video.onplay = function (e) {
        jsro.model[controlId]['state'] = 'Playing';
    };
    // -- Playing after having been paused or stopped.
    video.onplaying = function (e) {
        jsro.model[controlId]['state'] = 'Playing';
    };
    // -- Playback position change
    video.ontimeupdate = function (e) {
        jsro.model[controlId]['position'] = video.currentTime;
    };
    // -- Not getting media data
    video.onsuspend = function (e) {
        // jsro.model[controlId]['state'] = 'Suspended';
    };
    //-- Delayed pending
    video.onwaiting = function (e) {
        jsro.model[controlId]['state'] = 'Waiting...';
    };
    // -- Load Start
    video.onloadstart = function (e) {
        jsro.model[controlId]['state'] = 'Loading...';
    };
    // -- First frame of the media has finished loading.
    video.onloadeddata = function (e) {
        jsro.model[controlId]['state'] = 'Ready';
    };
    // -- Error.
    video.onerror = function (e) {
        function getErrorName(code) {
            for (var attrib in video.error) {
                if (video.error[attrib] == code) {
                    return attrib;
                }
            }
        };
        var errorName = getErrorName(video.error.code)
        jsro.model[controlId]['state'] = 'Error - ' + errorName;
    };
};