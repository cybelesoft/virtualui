unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, StdCtrls,
  Windows,
  VirtualUI_SDK;

type

  { TMainForm }

  TMainForm = class(TForm)
    ButtonScreenshot: TButton;
    ButtonDownload: TButton;
    ButtonOpen: TButton;
    ButtonLaunch: TButton;
    ButtonOpenFile: TButton;
    ButtonSaveFile: TButton;
    ButtonShow: TButton;
    CheckStdDialogs: TCheckBox;
    EditParams: TEdit;
    EditMessage: TEdit;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    OpenDialog: TOpenDialog;
    SaveDialog: TSaveDialog;
    procedure ButtonScreenshotClick(Sender: TObject);
    procedure ButtonDownloadClick(Sender: TObject);
    procedure ButtonLaunchClick(Sender: TObject);
    procedure ButtonOpenClick(Sender: TObject);
    procedure ButtonOpenFileClick(Sender: TObject);
    procedure ButtonSaveFileClick(Sender: TObject);
    procedure ButtonShowClick(Sender: TObject);
    procedure CheckStdDialogsChange(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { private declarations }
  public
    { public declarations }
  end;

var
  MainForm: TMainForm;

implementation

{$R *.lfm}

{ TMainForm }

procedure TMainForm.FormCreate(Sender: TObject);
begin
  VirtualUI.Start();
  VirtualUI.StdDialogs := true;
  Caption := Caption + Format(' [pid=%d]',[GetCurrentProcessId]);
end;

procedure TMainForm.ButtonShowClick(Sender: TObject);
begin
  showMessage(EditMessage.Text);
end;

procedure TMainForm.ButtonOpenFileClick(Sender: TObject);
begin
  if OpenDialog.Execute then
    showMessage(OpenDialog.FileName);
end;

procedure TMainForm.ButtonLaunchClick(Sender: TObject);
var
  si: TStartupInfo;
  pi: TProcessInformation;
begin
  VirtualUI.AllowExecute(ParamStr(0));
  FillChar(pi, sizeof(TProcessInformation), 0);
  FillChar(si, sizeof(TStartupInfo), 0);
  si.cb := sizeof(TStartupInfo);
  CreateProcess(nil, PChar(trim(ParamStr(0)+' '+EditParams.Text)), nil, nil, false, NORMAL_PRIORITY_CLASS, nil, nil, si, pi);
end;

procedure TMainForm.ButtonOpenClick(Sender: TObject);
begin
  VirtualUI.DownloadFile(ExtractFilePath(ParamStr(0)) + 'test.png', '', 'image/png');
end;

procedure TMainForm.ButtonDownloadClick(Sender: TObject);
begin
  VirtualUI.DownloadFile(ExtractFilePath(ParamStr(0)) + 'test.png');
end;

procedure TMainForm.ButtonScreenshotClick(Sender: TObject);
var fileName: string;
begin
  fileName := ExtractFilePath(ParamStr(0)) + 'screenshot.png';
  if VirtualUI.TakeScreenshot(0, fileName) then
    VirtualUI.DownloadFile(fileName, '', 'image/png')
  else begin
    showMessage('Error saving to ' + fileName);
  end;
end;

procedure TMainForm.ButtonSaveFileClick(Sender: TObject);
begin
  if SaveDialog.Execute then
    showMessage(SaveDialog.FileName);
end;

procedure TMainForm.CheckStdDialogsChange(Sender: TObject);
begin
  VirtualUI.StdDialogs := CheckStdDialogs.Checked;
end;

end.

