program VuiSignatureTest;

uses
  VirtualUI_AutoRun,
  Vcl.Forms,
  VuiSignature.Main in 'VuiSignature.Main.pas' {Form6},
  Vui.Signature.Pad in 'Vui.Signature.Pad.pas',
  VuiSignature.Dlg in 'VuiSignature.Dlg.pas' {frmSignatureDlg};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm6, Form6);
  Application.Run;
end.
