Requirements: 
1. Needs to add an unsafe-eval policy to web-headers.json

path:
templates/default/headers/Content-Security-Policy

replace:
"script-src": "'self' blob: 'unsafe-inline'",
with:
"script-src": "'self' blob: 'unsafe-inline' 'unsafe-eval'",

2. Take dojo-release-1.16.4.zip uncompress the following subdirs (dijit, dojo,  dojox) inside .\home
There are convenience batch files inside .\home (try get-dojo.bat). (Needs Wget and 7zip command line)

