unit JsROVideo.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs,Vui.Video, Vcl.ComCtrls, Vcl.ExtCtrls,
  Vcl.StdCtrls;

type
  TForm5 = class(TForm)
    Label1: TLabel;
    cbUrl: TComboBox;
    bGo: TButton;
    Panel1: TPanel;
    GroupBox1: TGroupBox;
    TrackBar1: TTrackBar;
    bPlay: TButton;
    bStop: TButton;
    Label2: TLabel;
    lblStatus: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure bGoClick(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure bPlayClick(Sender: TObject);
    procedure bStopClick(Sender: TObject);
  private
    { Private declarations }
    FVideo : TVuiVideo;
    FPositionChanging : Boolean;
    FPlaying : Boolean;
    procedure LengthChanged(Sender: TObject);
    procedure PositionChanged(Sender: TObject);
    procedure StateChanged(Sender: TObject);
    procedure EnableControls(AControl: TControl; AValue: Boolean);
  public
    { Public declarations }
  end;

var
  Form5: TForm5;

implementation

{$R *.dfm}

procedure TForm5.bGoClick(Sender: TObject);
begin
  FVideo.Src := cbUrl.Text;
end;

procedure TForm5.bPlayClick(Sender: TObject);
begin
  if not FPlaying then begin
      bPlay.Caption := 'Pause';
      FVideo.Play;
  end else begin
      bPlay.Caption := 'Play';
      FVideo.Pause;
  end;
  FPlaying := not FPlaying;
end;

procedure TForm5.bStopClick(Sender: TObject);
begin
  bPlay.Caption := 'Play';
  FPlaying := false;
  FVideo.Stop;
end;

procedure TForm5.EnableControls(AControl: TControl; AValue: Boolean);
var
  n: Integer;
begin
  AControl.Enabled := AValue;
  if AControl is TWinControl then
    for n := 0 to (AControl as TWinControl).ControlCount - 1 do
      EnableControls((AControl as TWinControl).Controls[n], AValue);
end;

procedure TForm5.FormCreate(Sender: TObject);
var
  mediafile : string;
begin
  FVideo := TVuiVideo.Create(Panel1);
  FVideo.OnStateChanged := StateChanged;
  FVideo.OnPositionChanged := PositionChanged;
  FVideo.OnLengthChanged := LengthChanged;
  FVideo.CreateComponent(panel1);

  EnableControls(Groupbox1,False);

  mediafile := ExpandFilename(FVideo.XTagDir + '..\demos\vui-video\media\big_buck_bunny_480p_2mb.mp4');

  cbUrl.Items.Insert(0, mediafile);
  cbUrl.ItemIndex := 0;
end;

procedure TForm5.StateChanged(Sender: TObject);
begin
  lblStatus.Caption := FVideo.State;
end;

procedure TForm5.TrackBar1Change(Sender: TObject);
begin
  if not FPositionChanging then
    FVideo.Move(TrackBar1.Position/100);
end;

procedure TForm5.PositionChanged(Sender: TObject);
begin
  FPositionChanging := true;
  TrackBar1.Position := Round(FVideo.Position * 100);
  FPositionChanging := False;
end;

procedure TForm5.LengthChanged(Sender: TObject);
begin
  TrackBar1.Max := Round(FVideo.Length * 100);
  EnableControls(Groupbox1,true);
end;

end.
