object Form6: TForm6
  Left = 0
  Top = 0
  BorderStyle = bsDialog
  Caption = 'Form6'
  ClientHeight = 308
  ClientWidth = 367
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnCreate = FormCreate
  DesignSize = (
    367
    308)
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 20
    Top = 16
    Width = 330
    Height = 250
    Anchors = [akLeft, akTop, akRight, akBottom]
    Caption = 'Panel1'
    TabOrder = 0
  end
  object Button1: TButton
    Left = 113
    Top = 275
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = 'Attach'
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 275
    Top = 275
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = 'Save'
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 194
    Top = 275
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = 'Freeze'
    TabOrder = 3
    OnClick = Button3Click
  end
end
