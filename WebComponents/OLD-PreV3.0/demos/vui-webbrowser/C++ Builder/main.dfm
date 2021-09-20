object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'VirtualUI browser demo'
  ClientHeight = 481
  ClientWidth = 767
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Panel2: TPanel
    Left = 0
    Top = 27
    Width = 767
    Height = 454
    Align = alClient
    Caption = 'Panel2'
    TabOrder = 0
    ExplicitHeight = 456
  end
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 767
    Height = 27
    Align = alTop
    TabOrder = 1
    DesignSize = (
      767
      27)
    object SpeedButton1: TSpeedButton
      Left = 2
      Top = 2
      Width = 23
      Height = 22
      Action = actPrev
    end
    object SpeedButton2: TSpeedButton
      Left = 26
      Top = 2
      Width = 23
      Height = 22
      Action = actNext
    end
    object SpeedButton5: TSpeedButton
      Left = 741
      Top = 2
      Width = 23
      Height = 22
      Action = actGoTo
      Anchors = [akTop, akRight]
    end
    object edAddress: TEdit
      Left = 53
      Top = 3
      Width = 686
      Height = 21
      Anchors = [akLeft, akTop, akRight]
      TabOrder = 0
      Text = 'http://www.cybelesoft.com'
      OnKeyDown = edAddressKeyDown
    end
  end
  object ActionList: TActionList
    Left = 624
    Top = 112
    object actPrev: TAction
      Caption = '<-'
      OnExecute = actPrevExecute
    end
    object actNext: TAction
      Caption = '->'
      OnExecute = actNextExecute
    end
    object actGoTo: TAction
      Caption = '>'
      OnExecute = actGoToExecute
    end
  end
end
