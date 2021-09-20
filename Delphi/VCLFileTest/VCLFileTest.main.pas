unit VCLFileTest.main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, VirtualUI_SDK, Vcl.StdCtrls;

type
  TMainForm = class(TForm)
    GroupBox1: TGroupBox;
    chkStdDlgs: TCheckBox;
    btnOpenFile: TButton;
    btnSaveFile: TButton;
    SaveDialog1: TSaveDialog;
    OpenDialog1: TOpenDialog;
    GroupBox2: TGroupBox;
    btnDownload: TButton;
    btnPrint: TButton;
    btnDownloadTxt: TButton;
    btnDownloadImage: TButton;
    chkFilterAllTypes: TCheckBox;
    chkFilterImageTypes: TCheckBox;
    chkFilterTextType: TCheckBox;
    btnUploadFile: TButton;
    btnMultiPrint: TButton;
    procedure chkStdDlgsClick(Sender: TObject);
    procedure btnSaveFileClick(Sender: TObject);
    procedure btnOpenFileClick(Sender: TObject);
    procedure btnDownloadClick(Sender: TObject);
    procedure btnPrintClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btnDownloadTxtClick(Sender: TObject);
    procedure btnDownloadImageClick(Sender: TObject);
    procedure checkOpenDialogFilters(Sender: TObject);
    procedure btnUploadFileClick(Sender: TObject);
    procedure btnMultiPrintClick(Sender: TObject);
  private
    { Private declarations }
    procedure InternalUploadEnd(Sender: TObject; const filename: string);
    procedure DownloadEnd(Sender: TObject; const filename: string);
  public
    { Public declarations }
  end;

var
  MainForm: TMainForm;

implementation

{$R *.dfm}

procedure TMainForm.DownloadEnd(Sender: TObject; const filename: string);
begin
  ShowMessage(Format('File %s downloaded',[Filename]));
end;

procedure TMainForm.btnDownloadClick(Sender: TObject);
begin
  VirtualUI.OnDownloadEnd := DownloadEnd;
  VirtualUI.DownloadFile(Application.ExeName);
end;

procedure TMainForm.btnDownloadImageClick(Sender: TObject);
begin
  VirtualUI.DownloadFile(ExtractFilePath(Application.ExeName) + 'Thinfinity_VirtualUI.png');
end;

procedure TMainForm.btnDownloadTxtClick(Sender: TObject);
begin
  VirtualUI.DownloadFile(ExtractFilePath(Application.ExeName) + 'vclfiletest.txt');
end;

procedure TMainForm.btnOpenFileClick(Sender: TObject);
begin
  if VirtualUI.StdDialogs then begin
    if OpenDialog1.Execute then
      ShowMessage(OpenDialog1.FileName);
  end else begin
    OpenDialog1.Execute;
  end;
end;

procedure TMainForm.btnPrintClick(Sender: TObject);
var
  Src: string;
begin
  Src := ExtractFilePath(Application.ExeName) + 'vclfiletest.pdf';
  VirtualUI.PrintPdf(Src);
end;

procedure TMainForm.btnMultiPrintClick(Sender: TObject);
begin
  VirtualUI.PrintPdf(ExtractFilePath(Application.ExeName) + 'vclfiletest.pdf');
  VirtualUI.PrintPdf(ExtractFilePath(Application.ExeName) + 'vclfiletest.txt');
end;

procedure TMainForm.btnSaveFileClick(Sender: TObject);
begin
  if SaveDialog1.Execute then
    ShowMessage(SaveDialog1.FileName);
end;

procedure TMainForm.checkOpenDialogFilters(Sender: TObject);
var filters,DefaultExt: string;
  procedure AddFilterMask(filter: string);
  begin
     if filters <> '' then
       filters := filters + '|';
     filters := filters + filter;
  end;

  procedure AddExtMask(Ext: string);
  begin
     if DefaultExt <> '' then
       DefaultExt := DefaultExt + '|';
     DefaultExt := DefaultExt + Ext;
  end;
begin
  filters := '';
  DefaultExt := '';
  if chkFilterAllTypes.Checked then begin
    AddFilterMask('All file extension|*.*');
    AddExtMask('pdf');
  end;
  if chkFilterImageTypes.Checked then begin
    AddFilterMask('Image files (gif,jpg,bmp)|*.gif;*.jp?;*.png;*.bmp');
    AddExtMask('jpg');
  end;
  if chkFilterTextType.Checked then begin
    AddFilterMask('Text files|*.txt');
    AddExtMask('txt');
  end;
  OpenDialog1.Filter := filters;
  SaveDialog1.Filter := filters;
  SaveDialog1.FilterIndex := 1;
  SaveDialog1.DefaultExt := DefaultExt;

end;

procedure TMainForm.chkStdDlgsClick(Sender: TObject);
begin
  VirtualUI.StdDialogs := chkStdDlgs.Checked;
end;

procedure TMainForm.FormCreate(Sender: TObject);
begin
  if not VirtualUI.Active then begin
    chkStdDlgs.Enabled := false;
    btnDownload.Enabled := false;
  end else begin
    chkStdDlgsClick(Sender);
    VirtualUI.OnUploadEnd := InternalUploadEnd;
    btnUploadFile.Enabled := true;
  end;
end;

procedure TMainForm.btnUploadFileClick(Sender: TObject);
begin
  VirtualUI.UploadFile;
end;

procedure TMainForm.InternalUploadEnd(Sender: TObject; const filename: string);
begin
  ShowMessage('The file ' + filename + ' was successfully uploaded');
end;

end.
