helper.dom.ready(function () {

var jsro = new Thinfinity.JsRO();
var ro = null;

jsro.on('model:ro', 'created', function () {
	ro = jsro.model.ro;
});


/* // Changes at Model level
jsro.on('model:ro', 'changed', function (obj) {
alert("The object 'ro' was changed: " + JSON.stringify(obj))
}); */

/* // Changes at property level
jsro.on('model:ro.writeText', 'changed', function (obj) {
alert("The property ‘text’ of ‘ro’ was changed: " + JSON.stringify(obj))
});
 */


jsro.on('ro', 'JsROCopy', function () {
	navigator.clipboard.writeText(ro.writeText).then((response)=>{}).catch((error)=>{});
});


jsro.on('ro', 'JsROPaste', function () {

	getClipboardContents()

});


async function getClipboardContents() {
try {
const text = await navigator.clipboard.readText();
ro.readText = text;
console.log('Pasted content: ', text);
} catch (err) {
console.error('Failed to read clipboard contents: ', err);
}
}

});