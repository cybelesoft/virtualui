program JsROAudioProj;

uses
  VirtualUI_Autorun,
  Vcl.Forms,
  jsroAudio in 'jsroAudio.pas' {frmJsROAudio},
  Vui.Audio in 'Vui.Audio.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmJsROAudio, frmJsROAudio);
  Application.Run;
end.
