object Form4: TForm4
  Left = 0
  Top = 0
  Caption = 'Form4'
  ClientHeight = 180
  ClientWidth = 450
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 16
    Top = 8
    Width = 409
    Height = 161
    Caption = 'Clipboard API Text'
    TabOrder = 0
    object Label1: TLabel
      Left = 32
      Top = 112
      Width = 149
      Height = 13
      Caption = 'Retrieved from user'#39's clipboard'
    end
    object Label2: TLabel
      Left = 208
      Top = 112
      Width = 31
      Height = 13
      Caption = 'Label2'
    end
    object Button1: TButton
      Left = 16
      Top = 32
      Width = 169
      Height = 25
      Caption = 'Copy to user'#39's clipboard'
      TabOrder = 0
      OnClick = Button1Click
    end
    object Edit1: TEdit
      Left = 208
      Top = 34
      Width = 177
      Height = 21
      TabOrder = 1
      Text = 'Text to clipboard'
    end
    object Button2: TButton
      Left = 16
      Top = 72
      Width = 169
      Height = 25
      Caption = 'Retrieve from user'#39's clipboard'
      TabOrder = 2
      OnClick = Button2Click
    end
  end
end
