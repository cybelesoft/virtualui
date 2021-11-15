In order for the demo to work, you need to replace the URL in the OpenLinkDlg method , with your VirtualUI's IP Address and Port.

vui.OpenLinkDlg($"ms-excel:ofv|u|http://127.0.0.1:6080/{mySafeURL}", "Open Excel");