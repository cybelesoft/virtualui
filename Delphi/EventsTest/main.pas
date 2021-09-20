unit main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs,
  VirtualUI_SDK, Vcl.StdCtrls;

type
  TFormMain = class(TForm)
    LblTestDir: TLabel;
    Label1: TLabel;
    MemoLog: TMemo;
    BtnDownload: TButton;
    BtnUpload: TButton;
    Label2: TLabel;
    CheckRemoveTestDir: TCheckBox;
    CheckSaveLog: TCheckBox;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure BtnDownloadClick(Sender: TObject);
    procedure BtnUploadClick(Sender: TObject);
  private
    { Private declarations }
    FTestDir: String;
    FLogFileName: string;
    procedure PrepareTestDir;
    procedure RemoveTestDir;
    procedure Log(const AData: string);

    procedure EvtGetUploadDir(Sender: TObject; var Directory: string; var Handled: Boolean);
    procedure EvtBrowserResize(Sender: TObject; var Width, Height: Integer; var ResizeMaximized: Boolean);
    procedure EvtReceiveMessage(Sender: TObject; Data: string);
    procedure EvtClose(Sender: TObject);
    procedure EvtDownloadEnd(Sender: TObject; const filename: string);
    procedure EvtUploadEnd(Sender: TObject; const filename: string);
    procedure EvtSaveDialog(Sender: TObject; const filename: string);
    procedure EvtRecorderChanged(Sender: TObject);
    procedure EvtOnDragFile(Action: DragAction; X, Y: Integer; const Filenames: string);
    procedure EvtOnDragFile2(Action: DragAction; ScreenX, ScreenY: Integer; const Filenames: string; out Accept: Boolean);
    procedure EvtOnDropFile(ScreenX, ScreenY: Integer; const Filenames, FileSizes: string; out IgnoreFiles: string);
  public
    { Public declarations }
  end;

var
  FormMain: TFormMain;

implementation

{$R *.dfm}

procedure TFormMain.PrepareTestDir;
var
  F: TFileStream;
  Data: AnsiString;
begin
  FTestDir := ExtractFilePath(ParamStr(0)) + 'test_' + IntToStr(GetCurrentProcessId) + '\';
  LblTestDir.Caption := 'Test directory: ' + FTestDir;

  // Create test directory:
  if not ForceDirectories(FTestDir) then begin
    LblTestDir.Caption := 'Error creating ' + FTestDir;
    Exit;
  end;

  // Create subdir for uploads:
  if not ForceDirectories(FTestDir + 'Uploads') then begin
    LblTestDir.Caption := 'Error creating ' + FTestDir + 'Uploads';
    Exit;
  end;

  // Create text file to be downloaded:
  Data := Format('File to download by PID %u',[GetCurrentProcessId]);
  F := TFileStream.Create(FTestDir+'test.txt', fmCreate);
  F.Write(Data[1], length(Data));
  F.Free;
end;

procedure TFormMain.RemoveTestDir;
  procedure DoRemoveDir(const APath: string);
  var
    F: TSearchRec;
  begin
    if FindFirst(IncludeTrailingPathDelimiter(APath)+'*.*', faAnyFile, F) = 0 then
    begin
      repeat
        if (F.Name = '.') or (F.Name = '..') then
          continue;
        if F.Attr and faDirectory = faDirectory then
          DoRemoveDir(IncludeTrailingPathDelimiter(APath) + F.Name)
        else begin
          DeleteFile(IncludeTrailingPathDelimiter(APath) + F.Name);
        end;
      until FindNext(F) <> 0;
      FindClose(F);
    end;
    RemoveDir(APath);
  end;
begin
  if FTestDir = '' then Exit;
  DoRemoveDir(FTestDir);
end;

procedure TFormMain.Log(const AData: string);
var
  F: TFileStream;
  B: TBytes;
begin
  MemoLog.Lines.Add(AData);
  if CheckSaveLog.Checked then begin
    if FileExists(FLogFileName) then begin
      F := TFileStream.Create(FLogFileName, fmOpenReadWrite);
      F.Seek(0, soFromEnd);
    end
    else begin
      F := TFileStream.Create(FLogFileName, fmCreate);
    end;

    B := TEncoding.Default.GetBytes(AData+#13#10);
    F.Write(B, length(B));
    F.Free;
  end;
end;


procedure TFormMain.EvtBrowserResize(Sender: TObject; var Width, Height: Integer; var ResizeMaximized: Boolean);
begin
  Log(Format('OnBrowserResize: %dx%d',[Width,Height]));
end;

procedure TFormMain.EvtClose(Sender: TObject);
begin
  Log('OnClose');
  Close;
end;

procedure TFormMain.EvtDownloadEnd(Sender: TObject; const filename: string);
begin
  Log('OnDownloadEnd: '+filename);
end;

procedure TFormMain.EvtGetUploadDir(Sender: TObject; var Directory: string; var Handled: Boolean);
begin
  Directory := FTestDir + 'Uploads\';
  Handled := True;
  Log('OnGetUploadDir: Set '+Directory);
end;

procedure TFormMain.EvtUploadEnd(Sender: TObject; const filename: string);
begin
  Log('OnUploadEnd: '+filename);
end;

procedure TFormMain.EvtSaveDialog(Sender: TObject; const filename: string);
begin
  Log('OnSaveDialog: '+filename);
end;

procedure TFormMain.EvtOnDragFile(Action: DragAction; X, Y: Integer; const Filenames: string);
begin
  // Using OnDragFile2
end;

procedure TFormMain.EvtOnDragFile2(Action: DragAction; ScreenX, ScreenY: Integer; const Filenames: string; out Accept: Boolean);
  function DragActionStr(Action: DragAction): string;
  begin
    Result := 'Unknown';
    case Action of
      DA_START: Result := 'Start';
      DA_OVER: Result := 'Over';
      DA_DROP: Result := 'Drop';
      DA_CANCEL: Result := 'Cancel';
      DA_ERROR: Result := 'Error';
    end;
  end;
var
  Info: string;
begin
  Info := Format('OnDragFile2: %s on %d.%d',[DragActionStr(Action),ScreenX,ScreenY]);
  if Filenames <> '' then
    Info := Info + ' (Files:' + Filenames + ')';
  Log(Info);

  Accept := True;
end;

procedure TFormMain.EvtOnDropFile(ScreenX, ScreenY: Integer; const Filenames, FileSizes: string; out IgnoreFiles: string);
var
  Info: string;
begin
  Info := Format('OnDropFile: %d.%d',[ScreenX,ScreenY]);
  if Filenames <> '' then
    Info := Info + ' (Files:' + Filenames + ')';
  if FileSizes <> '' then
    Info := Info + ' (Sizes:' + FileSizes + ')';
  Log(Info);

  //TODO: Test IgnoreFiles (Set in the form: "ignore1.txt|ignore2.log|ignoreN.exe")
  VirtualUI.UploadFile;
end;

procedure TFormMain.EvtReceiveMessage(Sender: TObject; Data: string);
begin
  Log('OnReceiveMessage: '+Data);
end;

procedure TFormMain.EvtRecorderChanged(Sender: TObject);
begin
  Log('RecorderChanged');
end;


procedure TFormMain.FormCreate(Sender: TObject);
begin
  VirtualUI.Start;
  VirtualUI.OnGetUploadDir := EvtGetUploadDir;
  VirtualUI.OnBrowserResize := EvtBrowserResize;
  VirtualUI.OnClose := EvtClose;
  VirtualUI.OnDownloadEnd := EvtDownloadEnd;
  VirtualUI.OnUploadEnd := EvtUploadEnd;
  VirtualUI.OnSaveDialog := EvtSaveDialog;
  VirtualUI.OnDragFile := EvtOnDragFile;
  VirtualUI.OnDragFile2 := EvtOnDragFile2;
  VirtualUI.OnDropFile := EvtOnDropFile;

  // Currently not tested on this app:
  VirtualUI.OnReceiveMessage := EvtReceiveMessage;
  VirtualUI.OnRecorderChanged := EvtRecorderChanged;

  PrepareTestDir;
  FLogFileName := ExtractFilePath(ParamStr(0)) + Format('VirtualUI_Events_%u.txt',[GetCurrentProcessId]);
  CheckSaveLog.Caption := 'Save log to ' + ExtractFileName(FLogFileName);
end;

procedure TFormMain.FormDestroy(Sender: TObject);
begin
  if CheckRemoveTestDir.Checked then
    RemoveTestDir;
end;

procedure TFormMain.BtnDownloadClick(Sender: TObject);
begin
  VirtualUI.DownloadFile(FTestDir + 'test.txt');
end;

procedure TFormMain.BtnUploadClick(Sender: TObject);
begin
  VirtualUI.UploadFile;
end;

end.
