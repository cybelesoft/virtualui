program TestSetImageQualityByWnd;

uses
  VirtualUI_SDK,
  Vcl.Forms,
  main in 'main.pas' {Form1};

{$R *.res}

begin
  VirtualUI.Start;
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
