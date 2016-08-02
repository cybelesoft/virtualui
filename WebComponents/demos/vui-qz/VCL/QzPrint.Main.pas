unit QzPrint.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, VirtualUI_SDK, Vcl.StdCtrls,
  Vcl.ExtCtrls,Httpapp, Vcl.ComCtrls,Vui.Qz;

type
  TForm1 = class(TForm)
    Button3: TButton;
    Panel1: TPanel;
    Label1: TLabel;
    cmbPrinters: TComboBox;
    Button1: TButton;
    Button2: TButton;
    Button4: TButton;
    StatusBar1: TStatusBar;
    procedure FormCreate(Sender: TObject);
    procedure cmbPrintersClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Button4Click(Sender: TObject);
  private
    { Private declarations }
    FQz : TVuiQz;
    procedure EnablePanel(Panel: TWinControl; Value: Boolean);
    procedure PrinterChanged(Sender: TObject);
    procedure StateChanged(Sender: TObject);
    procedure PrintZPLFile(AFilename: string);
  public
    { Public declarations }
  end;

var
  Form1: TForm1;


implementation
{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  EnablePanel(Panel1,false);
  FQz := TVuiQz.Create;
  FQz.OnPrinterChange := PrinterChanged;
  FQz.OnStateChange := StateChanged;
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  FQz.Free;
end;

procedure TForm1.EnablePanel(Panel:TWinControl;Value:Boolean);
var
  n : Integer;
begin
  for n := 0 to Panel.ControlCount-1 do
    Panel.Controls[n].Enabled := Value;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  FQz.Init;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  FQz.PrintPDF('assets/pdf_sample.pdf');
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  ShowMessage(FQz.QzRo.Properties['settings'].AsString);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  PrintZPLFile(ExpandFilename('..\web\assets\zpl_sample.txt'));
end;

procedure TForm1.cmbPrintersClick(Sender: TObject);
begin
  FQz.DefaultPrinter := cmbPrinters.Text;
end;

procedure TForm1.PrinterChanged(Sender: TObject);
begin
  cmbPrinters.Items.Assign(FQz.PrinterList);
  cmbPrinters.ItemIndex := cmbPrinters.Items.IndexOf(FQz.DefaultPrinter);
  EnablePanel(Panel1,true);
end;

procedure TForm1.StateChanged(Sender: TObject);
begin
  Statusbar1.Panels[0].Text := FQz.State;
end;

procedure TForm1.PrintZPLFile(AFilename:string);
var
  SL : TStringList;
  S : string;
begin
  SL := TStringList.Create;
  try
    SL.LoadFromFile(AFilename);
    FQz.BeginDoc;
    for S in SL do
      FQz.PrintText(S);
    FQz.EndDoc;
  finally
    SL.Free;
  end;

end;

end.
