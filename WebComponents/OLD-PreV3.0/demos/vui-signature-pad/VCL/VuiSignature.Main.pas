unit VuiSignature.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
  Vui.Signature.Pad,VuiSignature.Dlg;

type
  TForm6 = class(TForm)
    Panel1: TPanel;
    Button1: TButton;
    Button2: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
    FSig : TVuiSignaturePad;
    procedure SignatureChanged(Sender: TObject);
  public
    { Public declarations }
  end;

var
  Form6: TForm6;

implementation

{$R *.dfm}

procedure TForm6.Button1Click(Sender: TObject);
begin
  FSig.Clear;
end;

procedure TForm6.Button2Click(Sender: TObject);
begin
  FSig.SaveToFile('');
end;

procedure TForm6.FormCreate(Sender: TObject);
begin
  FSig := TVuiSignaturePad.Create(Panel1);
  FSig.OnSignatureChanged := SignatureChanged;
end;

procedure TForm6.SignatureChanged(Sender: TObject);
begin
  With TFrmSignatureDlg.Create(Self) do begin
    image1.Picture.Assign(TGraphic(Sender));
    ShowModal;
    free;
  end;
end;

end.
