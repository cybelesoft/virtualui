program JsROVideo;

uses
  VirtualUI_Autorun,
  Vcl.Forms,
  JsROVideo.Main in 'JsROVideo.Main.pas' {Form5},
  Vui.Video in 'Vui.Video.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm5, Form5);
  Application.Run;
end.
