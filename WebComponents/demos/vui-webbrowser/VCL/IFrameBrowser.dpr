program IFrameBrowser;

uses
  VirtualUI_AutoRun,
  Vcl.Forms,
  IFrameBrowser.Main in 'IFrameBrowser.Main.pas' {Form7};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm7, Form7);
  Application.Run;
end.
