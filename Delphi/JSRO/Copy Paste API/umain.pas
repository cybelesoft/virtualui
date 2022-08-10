unit umain;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, VirtualUI_SDK;

type
  TForm4 = class(TForm)
    GroupBox1: TGroupBox;
    Button1: TButton;
    Edit1: TEdit;
    Button2: TButton;
    Label1: TLabel;
    Label2: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    ro: TJSObject;
    procedure HandleOnPropertyChange(const Sender: IJSObject; const Prop: IJSProperty);
    function GetWebDir: string;
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

procedure TForm4.Button1Click(Sender: TObject);
begin
  ro.Properties['writeText'].AsString := Edit1.Text;
  ro.Events['JsROCopy'].Fire();
end;

procedure TForm4.Button2Click(Sender: TObject);
begin
  ro.Events['JsROPaste'].Fire();
end;

procedure TForm4.FormCreate(Sender: TObject);
var
  WebDir: string;
begin
  // Creates object with "ro" ID . In the clphandler.js , it's the 'ro = null'.
  ro := TJSObject.Create('ro');

  //Creates all events
  ro.Events.Add('JsROCopy');
  ro.Events.Add('JsROPaste');

  //Creates all properties
  ro.Properties.Add('writeText').AsString := '';
  ro.Properties.Add('readText').AsString := '';


  //Event that handles property change
  ro.OnPropertyChange := HandleOnPropertyChange;

  //Applies model to the browser
  ro.ApplyModel();

  WebDir := GetWebDir();

  VirtualUI.HTMLDoc.CreateSessionURL('/web/', WebDir);
  VirtualUI.HTMLDoc.LoadScript('web/clphandler.js', '');
end;

function TForm4.GetWebDir: string;
const
  dirs: Array of string = ['.','..','..\..'];
begin
  for var dir in dirs do
  begin
    var aux : string := ExpandFilename(dir+'\web');
    if DirectoryExists(aux) then
      Exit(Aux);
  end;
  raise Exception.Create('Could not find web directory');
end;

procedure TForm4.HandleOnPropertyChange(const Sender: IJSObject; const Prop: IJSProperty);
begin
  if (Prop.Name = 'readText') then
    Label2.Caption := Prop.AsString;
end;

end.
