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
    Label2: TLabel;
    Label3: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure cmbPrintersClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Label3Click(Sender: TObject);
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

uses ShellApi;

const
  QZ_RUNTIME_CERTIFICATE =
              '-----BEGIN CERTIFICATE-----' + #13#10 +
              'MIIEADCCAuigAwIBAgIBADANBgkqhkiG9w0BAQsFADCBuDEbMBkGA1UEAwwSd3d3' + #13#10 +
              'LnRoaW5maW5pdHkuY29tMRwwGgYDVQQLDBNQcm9kdWN0IERldmVsb3BtZW50MREw' + #13#10 +
              'DwYDVQQIDAhEZWxhd2FyZTEeMBwGA1UECgwVQ3liZWxlIFNvZnR3YXJlLCBJbmMu' + #13#10 +
              'MQswCQYDVQQGEwJVUzETMBEGA1UEBwwKV2lsbWluZ3RvbjEmMCQGCSqGSIb3DQEJ' + #13#10 +
              'ARYXIHN1cHBvcnRAY3liZWxlc29mdC5jb20wHhcNMTUwOTE1MjEyMjEyWhcNMjUw' + #13#10 +
              'OTEyMjEyMjEyWjCBuDEbMBkGA1UEAwwSd3d3LnRoaW5maW5pdHkuY29tMRwwGgYD' + #13#10 +
              'VQQLDBNQcm9kdWN0IERldmVsb3BtZW50MREwDwYDVQQIDAhEZWxhd2FyZTEeMBwG' + #13#10 +
              'A1UECgwVQ3liZWxlIFNvZnR3YXJlLCBJbmMuMQswCQYDVQQGEwJVUzETMBEGA1UE' + #13#10 +
              'BwwKV2lsbWluZ3RvbjEmMCQGCSqGSIb3DQEJARYXIHN1cHBvcnRAY3liZWxlc29m' + #13#10 +
              'dC5jb20wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDi1LALY9SGcisH' + #13#10 +
              'PtyKt+yR/zJ2EcInuZmSrzkH1Gps30k9rQM7PbFQtGw5iiN9pzJDUnRGrzpFkJzG' + #13#10 +
              'LkfLO3pJ1kJJeH0CCJFyK8rcVRESRzI/PnwRich9R5wp9BOorShga1DcYPbEiT5D' + #13#10 +
              'H8lepblwbu1J3p+DoaJ7IqK25PNl+a3IiMLzQ7roJIeYm3rDAWEksbSMO9ZvJpfd' + #13#10 +
              'QJryYz1pXdwEo550fS+oPH1J3Fj7Sw87BjU/qiXp3s1AzHP5/MnpGToimImYeuBD' + #13#10 +
              'A7JEecnatrtEscFQA4FwNAjznSY5dXtbeHqSqhRfZ0j5ttuWceg4Udk/XG1CZUH8' + #13#10 +
              '/WKzfM4hAgMBAAGjEzARMA8GA1UdEwEB/wQFMAMBAf8wDQYJKoZIhvcNAQELBQAD' + #13#10 +
              'ggEBAMaVn4eFj3huqJdyPU9Mqtbq2C0hq4JEzWsI5oQddrFjcFXQEd1+JFEyzHdp' + #13#10 +
              'ldNBBqg9m8coQaygrVBPmcfTsfv6eIMJIZbBI/UwiKhFdq9v1MfqoMH53gLSq7c2' + #13#10 +
              'l8zSEp+dCSIYOSIBMyBCwm8h8Gg3nOQ09BFBuLCaK6dbwj3xb5bWe8i5+bkVjpBl' + #13#10 +
              '9lZTpV943csrA9XKLOJ8yhNwbIzkjjNg5+nfa5jWIAWYCdW4dO7uVQcaD/P1o+ye' + #13#10 +
              '8XzTl3EV8oOcaMU4mB5NayiR+3/wumgKkblLuP+3lJN+lLDRw/TdTShChZFYqZKY' + #13#10 +
              'b3lk1hGQ33FMETQW0ZtY1u4ogCg=' + #13#10 +
              '-----END CERTIFICATE-----' + #13#10;

  QZ_RUNTIME_PRIVATE_KEY =
              '-----BEGIN PRIVATE KEY-----' + #13#10 +
              'MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDi1LALY9SGcisH' + #13#10 +
              'PtyKt+yR/zJ2EcInuZmSrzkH1Gps30k9rQM7PbFQtGw5iiN9pzJDUnRGrzpFkJzG' + #13#10 +
              'LkfLO3pJ1kJJeH0CCJFyK8rcVRESRzI/PnwRich9R5wp9BOorShga1DcYPbEiT5D' + #13#10 +
              'H8lepblwbu1J3p+DoaJ7IqK25PNl+a3IiMLzQ7roJIeYm3rDAWEksbSMO9ZvJpfd' + #13#10 +
              'QJryYz1pXdwEo550fS+oPH1J3Fj7Sw87BjU/qiXp3s1AzHP5/MnpGToimImYeuBD' + #13#10 +
              'A7JEecnatrtEscFQA4FwNAjznSY5dXtbeHqSqhRfZ0j5ttuWceg4Udk/XG1CZUH8' + #13#10 +
              '/WKzfM4hAgMBAAECggEATo6MXZV4YAugHUVHCf/CvZldN4jU7f8YUbW/kZeeOBBo' + #13#10 +
              'hCSsLtMh2qpxpMfTnMvP24Lt5CEBlGAN+5DBqn/xzSqYEGvbF14ySREjk4UegW8I' + #13#10 +
              '1uBkBYrrVX/8dIckW9GEX0grW/d03wIM/yA+FDpe67JvGZsxMVxEMlL/eUn3hcP4' + #13#10 +
              '4IjhqE3uSkuSfxxIi0uE2TS7lTqqw37s3JU1TVXnwSCBLhwBiVxuXpWxo6U0aIZY' + #13#10 +
              'Mcd/5ppisTOE0WV+d4fbDtHIVhj/rfutAHI3ITRpFucMfoVPPE4D/jqShQcpq2Nj' + #13#10 +
              '+zDhAWO1B/veG0fjL84u0ytcoIsfLfQ03ku0e+LYAQKBgQDzlmr8IeSuNYFN79p4' + #13#10 +
              'bRsowROHE89Y7bdgrKsFf/VNCXKItyI864slq2R5Ph0w5y4FyyOaHUfC6yLUxQb4' + #13#10 +
              'MzjeHHW6sos6ry80iJz5PAO7YTpi8O1CNjcHPJi3EQRMraU4d9M8FAEuQagb7tXF' + #13#10 +
              'KpZu7JTY73ouNz/jWYuAdAbk4QKBgQDuY63XaD6AvsC44+GNkY2n38VUWYFSnBFW' + #13#10 +
              'E8nF6wihN9eJ3R59kglmoiYB+l4T0C7CZn5Cl8MLawh2+otL61QJrmD70BbOxUFO' + #13#10 +
              'OUEFlDxq24V84yvZU3cumHUWOT8BJuB58mZoDhCDuLL7eDITtN+g8Amn39F3WPpo' + #13#10 +
              '7jfjuAHRQQKBgCG/nWMBbyWT1C5wJNy6gSDMX2A/pmKzzMxgH/HLILljrbKzbNLz' + #13#10 +
              '73twm6MQsAqufPnggzY/CEpBObow8h5BOofLeaQ8SH4A95FXvCfr4Lh9aBF9P+IE' + #13#10 +
              'kOs3whDbErVs+Y8xStrwCpnWDuyP0p5WoDEOJjFIPK1aikd9iI5rhOkBAoGBALOY' + #13#10 +
              'yTmFwcEA9PTWSfF7/PrCbUn0/KceCTmOQu8m+SNsjKfCvNvhj8+QzY2j8AiBSRkQ' + #13#10 +
              'WoMVDs6lXoU0kIkry+5XP5220dgJZ//kxoXLfhELPXAvPbPHW/zwwxVxH3Rgs7Fr' + #13#10 +
              '25b9MZfrKHynuyJ5nBkFfmDJEGgX0uAGyHh5AnWBAoGAX5FKOZyQr8DB8YolTlxH' + #13#10 +
              'aAfgEB7/E7d2ogg9QFZ1Y2NG5xdUfKWJvlsoKGWoEzlVqtHsYb0/Qn9l04WMKMKQ' + #13#10 +
              'SEjjTfWx2eeAJrPiJTNtxCUKxiaJvLbgNVnWtcX8on3TkVF12+9uMbYSuXubJYIH' + #13#10 +
              'kwEG8Zlj7V1/EzWOnldBCIs=' + #13#10 +
              '-----END PRIVATE KEY-----' + #13#10;


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

procedure TForm1.Label3Click(Sender: TObject);
var
  Url : string;
begin
  Url := (Sender as TLabel).Caption;
  ShellExecute(0,'open',PWideChar(Url), '',nil,SW_SHOWNORMAL);
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
  FQz.Init(QZ_RUNTIME_CERTIFICATE, QZ_RUNTIME_PRIVATE_KEY);
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
