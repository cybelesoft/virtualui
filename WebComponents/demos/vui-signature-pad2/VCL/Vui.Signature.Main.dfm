object MainForm: TMainForm
  Left = 0
  Top = 0
  Caption = 'VirtualUI Signature Pad Demo'
  ClientHeight = 70
  ClientWidth = 343
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
  object Label1: TLabel
    Left = 16
    Top = 8
    Width = 217
    Height = 57
    Caption = 
      'This Thinfinity VirtualUI Demo shows a mixed Delphi-Web Componen' +
      't implementation of a Signature Pad. Please, click the "Open Pad' +
      '" button to try.'
    WordWrap = True
  end
  object BtnOpenPad: TButton
    Left = 250
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Open Pad'
    TabOrder = 0
    OnClick = BtnOpenPadClick
  end
end
