unit FileList.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ExtCtrls, Vcl.FileCtrl, Vcl.StdCtrls,Inifiles,
  VirtualUI_SDK, Vcl.ComCtrls, System.ImageList, Vcl.ImgList, Vcl.ToolWin,
  Vcl.Buttons, ShellApi;

type
  TFrmMain = class(TForm)
    DirectoryListBox: TDirectoryListBox;
    FileListBox: TFileListBox;
    Splitter1: TSplitter;
    Panel1: TPanel;
    bApplyUser: TButton;
    Label1: TLabel;
    edUser: TEdit;
    bActivate: TButton;
    edConfigFile: TEdit;
    Label2: TLabel;
    ToolBar1: TToolBar;
    ImageList32: TImageList;
    TbCreateFolder: TToolButton;
    ToolButton2: TToolButton;
    TbCreateFile: TToolButton;
    TbRename: TToolButton;
    TbDelete: TToolButton;
    TbUpload: TToolButton;
    SpbOpenCfg: TSpeedButton;
    FileOpenDlg: TFileOpenDialog;
    BtnNewInstance: TButton;
    procedure DirectoryListBoxClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure bApplyUserClick(Sender: TObject);
    procedure bActivateClick(Sender: TObject);
    procedure TbCreateFolderClick(Sender: TObject);
    procedure TbCreateFileClick(Sender: TObject);
    procedure TbRenameClick(Sender: TObject);
    procedure TbDeleteClick(Sender: TObject);
    procedure TbUploadClick(Sender: TObject);
    procedure SpbOpenCfgClick(Sender: TObject);
    procedure BtnNewInstanceClick(Sender: TObject);
    procedure FileListBoxClick(Sender: TObject);
    procedure FileListBoxKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
  private
    procedure UpdateControls;
    procedure LoadFromIni;
    procedure SaveToIni;
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FrmMain: TFrmMain;

implementation

{$R *.dfm}

procedure TFrmMain.LoadFromIni;
var
  ini : TInifile;
begin
  Ini := TInifile.Create(ChangeFileExt(ParamStr(0),'.ini'));
  try
    edUser.Text := ini.ReadString('Last','User',edUser.text);
    edConfigFile.Text := ini.ReadString('Last','CfgFile',ExtractFilePath(ParamStr(0))+'test.vdir');
  finally
    ini.Free;
  end;
end;

procedure TFrmMain.SaveToIni;
var
  ini : TInifile;
begin
  Ini := TInifile.Create(ChangeFileExt(ParamStr(0),'.ini'));
  try
    ini.WriteString('Last','User',edUser.Text);
    ini.WriteString('Last','CfgFile',edConfigFile.Text);
  finally
    ini.Free;
  end;
end;

procedure TFrmMain.UpdateControls;
begin
  TbDelete.Enabled := FileListBox.ItemIndex <> -1;
  TbRename.Enabled := FileListBox.ItemIndex <> -1;

  if not VirtualUI.Active then begin
    bActivate.Enabled := False;
    bApplyUser.Enabled := False;
    TbUpload.Enabled := False;
    Exit;
  end;

  if VirtualUI.FileSystemFilter.Active then
    bActivate.Caption :='Deactivate'
  else
    bActivate.Caption :='Activate';
end;


procedure TFrmMain.SpbOpenCfgClick(Sender: TObject);
begin
  if FileOpenDlg.Execute then
    edConfigFile.Text := FileOpenDlg.FileName;
end;

procedure TFrmMain.bActivateClick(Sender: TObject);
begin
  if VirtualUI.FileSystemFilter.Active then
    VirtualUI.FileSystemFilter.Active := false
  else begin
    try
      SaveToIni;
    except
    end;
    VirtualUI.FileSystemFilter.CfgFile := edConfigFile.Text;
    VirtualUI.FileSystemFilter.User := edUser.text;
    VirtualUI.FileSystemFilter.Active := True;
  end;
  DirectoryListBox.Update;
  FileListBox.Directory := DirectoryListBox.GetItemPath(DirectoryListBox.ItemIndex);
  UpdateControls;
end;

procedure TFrmMain.bApplyUserClick(Sender: TObject);
begin
  VirtualUI.FileSystemFilter.User := edUser.text;
  DirectoryListBox.Update;
  FileListBox.Directory := DirectoryListBox.GetItemPath(DirectoryListBox.ItemIndex);
  UpdateControls;
end;

procedure TFrmMain.BtnNewInstanceClick(Sender: TObject);
begin
  ShellExecute(0, 'open', PChar(ParamStr(0)), nil, PChar(ExtractFilePath(ParamStr(0))), SW_SHOWNORMAL);
end;

procedure TFrmMain.TbCreateFolderClick(Sender: TObject);
var
  curDir, folderName: string;
begin
  curDir := DirectoryListBox.GetItemPath(DirectoryListBox.ItemIndex);
  folderName := 'new_folder';
  if InputQuery('Create folder', 'Create folder on '+curDir, folderName) then begin
    if CreateDirectory(PChar(curDir+'\'+folderName), nil) then
      DirectoryListBox.Update
    else begin
      Application.MessageBox(PChar(Format('Error %d: %s',[GetLastError, SysErrorMessage(GetLastError)])), 'Create folder', MB_ICONWARNING);
    end;
  end;
end;

procedure TFrmMain.TbCreateFileClick(Sender: TObject);
var
  curDir, fileName: string;
  F: THandle;
begin
  curDir := DirectoryListBox.GetItemPath(DirectoryListBox.ItemIndex);
  fileName := 'new_file.txt';
  if InputQuery('Create file', 'Create file on '+curDir, fileName) then begin
    F := CreateFile(PChar(curDir+'\'+fileName), GENERIC_WRITE, FILE_SHARE_READ or FILE_SHARE_WRITE, nil, CREATE_ALWAYS, 0, 0);
    if F = INVALID_HANDLE_VALUE then
      Application.MessageBox(PChar(Format('Error %d: %s',[GetLastError, SysErrorMessage(GetLastError)])), 'Create file', MB_ICONWARNING)
    else begin
      CloseHandle(F);
      FileListBox.Update;
    end;
  end;
end;

procedure TFrmMain.TbRenameClick(Sender: TObject);
var
  curDir, newFileName: string;
begin
  curDir := ExtractFilePath(FileListBox.FileName);
  newFileName := ExtractFileName(FileListBox.FileName);
  if InputQuery('Rename file', 'Rename '+curDir, newFileName) then begin
    if RenameFile(FileListBox.FileName, curDir+'\'+newFileName) then begin
      FileListBox.Update;
      UpdateControls;
    end
    else begin
      Application.MessageBox(PChar(Format('Error %d: %s',[GetLastError, SysErrorMessage(GetLastError)])), 'Rename file', MB_ICONWARNING)
    end;
  end;
end;

procedure TFrmMain.TbDeleteClick(Sender: TObject);
begin
  if Application.MessageBox(PChar('Delete '+FileListBox.FileName+'?'), 'Delete file', MB_ICONQUESTION+MB_YESNO) = ID_YES then begin
    if DeleteFile(FileListBox.FileName) then begin
      FileListBox.Update;
      UpdateControls;
    end
    else begin
      Application.MessageBox(PChar(Format('Error %d: %s',[GetLastError, SysErrorMessage(GetLastError)])), 'Delete file', MB_ICONWARNING)
    end;
  end;
end;

procedure TFrmMain.TbUploadClick(Sender: TObject);
var
  fileName: WideString;
begin
  // Upload to default directory and then move file.
  // Don't use UploadFile(virtualizedDestDir,filename), because
  // only app is virtualized (not the Server processing the upload).
  VirtualUI.UploadFileEx(fileName);
  if MoveFile(PChar(fileName), PChar(DirectoryListBox.GetItemPath(DirectoryListBox.ItemIndex)+'\'+ExtractFileName(fileName))) then
  begin
    FileListBox.Update;
    UpdateControls;
  end
  else begin
    Application.MessageBox(PChar(Format('Error %d: %s',[GetLastError, SysErrorMessage(GetLastError)])), 'Upload file', MB_ICONWARNING);
  end;
end;

procedure TFrmMain.DirectoryListBoxClick(Sender: TObject);
begin
  FileListBox.Directory := DirectoryListBox.GetItemPath(DirectoryListBox.ItemIndex);
  UpdateControls;
end;

procedure TFrmMain.FileListBoxClick(Sender: TObject);
begin
  UpdateControls;
end;

procedure TFrmMain.FileListBoxKeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
begin
  case Key of
    VK_F2: if TbRename.Enabled then TbRename.Click;
    VK_DELETE: if TbDelete.Enabled then TbDelete.Click;
  end;
end;

procedure TFrmMain.FormCreate(Sender: TObject);
begin
  Caption := Format('%s (PID:%u)',[Caption, GetCurrentProcessId]);
  DirectoryListbox.Directory := 'c:\';
  FileListBox.Directory := 'c:\';
  LoadFromIni;
  UpdateControls;

  VirtualUI.StdDialogs := true;
  VirtualUI.AllowExecute('.+');
end;

end.
