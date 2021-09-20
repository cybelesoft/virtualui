unit Vui.Audio;

interface
uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls,VirtualUI_SDK;

  type
  TVuiAudio = class
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

constructor TVuiAudio.Create(AControl:TWinControl);
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

destructor TVuiAudio.Destroy;
begin
  FRo := nil;
  inherited;
end;

procedure TVuiAudio.CreateComponent(AControl: TWinControl);
begin
  VirtualUI.HTMLDoc.CreateSessionURL('/x-tag/',FXtagDir);
  VirtualUI.HTMLDoc.LoadScript('/x-tag/x-tag-core.min.js','');
  VirtualUI.HTMLDoc.ImportHTML('/x-tag/vui-audio/vui-audio.html','');

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
  VirtualUI.HTMLDoc.CreateComponent(AControl.Name,'vui-audio',AControl.Handle);
end;

procedure TVuiAudio.PropertyChanged(const Sender: IJSObject; const Prop: IJSProperty);
begin
  if (Prop.Name = 'state') and Assigned(OnStateChanged) then OnStateChanged(Self);
  if (Prop.Name = 'position') and Assigned(OnPositionChanged) then OnPositionChanged(Self);
  if (Prop.Name = 'length') and Assigned(OnLengthChanged) then OnLengthChanged(Self);
end;

function TVuiAudio.GetLength: Single;
begin
  Result := FRo.Properties['length'].AsFloat;
end;

function TVuiAudio.GetPosition: Single;
begin
  Result := FRo.Properties['position'].AsFloat;
end;

function TVuiAudio.GetSrc: string;
begin
  Result := FSrc;
end;

procedure TVuiAudio.SetSrc(const Value: string);
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

function TVuiAudio.GetState: string;
begin
  Result := FRo.Properties['state'].AsString;
end;

procedure TVuiAudio.Move(APos: Single);
begin
  FRo.Events['move'].ArgumentAsFloat('Position',APos).Fire;
end;

procedure TVuiAudio.Pause;
begin
  FRo.Events['pause'].Fire;
end;

procedure TVuiAudio.Play;
begin
  FRo.Events['play'].Fire;
end;

procedure TVuiAudio.Stop;
begin
  FRo.Events['stop'].Fire;
end;
end.
