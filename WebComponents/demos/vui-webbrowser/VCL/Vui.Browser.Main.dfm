object Form7: TForm7
  Left = 0
  Top = 0
  Caption = 'Form7'
  ClientHeight = 474
  ClientWidth = 811
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
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 811
    Height = 25
    Align = alTop
    TabOrder = 0
    DesignSize = (
      811
      25)
    object SpeedButton1: TSpeedButton
      Left = 0
      Top = 0
      Width = 23
      Height = 22
      Action = actPrev
    end
    object SpeedButton2: TSpeedButton
      Left = 24
      Top = 0
      Width = 23
      Height = 22
      Action = actNext
    end
    object SpeedButton3: TSpeedButton
      Left = 48
      Top = 0
      Width = 23
      Height = 22
      Action = actHome
    end
    object SpeedButton4: TSpeedButton
      Left = 72
      Top = 0
      Width = 23
      Height = 22
      Action = actReload
    end
    object SpeedButton5: TSpeedButton
      Left = 788
      Top = 0
      Width = 23
      Height = 22
      Action = actGoTo
      Anchors = [akTop, akRight]
      ExplicitLeft = 841
    end
    object edAddress: TEdit
      Left = 95
      Top = 0
      Width = 691
      Height = 21
      Anchors = [akLeft, akTop, akRight]
      TabOrder = 0
      Text = 'http://www.cybelesoft.com'
    end
  end
  object Panel2: TPanel
    Left = 0
    Top = 25
    Width = 811
    Height = 449
    Align = alClient
    Caption = 'Panel2'
    TabOrder = 1
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
    object actHome: TAction
      Caption = 'H'
    end
    object actReload: TAction
      Caption = 'R'
    end
    object actGoTo: TAction
      Caption = '>'
      OnExecute = actGoToExecute
    end
    object actGetSource: TAction
      Caption = 'Get source'
    end
    object actGetText: TAction
      Caption = 'Get text'
    end
    object actZoomIn: TAction
      Caption = 'Zoom in'
    end
    object actZoomOut: TAction
      Caption = 'Zoom out'
    end
    object actZoomReset: TAction
      Caption = 'Zoom reset'
    end
    object actExecuteJS: TAction
      Caption = 'Execute JavaScript'
    end
    object actDom: TAction
      Caption = 'Hook DOM'
    end
    object actDevTool: TAction
      AutoCheck = True
      Caption = 'Show DevTools'
    end
    object actDoc: TAction
      Caption = 'Documentation'
    end
    object actGroup: TAction
      Caption = 'Google group'
    end
    object actFileScheme: TAction
      Caption = 'File Scheme'
    end
    object actPrint: TAction
      Caption = 'Print'
    end
  end
end
