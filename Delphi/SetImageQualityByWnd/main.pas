unit main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls, Vcl.ComCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Panel1: TPanel;
    Panel2: TPanel;
    Panel3: TPanel;
    Timer1: TTimer;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    CkInvertBackground: TCheckBox;
    Label4: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure CkInvertBackgroundClick(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
  private
    { Private declarations }
    FBmp: TBitmap;
    fLastY: Integer;
    fBackground: TColor;
    fForeground: TColor;
    procedure Step;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}
uses
  StrUtils, VirtualUI_SDK;

procedure TForm1.Button1Click(Sender: TObject);
begin
  Timer1.Enabled := Not Timer1.Enabled;
  Button1.Caption := IfThen(Timer1.Enabled, 'Stop', 'Continue');
end;

procedure TForm1.CkInvertBackgroundClick(Sender: TObject);
begin
  case CKInvertBackground.Checked of
    False: begin
      FBackGround := ClWhite;
      FForeground := ClRed;
    end;
    True: begin
      FBackGround := ClBlack;
      FForeground := ClYellow;
    end;
  end;

  with FBmp.Canvas do
  begin
    Brush.Color := FBackGround;
    FillRect(Rect(0,0,FBmp.Width, FBmp.Height));
  end;
  Step;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  FBmp := TBitmap.Create;
  FBmp.SetSize(Panel1.ClientWidth, Panel1.ClientHeight);
  FBmp.PixelFormat := pf32Bit;

  FLastY := Panel1.Height div 2;
  FBackground := ClWhite;
  FForeground := ClRed;

  // Sets Imagen quality in panels 2 and 3.
  VirtualUI.SetImageQualityByWnd(Panel2.Handle, '', 100); // LossLess PNG
  VirtualUI.SetImageQualityByWnd(Panel3.Handle, '', 80);  // JPeg 80%
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  FBmp.Free;
end;

procedure TForm1.Step;
var
  NewY: Integer;

  // Draws bitmap inside a Panel.
  procedure DrawOnPanel(bmp: TBitmap; Panel: TPanel);
  var
    dc: HDC;
  begin
    dc := GetDc(Panel.Handle);
    BitBlt(dc,0,0,Panel.Width,Panel.Height, bmp.Canvas.Handle, 0,0, SrcCopy);
    releaseDc(Panel.Handle, dc);
  end;

begin
  with FBmp.Canvas do
  begin
    // Scroll left
    BitBlt(FBmp.Canvas.Handle, 0, 0, FBmp.Width - 1, FBmp.Height, FBmp.canvas.handle, 1, 0, SRCCOPY);
    Brush.Color := FBackGround;
    FillRect(Rect(FBmp.Width-1, 0, FBmp.Width, FBmp.Height));

    // Generate new simulated point
    NewY := FLastY + Random(25) - 12;
    if NewY < 0 then
      NewY := 0;
    if NewY > FBmp.Height then
      NewY := FBmp.Height;

    // Draw new point
    moveTo(FBmp.Width - 2, FLastY);
    pen.Color := FForeground;
    LineTo(FBmp.Width -1, NewY);

    FLastY := NewY;
  end;

  // Do the actual drawing. Same image to all panels.
  DrawOnPanel(FBmp, Panel1);
  DrawOnPanel(FBmp, Panel2);
  DrawOnPanel(FBmp, Panel3);
end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
  Step;
end;

end.
