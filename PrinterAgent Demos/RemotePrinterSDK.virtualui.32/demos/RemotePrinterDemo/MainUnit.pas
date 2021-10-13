unit MainUnit;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, StrUtils,
  RemotePrinter_SDK;

type
  TMainForm = class(TForm)
    BtnPrintDoc: TButton;
    Label1: TLabel;
    EdtPrinterName: TEdit;
    Label2: TLabel;
    EdtDocTitle: TEdit;
    Memo1: TMemo;
    BtnGetPrinters: TButton;
    LboxPrinters: TListBox;
    procedure BtnPrintDocClick(Sender: TObject);
    procedure BtnGetPrintersClick(Sender: TObject);
    procedure LboxPrintersClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  MainForm: TMainForm;

implementation

{$R *.dfm}

procedure TMainForm.LboxPrintersClick(Sender: TObject);
var
  i: Integer;
  Selected: String;
begin
  for i := 0 to (LboxPrinters.Items.Count - 1) do begin
    if LboxPrinters.Selected[i] then begin
      Selected := LboxPrinters.Items[i];
      break;
    end;
  end;

  if (Selected <> String.Empty) then
    EdtPrinterName.Text := Selected;
end;

procedure TMainForm.BtnGetPrintersClick(Sender: TObject);
var
  I, ErrorCode: Integer;
  Printers,ErrorMessage: WideString;
  tmpArray: TArray<string>;
begin
  if RemotePrinter.GetPrinters(';',Printers) then begin
    tmpArray := String(Printers).Split([';']);
    for I := Low(tmpArray) to High(tmpArray) do begin
      LBoxPrinters.Items.Add(tmpArray[I]);
    end;

  end else begin
    RemotePrinter.LastError(ErrorCode, ErrorMessage);
    ShowMessage(Format('Error: [%d] "%s"',[ErrorCode, ErrorMessage]));
  end;
end;

procedure TMainForm.BtnPrintDocClick(Sender: TObject);
var
  ErrorCode: Integer;
  DocID, ErrorMessage: WideString;
  done,printing: Boolean;
begin
  done  := False;
  printing := False;

  if RemotePrinter.BeginDoc(PRINT_TYPE_RAW, EdtPrinterName.Text,EdtDocTitle.Text, PRINT_ENCODE_UTF8, DocID) then begin
    printing := True;

    if RemotePrinter.Print(DocID, WideString(Memo1.Text)) then
      if RemotePrinter.EndDoc(DocID) then begin
        done := True;
        printing := False;
        ShowMessage('done.');
      end;
  end;

  if not done then begin
    RemotePrinter.LastError(ErrorCode, ErrorMessage);
    ShowMessage(Format('Error: [%d] "%s"',[ErrorCode, ErrorMessage]));
  end;

  if printing then
    if not RemotePrinter.Abort(DocID) then begin
      RemotePrinter.LastError(ErrorCode, ErrorMessage);
      ShowMessage(Format('Error: [%d] "%s"',[ErrorCode, ErrorMessage]));
    end;

end;

end.
