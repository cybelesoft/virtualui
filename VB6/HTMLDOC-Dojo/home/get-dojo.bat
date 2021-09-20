@echo

set dojozip=dojo-release-1.16.4.zip
if exist %dojozip% goto uncompress
wget http://download.dojotoolkit.org/release-1.16.4/%dojozip%
if ERRORLEVEL 1 goto errorwget
:uncompress
call uncomp-dojo.bat
if ERRORLEVEL 1 goto error
del /q %dojozip%
@goto :eof
:errorwget
@echo Error. wget returned %ERRORLEVEL%Q
@goto :eof
:error
@goto :eof