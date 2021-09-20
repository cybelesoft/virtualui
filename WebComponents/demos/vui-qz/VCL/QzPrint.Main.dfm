object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Remote Printing Test'
  ClientHeight = 224
  ClientWidth = 318
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
  object Label2: TLabel
    Left = 32
    Top = 13
    Width = 227
    Height = 26
    Caption = 'This demo requires the installation of "QZ" tray program from'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clDefault
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    WordWrap = True
  end
  object Label3: TLabel
    Left = 103
    Top = 26
    Width = 65
    Height = 13
    Cursor = crHandPoint
    Caption = 'http://qz.io'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clHotLight
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold, fsUnderline]
    ParentFont = False
    WordWrap = True
    OnClick = Label3Click
  end
  object Panel1: TPanel
    Left = 0
    Top = 83
    Width = 318
    Height = 141
    Align = alBottom
    BevelOuter = bvNone
    TabOrder = 1
    object Label1: TLabel
      Left = 32
      Top = 16
      Width = 87
      Height = 13
      Caption = 'Available Printers:'
    end
    object cmbPrinters: TComboBox
      Left = 125
      Top = 12
      Width = 164
      Height = 21
      Style = csDropDownList
      TabOrder = 0
      OnClick = cmbPrintersClick
    end
    object Button1: TButton
      Left = 34
      Top = 81
      Width = 97
      Height = 25
      Caption = 'Print PDF'
      TabOrder = 1
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 34
      Top = 50
      Width = 257
      Height = 25
      Caption = 'Show Settings'
      TabOrder = 2
      OnClick = Button2Click
    end
    object Button4: TButton
      Left = 194
      Top = 81
      Width = 97
      Height = 25
      Caption = 'Print ZPL'
      TabOrder = 3
      OnClick = Button4Click
    end
    object StatusBar1: TStatusBar
      Left = 0
      Top = 122
      Width = 318
      Height = 19
      Panels = <
        item
          Width = 100
        end>
    end
  end
  object Button3: TButton
    Left = 32
    Top = 52
    Width = 257
    Height = 25
    Caption = 'Init'
    TabOrder = 0
    OnClick = Button3Click
  end
end
