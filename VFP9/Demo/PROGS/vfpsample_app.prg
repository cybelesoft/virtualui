* VFPSAMPLE_APP.PRG

* This file is a generated, framework-enabling component
* created by APPBUILDER 
* (c) Microsoft Corporation


* Framework-generated application startup program
* for C:\SOURCE\APPBRIDGE\SOURCES\DEMOS\VFP\VFPSAMPLE Project

#INCLUDE [..\VFPSAMPLE_APP.H]

IF TYPE([APP_GLOBAL.Class]) = "C" AND ;
   UPPER(APP_GLOBAL.Class) == UPPER(APP_CLASSNAME)
   MESSAGEBOX(APP_ALREADY_RUNNING_LOC,48, ;
              APP_GLOBAL.cCaption )
   IF VARTYPE(APP_GLOBAL.oFrame) = "O"
      APP_GLOBAL.oFrame.Show()
   ENDIF              
   RETURN
   
ENDIF   

RELEASE APP_GLOBAL
PUBLIC  APP_GLOBAL

RELEASE VirtualUI
PUBLIC VirtualUI
VirtualUI = CREATEOBJECT("Thinfinity.VirtualUI")
VirtualUI.DevMode = .T.
VirtualUI.DevServer.Port = 6080
VirtualUI.DevServer.Enabled = .T.
VirtualUI.StdDialogs = .T.
VirtualUI.Start(60)


LOCAL lcLastSetTalk, llAppRan, lnSeconds, loSplash
LOCAL ARRAY laCheck[1]

lcLastSetTalk=SET("TALK")
loSplash = .NULL.
SET TALK OFF

#IFDEF APP_SPLASHCLASS

   IF NOT EMPTY(APP_SPLASHCLASS)
      loSplash = NEWOBJECT(APP_SPLASHCLASS, APP_SPLASHCLASSLIB)
      IF VARTYPE(loSplash) = "O"   
         lnSeconds = SECONDS()
         loSplash.Show()
      ENDIF
   ENDIF                                

#ENDIF

APP_GLOBAL = NEWOBJECT(APP_CLASSNAME, APP_CLASSLIB)

IF VARTYPE(APP_GLOBAL) = "O" ;
      AND ACLASS(laCheck,APP_GLOBAL) > 0 AND ;
      ASCAN(laCheck,UPPER(APP_SUPERCLASS)) > 0

   APP_GLOBAL.cReference =[APP_GLOBAL]
   APP_GLOBAL.cFormMediatorName = APP_MEDIATOR_NAME

   #IFDEF APP_CD
      APP_CD
   #ENDIF
      
   #IFDEF APP_PATH
      APP_PATH
   #ENDIF   
   
   #IFDEF APP_INITIALIZE
       APP_INITIALIZE
   #ENDIF
   
   IF VARTYPE(loSplash) = "O"
   
      IF SECONDS() < lnSeconds + APP_SPLASHDELAY
         =INKEY(APP_SPLASHDELAY-(SECONDS()-lnSeconds),"MH")
      ENDIF

      loSplash.Release()
      loSplash = .NULL.

   ENDIF
   
   RELEASE laCheck, loSplash, lnSeconds
 
   IF NOT APP_GLOBAL.Show()

      IF TYPE([APP_GLOBAL.Name]) = "C"
         MESSAGEBOX(APP_CANNOT_RUN_LOC,16, ;
                 APP_GLOBAL.cCaption )
         APP_GLOBAL.Release()
      ELSE
         MESSAGEBOX(APP_CANNOT_RUN_LOC,16)
      ENDIF

   ELSE
      llAppRan = .T.
   ENDIF
   
     
   IF TYPE([APP_GLOBAL.lReadEvents]) = "L"
   
      IF APP_GLOBAL.lReadEvents
         * the Release() method was not used
         * but we've somehow gotten out of READ EVENTS...
         APP_GLOBAL.Release()
      ENDIF
   ELSE
      RELEASE APP_GLOBAL
   ENDIF

ELSE

   MESSAGEBOX(APP_WRONG_SUPERCLASS_LOC,16)
   RELEASE APP_GLOBAL

ENDIF

IF lcLastSetTalk=="ON"
   SET TALK ON
ELSE
   SET TALK OFF
ENDIF

IF TYPE([APP_GLOBAL]) = "O"
   * non-read events app
   RETURN APP_GLOBAL
ELSE
   RETURN llAppRan
ENDIF   
