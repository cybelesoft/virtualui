This demo shows how to programatically create an iframe inside your application ( using HTMLDOC.CreateComponent ) , and how to communicate back and foward between the application and the website running inside that iframe, using Javascript Remote Objects ( JSRO ) .


The demo is composed of 3 different parts: 

  . The 'backend' application with the Vuiframe class ( Vuiframe.cs ). **(Required)**
  
  . The JSRO running in the VirtualUI tab ( vui-frame.html and vui-frame.js ). **(Required)**
  
  . The JSRO running in the web application inside the iframe ( jsro_iframe.html ). (Optional)
 


**Vuiframe.cs**
      
    vui.HTMLDoc.CreateSessionURL("/x-tag/", m_Xtagdir); 
    
_Creates an url pointing to a local filename. This url is valid during the session lifetime and its private to this session._
      
      
      
    vui.HTMLDoc.LoadScript(@"/x-tag/x-tag-core.min.js"); 

_Loads a script from url into VirtualUI's app.html . This is useful if you want to programatically add more .js files to the app.html withouth having to modify it by hand_
 
 
 
    vui.HTMLDoc.ImportHTML(@"/x-tag/vui-iframe.html"); 
    
_Same as LoadScript but with HTML files_
    
    
    
    
    vui.HTMLDoc.CreateComponent(ctrl.Name, "vui-iframe", ctrl.Handle);
    
_Inserts HTML elemtents to the app.html , the .html file where the app is running . Used to insert regular HTML elements or WebComponents with custom elements. _

_This creates the iframe where we will call the 'jsro_iframe.html' file_
    
    
     
**Javascript Remote Objects methods, events and properties.** 

These will be used for communicating 'color' and 'backgroundColor' back and forth.

    // -- The given name, is how the model shown this object in the model reference.
    m_iframe = new JSObject(ctrl.Name);
    m_iframe.OnPropertyChange += m_iframe_OnPropertyChange;
    // -- Adding properties, methods and events.
    m_iframe.Properties.Add("src").AsString = "";
    m_iframe.Properties.Add("color").AsString = "";
    m_iframe.Properties.Add("backgroundColor").AsString = "";
    m_iframe.ApplyModel();
     
     
     
**vuiframe.html / vuiframe.js **



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

__


    xtag.register('vui-iframe', {
        'content': style + '<iframe src=""><iframe>',
        'lifecycle': {
            'inserted': function () {
                iframe = this.querySelector("iframe");
                startJsRO(this.id);
            }
        }
    });


 
 
**jsro_iframe.html**
  
   This example shows how Javascript Remote Objects needs to be called in the destination website, if you want to communicate back and forth to the Thinfinity Application. 
   
  

