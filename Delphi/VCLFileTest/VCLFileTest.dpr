program VCLFileTest;

uses
  Vcl.Forms,
  VirtualUI_Autorun,
  VCLFileTest.main in 'VCLFileTest.main.pas' {MainForm};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TMainForm, MainForm);
  Application.Run;
end.
