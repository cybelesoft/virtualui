unit main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, RemotePrinter_SDK;

type
  TForm1 = class(TForm)
    btnPrintPdf: TButton;
    btnPrintXps: TButton;
    EdXPSFile: TEdit;
    EdPDFFile: TEdit;
    btnPrintDirect: TButton;
    EdDirectFile: TEdit;
    BtnOpenXPS: TButton;
    OpenFilesDialog: TOpenDialog;
    BtnOpenPDF: TButton;
    BtnOpenFile: TButton;
    EdtPrinterName: TEdit;
    LboxPrinters: TListBox;
    BtnGetPrinters: TButton;
    Label1: TLabel;
    procedure btnPrintXpsClick(Sender: TObject);
    procedure btnPrintPdfClick(Sender: TObject);
    procedure btnPrintDirectClick(Sender: TObject);
    procedure BtnOpenXPSClick(Sender: TObject);
    procedure BtnOpenPDFClick(Sender: TObject);
    procedure BtnOpenFileClick(Sender: TObject);
    procedure BtnGetPrintersClick(Sender: TObject);
    procedure LboxPrintersClick(Sender: TObject);
  private
    { Private declarations }
    FErrorCode: Integer;
    FErrorMessage: WideString;
  public
    { Public declarations }
    function CheckFileExists(const Filename: string): Boolean;
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.BtnOpenPDFClick(Sender: TObject);
begin
  OpenFilesDialog.Title := 'Select a PDF File';
  OpenFilesDialog.InitialDir := ExtractFilePath(Application.ExeName);
  OpenFilesDialog.Filter := 'Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*';
  if OpenFilesDialog.Execute then
    EdPDFFile.Text := OpenFilesDialog.FileName;
end;

procedure TForm1.BtnOpenXPSClick(Sender: TObject);
begin
  OpenFilesDialog.Title := 'Select a XPS File';
  OpenFilesDialog.InitialDir := ExtractFilePath(Application.ExeName);
  OpenFilesDialog.Filter := 'Xps files (*.xps)|*.xps|Oxps files(*.oxps)|*.oxps|All files (*.*)|*.*';
  if OpenFilesDialog.Execute then
    EdXPSFile.Text := OpenFilesDialog.FileName;
end;

procedure TForm1.BtnOpenFileClick(Sender: TObject);
begin
  OpenFilesDialog.Title := 'Select a RAW File';
  OpenFilesDialog.InitialDir := ExtractFilePath(Application.ExeName);
  OpenFilesDialog.Filter := 'All files (*.*)|*.*';
  if OpenFilesDialog.Execute then
    EdDirectFile.Text := OpenFilesDialog.FileName;
end;

procedure TForm1.btnPrintPdfClick(Sender: TObject);
begin
  if not CheckFileExists(EdPdfFile.Text) then Exit;
  if not RemotePrinter.PrintFile(PRINT_TYPE_PDF, EdPdfFile.Text, EdtPrinterName.Text) then begin//'pdf'
    RemotePrinter.LastError(FErrorCode, FErrorMessage);
    ShowMessage(Format('Error: [%d] "%s"',[FErrorCode, FErrorMessage]));
  end else begin
    ShowMessage('done.');
  end;
end;

procedure TForm1.btnPrintXpsClick(Sender: TObject);
begin
  if not CheckFileExists(EdXpsFile.Text) then Exit;
  if not RemotePrinter.PrintFile(PRINT_TYPE_XPS, EdXpsFile.Text, EdtPrinterName.Text) then begin//'xps'
      RemotePrinter.LastError(FErrorCode, FErrorMessage);
    ShowMessage(Format('Error: [%d] "%s"',[FErrorCode, FErrorMessage]));
  end else begin
    ShowMessage('done.');
  end;
end;

procedure TForm1.btnPrintDirectClick(Sender: TObject);
begin
  if not CheckFileExists(EdDirectFile.Text) then Exit;
  if not RemotePrinter.PrintFile(PRINT_TYPE_DIRECT, EdDirectFile.Text, EdtPrinterName.Text) then begin//'pdf direct'
    RemotePrinter.LastError(FErrorCode, FErrorMessage);
    ShowMessage(Format('Error: [%d] "%s"',[FErrorCode, FErrorMessage]));
  end else begin
    ShowMessage('done.');
  end;
end;

function TForm1.CheckFileExists(const Filename: string): Boolean;
begin
  Result := False;
  if not FileExists(Filename) then
    MessageBox(Handle, PChar(Format('File %s does not exist',[Filename])), 'Error',
      MB_ICONERROR + MB_OK)
  else Result := True;
end;

procedure TForm1.BtnGetPrintersClick(Sender: TObject);
var
  I, ErrorCode: Integer;
  Printers,ErrorMessage: WideString;
  tmpArray: TArray<string>;
begin
  LBoxPrinters.Items.Clear;
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

procedure TForm1.LboxPrintersClick(Sender: TObject);
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

end.
