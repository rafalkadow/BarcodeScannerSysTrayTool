using BarcodeScannerSysTrayTool.Forms;
using BarcodeScannerSysTrayTool.Properties;
using Common.BusinessModels.Modules.Settings.Constants;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace BarcodeScannerSysTrayTool.ApplicationElements
{
    public class ContextMenus
    {
        /// <summary>
        /// Is the About box displayed?
        /// </summary>
        private bool isAboutLoaded = false;

        /// <summary>
        /// Is the Settings box displayed?
        /// </summary>
        private bool isAuthenticationFormLoaded = false;
        private SettingsForm settingsForm;

        public ContextMenus(SettingsForm settingsForm)
        {
            this.settingsForm = settingsForm;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ContextMenuStrip</returns>
        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;

            // Settings.
            item = new ToolStripMenuItem();
            item.Text = "Settings";
            item.Click += new EventHandler(Settings_Click);
            item.Image = Resources.settings_32;
            menu.Items.Add(item);

            // About.
            item = new ToolStripMenuItem();
            item.Text = "About";
            item.Click += new EventHandler(About_Click);
            item.Image = Resources.about_32;
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            item.Image = Resources.close_32;
            menu.Items.Add(item);

            return menu;
        }

        /// <summary>
        /// Handles the Click event of the Explorer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Settings_Click(object sender, EventArgs e)
        {
            if (!isAuthenticationFormLoaded)
            {
                isAuthenticationFormLoaded = true;
                new AuthenticationForm(settingsForm).ShowDialog();
                isAuthenticationFormLoaded = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the About control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void About_Click(object sender, EventArgs e)
        {
            if (!isAboutLoaded)
            {
                isAboutLoaded = true;
                new AboutForm().ShowDialog();
                isAboutLoaded = false;
            }
        }

        /// <summary>
        /// Processes a menu item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Exit_Click(object sender, EventArgs e)
        {
            if (AskedClosingLoad())
            {
                if (MessageBox.Show("Are you sure you want closing the application?", "Barcode scanner", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }


        private bool AskedClosingLoad()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        
            string AskedClosing = string.Empty;
            if (config.AppSettings.Settings[SettingsApplicationConstants.AskedClosing] != null)
            {
                AskedClosing = config.AppSettings.Settings[SettingsApplicationConstants.AskedClosing].Value;
            }
            else
            {
                AskedClosing = "false";
            }

            bool parsedValue = false;
            if (Boolean.TryParse(AskedClosing, out parsedValue))
            {
            }
            return parsedValue;
        }

    }
}
