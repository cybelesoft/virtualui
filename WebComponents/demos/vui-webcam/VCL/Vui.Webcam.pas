unit Vui.Webcam;

interface
uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls,VirtualUI_SDK,Soap.EncdDecd,Vcl.Imaging.pngimage,Vcl.Imaging.jpeg;

type
  TVuiWebcam = class
  private
    FRo: TJSObject;
    FFilename : string;
    FXtagDir: string;
    FOnPictureChanged: TNotifyEvent;
    function Base64ToImg(AData: String): TGraphic;
  public
    constructor Create;
    destructor Destroy;override;
    procedure CreateComponent(AControl:TWinControl);
    procedure Freeze;
    procedure Unfreeze;
    procedure Attach(AWidth,AHeight:Integer);
    procedure SaveToFile(const AFilename:string);
    property  XTagDir: string read FXtagDir write FXTagDir;
    property  OnPictureChanged:TNotifyEvent read FOnPictureChanged write FOnPictureChanged;
  end;

implementation

{ TVuiWebcam }

constructor TVuiWebcam.Create;
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

procedure TVuiWebcam.CreateComponent(AControl: TWinControl);
begin
  VirtualUI.HTMLDoc.CreateSessionURL('/x-tag/',FXtagDir);
  VirtualUI.HTMLDoc.LoadScript('/x-tag/x-tag-core.min.js','');
  VirtualUI.HTMLDoc.ImportHTML('/x-tag/vui-webcam/vui-webcam.html','');

  FRo := TJSObject.Create(AControl.Name);
  FRo.Properties.Add('data')
    .OnSet(TJSBinding.Create(
      procedure(const Parent: IJSObject; const Prop: IJSProperty)
      var Img : TGraphic;
      begin
        Img := Base64ToImg(Prop.AsString);
        try
          if Assigned(OnPictureChanged) then
            OnPictureChanged(Img);
        finally
          Img.Free;
        end;
      end))
    .AsString := '';
  FRo.Events.Add('attach').AddArgument('width',JSDT_INT).AddArgument('height',JSDT_INT);
  FRo.Events.Add('freeze');
  FRo.Events.Add('unfreeze');
  FRo.Events.Add('save').AddArgument('type',JSDT_STRING);
  FRo.ApplyModel;
  VirtualUI.HTMLDoc.CreateComponent(AControl.Name,'vui-webcam',AControl.Handle);
end;

destructor TVuiWebcam.Destroy;
begin
  FRo := nil;
  inherited;
end;

function TVuiWebcam.Base64ToImg(AData: String): TGraphic;
var
  Input: TStringStream;
  Output: TBytesStream;
  Idx : Integer;
  Mime : string;
begin
  Result := nil;
  Idx := Pos(',',AData);
  if Idx>0 then begin
    Mime := Copy(AData,1,idx-1);
    if Pos('png',Mime)>0 then
      Result := TPngImage.Create
    else
      Result := TJpegImage.Create;

    AData := Copy(AData,Idx+1,Length(AData));
    Input := TStringStream.Create(AData, TEncoding.ASCII);
    Output := TBytesStream.Create;
    try
      DecodeStream(Input, Output);
      Output.Position := 0;
      Result.LoadFromStream(Output);
    finally
      Input.Free;
      Output.Free;
    end;
  end;
end;

procedure TVuiWebcam.Attach(AWidth,AHeight:Integer);
begin
  FRo.Events['attach'].ArgumentAsInt('width',AWidth).ArgumentAsInt('height',AHeight).Fire;
end;

procedure TVuiWebcam.Freeze;
begin
  FRo.Events['freeze'].Fire;
end;

procedure TVuiWebcam.Unfreeze;
begin
  FRo.Events['unfreeze'].Fire;
end;

procedure TVuiWebcam.SaveToFile(const AFilename: string);
begin
  FFilename := AFilename;
  FRo.Events['save'].ArgumentAsString('type','png').Fire;
end;

end.
