object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'SetImageQualityByWnd'
  ClientHeight = 254
  ClientWidth = 686
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 44
    Height = 13
    Caption = 'Standard'
  end
  object Label2: TLabel
    Left = 248
    Top = 8
    Width = 109
    Height = 13
    Caption = 'Quality: 100 (Lossless)'
  end
  object Label3: TLabel
    Left = 488
    Top = 8
    Width = 53
    Height = 13
    Caption = 'Quality: 80'
  end
  object Label4: TLabel
    Left = 216
    Top = 216
    Width = 225
    Height = 13
    Caption = 'Note: All images are the same source (BitBlted)'
  end
  object Button1: TButton
    Left = 598
    Top = 208
    Width = 75
    Height = 25
    Caption = 'Stop'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Panel1: TPanel
    Left = 8
    Top = 32
    Width = 185
    Height = 161
    Caption = 'Panel1'
    TabOrder = 1
  end
  object Panel2: TPanel
    Left = 248
    Top = 32
    Width = 185
    Height = 161
    Caption = 'Panel1'
    TabOrder = 2
  end
  object Panel3: TPanel
    Left = 488
    Top = 32
    Width = 185
    Height = 161
    Caption = 'Panel1'
    TabOrder = 3
  end
  object CkInvertBackground: TCheckBox
    Left = 8
    Top = 212
    Width = 113
    Height = 17
    Caption = 'Invert Background'
    TabOrder = 4
    OnClick = CkInvertBackgroundClick
  end
  object Timer1: TTimer
    Interval = 100
    OnTimer = Timer1Timer
    Left = 144
    Top = 240
  end
end
