object frmVUISignaturePadDlg: TfrmVUISignaturePadDlg
  Left = 0
  Top = 0
  Caption = 'VirtualUI Signature Pad Demo'
  ClientHeight = 293
  ClientWidth = 505
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poMainFormCenter
  OnCreate = FormCreate
  DesignSize = (
    505
    293)
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 24
    Top = 16
    Width = 465
    Height = 233
    Anchors = [akLeft, akTop, akRight, akBottom]
    Caption = 'Panel1'
    TabOrder = 0
  end
  object btnClear: TButton
    Left = 333
    Top = 260
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = 'Clear'
    TabOrder = 1
    OnClick = btnClearClick
  end
  object btnSave: TButton
    Left = 414
    Top = 260
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = 'Save'
    TabOrder = 2
    OnClick = btnSaveClick
  end
end
