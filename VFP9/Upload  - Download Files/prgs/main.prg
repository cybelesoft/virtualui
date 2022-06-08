On Shutdown Quit
Set Classlib To [forms] Additive
Public gcVUI
goVUI=Createobject("Thinfinity.VirtualUI")
goVUI.Start(60)
Local loMainform
loMainform=Createobject("frmmain")
loMainform.Show()
Read Events