object frmJsROAudio: TfrmJsROAudio
  Left = 0
  Top = 0
  Caption = 'JsROAudio'
  ClientHeight = 299
  ClientWidth = 635
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
  object lblAudio: TLabel
    Left = 16
    Top = 32
    Width = 31
    Height = 13
    Caption = 'Audio:'
  end
  object cmbAudio: TComboBox
    Left = 96
    Top = 29
    Width = 521
    Height = 21
    TabOrder = 0
    OnChange = cmbAudioChange
  end
  object panelXAudio: TPanel
    Left = 16
    Top = 231
    Width = 601
    Height = 41
    BevelOuter = bvNone
    TabOrder = 1
  end
  object GroupBox1: TGroupBox
    Left = 16
    Top = 56
    Width = 601
    Height = 161
    TabOrder = 2
    object lblStatus: TLabel
      Left = 240
      Top = 21
      Width = 41
      Height = 13
      Caption = 'lblStatus'
    end
    object lblStatusCaption: TLabel
      Left = 192
      Top = 21
      Width = 35
      Height = 13
      Caption = 'Status:'
    end
    object btnPlay: TButton
      Left = 16
      Top = 16
      Width = 75
      Height = 25
      Caption = 'Play'
      TabOrder = 0
      OnClick = btnPlayClick
    end
    object btnStop: TButton
      Left = 97
      Top = 16
      Width = 75
      Height = 25
      Caption = 'Stop'
      TabOrder = 1
      OnClick = btnStopClick
    end
    object TrackBar1: TTrackBar
      Left = 16
      Top = 104
      Width = 577
      Height = 45
      TabOrder = 2
      OnChange = TrackBar1Change
    end
  end
end
