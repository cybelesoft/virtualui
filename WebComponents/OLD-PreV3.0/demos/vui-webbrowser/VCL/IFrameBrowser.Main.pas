unit IFrameBrowser.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Buttons, Vcl.ExtCtrls,
  System.Actions, Vcl.ActnList,VirtualUI_SDK;

type
  TForm7 = class(TForm)
    ActionList: TActionList;
    actPrev: TAction;
    actNext: TAction;
    actHome: TAction;
    actReload: TAction;
    actGoTo: TAction;
    actGetSource: TAction;
    actGetText: TAction;
    actZoomIn: TAction;
    actZoomOut: TAction;
    actZoomReset: TAction;
    actExecuteJS: TAction;
    actDom: TAction;
    actDevTool: TAction;
    actDoc: TAction;
    actGroup: TAction;
    actFileScheme: TAction;
    actPrint: TAction;
    Panel1: TPanel;
    SpeedButton1: TSpeedButton;
    SpeedButton2: TSpeedButton;
    SpeedButton3: TSpeedButton;
    SpeedButton4: TSpeedButton;
    SpeedButton5: TSpeedButton;
    edAddress: TEdit;
    Panel2: TPanel;
    procedure actGoToExecute(Sender: TObject);
    procedure actPrevExecute(Sender: TObject);
    procedure actNextExecute(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
    FHistoryIndex : Integer;
    FHistory : TStringList;
    FRemoteBrowser : TJSObject;
    procedure Init;
  public
    { Public declarations }
  end;

var
  Form7: TForm7;

implementation

{$R *.dfm}

procedure TForm7.actGoToExecute(Sender: TObject);
begin
  FRemoteBrowser.Events['go'].ArgumentAsString('url',edAddress.Text).Fire;
end;

procedure TForm7.actNextExecute(Sender: TObject);
begin
  if (FHistoryIndex=(FHistory.Count-1)) or (FHistory.Count=0) then Exit;
  Inc(FHistoryIndex);
  FRemoteBrowser.Events['go'].ArgumentAsString('url',FHistory[FHistoryIndex]).Fire;
end;

procedure TForm7.actPrevExecute(Sender: TObject);
begin
  if FHistoryIndex<1 then Exit;
  Dec(FHistoryIndex);
  FRemoteBrowser.Events['go'].ArgumentAsString('url',FHistory[FHistoryIndex]).Fire;
end;

procedure TForm7.FormCreate(Sender: TObject);
begin
  Init;
end;

procedure TForm7.Init;
var
  Path : string;
begin
  path := ExtractFilePath(Application.ExeName);
  VirtualUI.HTMLDoc.LoadScript('/x-tag/x-tag-no-polyfills.min.js',path+'..\x-tag\x-tag-no-polyfills.min.js');
  VirtualUI.HTMLDoc.ImportHTML('/x-tag/vui-webbrowser.html',path+'..\x-tag\vui-webbrowser\vui-webbrowser.html');
  VirtualUI.HTMLDoc.CreateComponent('browser1','vui-webbrowser',Panel2.Handle);
  FRemoteBrowser := TJSObject.Create('browser1');
  FRemoteBrowser.Properties.Add('url').AsString := '';
  FRemoteBrowser.Events.Add('go').AddArgument('url',JSDT_STRING);
  FRemoteBrowser.Methods.Add('loadEnd').AddArgument('url',JSDT_STRING).OnCall(
    TJSCallback.Create( procedure(const Parent: IJSObject; const Method: IJSMethod)
    begin
      FHistory.Add( Method.Arguments['url'].AsString);
      FHistoryIndex := FHistory.Count-1;
      edAddress.Text := FHistory[FHistoryIndex];
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

end.
