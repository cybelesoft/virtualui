program TestApp;

uses
  VirtualUI_AutoRun,
  Vcl.Forms,
  main in 'main.pas' {Form2};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm2, Form2);
  Application.Run;
end.
