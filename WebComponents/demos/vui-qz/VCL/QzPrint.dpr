program QzPrint;

uses
  Vcl.Forms,
  Vui.Qz,
  VirtualUI_Autorun,
  QzPrint.Main in 'QzPrint.Main.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
