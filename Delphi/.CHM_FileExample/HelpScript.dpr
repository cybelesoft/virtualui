program HelpScript;

uses
  Vcl.Forms,
  MainHelpScript in 'MainHelpScript.pas' {Form1},
  VirtualUI_SDK;

{$R *.res}

begin
  VirtualUI.Start();
  VirtualUI.StdDialogs := True;
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
