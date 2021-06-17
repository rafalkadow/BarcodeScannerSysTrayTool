using System;
using System.Windows.Forms;

namespace BarcodeScannerSysTrayTool
{
    public partial class AboutForm : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public AboutForm()
        {
            logger.Info("AboutForm()");
            InitializeComponent();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
