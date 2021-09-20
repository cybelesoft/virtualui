object MainForm: TMainForm
  Left = 0
  Top = 0
  BorderStyle = bsSingle
  Caption = 'Thinfinity VirtualUI File Test'
  ClientHeight = 509
  ClientWidth = 278
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox2: TGroupBox
    Left = 0
    Top = 217
    Width = 278
    Height = 292
    Align = alClient
    Caption = 'Others'
    TabOrder = 1
    object btnDownload: TButton
      Left = 40
      Top = 24
      Width = 200
      Height = 40
      Caption = '&Download this program'
      TabOrder = 0
      OnClick = btnDownloadClick
    end
    object btnPrint: TButton
      Left = 40
      Top = 124
      Width = 200
      Height = 40
      Caption = '&Print / Download PDF'
      TabOrder = 1
      OnClick = btnPrintClick
    end
    object btnDownloadTxt: TButton
      Left = 40
      Top = 74
      Width = 100
      Height = 40
      Caption = 'Download &text file'
      TabOrder = 2
      OnClick = btnDownloadTxtClick
    end
    object btnDownloadImage: TButton
      Left = 140
      Top = 74
      Width = 100
      Height = 40
      Caption = 'Download &image'
      TabOrder = 3
      OnClick = btnDownloadImageClick
    end
    object btnUploadFile: TButton
      Left = 40
      Top = 228
      Width = 200
      Height = 40
      Caption = '&Upload a File'
      Enabled = False
      TabOrder = 4
      OnClick = btnUploadFileClick
    end
    object btnMultiPrint: TButton
      Left = 40
      Top = 176
      Width = 200
      Height = 40
      Caption = 'Launch &Multiprint'
      TabOrder = 5
      OnClick = btnMultiPrintClick
    end
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 0
    Width = 278
    Height = 217
    Align = alTop
    Caption = 'File dialogs'
    TabOrder = 0
    object chkStdDlgs: TCheckBox
      Left = 40
      Top = 119
      Width = 200
      Height = 17
      Caption = '&Use standard Dialogs'
      Checked = True
      State = cbChecked
      TabOrder = 0
      OnClick = chkStdDlgsClick
    end
    object btnOpenFile: TButton
      Left = 40
      Top = 74
      Width = 200
      Height = 39
      Caption = '&Open file'
      TabOrder = 1
      OnClick = btnOpenFileClick
    end
    object btnSaveFile: TButton
      Left = 40
      Top = 24
      Width = 200
      Height = 40
      Caption = '&Save file'
      TabOrder = 2
      OnClick = btnSaveFileClick
    end
    object chkFilterAllTypes: TCheckBox
      Left = 40
      Top = 142
      Width = 200
      Height = 17
      Caption = 'Add filter by all file types'
      TabOrder = 3
      OnClick = checkOpenDialogFilters
    end
    object chkFilterImageTypes: TCheckBox
      Left = 40
      Top = 165
      Width = 200
      Height = 17
      Caption = 'Add filter by images'
      TabOrder = 4
      OnClick = checkOpenDialogFilters
    end
    object chkFilterTextType: TCheckBox
      Left = 40
      Top = 188
      Width = 97
      Height = 17
      Caption = 'Add filter by text files'
      TabOrder = 5
      OnClick = checkOpenDialogFilters
    end
  end
  object SaveDialog1: TSaveDialog
    Left = 8
    Top = 40
  end
  object OpenDialog1: TOpenDialog
    Left = 8
    Top = 96
  end
end
