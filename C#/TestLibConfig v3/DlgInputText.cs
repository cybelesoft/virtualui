using System.Windows.Forms;

namespace TestLibConfig {
    public partial class DlgInputText : Form {
        public string InputValue {
            get { return TxtValue.Text; }
        }

        public DlgInputText(string title, string text) {
            InitializeComponent();
            Text = title;
            LblText.Text = text;
        }
    }
}
