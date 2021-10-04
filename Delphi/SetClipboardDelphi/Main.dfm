object FrmMain: TFrmMain
  Left = 0
  Top = 0
  Caption = 'SetClipboard example'
  ClientHeight = 110
  ClientWidth = 329
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Edit1: TEdit
    Left = 16
    Top = 24
    Width = 273
    Height = 21
    TabOrder = 0
    Text = 'Text to copy to Clipboard'
  end
  object Button1: TButton
    Left = 16
    Top = 59
    Width = 161
    Height = 25
    Caption = 'Copy to Clipboard'
    TabOrder = 1
    OnClick = Button1Click
  end
end
