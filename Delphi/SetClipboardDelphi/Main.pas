unit Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, System.JSON, VirtualUI_SDK;

type
  TFrmMain = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    procedure CopyTextToClipboard(const s: string);
  end;

var
  FrmMain: TFrmMain;

implementation

{$R *.dfm}

procedure TFrmMain.Button1Click(Sender: TObject);
begin
  if VirtualUI.Active then
  begin
    CopyTextToClipboard(Edit1.Text)
  end else
  begin
    Edit1.SelectAll;
    Edit1.CopyToClipboard;
  end;
end;

procedure TFrmMain.CopyTextToClipboard(const s: string);
var
  jo: TJSonObject;
begin
  jo := TJsonObject.Create;
  try
    jo.AddPair('Action','copy');
    jo.AddPair('Type','text/plain');
    jo.AddPair('Text',s);
    VirtualUI.SendMessage(jo.ToJson);
  finally
    jo.Free;
  end;
end;

end.
