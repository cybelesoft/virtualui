unit jsroAudio;

interface

uses
   Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
   Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vui.Audio, Vcl.ComCtrls, Vcl.ExtCtrls,
   Vcl.StdCtrls;

type
  TfrmJsROAudio = class(TForm)
    lblAudio: TLabel;
    cmbAudio: TComboBox;
    panelXAudio: TPanel;
    GroupBox1: TGroupBox;
    lblStatus: TLabel;
    btnPlay: TButton;
    btnStop: TButton;
    lblStatusCaption: TLabel;
    TrackBar1: TTrackBar;
    procedure cmbAudioChange(Sender: TObject);
    procedure btnPlayClick(Sender: TObject);
    procedure btnStopClick(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
    FAudio : TVuiAudio;
    FPositionChanging : Boolean;
    FPlaying : Boolean;
    procedure LengthChanged(Sender: TObject);
    procedure PositionChanged(Sender: TObject);
    procedure StateChanged(Sender: TObject);
    procedure EnableControls(AControl: TControl; AValue: Boolean);
    procedure AddLocalMediaFiles;
  public
    { Public declarations }
  end;

var
  frmJsROAudio: TfrmJsROAudio;

implementation

{$R *.dfm}

procedure TfrmJsROAudio.AddLocalMediaFiles;
var
  Path: string;
  F: TSearchRec;
begin
  Path := ExtractFilePath(ExcludeTrailingPathDelimiter(FAudio.XTagDir)) +
    'demos\vui-audio\media\';
  if FindFirst(Path + '*.mp3', faAnyFile, F) = 0 then
  begin
    repeat
      cmbAudio.Items.Add(Path + F.Name);
    until FindNext(F) <> 0;
    FindClose(F);
  end;
  if cmbAudio.Items.Count > 0 then
  begin
    cmbAudio.ItemIndex := 0;
    FAudio.Src := cmbAudio.Text;
    TrackBar1.Position := 0;
  end;
  EnableControls(Groupbox1, cmbAudio.Items.Count > 0);
end;

procedure TfrmJsROAudio.btnPlayClick(Sender: TObject);
begin
  if not FPlaying then begin
    btnPlay.Caption := 'Pause';
    FAudio.Play;
  end else begin
    btnPlay.Caption := 'Play';
    FAudio.Pause;
  end;
  FPlaying := not FPlaying;
end;

procedure TfrmJsROAudio.btnStopClick(Sender: TObject);
begin
  btnPlay.Caption := 'Play';
  FPlaying := False;
  FAudio.Stop;
  TrackBar1.Position := 0;
end;

procedure TfrmJsROAudio.cmbAudioChange(Sender: TObject);
begin
  btnStop.Click;
  FAudio.Src := cmbAudio.Text;
end;

procedure TfrmJsROAudio.FormCreate(Sender: TObject);
begin
  FAudio := TVuiAudio.Create(panelXAudio);
  FAudio.OnStateChanged := StateChanged;
  FAudio.OnPositionChanged := PositionChanged;
  FAudio.OnLengthChanged := LengthChanged;
  FAudio.CreateComponent(panelXAudio);
  lblStatus.Caption := '';
  AddLocalMediaFiles;
end;

procedure TfrmJsROAudio.TrackBar1Change(Sender: TObject);
begin
  if not FPositionChanging then
    FAudio.Move(TrackBar1.Position/100);
end;


procedure TfrmJsROAudio.EnableControls(AControl: TControl; AValue: Boolean);
var
  n: Integer;
begin
  AControl.Enabled := AValue;
  if AControl is TWinControl then
    for n := 0 to (AControl as TWinControl).ControlCount - 1 do
      EnableControls((AControl as TWinControl).Controls[n], AValue);
end;

procedure TfrmJsROAudio.StateChanged(Sender: TObject);
begin
  lblStatus.Caption := FAudio.State;
end;

procedure TfrmJsROAudio.PositionChanged(Sender: TObject);
begin
  FPositionChanging := true;
  TrackBar1.Position := Round(FAudio.Position * 100);
  FPositionChanging := False;
end;

procedure TfrmJsROAudio.LengthChanged(Sender: TObject);
begin
  TrackBar1.Max := Round(FAudio.Length * 100);
  EnableControls(Groupbox1,true);
end;

end.
