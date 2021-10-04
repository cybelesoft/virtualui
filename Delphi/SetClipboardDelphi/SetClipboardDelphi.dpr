program SetClipboardDelphi;

uses
  VirtualUI_SDK,
  Vcl.Forms,
  Main in 'Main.pas' {FrmMain};

{$R *.res}

begin
  VirtualUI.Start;
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TFrmMain, FrmMain);
  Application.Run;
end.
