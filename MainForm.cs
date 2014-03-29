using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public SidePanel SidePanelLeft
        {
            get { return sidePanel1; }
        }

        public SidePanel SidePanelRight
        {
            get { return sidePanel2; }
        }
    }
}