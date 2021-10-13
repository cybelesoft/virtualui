program Thinfinity.RemotePrinter.PrintFile.Demo;

uses
  Vcl.Forms,
  main in 'main.pas' {Form1},
  RemotePrinter_SDK in '..\..\sdk\Delphi\RemotePrinter_SDK.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
