object FormMain: TFormMain
  Left = 323
  Top = 181
  Width = 708
  Height = 552
  Caption = 'JSRO Video'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  DesignSize = (
    700
    521)
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 24
    Top = 28
    Width = 25
    Height = 13
    Caption = 'URL:'
  end
  object Label2: TLabel
    Left = 216
    Top = 80
    Width = 33
    Height = 13
    Caption = 'Status:'
  end
  object LabelStatus: TLabel
    Left = 256
    Top = 80
    Width = 78
    Height = 13
    Caption = '                          '
  end
  object ComboUrl: TComboBox
    Left = 56
    Top = 24
    Width = 554
    Height = 21
    Anchors = [akLeft, akTop, akRight]
    ItemHeight = 13
    TabOrder = 0
    Text = 'ComboUrl'
  end
  object ButGo: TButton
    Left = 625
    Top = 25
    Width = 41
    Height = 20
    Anchors = [akTop, akRight]
    Caption = 'GO'
    TabOrder = 1
    OnClick = ButGoClick
  end
  object ButPlay: TButton
    Left = 24
    Top = 72
    Width = 75
    Height = 25
    Caption = 'Play'
    TabOrder = 2
    OnClick = ButPlayClick
  end
  object ButStop: TButton
    Left = 112
    Top = 72
    Width = 75
    Height = 25
    Caption = 'Stop'
    TabOrder = 3
    OnClick = ButStopClick
  end
  object Slider: TTrackBar
    Left = 23
    Top = 120
    Width = 657
    Height = 45
    Anchors = [akLeft, akTop, akRight]
    Max = 1000
    Orientation = trHorizontal
    Frequency = 1
    Position = 0
    SelEnd = 0
    SelStart = 0
    TabOrder = 4
    TickMarks = tmBottomRight
    TickStyle = tsNone
    OnChange = SliderChange
  end
  object PanelXVideo: TPanel
    Left = 24
    Top = 176
    Width = 653
    Height = 325
    Anchors = [akLeft, akTop, akRight, akBottom]
    BevelOuter = bvNone
    TabOrder = 5
  end
end
