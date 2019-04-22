unit Vui.Qz;

interface
uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  VirtualUI_SDK;

type
  TVuiQz = class
  private
    FQzRo: TJSObject;
    FDefaultPrinter : string;
    FPrintLines : string;
    FPrinterList : TStringList;
    FOnPrinterChange: TNotifyEvent;
    FState: string;
    FOnStateChange: TNotifyEvent;
    FXtagDir: string;
    procedure SetDefaultPrinter(const Value: string);
    function GetActive: boolean;
    function Encode(const str: UnicodeString): string;
    procedure AddRow(ARow: string);
  public
    constructor Create;
    destructor Destroy;override;
    procedure Init(ACertificate: string = ''; APrivateKey: string = '');
    procedure BeginDoc;
    procedure EndDoc;
    procedure PrintPDF(AFilename: string);
    procedure PrintText(AData: string);
    procedure PrintF(ADataType, AFormat, AData, AOptions: string);
    property  XTagDir: string read FXtagDir write FXTagDir;
    property  QzRo: TJSObject read FQzRo;
    property  Active: boolean read GetActive;
    property  DefaultPrinter:string read FDefaultPrinter write SetDefaultPrinter;
    property  PrinterList:TStringList read FPrinterList;
    property  State: string read FState write FState;
    property  OnPrinterChange:TNotifyEvent read FOnPrinterChange write FOnPrinterChange;
    property  OnStateChange:TNotifyEvent read FOnStateChange write FOnStateChange;
  end;

implementation


{ TVuiQz }

{ ===============
* TVuiQz.Create
* ===============
* Creates the jsRO object with their properties, methods and events.
* Creates the StringList to contain the received printer list.
}
constructor TVuiQz.Create;
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
  VirtualUI.HTMLDoc.ImportHTML('/x-tag/vui-qz/vui-qz.html','');
  FPrinterList := TStringList.Create;

  FQzRo := TJSObject.Create('qzro');
  FQzRo.Properties.Add('settings').AsJSON := '{}';
  FQzRo.Properties.Add('printers')
    .OnSet(TJSBinding.Create(
      procedure(const Parent: IJSObject; const Prop: IJSProperty)
        begin
          FPrinterList.Text := StringReplace(Prop.AsString,',',#13#10,[rfReplaceAll]);
        end))
    .AsString := '';
  FQzRo.Properties.Add('default')
    .OnSet(TJSBinding.Create(
      procedure(const Parent: IJSObject; const Prop: IJSProperty)
        begin
          FDefaultPrinter := Prop.AsString;
          if Assigned(FOnPrinterChange) then
            FOnPrinterChange(Self);
        end))
    .AsString := '';
  FQzRo.Properties.Add('state')
    .OnSet(TJSBinding.Create(
      procedure(const Parent: IJSObject; const Prop: IJSProperty)
        begin
          FState := Prop.AsString;
          if Assigned(FOnStateChange) then
            FOnStateChange(Self);
        end))
    .AsString := '';
  FQzRo.Events.Add('init')
    .AddArgument('certificate',JSDT_STRING)
    .AddArgument('privateKey',JSDT_STRING);
  FQzRo.Events.Add('print')
    .AddArgument('printer',JSDT_STRING)
    .AddArgument('contentType',JSDT_STRING)
    .AddArgument('data',JSDT_STRING);
  FQzRo.ApplyModel;
  VirtualUI.HTMLDoc.CreateComponent('qzprint','vui-qz',0);
end;

{ ================
* TVuiQz.Destroy
* ================
* Creates the jsRO object with their properties, methods and events.
* Creates the StringList to contain the received printer list.
}
destructor TVuiQz.Destroy;
begin
  FQzRo := nil;
  FPrinterList.Free;
  inherited;
end;

{ =================
* TVuiQz.BeginDoc
* =================
* Initializes the internal printing buffer string.
}
procedure TVuiQz.BeginDoc;
begin
  FPrintLines := '';
end;

{ =================
* TVuiQz.EndDoc
* =================
* Sends the internal buffer string as RAW content to the remote printer
* by firing the 'print' jsRO message event.
}
procedure TVuiQz.EndDoc;
var
  data : String;
begin
  data := '['+FPrintLines+']';
  FQzRo.Events['print']
    .ArgumentAsString('printer',FDefaultPrinter)
    .ArgumentAsString('contentType','raw')
    .ArgumentAsString('data',data)
    .Fire;
end;

{ =============
* TVuiQz.Init
* =============
* Fires the 'init' jsRO message event to send it to the browser.
}
procedure TVuiQz.Init(ACertificate, APrivateKey: string);
begin
  FQzRo.Events['init']
    .ArgumentAsString('certificate',ACertificate)
    .ArgumentAsString('privateKey',APrivateKey)
    .Fire;
end;

{ =================
* TVuiQz.PrintPDF
* =================
* Sends a PDF file to the remote printer
* by firing the 'print' jsRO message event.
* Parameter:
*   AFileName: string - Name of the file to print
}
procedure TVuiQz.PrintPDF(AFilename:string);
var
  SafeURL, Cookie: string;
begin
  SafeURL := VirtualUI.HTMLDoc.GetSafeURL(AFilename, 10);
  Cookie := VirtualUI.BrowserInfo.GetCookie('GWSID');
  if Cookie <> '' then
    SafeURL := SafeURL + '?_gwsid=' + Cookie;
  FQzRo.Events['print']
    .ArgumentAsString('printer',FDefaultPrinter)
    .ArgumentAsString('contentType','pdf')
    .ArgumentAsString('data',SafeURL)
    .Fire;
end;

{ ==================
* TVuiQz.PrintText
* ==================
* Adds text content to the internal printing buffer string.
* The printing buffer string will be sent to the remote printer
* by using the EndDoc method.
* Parameter:
*   AData (string) - text to be added to the buffer.
}
procedure TVuiQz.PrintText(AData:string);
begin
  AddRow('"'+Encode(AData)+'"');
end;

{ ===============
* TVuiQz.PrintF
* ===============
* Adds formatted text content to the internal printing buffer string.
* The formatted text will be saved as a JSON object and
* the printing data will be encoded.
* The printing buffer string will be sent to the remote printer
* by using the EndDoc method.
* Parameter:
*   ADataType (string) -
*   AFormat (string)   -
*   AData (string)     - text to be added to the buffer.
*   AOptions (string)  -
}
procedure TVuiQz.PrintF(ADataType,AFormat,AData,AOptions:string);
var
  row : string;
begin
  row := Format('{"type":"%s","data":"%s"',[ADataType.ToLower,AFormat.ToLower,Encode(AData)]);
  if AOptions='' then row := Format('%s}',[row])
  else                row := Format('%s,"options":{%s}}',[AOptions]);
  AddRow(Row);
end;

{ private methods }

function TVuiQz.GetActive: boolean;
begin
  Result := FState = 'active';
end;

procedure TVuiQz.AddRow(ARow:string);
begin
  if FPrintLines<>'' then
    FPrintLines := FPrintLines + ',' + ARow
  else FPrintLines := FPrintLines + ARow;
end;

procedure TVuiQz.SetDefaultPrinter(const Value: string);
begin
  FDefaultPrinter := Value;
end;

function TVuiQz.Encode(const str : UnicodeString):string;

   function WriteUTF16(c : Integer): string;
   const
      cIntToHex : array [0..15] of WideChar = (
         '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F');
   begin
     SetLength(Result,6);
     Result[1]:='\';
     Result[2]:='u';
     Result[3]:=cIntToHex[c shr 12];
     Result[4]:=cIntToHex[(c shr 8) and $F];
     Result[5]:=cIntToHex[(c shr 4) and $F];
     Result[6]:=cIntToHex[c and $F];
   end;

var
   c : WideChar;
   p : PWideChar;
begin
   Result := '';
   p:=PWideChar(Pointer(str));
   if p<>nil then while True do begin
      c:=p^;
      case Ord(c) of
         0..31 :
            case Ord(c) of
               0 : Break;
               8 : Result := Result + '\b';
               9 : Result := Result + '\t';
               10 : Result := Result + '\n';
               12 : Result := Result + '\f';
               13 : Result := Result + '\r';
            else
               Result := Result + WriteUTF16(Ord(c));
            end;
         Ord('"') :
            Result := Result + '\"';
         Ord('\') :
            Result := Result + '\\';
         $100..$FFFF :
            Result := Result + WriteUTF16(Ord(c));
      else
         Result := Result + p^;
      end;
      Inc(p);
   end;
end;

end.
