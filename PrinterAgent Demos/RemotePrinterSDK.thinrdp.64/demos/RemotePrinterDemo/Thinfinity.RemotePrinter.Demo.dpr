program Thinfinity.RemotePrinter.Demo;

uses
  Vcl.Forms,
  MainUnit in 'MainUnit.pas' {MainForm},
  RemotePrinter_SDK in '..\..\sdk\Delphi\RemotePrinter_SDK.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TMainForm, MainForm);
  Application.Run;
end.
