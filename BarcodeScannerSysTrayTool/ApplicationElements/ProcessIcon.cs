using BarcodeScannerSysTrayTool.Forms;
using BarcodeScannerSysTrayTool.Properties;
using Common.BusinessLogic.Modules.Settings.Utilities;
using Common.BusinessModels.Modules.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BarcodeScannerSysTrayTool.ApplicationElements
{
    public class ProcessIcon : IDisposable
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        public NotifyIcon notifyIconObject;
        private SettingsApplicationModel SettingsApplicationModelApplication = new SettingsApplicationModel();

        private bool isAuthenticationFormLoaded = false;
        
        private SettingsForm settingsForm;

        private string barcode = string.Empty;

        private bool resultOperation = false;

        private string defineTheSequencePatternBarcode = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessIcon"/> class.
        /// </summary>
        public ProcessIcon()
        {
            logger.Info("ProcessIcon()");
            // Instantiate the NotifyIcon object.
            notifyIconObject = new NotifyIcon();
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
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "LoadDataForm failed");
            }
        }
        
        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            notifyIconObject.MouseClick += new MouseEventHandler(ni_MouseClick);
            notifyIconObject.Icon = Resources.barcode_32;
            notifyIconObject.Text = "Barcode Scanner SysTray Tool";
            notifyIconObject.Visible = true;

            HookManager.KeyPress += HookManager_KeyPress;
            HookManager.KeyUp += HookManager_KeyUp;

            settingsForm = new SettingsForm();
            settingsForm.SettingsApplicationModelConfirmOk += SettingsApplicationModel_ConfirmEvent;
            // Attach a context menu.
            notifyIconObject.ContextMenuStrip = new ContextMenus(settingsForm).Create();
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            if (resultOperation)
            {
                logger.Info("HookManager_KeyUp(barcode='{0}')", barcode);
                e.Handled = true;
                HookManager.KeyUp -= HookManager_KeyUp;
                HookManager.KeyPress -= HookManager_KeyPress;
                StartSending(barcode);
                ResetBarcodeState();
                HookManager.KeyUp += HookManager_KeyUp;
                HookManager.KeyPress += HookManager_KeyPress;
            }
        }

        private  void SettingsApplicationModel_ConfirmEvent(SettingsApplicationModel settingsApplicationModel)
        {
            SettingsApplicationModelApplication = settingsApplicationModel;
        }
     
        private void ResetBarcodeState()
        {
            barcode = string.Empty;
            resultOperation = false;
            defineTheSequencePatternBarcode = string.Empty;
        }

        private bool TryMatchConfiguredPatterns(string value, out string defineTheSequence)
        {
            defineTheSequence = string.Empty;
            var patterns = SettingsApplicationModelApplication?.PatternRegexList;
            if (patterns == null || patterns.Count == 0)
            {
                return false;
            }

            foreach (var pattern in patterns)
            {
                if (string.IsNullOrEmpty(pattern?.PatternValue))
                {
                    continue;
                }

                try
                {
                    if (Regex.IsMatch(value, pattern.PatternValue, RegexOptions.None, TimeSpan.FromSeconds(1)))
                    {
                        defineTheSequence = pattern.DefineTheSequence ?? string.Empty;
                        return true;
                    }
                }
                catch (RegexMatchTimeoutException ex)
                {
                    logger.Warn(ex, "Pattern match timeout for '{0}'", pattern.NamePattern);
                }
                catch (ArgumentException ex)
                {
                    logger.Warn(ex, "Invalid regex for pattern '{0}'", pattern.NamePattern);
                }
            }

            return false;
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                logger.Debug("HookManager_KeyPress(key='{0}')", e.KeyChar);

                if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != '/') && (e.KeyChar != '-'))
                {
                    ResetBarcodeState();
                    return;
                }

                if (e.KeyChar != (char)Keys.Enter)
                {
                    barcode += e.KeyChar;
                }

                resultOperation = false;
                defineTheSequencePatternBarcode = string.Empty;

                if (TryMatchConfiguredPatterns(barcode, out string sequence))
                {
                    resultOperation = true;
                    defineTheSequencePatternBarcode = sequence;
                }

                if (!resultOperation)
                {
                    if (!string.IsNullOrEmpty(barcode) && barcode.Length > 30)
                    {
                        ResetBarcodeState();
                    }
                    else if (e.KeyChar == (char)Keys.Enter)
                    {
                        ResetBarcodeState();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "HookManager_KeyPress failed");
            }
        }
        
        private void AnalyzeDefineTheSequence(string elementSequence, string barcodeValue, string valuesString)
        {
            logger.Info("AnalyzeDefineTheSequence(elementSequence='{0}',barcodeValue='{1}',valuesString='{2}')", elementSequence, barcodeValue, valuesString);

            int Delay1 = (int)(SettingsApplicationModelApplication.Delay1 * 1000);
            int Delay2 = (int)(SettingsApplicationModelApplication.Delay2 * 1000);
            int Delay3 = (int)(SettingsApplicationModelApplication.Delay3 * 1000);

            switch (elementSequence)
            {
                case "BARCODE":
                    SendKeys.SendWait(barcodeValue);
                    break;

                case "RETURN":
                    SendKeys.SendWait("{" + Enum.GetName(typeof(Keys), Keys.Return) + "}");
                    break;

                case "ENTER":
                    SendKeys.SendWait("{" + Enum.GetName(typeof(Keys), Keys.Enter) + "}");
                    break;

                case "F1":
                case "F2":
                case "F3":
                case "F4":
                case "F5":
                case "F6":
                case "F7":
                case "F8":
                case "F9":
                case "F10":
                case "F11":
                case "F12":
                    SendKeys.SendWait("{" + elementSequence + "}");
                    break;

                case "DELAY1":
                    Thread.Sleep(Delay1);
                    break;

                case "DELAY2":
                    Thread.Sleep(Delay2);
                    break;

                case "DELAY3":
                    Thread.Sleep(Delay3);
                    break;

                case "TAB":
                    
                    SendKeys.SendWait("{" + Enum.GetName(typeof(Keys), Keys.Tab) + "}");
                    break;

                case "(STRG~A)":
                    SendKeys.SendWait("^a");
                    break;

                case "(STRG~C)":
                    SendKeys.SendWait("^c");
                    break;

                case "(STRG~V)":
                    SendKeys.SendWait("^v");
                    break;

                case "(STRG~S)":
                    SendKeys.SendWait("^s");
                    break;

                case "ALTKEY":
                    SendKeys.Send("%");
                    break;

                case "ALTGRKEY":
                    SendKeys.Send("^%");
                    break;

                case "VALUE":
                    SendKeys.SendWait(valuesString);
                    break;
            }
        }

        private static string ExtractQuotedValue(string analyzeSequence, string openQuote, string closeQuote)
        {
            int start = analyzeSequence.IndexOf(openQuote, StringComparison.Ordinal);
            if (start < 0)
            {
                return string.Empty;
            }

            start += openQuote.Length;
            int end = analyzeSequence.IndexOf(closeQuote, start, StringComparison.Ordinal);
            if (end < 0 || end <= start)
            {
                return string.Empty;
            }

            return analyzeSequence.Substring(start, end - start);
        }

        private string GetValueFromSequenceFirst(string analyzeSequence)
        {
            return ExtractQuotedValue(analyzeSequence, "\"", "\"");
        }

        private string GetValueFromSequenceSecond(string analyzeSequence)
        {
            return ExtractQuotedValue(analyzeSequence, "“", "”");
        }

        private void StartSending(string barcodeValue)
        {
            logger.Info("StartSending(barcodeValue='{0}')", barcodeValue);
            try
            {
                string DefineTheSequence = defineTheSequencePatternBarcode;
                string DefineTheSequenceCopy = defineTheSequencePatternBarcode;

                if (string.IsNullOrEmpty(DefineTheSequence))
                {
                    return;
                }

                //Remove space
                DefineTheSequence = DefineTheSequence.Replace(" ", string.Empty);
                DefineTheSequence = DefineTheSequence.Replace("\n", string.Empty);
                //-------------------------
                DefineTheSequenceCopy = DefineTheSequenceCopy.Replace(" ", string.Empty);
                DefineTheSequenceCopy = DefineTheSequenceCopy.Replace("\n", string.Empty);

                //ToUpper
                DefineTheSequence = DefineTheSequence.ToUpper();

                if (DefineTheSequence.StartsWith("BARCODE"))
                {
                    DefineTheSequence = DefineTheSequence.Remove(0, "BARCODE".Length);
                    DefineTheSequenceCopy = DefineTheSequenceCopy.Remove(0, "BARCODE".Length);
                }

                DefineTheSequence = DefineTheSequence.Replace("(STRG+A)", "(STRG~A)");
                DefineTheSequence = DefineTheSequence.Replace("(STRG+C)", "(STRG~C)");
                DefineTheSequence = DefineTheSequence.Replace("(STRG+V)", "(STRG~V)");
                DefineTheSequence = DefineTheSequence.Replace("(STRG+S)", "(STRG~S)");

                string[] tabCollection = DefineTheSequence.Split('+');
                List<string> listCollection = new List<string>(tabCollection);

                string[] tabCollectionCopy = DefineTheSequenceCopy.Split('+');
                List<string> listCollectionCopy = new List<string>(tabCollectionCopy);

                string valuesString = string.Empty;

                for (int i = 0; i < listCollection.Count; i++)
                {
                    string analyzeSequence = listCollection[i].ToUpperInvariant();
                    if (listCollectionCopy[i].Contains("\""))
                    {
                        analyzeSequence = listCollectionCopy[i];
                        valuesString = GetValueFromSequenceFirst(analyzeSequence);
                        analyzeSequence = "VALUE";
                    }
                    else if (listCollectionCopy[i].Contains("“"))
                    {
                        analyzeSequence = listCollectionCopy[i];
                        valuesString = GetValueFromSequenceSecond(analyzeSequence);
                        analyzeSequence = "VALUE";
                    }
                    else
                    {
                        valuesString = string.Empty;
                    }
                    AnalyzeDefineTheSequence(analyzeSequence, barcodeValue, valuesString);
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "StartSending failed");
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            HookManager.KeyPress -= HookManager_KeyPress;
            HookManager.KeyUp -= HookManager_KeyUp;

            if (settingsForm != null)
            {
                settingsForm.SettingsApplicationModelConfirmOk -= SettingsApplicationModel_ConfirmEvent;
                settingsForm.Dispose();
                settingsForm = null;
            }

            if (notifyIconObject != null)
            {
                notifyIconObject.MouseClick -= ni_MouseClick;
                notifyIconObject.ContextMenuStrip?.Dispose();
                notifyIconObject.Visible = false;
                notifyIconObject.Dispose();
                notifyIconObject = null;
            }
        }

        /// <summary>
        /// Handles the MouseClick event of the ni control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        public void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // Start 
                if (!isAuthenticationFormLoaded)
                {
                    isAuthenticationFormLoaded = true;
                    new AuthenticationForm(settingsForm).ShowDialog();
                    isAuthenticationFormLoaded = false;
                }
            }
        }

    }
}
