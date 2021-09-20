program VuiWebcamTest;

uses
  VirtualUI_AutoRun,
  Vcl.Forms,
  VuiWebcam.Main in 'VuiWebcam.Main.pas' {Form6},
  Vui.Webcam in 'Vui.Webcam.pas',
  VuiWebcam.Dlg in 'VuiWebcam.Dlg.pas' {frmPhotoDlg};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm6, Form6);
  Application.Run;
end.
