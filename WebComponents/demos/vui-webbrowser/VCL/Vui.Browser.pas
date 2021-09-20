unit Vui.Browser;

interface
uses Classes,SysUtils,Controls,VirtualUI_SDK;

type
  TVuiBrowser = class
  private
    FXtagDir: string;
    FHistoryIndex : Integer;
    FHistory : TStringList;
    FRemoteBrowser : TJSObject;
    FAddress: string;
  public
    constructor Create(AControl:TWinControl);
    destructor Destroy;override;
    procedure CreateComponent(AControl:TWinControl);
    procedure Go(const Url:string);
    procedure Next;
    procedure Prev;
    property  Address:string read FAddress write FAddress;
    property  XTagDir: string read FXtagDir write FXTagDir;
  end;

implementation

{ TVuiBrowser }

constructor TVuiBrowser.Create(AControl: TWinControl);
var
  BaseDir : string;
begin
  BaseDir := ExtractFilePath(ParamStr(0));
  while BaseDir<>'' do begin
    FXtagDir := BaseDir + 'x-tag\';
    if DirectoryExists(FXtagDir) then break;
    BaseDir := ExtractFilePath(ExcludeTrailingBackSlash(BaseDir));
  end;

  CreateComponent(AControl);

  FRemoteBrowser := TJSObject.Create('browser1');
  FRemoteBrowser.Properties.Add('url').AsString := '';
  FRemoteBrowser.Events.Add('go').AddArgument('url',JSDT_STRING);
  FRemoteBrowser.Methods.Add('loadEnd').AddArgument('url',JSDT_STRING).OnCall(
    TJSCallback.Create( procedure(const Parent: IJSObject; const Method: IJSMethod)
    begin
      FHistory.Add( Method.Arguments['url'].AsString);
      FHistoryIndex := FHistory.Count-1;
      FAddress := FHistory[FHistoryIndex];
    end)
  );
  FRemoteBrowser.Methods.Add('loadStart').AddArgument('url',JSDT_STRING).OnCall(
    TJSCallback.Create( procedure(const Parent: IJSObject; const Method: IJSMethod)
    begin
//      Listbox1.Items.Add('pagehide: '+ Method.Arguments['url'].AsString);
    end)
  );
  FRemoteBrowser.ApplyModel;

  FHistory := TStringList.Create;
  FHistoryIndex := -1;
end;

procedure TVuiBrowser.CreateComponent(AControl: TWinControl);
begin
  VirtualUI.HTMLDoc.CreateSessionURL('/x-tag/',FXtagDir);
  VirtualUI.HTMLDoc.LoadScript('/x-tag/x-tag-core.min.js','');
  VirtualUI.HTMLDoc.ImportHTML('/x-tag/vui-browser/vui-browser.html','');
  VirtualUI.HTMLDoc.CreateComponent('browser1','vui-browser',AControl.Handle);
end;

destructor TVuiBrowser.Destroy;
begin

  inherited;
end;

procedure TVuiBrowser.Go(const Url: string);
begin
  FRemoteBrowser.Events['go'].ArgumentAsString('url',Url).Fire;
end;

procedure TVuiBrowser.Next;
begin
  if (FHistoryIndex=(FHistory.Count-1)) or (FHistory.Count=0) then Exit;
  Inc(FHistoryIndex);
  FRemoteBrowser.Events['go'].ArgumentAsString('url',FHistory[FHistoryIndex]).Fire;
end;

procedure TVuiBrowser.Prev;
begin
  if FHistoryIndex<1 then Exit;
  Dec(FHistoryIndex);
  FRemoteBrowser.Events['go'].ArgumentAsString('url',FHistory[FHistoryIndex]).Fire;
end;

end.
