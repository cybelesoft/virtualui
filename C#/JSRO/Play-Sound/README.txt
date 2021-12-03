Inside \JSRO Copy Paste\web you'll find 2 different files : 


app.html.append.txt
beepPlay.js

You'll need to modify the app.html file in C:\Program Files\Thinfinity\VirtualUI\web and add 

<!-- Add this line in app.html after app.js --> 	
<script src="<%=@BASEURL%>js/beepPlay.js" type="text/javascript"></script>	


You'll also need to move the beepPlay.js file to C:\Program Files\Thinfinity\VirtualUI\web\js 

