unit Vui.Signature.Pad;

interface
uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls,VirtualUI_SDK,Soap.EncdDecd,Vcl.Imaging.pngimage,Vcl.Imaging.jpeg;

type
  TVuiSignaturePad = class
  private
    FSignPadRO: TJSObject;
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
   if VirtualUI.Enabled then begin
      BaseDir := ExtractFilePath(ParamStr(0));
      while BaseDir<>'' do begin
        FXtagDir := BaseDir + 'x-tag\';
        if DirectoryExists(FXtagDir) then break;
        BaseDir := ExtractFilePath(ExcludeTrailingBackSlash(BaseDir));
      end;

      VirtualUI.HTMLDoc.CreateSessionURL('/x-tag/',FXtagDir);
      VirtualUI.HTMLDoc.LoadScript('/x-tag/x-tag-core.min.js','');
      VirtualUI.HTMLDoc.ImportHTML('/x-tag/vui-signature-pad2/vui-signature-pad.html','');

      FSignPadRO := TJSObject.Create(AControl.Name);
      FSignPadRO.Events.Add('clear');
      FSignPadRO.Events.Add('save').AddArgument('type',JSDT_STRING);
      FSignPadRO.Methods.Add('updateSignature').AddArgument('data',JSDT_STRING)
      .OnCall(TJSCallback.Create(
          procedure(const Parent: IJSObject; const Method: IJSMethod)
          var Img : TGraphic;
          begin
            Img := Base64ToImg(Method.Arguments['data'].AsString);
            try
              if Assigned(OnSignatureChanged) then
                OnSignatureChanged(Img);
            finally
              Img.Free;
            end;
          end)
      ).ReturnValue.DataType := JSDT_NULL;
      FSignPadRO.ApplyModel;
      VirtualUI.HTMLDoc.CreateComponent(AControl.Name,'vui-signature-pad',AControl.Handle);
   end;
end;

destructor TVuiSignaturePad.Destroy;
begin
  FSignPadRO := nil;
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
  // The next line fires a "clear" event message to the web, and it will be
  // catched from vui-signature-pad.html
  FSignPadRO.Events['clear'].Fire;
end;

procedure TVuiSignaturePad.SaveToFile(const AFilename: string);
begin
  FFilename := AFilename;
  FSignPadRO.Events['save'].ArgumentAsString('type','png').Fire;
end;

end.
