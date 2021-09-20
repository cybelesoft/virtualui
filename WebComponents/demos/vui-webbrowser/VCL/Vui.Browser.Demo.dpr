program Vui.Browser.Demo;

uses
  VirtualUI_AutoRun,
  Vcl.Forms,
  Vui.Browser.Main in 'Vui.Browser.Main.pas' {Form7};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm7, Form7);
  Application.Run;
end.
