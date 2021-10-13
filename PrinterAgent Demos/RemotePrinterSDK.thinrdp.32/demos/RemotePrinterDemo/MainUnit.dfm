object MainForm: TMainForm
  Left = 0
  Top = 0
  Caption = 'Thinfinity Printer API Demo'
  ClientHeight = 370
  ClientWidth = 332
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 93
    Width = 66
    Height = 13
    Caption = 'Printer Name:'
  end
  object Label2: TLabel
    Left = 8
    Top = 120
    Width = 45
    Height = 13
    Caption = 'Doc Title:'
  end
  object BtnPrintDoc: TButton
    Left = 8
    Top = 337
    Width = 89
    Height = 25
    Caption = 'Print Document'
    TabOrder = 0
    OnClick = BtnPrintDocClick
  end
  object EdtPrinterName: TEdit
    Left = 88
    Top = 90
    Width = 233
    Height = 21
    TabOrder = 1
    Text = 'ZPL RAW Printer'
  end
  object EdtDocTitle: TEdit
    Left = 88
    Top = 117
    Width = 233
    Height = 21
    TabOrder = 2
    Text = 'ZPL RAW Document 1'
  end
  object Memo1: TMemo
    Left = 8
    Top = 152
    Width = 313
    Height = 179
    Lines.Strings = (
      '^XA'
      ''
      '^FX Top section with company logo, name and address.'
      '^CF0,60'
      '^FO50,50^GB100,100,100^FS'
      '^FO75,75^FR^GB100,100,100^FS'
      '^FO88,88^GB50,50,50^FS'
      '^FO220,50^FDInternational Shipping, Inc.^FS'
      '^CF0,40'
      '^FO220,100^FD1000 Shipping Lane^FS'
      '^FO220,135^FDShelbyville TN 38102^FS'
      '^FO220,170^FDUnited States (USA)^FS'
      '^FO50,250^GB700,1,3^FS'
      ''
      '^FX Second section with recipient address and permit '
      'information.'
      '^CFA,30'
      '^FO50,300^FDJohn Doe^FS'
      '^FO50,340^FD100 Main Street^FS'
      '^FO50,380^FDSpringfield TN 39021^FS'
      '^FO50,420^FDUnited States (USA)^FS'
      '^CFA,15'
      '^FO600,300^GB150,150,3^FS'
      '^FO638,340^FDPermit^FS'
      '^FO638,390^FD123456^FS'
      '^FO50,500^GB700,1,3^FS'
      ''
      '^FX Third section with barcode.'
      '^BY5,2,270'
      '^FO100,550^BC^FD12345678^FS'
      ''
      '^FX Fourth section (the two boxes on the bottom).'
      '^FO50,900^GB700,250,3^FS'
      '^FO400,900^GB1,250,3^FS'
      '^CF0,40'
      '^FO100,960^FDShipping Ctr. X34B-1^FS'
      '^FO100,1010^FDREF1 F00B47^FS'
      '^FO100,1060^FDREF2 BL4H8^FS'
      '^CF0,190'
      '^FO485,965^FDCA^FS'
      ''
      '^XZ')
    ScrollBars = ssVertical
    TabOrder = 3
  end
  object BtnGetPrinters: TButton
    Left = 7
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Get Printers'
    TabOrder = 4
    OnClick = BtnGetPrintersClick
  end
  object LboxPrinters: TListBox
    Left = 88
    Top = 8
    Width = 233
    Height = 76
    ItemHeight = 13
    TabOrder = 5
    OnClick = LboxPrintersClick
  end
end
