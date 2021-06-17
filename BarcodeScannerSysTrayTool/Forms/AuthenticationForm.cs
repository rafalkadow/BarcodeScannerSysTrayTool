using Common.BusinessLogic.Modules.Settings.Utilities;
using Common.BusinessLogic.Utilities;
using Common.BusinessModels.Modules.Models;
using System;
using System.Windows.Forms;

namespace BarcodeScannerSysTrayTool.Forms
{
    public partial class AuthenticationForm : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private bool isSettingsLoaded = false;
        private SettingsForm settingsForm;
        private SettingsApplicationModel SettingsApplicationModelApplication = new SettingsApplicationModel();

        public AuthenticationForm(SettingsForm settingsForm)
        {
            InitializeComponent();
            this.settingsForm = settingsForm;
            LoadDataForm();
        }
        private void LoadDataForm()
        {
            logger.Info("LoadDataForm()");
            try
            {
                SettingsApplicationUtility settingsApplicationUtility = new SettingsApplicationUtility();
                var settingsApplicationModel = settingsApplicationUtility.LoadDataSettings(Application.ExecutablePath);
                SettingsApplicationModelApplication = settingsApplicationModel;

                if (!SettingsApplicationModelApplication.IsPasswordOnApplication)
                {
                    this.Hide();
                    isSettingsLoaded = true;
                    settingsForm.LoadDataForm();
                    settingsForm.FormClosing += SettingsForm_FormClosing; ;      
                    settingsForm.ShowDialog();
                   
                    
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("LoadDataForm(ex='{0}')", ex.StackTrace);
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Shown += AuthenticationForm_Shown;
        }

        private void AuthenticationForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonAuthenticationLogin_Click(object sender, System.EventArgs e)
        {
            string dateTimeStr = DateTimeToStringUtility.AddDateTime("");
            if (textBoxPassword.Text == SettingsApplicationModelApplication.PasswordSettings)
            {
                if (!isSettingsLoaded)
                {
                    this.Hide();
                    isSettingsLoaded = true;
                    settingsForm.LoadDataForm();
                    settingsForm.ShowDialog();
                    isSettingsLoaded = false;                    
                }
            }
            else
            {
                toolStripStatusLabelSettings.Text = dateTimeStr + " Incorrect password";
            }
        }

        private void buttonAuthenticationCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAuthenticationLogin.PerformClick();
            }
        }
    }
}
