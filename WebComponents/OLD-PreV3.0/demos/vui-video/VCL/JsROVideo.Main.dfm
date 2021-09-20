object Form5: TForm5
  Left = 0
  Top = 0
  Caption = 'Form5'
  ClientHeight = 464
  ClientWidth = 684
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  DesignSize = (
    684
    464)
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 18
    Width = 23
    Height = 13
    Caption = 'URL:'
  end
  object cbUrl: TComboBox
    Left = 56
    Top = 15
    Width = 562
    Height = 21
    Style = csDropDownList
    Anchors = [akLeft, akTop, akRight]
    TabOrder = 0
    Items.Strings = (
      
        'http://www.sample-videos.com/video/mp4/480/big_buck_bunny_480p_2' +
        'mb.mp4'
      
        'http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_' +
        'H264_AAC_25fps_7200K.MP4'
      
        'http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_' +
        'H264_AAC_25fps_7200K_short.MP4'
      
        'http://download.openbricks.org/sample/H264/h264_Linkin_Park-Leav' +
        'e_Out_All_The_Rest.mp4'
      
        'http://download.wavetlan.com/SVV/Media/HTTP/H264/Talkinghead_Med' +
        'ia/H264_test1_Talkinghead_mp4_480x360.mp4'
      
        'http://download.wavetlan.com/SVV/Media/HTTP/H264/Talkinghead_Med' +
        'ia/H264_test3_Talkingheadclipped_mp4_480x360.mp4')
  end
  object bGo: TButton
    Left = 624
    Top = 13
    Width = 52
    Height = 25
    Anchors = [akTop, akRight]
    Caption = 'Go'
    TabOrder = 1
    OnClick = bGoClick
  end
  object Panel1: TPanel
    Left = 8
    Top = 118
    Width = 668
    Height = 338
    Anchors = [akLeft, akTop, akRight, akBottom]
    Caption = 'Panel1'
    TabOrder = 2
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 42
    Width = 668
    Height = 81
    Anchors = [akLeft, akTop, akRight]
    TabOrder = 3
    DesignSize = (
      668
      81)
    object Label2: TLabel
      Left = 240
      Top = 22
      Width = 35
      Height = 13
      Caption = 'Status:'
    end
    object lblStatus: TLabel
      Left = 296
      Top = 22
      Width = 353
      Height = 19
      Anchors = [akLeft, akTop, akRight]
      AutoSize = False
    end
    object TrackBar1: TTrackBar
      Left = 16
      Top = 48
      Width = 641
      Height = 25
      Anchors = [akLeft, akTop, akRight]
      TabOrder = 0
      OnChange = TrackBar1Change
    end
    object bPlay: TButton
      Left = 24
      Top = 17
      Width = 70
      Height = 25
      Caption = 'Play'
      TabOrder = 1
      OnClick = bPlayClick
    end
    object bStop: TButton
      Left = 100
      Top = 17
      Width = 70
      Height = 25
      Caption = 'Stop'
      TabOrder = 2
      OnClick = bStopClick
    end
  end
end
