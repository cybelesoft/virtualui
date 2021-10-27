Requirements: 
1. Needs to add an unsafe-eval policy to web-headers.json (located in the installation folder)

path:
templates/default/headers/Content-Security-Policy

replace:
"script-src": "'self' blob: 'unsafe-inline'",
with:
"script-src": "'self' blob: 'unsafe-inline' 'unsafe-eval'",

2. Take dojo-release-1.16.4.zip uncompress the following subdirs (dijit, dojo,  dojox) inside .\home
There are convenience batch files inside .\home (try get-dojo.bat). (Needs Wget and 7zip command line)


3. Set the 'homepage' in the Application profile editor to 'myapp.html' , as shown in the screenshot 'Application Profile Editor.png' .

