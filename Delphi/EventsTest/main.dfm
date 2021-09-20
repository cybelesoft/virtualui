object FormMain: TFormMain
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 'VirtualUI - Events test'
  ClientHeight = 332
  ClientWidth = 581
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
  object LblTestDir: TLabel
    Left = 8
    Top = 8
    Width = 71
    Height = 13
    Caption = 'Test directory:'
  end
  object Label1: TLabel
    Left = 8
    Top = 88
    Width = 54
    Height = 13
    Caption = 'Events log:'
  end
  object Label2: TLabel
    Left = 120
    Top = 71
    Width = 120
    Height = 13
    Caption = '(or drag files to browser)'
    Color = clBtnFace
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clGrayText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentColor = False
    ParentFont = False
  end
  object MemoLog: TMemo
    Left = 8
    Top = 107
    Width = 565
    Height = 194
    Color = clBtnFace
    ReadOnly = True
    ScrollBars = ssVertical
    TabOrder = 2
  end
  object BtnDownload: TButton
    Left = 8
    Top = 40
    Width = 97
    Height = 25
    Caption = 'DownloadFile'
    TabOrder = 0
    OnClick = BtnDownloadClick
  end
  object BtnUpload: TButton
    Left = 120
    Top = 40
    Width = 97
    Height = 25
    Caption = 'Uploadfile'
    TabOrder = 1
    OnClick = BtnUploadClick
  end
  object CheckRemoveTestDir: TCheckBox
    Left = 8
    Top = 307
    Width = 193
    Height = 17
    Caption = 'Remove Test directory on close'
    Checked = True
    State = cbChecked
    TabOrder = 3
  end
  object CheckSaveLog: TCheckBox
    Left = 224
    Top = 307
    Width = 257
    Height = 17
    Caption = 'Save log to VirtualUI_Events_PID.txt'
    Checked = True
    State = cbChecked
    TabOrder = 4
  end
end
