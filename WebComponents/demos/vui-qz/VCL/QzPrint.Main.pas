unit QzPrint.Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, VirtualUI_SDK, Vcl.StdCtrls,
  Vcl.ExtCtrls,Httpapp, Vcl.ComCtrls,Vui.Qz;

type
  TForm1 = class(TForm)
    Button3: TButton;
    Panel1: TPanel;
    Label1: TLabel;
    cmbPrinters: TComboBox;
    Button1: TButton;
    Button2: TButton;
    Button4: TButton;
    StatusBar1: TStatusBar;
    procedure FormCreate(Sender: TObject);
    procedure cmbPrintersClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Button4Click(Sender: TObject);
  private
    { Private declarations }
    FQz : TVuiQz;
    procedure EnablePanel(Panel: TWinControl; Value: Boolean);
    procedure PrinterChanged(Sender: TObject);
    procedure StateChanged(Sender: TObject);
    procedure PrintZPLFile(AFilename: string);
  public
    { Public declarations }
  end;

var
  Form1: TForm1;


implementation

const
  QZ_RUNTIME_CERTIFICATE =
              '-----BEGIN CERTIFICATE-----' + #13#10 +
              'MIIFAzCCAuugAwIBAgICEAIwDQYJKoZIhvcNAQEFBQAwgZgxCzAJBgNVBAYTAlVT' + #13#10 +
              'MQswCQYDVQQIDAJOWTEbMBkGA1UECgwSUVogSW5kdXN0cmllcywgTExDMRswGQYD' + #13#10 +
              'VQQLDBJRWiBJbmR1c3RyaWVzLCBMTEMxGTAXBgNVBAMMEHF6aW5kdXN0cmllcy5j' + #13#10 +
              'b20xJzAlBgkqhkiG9w0BCQEWGHN1cHBvcnRAcXppbmR1c3RyaWVzLmNvbTAeFw0x' + #13#10 +
              'NTAzMTkwMjM4NDVaFw0yNTAzMTkwMjM4NDVaMHMxCzAJBgNVBAYTAkFBMRMwEQYD' + #13#10 +
              'VQQIDApTb21lIFN0YXRlMQ0wCwYDVQQKDAREZW1vMQ0wCwYDVQQLDAREZW1vMRIw' + #13#10 +
              'EAYDVQQDDAlsb2NhbGhvc3QxHTAbBgkqhkiG9w0BCQEWDnJvb3RAbG9jYWxob3N0' + #13#10 +
              'MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtFzbBDRTDHHmlSVQLqjY' + #13#10 +
              'aoGax7ql3XgRGdhZlNEJPZDs5482ty34J4sI2ZK2yC8YkZ/x+WCSveUgDQIVJ8oK' + #13#10 +
              'D4jtAPxqHnfSr9RAbvB1GQoiYLxhfxEp/+zfB9dBKDTRZR2nJm/mMsavY2DnSzLp' + #13#10 +
              't7PJOjt3BdtISRtGMRsWmRHRfy882msBxsYug22odnT1OdaJQ54bWJT5iJnceBV2' + #13#10 +
              '1oOqWSg5hU1MupZRxxHbzI61EpTLlxXJQ7YNSwwiDzjaxGrufxc4eZnzGQ1A8h1u' + #13#10 +
              'jTaG84S1MWvG7BfcPLW+sya+PkrQWMOCIgXrQnAsUgqQrgxQ8Ocq3G4X9UvBy5VR' + #13#10 +
              'CwIDAQABo3sweTAJBgNVHRMEAjAAMCwGCWCGSAGG+EIBDQQfFh1PcGVuU1NMIEdl' + #13#10 +
              'bmVyYXRlZCBDZXJ0aWZpY2F0ZTAdBgNVHQ4EFgQUpG420UhvfwAFMr+8vf3pJunQ' + #13#10 +
              'gH4wHwYDVR0jBBgwFoAUkKZQt4TUuepf8gWEE3hF6Kl1VFwwDQYJKoZIhvcNAQEF' + #13#10 +
              'BQADggIBAFXr6G1g7yYVHg6uGfh1nK2jhpKBAOA+OtZQLNHYlBgoAuRRNWdE9/v4' + #13#10 +
              'J/3Jeid2DAyihm2j92qsQJXkyxBgdTLG+ncILlRElXvG7IrOh3tq/TttdzLcMjaR' + #13#10 +
              '8w/AkVDLNL0z35shNXih2F9JlbNRGqbVhC7qZl+V1BITfx6mGc4ayke7C9Hm57X0' + #13#10 +
              'ak/NerAC/QXNs/bF17b+zsUt2ja5NVS8dDSC4JAkM1dD64Y26leYbPybB+FgOxFu' + #13#10 +
              'wou9gFxzwbdGLCGboi0lNLjEysHJBi90KjPUETbzMmoilHNJXw7egIo8yS5eq8RH' + #13#10 +
              'i2lS0GsQjYFMvplNVMATDXUPm9MKpCbZ7IlJ5eekhWqvErddcHbzCuUBkDZ7wX/j' + #13#10 +
              'unk/3DyXdTsSGuZk3/fLEsc4/YTujpAjVXiA1LCooQJ7SmNOpUa66TPz9O7Ufkng' + #13#10 +
              '+CoTSACmnlHdP7U9WLr5TYnmL9eoHwtb0hwENe1oFC5zClJoSX/7DRexSJfB7YBf' + #13#10 +
              'vn6JA2xy4C6PqximyCPisErNp85GUcZfo33Np1aywFv9H+a83rSUcV6kpE/jAZio' + #13#10 +
              '5qLpgIOisArj1HTM6goDWzKhLiR/AeG3IJvgbpr9Gr7uZmfFyQzUjvkJ9cybZRd+' + #13#10 +
              'G8azmpBBotmKsbtbAU/I/LVk8saeXznshOVVpDRYtVnjZeAneso7' + #13#10 +
              '-----END CERTIFICATE-----' + #13#10 +
              '--START INTERMEDIATE CERT--' + #13#10 +
              '-----BEGIN CERTIFICATE-----' + #13#10 +
              'MIIFEjCCA/qgAwIBAgICEAAwDQYJKoZIhvcNAQELBQAwgawxCzAJBgNVBAYTAlVT' + #13#10 +
              'MQswCQYDVQQIDAJOWTESMBAGA1UEBwwJQ2FuYXN0b3RhMRswGQYDVQQKDBJRWiBJ' + #13#10 +
              'bmR1c3RyaWVzLCBMTEMxGzAZBgNVBAsMElFaIEluZHVzdHJpZXMsIExMQzEZMBcG' + #13#10 +
              'A1UEAwwQcXppbmR1c3RyaWVzLmNvbTEnMCUGCSqGSIb3DQEJARYYc3VwcG9ydEBx' + #13#10 +
              'emluZHVzdHJpZXMuY29tMB4XDTE1MDMwMjAwNTAxOFoXDTM1MDMwMjAwNTAxOFow' + #13#10 +
              'gZgxCzAJBgNVBAYTAlVTMQswCQYDVQQIDAJOWTEbMBkGA1UECgwSUVogSW5kdXN0' + #13#10 +
              'cmllcywgTExDMRswGQYDVQQLDBJRWiBJbmR1c3RyaWVzLCBMTEMxGTAXBgNVBAMM' + #13#10 +
              'EHF6aW5kdXN0cmllcy5jb20xJzAlBgkqhkiG9w0BCQEWGHN1cHBvcnRAcXppbmR1' + #13#10 +
              'c3RyaWVzLmNvbTCCAiIwDQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBANTDgNLU' + #13#10 +
              'iohl/rQoZ2bTMHVEk1mA020LYhgfWjO0+GsLlbg5SvWVFWkv4ZgffuVRXLHrwz1H' + #13#10 +
              'YpMyo+Zh8ksJF9ssJWCwQGO5ciM6dmoryyB0VZHGY1blewdMuxieXP7Kr6XD3GRM' + #13#10 +
              'GAhEwTxjUzI3ksuRunX4IcnRXKYkg5pjs4nLEhXtIZWDLiXPUsyUAEq1U1qdL1AH' + #13#10 +
              'EtdK/L3zLATnhPB6ZiM+HzNG4aAPynSA38fpeeZ4R0tINMpFThwNgGUsxYKsP9kh' + #13#10 +
              '0gxGl8YHL6ZzC7BC8FXIB/0Wteng0+XLAVto56Pyxt7BdxtNVuVNNXgkCi9tMqVX' + #13#10 +
              'xOk3oIvODDt0UoQUZ/umUuoMuOLekYUpZVk4utCqXXlB4mVfS5/zWB6nVxFX8Io1' + #13#10 +
              '9FOiDLTwZVtBmzmeikzb6o1QLp9F2TAvlf8+DIGDOo0DpPQUtOUyLPCh5hBaDGFE' + #13#10 +
              'ZhE56qPCBiQIc4T2klWX/80C5NZnd/tJNxjyUyk7bjdDzhzT10CGRAsqxAnsjvMD' + #13#10 +
              '2KcMf3oXN4PNgyfpbfq2ipxJ1u777Gpbzyf0xoKwH9FYigmqfRH2N2pEdiYawKrX' + #13#10 +
              '6pyXzGM4cvQ5X1Yxf2x/+xdTLdVaLnZgwrdqwFYmDejGAldXlYDl3jbBHVM1v+uY' + #13#10 +
              '5ItGTjk+3vLrxmvGy5XFVG+8fF/xaVfo5TW5AgMBAAGjUDBOMB0GA1UdDgQWBBSQ' + #13#10 +
              'plC3hNS56l/yBYQTeEXoqXVUXDAfBgNVHSMEGDAWgBQDRcZNwPqOqQvagw9BpW0S' + #13#10 +
              'BkOpXjAMBgNVHRMEBTADAQH/MA0GCSqGSIb3DQEBCwUAA4IBAQAJIO8SiNr9jpLQ' + #13#10 +
              'eUsFUmbueoxyI5L+P5eV92ceVOJ2tAlBA13vzF1NWlpSlrMmQcVUE/K4D01qtr0k' + #13#10 +
              'gDs6LUHvj2XXLpyEogitbBgipkQpwCTJVfC9bWYBwEotC7Y8mVjjEV7uXAT71GKT' + #13#10 +
              'x8XlB9maf+BTZGgyoulA5pTYJ++7s/xX9gzSWCa+eXGcjguBtYYXaAjjAqFGRAvu' + #13#10 +
              'pz1yrDWcA6H94HeErJKUXBakS0Jm/V33JDuVXY+aZ8EQi2kV82aZbNdXll/R6iGw' + #13#10 +
              '2ur4rDErnHsiphBgZB71C5FD4cdfSONTsYxmPmyUb5T+KLUouxZ9B0Wh28ucc1Lp' + #13#10 +
              'rbO7BnjW' + #13#10 +
              '-----END CERTIFICATE-----' + #13#10;
{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  EnablePanel(Panel1,false);
  FQz := TVuiQz.Create;
  FQz.OnPrinterChange := PrinterChanged;
  FQz.OnStateChange := StateChanged;
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  FQz.Free;
end;

procedure TForm1.EnablePanel(Panel:TWinControl;Value:Boolean);
var
  n : Integer;
begin
  for n := 0 to Panel.ControlCount-1 do
    Panel.Controls[n].Enabled := Value;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  FQz.Init(QZ_RUNTIME_CERTIFICATE);
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  FQz.PrintPDF(ExpandFilename('vui-qz\assets\pdf_sample.pdf'));
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  ShowMessage(FQz.QzRo.Properties['settings'].AsString);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  PrintZPLFile(ExpandFilename('vui-qz\assets\zpl_sample.txt'));
end;

procedure TForm1.cmbPrintersClick(Sender: TObject);
begin
  FQz.DefaultPrinter := cmbPrinters.Text;
end;

procedure TForm1.PrinterChanged(Sender: TObject);
begin
  cmbPrinters.Items.Assign(FQz.PrinterList);
  cmbPrinters.ItemIndex := cmbPrinters.Items.IndexOf(FQz.DefaultPrinter);
  EnablePanel(Panel1,true);
end;

procedure TForm1.StateChanged(Sender: TObject);
begin
  Statusbar1.Panels[0].Text := FQz.State;
end;

procedure TForm1.PrintZPLFile(AFilename:string);
var
  SL : TStringList;
  S : string;
begin
  SL := TStringList.Create;
  try
    SL.LoadFromFile(AFilename);
    FQz.BeginDoc;
    for S in SL do
      FQz.PrintText(S);
    FQz.EndDoc;
  finally
    SL.Free;
  end;

end;

end.
