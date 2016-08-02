unit Vui.Signature.Pad;

interface
uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls,VirtualUI_SDK,Soap.EncdDecd,Vcl.Imaging.pngimage,Vcl.Imaging.jpeg;

type
  TVuiSignaturePad = class
  private
    FSigRo: TJSObject;
    FFilename : string;
    FXtagDir: string;
    FOnSignatureChanged: TNotifyEvent;
    function Base64ToImg(AData: String): TGraphic;
  public
    constructor Create(AControl:TWinControl);
    destructor Destroy;override;
    procedure Clear;
    procedure SaveToFile(const AFilename:string);
    property  XTagDir: string read FXtagDir write FXTagDir;
    property  OnSignatureChanged:TNotifyEvent read FOnSignatureChanged write FOnSignatureChanged;
  end;

implementation

{ TVuiSignaturePad }

constructor TVuiSignaturePad.Create(AControl:TWinControl);
var
  BaseDir : string;
begin
  BaseDir := ExtractFilePath(ParamStr(0));
  while BaseDir<>'' do begin
    FXtagDir := BaseDir + 'x-tag\';
    if DirectoryExists(FXtagDir) then break;
    BaseDir := ExtractFilePath(ExcludeTrailingBackSlash(BaseDir));
  end;

  VirtualUI.HTMLDoc.CreateSessionURL('/x-tag/',FXtagDir);
  VirtualUI.HTMLDoc.LoadScript('/x-tag/x-tag-core.min.js','');
  VirtualUI.HTMLDoc.ImportHTML('/x-tag/vui-signature-pad/vui-signature-pad.html','');

  FSigRo := TJSObject.Create(AControl.Name);
  FSigRo.Properties.Add('data')
    .OnSet(TJSBinding.Create(
      procedure(const Parent: IJSObject; const Prop: IJSProperty)
      var Img : TGraphic;
      begin
        Img := Base64ToImg(Prop.AsString);
        try
          if Assigned(OnSignatureChanged) then
            OnSignatureChanged(Img);
        finally
          Img.Free;
        end;
      end))
    .AsString := '';
  FSigRo.Events.Add('clear');
  FSigRo.Events.Add('save').AddArgument('type',JSDT_STRING);
  FSigRo.ApplyModel;
  VirtualUI.HTMLDoc.CreateComponent(AControl.Name,'vui-signature-pad',AControl.Handle);
end;

destructor TVuiSignaturePad.Destroy;
begin
  FSigRo := nil;
  inherited;
end;

function TVuiSignaturePad.Base64ToImg(AData: String): TGraphic;
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

procedure TVuiSignaturePad.Clear;
begin
  FSigRo.Events['clear'].Fire;
end;

procedure TVuiSignaturePad.SaveToFile(const AFilename: string);
begin
  FFilename := AFilename;
  FSigRo.Events['save'].ArgumentAsString('type','png').Fire;
end;

end.
