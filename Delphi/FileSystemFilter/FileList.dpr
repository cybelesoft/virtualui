program FileList;

uses
  VirtualUI_Autorun,
  Vcl.Forms,
  FileList.Main in 'FileList.Main.pas' {FrmMain};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TFrmMain, FrmMain);
  Application.Run;
end.
