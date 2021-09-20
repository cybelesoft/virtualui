unit Vui.Video;

interface
uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls,VirtualUI_SDK;

type
  TVuiVideo = class
  private
    FRo: TJSObject;
    FFilename : string;
    FXtagDir: string;
    FSrc : string;
    FOnPositionChanged: TNotifyEvent;
    FOnLengthChanged: TNotifyEvent;
    FOnStateChanged: TNotifyEvent;
    function GetLength: Single;
    function GetPosition: Single;
    function GetSrc: string;
    function GetState: string;
    procedure SetSrc(const Value: string);
    procedure PropertyChanged(const Sender: IJSObject; const Prop: IJSProperty);
  public
    constructor Create(AControl:TWinControl);
    destructor Destroy;override;
    procedure Play;
    procedure Pause;
    procedure Stop;
    procedure Move(APos:Single);
    procedure CreateComponent(AControl:TWinControl);
    property  XTagDir: string read FXtagDir write FXTagDir;
    property  Position: Single read GetPosition;
    property  Length: Single read GetLength;
    property  State:string read GetState;
    property  Src:string read GetSrc write SetSrc;
    property  OnStateChanged:TNotifyEvent read FOnStateChanged write FOnStateChanged;
    property  OnLengthChanged:TNotifyEvent read FOnLengthChanged write FOnLengthChanged;
    property  OnPositionChanged:TNotifyEvent read FOnPositionChanged write FOnPositionChanged;
  end;

implementation

constructor TVuiVideo.Create(AControl:TWinControl);
var
  BaseDir : string;
begin
  BaseDir := ExtractFilePath(ParamStr(0));
  while BaseDir<>'' do begin
    FXtagDir := BaseDir + 'x-tag\';
    if DirectoryExists(FXtagDir) then break;
    BaseDir := ExtractFilePath(ExcludeTrailingBackSlash(BaseDir));
  end;
end;

destructor TVuiVideo.Destroy;
begin
  FRo := nil;
  inherited;
end;

procedure TVuiVideo.CreateComponent(AControl: TWinControl);
begin
  VirtualUI.HTMLDoc.CreateSessionURL('/x-tag/',FXtagDir);
  VirtualUI.HTMLDoc.LoadScript('/x-tag/x-tag-core.min.js','');
  VirtualUI.HTMLDoc.ImportHTML('/x-tag/vui-video/vui-video.html','');

  FRo := TJSObject.Create(AControl.Name);
  FRo.OnPropertyChange := PropertyChanged;
  FRo.Properties.Add('length').AsFloat := 0;
  FRo.Properties.Add('position').AsFloat := 0;
  FRo.Properties.Add('src').AsString := '';
  FRo.Properties.Add('state').AsString := '';
  FRo.Events.Add('play');
  FRo.Events.Add('pause');
  FRo.Events.Add('stop');
  FRo.Events.Add('move').AddArgument('position',JSDT_FLOAT);
  FRo.ApplyModel;
  VirtualUI.HTMLDoc.CreateComponent(AControl.Name,'vui-video',AControl.Handle);
end;

procedure TVuiVideo.PropertyChanged(const Sender: IJSObject; const Prop: IJSProperty);
begin
  if (Prop.Name = 'state') and Assigned(OnStateChanged) then OnStateChanged(Self);
  if (Prop.Name = 'position') and Assigned(OnPositionChanged) then OnPositionChanged(Self);
  if (Prop.Name = 'length') and Assigned(OnLengthChanged) then OnLengthChanged(Self);
end;

function TVuiVideo.GetLength: Single;
begin
  Result := FRo.Properties['length'].AsFloat;
end;

function TVuiVideo.GetPosition: Single;
begin
  Result := FRo.Properties['position'].AsFloat;
end;

function TVuiVideo.GetSrc: string;
begin
  Result := FSrc;
end;

procedure TVuiVideo.SetSrc(const Value: string);
var
  url : string;
begin
  FSrc := value;
  url := FSrc;
  if FileExists(FSrc) then begin
    url := VirtualUI.HTMLDoc.GetSafeUrl(FSrc, 60);
  end;
  FRo.Properties['src'].AsString := url;
end;

function TVuiVideo.GetState: string;
begin
  Result := FRo.Properties['state'].AsString;
end;

procedure TVuiVideo.Move(APos: Single);
begin
  FRo.Events['move'].ArgumentAsFloat('Position',APos).Fire;
end;

procedure TVuiVideo.Pause;
begin
  FRo.Events['pause'].Fire;
end;

procedure TVuiVideo.Play;
begin
  FRo.Events['play'].Fire;
end;

procedure TVuiVideo.Stop;
begin
  FRo.Events['stop'].Fire;
end;

end.
