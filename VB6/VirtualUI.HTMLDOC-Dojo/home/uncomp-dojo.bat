set base=dojo-release-1.16.4
if not exist %base%.zip goto nofile
rd dijit dojo dojox /s /q
7z x %base%.zip
move %base%\dijit .
move %base%\dojo .
move %base%\dojox .
rd /q  /s %base%
@echo We are done.
@goto :eof
:nofile
@echo file %base%.zip does not exist
@goto :eof