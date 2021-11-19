Inside \Iframe\web you'll find 2 different files : 


app.html.append.txt
web-browser.js

You'll need to modify the app.html file in C:\Program Files\Thinfinity\VirtualUI\web and add 

<!-- Add this line in app.html after app.js --> 	
<script src="<%=@BASEURL%>js/web-browser.js" type="text/javascript"></script>	


You'll also need to move the web-browser.js file to C:\Program Files\Thinfinity\VirtualUI\web\js 

