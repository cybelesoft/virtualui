object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Thinfinity RemotePrinter Demo - PrintFile (VirtualUI)'
  ClientHeight = 228
  ClientWidth = 612
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  DesignSize = (
    612
    228)
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 19
    Top = 93
    Width = 66
    Height = 13
    Caption = 'Printer Name:'
  end
  object btnPrintPdf: TButton
    Left = 16
    Top = 152
    Width = 193
    Height = 25
    Caption = 'Print PDF'
    TabOrder = 0
    OnClick = btnPrintPdfClick
  end
  object btnPrintXps: TButton
    Left = 16
    Top = 115
    Width = 193
    Height = 25
    Caption = 'Print XPS'
    TabOrder = 1
    OnClick = btnPrintXpsClick
  end
  object EdXPSFile: TEdit
    Left = 232
    Top = 117
    Width = 327
    Height = 21
    Anchors = [akLeft, akTop, akRight]
    TabOrder = 2
    Text = 'Test1.xps'
    ExplicitWidth = 338
  end
  object EdPDFFile: TEdit
    Left = 232
    Top = 154
    Width = 327
    Height = 21
    Anchors = [akLeft, akTop, akRight]
    TabOrder = 3
    Text = 'Test1.pdf'
    ExplicitWidth = 338
  end
  object btnPrintDirect: TButton
    Left = 16
    Top = 190
    Width = 193
    Height = 25
    Caption = 'Print Direct PDF / ZPL (Raw to Printer)'
    TabOrder = 4
    OnClick = btnPrintDirectClick
  end
  object EdDirectFile: TEdit
    Left = 232
    Top = 192
    Width = 327
    Height = 21
    Anchors = [akLeft, akTop, akRight]
    TabOrder = 5
    Text = 'Test1.txt'
    ExplicitWidth = 338
  end
  object BtnOpenXPS: TButton
    Left = 565
    Top = 115
    Width = 25
    Height = 25
    Anchors = [akTop, akRight]
    Caption = '...'
    TabOrder = 6
    OnClick = BtnOpenXPSClick
    ExplicitLeft = 576
  end
  object BtnOpenPDF: TButton
    Left = 565
    Top = 152
    Width = 25
    Height = 25
    Anchors = [akTop, akRight]
    Caption = '...'
    TabOrder = 7
    OnClick = BtnOpenPDFClick
    ExplicitLeft = 576
  end
  object BtnOpenFile: TButton
    Left = 565
    Top = 190
    Width = 25
    Height = 25
    Anchors = [akTop, akRight]
    Caption = '...'
    TabOrder = 8
    OnClick = BtnOpenFileClick
    ExplicitLeft = 576
  end
  object EdtPrinterName: TEdit
    Left = 99
    Top = 90
    Width = 233
    Height = 21
    TabOrder = 9
  end
  object LboxPrinters: TListBox
    Left = 99
    Top = 8
    Width = 233
    Height = 76
    ItemHeight = 13
    TabOrder = 10
    OnClick = LboxPrintersClick
  end
  object BtnGetPrinters: TButton
    Left = 18
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Get Printers'
    TabOrder = 11
    OnClick = BtnGetPrintersClick
  end
  object OpenFilesDialog: TOpenDialog
  end
end
