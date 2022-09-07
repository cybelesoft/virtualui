unit MainHelpScript;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, IniFiles;

type
  TForm1 = class(TForm)
    BHelp: TButton;
    Button2: TButton;
    EdHelpFilename: TEdit;
    OpenDialog1: TOpenDialog;
    procedure BHelpClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    function GetHelpFilename: string;
  end;

var
  Form1: TForm1;

implementation
uses
  ShellApi;
{$R *.dfm}

procedure TForm1.Button2Click(Sender: TObject);
begin
  if OpenDialog1.Execute then
    EdHelpFilename.Text := OpenDialog1.FileName;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  EdHelpFilename.Text := GetHelpFilename;
end;

function TForm1.GetHelpFilename: string;
var
  ini: TIniFile;
begin
  ini := TIniFile.Create(ChangeFileExt(ParamStr(0), '.ini'));
  try
    Result := ExpandFilename(Ini.ReadString('GENERAL','HELPFILE', ''));
  finally
    ini.Free;
  end;
end;

procedure TForm1.BHelpClick(Sender: TObject);
var
  Filename: string;
begin
  Filename := EdHelpFilename.Text;

  if HtmlHelp(GetDesktopWindow, FileName, HH_DISPLAY_TOC, 0) = 0 then
    RaiseLastOsError;
end;

end.
