unit Vui.Signature.Pad.Dlg;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls, VirtualUI_SDK,
  Vui.Signature.Pad,Vui.Saved.Signature.Dlg;

type
  TfrmVUISignaturePadDlg = class(TForm)
    Panel1: TPanel;
    btnClear: TButton;
    btnSave: TButton;
    procedure FormCreate(Sender: TObject);
    procedure btnClearClick(Sender: TObject);
    procedure btnSaveClick(Sender: TObject);
  private
    { Private declarations }
    FSigPad : TVuiSignaturePad;
    procedure SignatureChanged(Sender: TObject);
  public
    { Public declarations }
  end;

var
  frmVUISignaturePadDlg: TfrmVUISignaturePadDlg;

implementation

{$R *.dfm}

procedure TfrmVUISignaturePadDlg.btnClearClick(Sender: TObject);
begin
  FSigPad.Clear;
end;

procedure TfrmVUISignaturePadDlg.btnSaveClick(Sender: TObject);
begin
  FSigPad.SaveToFile('');
end;

procedure TfrmVUISignaturePadDlg.FormCreate(Sender: TObject);
begin
  if VirtualUI.Enabled then begin
    FSigPad := TVuiSignaturePad.Create(Panel1);
    FSigPad.OnSignatureChanged := SignatureChanged;
  end else begin
    btnClear.Enabled := false;
    BtnSave.Enabled := false;
  end;
end;

procedure TfrmVUISignaturePadDlg.SignatureChanged(Sender: TObject);
begin
  With TFrmSavedSignatureDlg.Create(Self) do begin
    image1.Picture.Assign(TGraphic(Sender));
    ShowModal;
    free;
  end;
end;

end.
