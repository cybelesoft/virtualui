unit Vui.Signature.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vui.Signature.Pad.Dlg, Vcl.StdCtrls, VirtualUI_SDK;

type
  TMainForm = class(TForm)
    BtnOpenPad: TButton;
    Label1: TLabel;
    procedure BtnOpenPadClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  MainForm: TMainForm;

implementation

{$R *.dfm}

procedure TMainForm.BtnOpenPadClick(Sender: TObject);
var frmVUISignaturePadDlg: TfrmVUISignaturePadDlg;
begin
  frmVUISignaturePadDlg := TfrmVUISignaturePadDlg.Create(self);
  frmVUISignaturePadDlg.Position := poMainFormCenter;
  frmVUISignaturePadDlg.ShowModal;
  frmVUISignaturePadDlg.Free;
end;

procedure TMainForm.FormCreate(Sender: TObject);
begin
  if VirtualUI.Enabled then begin
    VirtualUI.ClientSettings.MouseMoveGestureAction := 0;
    VirtualUI.ClientSettings.MouseMoveGestureStyle := 1;
  end;
end;

end.
