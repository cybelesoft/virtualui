using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cybele.Thinfinity;
using Cybele.Thinfinity.WebComponents;

namespace QzPrint
{
    public partial class Form1 : Form
    {
        private const string QZ_RUNTIME_CERTIFICATE =
              "-----BEGIN CERTIFICATE-----\n" +
              "MIIEADCCAuigAwIBAgIBADANBgkqhkiG9w0BAQsFADCBuDEbMBkGA1UEAwwSd3d3\n" +
              "LnRoaW5maW5pdHkuY29tMRwwGgYDVQQLDBNQcm9kdWN0IERldmVsb3BtZW50MREw\n" +
              "DwYDVQQIDAhEZWxhd2FyZTEeMBwGA1UECgwVQ3liZWxlIFNvZnR3YXJlLCBJbmMu\n" +
              "MQswCQYDVQQGEwJVUzETMBEGA1UEBwwKV2lsbWluZ3RvbjEmMCQGCSqGSIb3DQEJ\n" +
              "ARYXIHN1cHBvcnRAY3liZWxlc29mdC5jb20wHhcNMTUwOTE1MjEyMjEyWhcNMjUw\n" +
              "OTEyMjEyMjEyWjCBuDEbMBkGA1UEAwwSd3d3LnRoaW5maW5pdHkuY29tMRwwGgYD\n" +
              "VQQLDBNQcm9kdWN0IERldmVsb3BtZW50MREwDwYDVQQIDAhEZWxhd2FyZTEeMBwG\n" +
              "A1UECgwVQ3liZWxlIFNvZnR3YXJlLCBJbmMuMQswCQYDVQQGEwJVUzETMBEGA1UE\n" +
              "BwwKV2lsbWluZ3RvbjEmMCQGCSqGSIb3DQEJARYXIHN1cHBvcnRAY3liZWxlc29m\n" +
              "dC5jb20wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDi1LALY9SGcisH\n" +
              "PtyKt+yR/zJ2EcInuZmSrzkH1Gps30k9rQM7PbFQtGw5iiN9pzJDUnRGrzpFkJzG\n" +
              "LkfLO3pJ1kJJeH0CCJFyK8rcVRESRzI/PnwRich9R5wp9BOorShga1DcYPbEiT5D\n" +
              "H8lepblwbu1J3p+DoaJ7IqK25PNl+a3IiMLzQ7roJIeYm3rDAWEksbSMO9ZvJpfd\n" +
              "QJryYz1pXdwEo550fS+oPH1J3Fj7Sw87BjU/qiXp3s1AzHP5/MnpGToimImYeuBD\n" +
              "A7JEecnatrtEscFQA4FwNAjznSY5dXtbeHqSqhRfZ0j5ttuWceg4Udk/XG1CZUH8\n" +
              "/WKzfM4hAgMBAAGjEzARMA8GA1UdEwEB/wQFMAMBAf8wDQYJKoZIhvcNAQELBQAD\n" +
              "ggEBAMaVn4eFj3huqJdyPU9Mqtbq2C0hq4JEzWsI5oQddrFjcFXQEd1+JFEyzHdp\n" +
              "ldNBBqg9m8coQaygrVBPmcfTsfv6eIMJIZbBI/UwiKhFdq9v1MfqoMH53gLSq7c2\n" +
              "l8zSEp+dCSIYOSIBMyBCwm8h8Gg3nOQ09BFBuLCaK6dbwj3xb5bWe8i5+bkVjpBl\n" +
              "9lZTpV943csrA9XKLOJ8yhNwbIzkjjNg5+nfa5jWIAWYCdW4dO7uVQcaD/P1o+ye\n" +
              "8XzTl3EV8oOcaMU4mB5NayiR+3/wumgKkblLuP+3lJN+lLDRw/TdTShChZFYqZKY\n" +
              "b3lk1hGQ33FMETQW0ZtY1u4ogCg=\n" +
              "-----END CERTIFICATE-----\n";

        private const string QZ_RUNTIME_PRIVATE_KEY =
              "-----BEGIN PRIVATE KEY-----\n" +
              "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDi1LALY9SGcisH\n" +
              "PtyKt+yR/zJ2EcInuZmSrzkH1Gps30k9rQM7PbFQtGw5iiN9pzJDUnRGrzpFkJzG\n" +
              "LkfLO3pJ1kJJeH0CCJFyK8rcVRESRzI/PnwRich9R5wp9BOorShga1DcYPbEiT5D\n" +
              "H8lepblwbu1J3p+DoaJ7IqK25PNl+a3IiMLzQ7roJIeYm3rDAWEksbSMO9ZvJpfd\n" +
              "QJryYz1pXdwEo550fS+oPH1J3Fj7Sw87BjU/qiXp3s1AzHP5/MnpGToimImYeuBD\n" +
              "A7JEecnatrtEscFQA4FwNAjznSY5dXtbeHqSqhRfZ0j5ttuWceg4Udk/XG1CZUH8\n" +
              "/WKzfM4hAgMBAAECggEATo6MXZV4YAugHUVHCf/CvZldN4jU7f8YUbW/kZeeOBBo\n" +
              "hCSsLtMh2qpxpMfTnMvP24Lt5CEBlGAN+5DBqn/xzSqYEGvbF14ySREjk4UegW8I\n" +
              "1uBkBYrrVX/8dIckW9GEX0grW/d03wIM/yA+FDpe67JvGZsxMVxEMlL/eUn3hcP4\n" +
              "4IjhqE3uSkuSfxxIi0uE2TS7lTqqw37s3JU1TVXnwSCBLhwBiVxuXpWxo6U0aIZY\n" +
              "Mcd/5ppisTOE0WV+d4fbDtHIVhj/rfutAHI3ITRpFucMfoVPPE4D/jqShQcpq2Nj\n" +
              "+zDhAWO1B/veG0fjL84u0ytcoIsfLfQ03ku0e+LYAQKBgQDzlmr8IeSuNYFN79p4\n" +
              "bRsowROHE89Y7bdgrKsFf/VNCXKItyI864slq2R5Ph0w5y4FyyOaHUfC6yLUxQb4\n" +
              "MzjeHHW6sos6ry80iJz5PAO7YTpi8O1CNjcHPJi3EQRMraU4d9M8FAEuQagb7tXF\n" +
              "KpZu7JTY73ouNz/jWYuAdAbk4QKBgQDuY63XaD6AvsC44+GNkY2n38VUWYFSnBFW\n" +
              "E8nF6wihN9eJ3R59kglmoiYB+l4T0C7CZn5Cl8MLawh2+otL61QJrmD70BbOxUFO\n" +
              "OUEFlDxq24V84yvZU3cumHUWOT8BJuB58mZoDhCDuLL7eDITtN+g8Amn39F3WPpo\n" +
              "7jfjuAHRQQKBgCG/nWMBbyWT1C5wJNy6gSDMX2A/pmKzzMxgH/HLILljrbKzbNLz\n" +
              "73twm6MQsAqufPnggzY/CEpBObow8h5BOofLeaQ8SH4A95FXvCfr4Lh9aBF9P+IE\n" +
              "kOs3whDbErVs+Y8xStrwCpnWDuyP0p5WoDEOJjFIPK1aikd9iI5rhOkBAoGBALOY\n" +
              "yTmFwcEA9PTWSfF7/PrCbUn0/KceCTmOQu8m+SNsjKfCvNvhj8+QzY2j8AiBSRkQ\n" +
              "WoMVDs6lXoU0kIkry+5XP5220dgJZ//kxoXLfhELPXAvPbPHW/zwwxVxH3Rgs7Fr\n" +
              "25b9MZfrKHynuyJ5nBkFfmDJEGgX0uAGyHh5AnWBAoGAX5FKOZyQr8DB8YolTlxH\n" +
              "aAfgEB7/E7d2ogg9QFZ1Y2NG5xdUfKWJvlsoKGWoEzlVqtHsYb0/Qn9l04WMKMKQ\n" +
              "SEjjTfWx2eeAJrPiJTNtxCUKxiaJvLbgNVnWtcX8on3TkVF12+9uMbYSuXubJYIH\n" +
              "kwEG8Zlj7V1/EzWOnldBCIs=\n" +
              "-----END PRIVATE KEY-----\n";

        private VirtualUI vui;
        private VuiQz qz;
        
        public Form1()
        {
            InitializeComponent();
            EnablePanel(panel1, false);

            vui = new VirtualUI();
            vui.Start();

            qz = new VuiQz();
            qz.CreateComponent();
            qz.OnPrinterChange += qz_OnPrinterChange;
            qz.OnStateChanged += qz_OnStateChanged;
        }

        void qz_OnStateChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = qz.State;
        }

        void qz_OnPrinterChange(object sender, EventArgs e)
        {
            cbPrinters.Items.Clear();
            foreach (string s in qz.Printers)
            {
                cbPrinters.Items.Add(s);
            }
            cbPrinters.SelectedIndex = cbPrinters.Items.IndexOf(qz.Default);
            EnablePanel(panel1,true);
        }

        private void bInit_Click(object sender, EventArgs e)
        {
            qz.Init(QZ_RUNTIME_CERTIFICATE, QZ_RUNTIME_PRIVATE_KEY);
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show(qz.Settings);
        }

        private void bPrintPDF_Click(object sender, EventArgs e)
        {
            qz.PrintPDF(AppDomain.CurrentDomain.BaseDirectory + @"\vui-qz\assets\pdf_sample.pdf");
        }

        private void bPrintZPL_Click(object sender, EventArgs e)
        {
            PrintZPLFile(AppDomain.CurrentDomain.BaseDirectory + @"\vui-qz\assets\zpl_sample.txt");
        }

        private void PrintZPLFile(String filename)
        {
            string[] lines = File.ReadAllLines(filename);
            qz.BeginDoc();
            foreach (string line in lines)
            {
                qz.PrintText(line);
            }
            qz.EndDoc();
        }

        private void EnablePanel(Control ctrl,bool value)
        {
            foreach(Control ct in ctrl.Controls)
            {
                ct.Enabled = value;
            }
        }

        private void cbPrinters_Click(object sender, EventArgs e)
        {
            qz.Default = cbPrinters.Text;

        }
    }
}
