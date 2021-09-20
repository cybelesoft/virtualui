program VuiSignatureTest;

uses
  Vcl.Forms,
  VirtualUI_AutoRun,
  Vui.Signature.Pad in 'Vui.Signature.Pad.pas',
  Vui.Saved.Signature.Dlg in 'Vui.Saved.Signature.Dlg.pas' {frmSavedSignatureDlg},
  Vui.Signature.Main in 'Vui.Signature.Main.pas' {MainForm},
  Vui.Signature.Pad.Dlg in 'Vui.Signature.Pad.Dlg.pas' {frmVUISignaturePadDlg};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TMainForm, MainForm);
  Application.CreateForm(TfrmVUISignaturePadDlg, frmVUISignaturePadDlg);
  Application.Run;
end.
