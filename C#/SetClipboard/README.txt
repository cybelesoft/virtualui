Inside \SetClipboardCSharp\web you'll find 2 different files : 


app.html.append.txt
clphandler.js

You'll need to modify the app.html file in C:\Program Files\Thinfinity\VirtualUI\web and add 

<!-- Add this line in app.html after app.js --> 	
<script src="<%=@BASEURL%>js/clphandler.js" type="text/javascript"></script>	


You'll also need to move the clphandler.js file to C:\Program Files\Thinfinity\VirtualUI\web\js 

