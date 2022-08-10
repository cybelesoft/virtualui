program JSROCopyPaste;

uses
  VirtualUI_SDK,
  Vcl.Forms,
  umain in 'umain.pas' {Form4};

{$R *.res}

begin
  VirtualUI.Start;
  VirtualUI.Options := VirtualUI.Options or OPT_JSRO_SYNCCALLS;
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm4, Form4);
  Application.Run;
end.
