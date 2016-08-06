unit VuiWebcam.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
  Vui.Webcam,VuiWebcam.Dlg;

type
  TForm6 = class(TForm)
    Panel1: TPanel;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
    FWebcam : TVuiWebcam;
    procedure PictureChanged(Sender: TObject);
  public
    { Public declarations }
  end;

var
  Form6: TForm6;

implementation

{$R *.dfm}

procedure TForm6.FormCreate(Sender: TObject);
begin
  FWebcam := TVuiWebcam.Create;
  FWebcam.CreateComponent(Panel1);
  FWebcam.OnPictureChanged := PictureChanged;
end;

procedure TForm6.Button1Click(Sender: TObject);
begin
  FWebcam.Attach(Round(Panel1.Height * 4 / 3),Panel1.Height);
end;

procedure TForm6.Button2Click(Sender: TObject);
begin
  FWebcam.SaveToFile('');
end;

procedure TForm6.Button3Click(Sender: TObject);
begin
  if Button3.Caption = 'Freeze' then begin
    Button3.Caption := 'Unfreeze';
    FWebCam.Freeze;
  end else begin
    Button3.Caption := 'Freeze';
    FWebCam.Unfreeze;
  end;
end;

procedure TForm6.PictureChanged(Sender: TObject);
begin
  With TFrmPhotoDlg.Create(Self) do begin
    image1.Picture.Assign(TGraphic(Sender));
    ShowModal;
    free;
  end;
end;

end.
