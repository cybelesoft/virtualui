object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'HelpScript 2'
  ClientHeight = 126
  ClientWidth = 562
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
  object BHelp: TButton
    Left = 16
    Top = 91
    Width = 75
    Height = 25
    Caption = 'Launch help'
    TabOrder = 0
    OnClick = BHelpClick
  end
  object Button2: TButton
    Left = 463
    Top = 6
    Width = 75
    Height = 25
    Caption = 'Select'
    TabOrder = 1
    OnClick = Button2Click
  end
  object EdHelpFilename: TEdit
    Left = 16
    Top = 8
    Width = 441
    Height = 21
    TabOrder = 2
    Text = 'EdHelpFilename'
  end
  object OpenDialog1: TOpenDialog
    DefaultExt = '.chm'
    Filter = 'HTML Help files (*.chm)|*.chm'
    Left = 344
    Top = 40
  end
end
