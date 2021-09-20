unit Vui.Browser.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Buttons, Vcl.ExtCtrls,Vui.Browser,
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
    procedure FormDestroy(Sender: TObject);
  private
    { Private declarations }
    FVuiBrowser : TVuiBrowser;
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
  FVuiBrowser.Go(edAddress.Text);
end;

procedure TForm7.actNextExecute(Sender: TObject);
begin
  FVuiBrowser.Next;
end;

procedure TForm7.actPrevExecute(Sender: TObject);
begin
  FVuiBrowser.Prev;
end;

procedure TForm7.FormCreate(Sender: TObject);
begin
  Init;
end;

procedure TForm7.FormDestroy(Sender: TObject);
begin
  FVuiBrowser.Free;
end;

procedure TForm7.Init;
var
  Path : string;
begin
  path := ExtractFilePath(Application.ExeName);
  FVuiBrowser := TVuiBrowser.Create(Panel2);
end;

end.
