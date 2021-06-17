using BarcodeScannerSysTrayTool.Forms;
using BarcodeScannerSysTrayTool.Properties;
using Common.BusinessLogic.Modules.Settings.Utilities;
using Common.BusinessModels.Modules.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
                logger.Fatal("LoadDataForm(ex='{0}')", ex.StackTrace);
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
            HookManager.KeyDown += HookManager_KeyDown;

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
                HookManager.KeyDown -= HookManager_KeyDown; 
                //Thread.Sleep(1000);
                StartSending(barcode);

                barcode = string.Empty;
                resultOperation = false;
                HookManager.KeyUp += HookManager_KeyUp;
                HookManager.KeyPress += HookManager_KeyPress;
                HookManager.KeyDown += HookManager_KeyDown;
            }
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            logger.Info("HookManager_KeyDown(e.KeyCode='{0}', e.Alt='{1}', e.Control='{2}', e.Modifiers='{3}', e.Shift='{4}', e.SuppressKeyPress='{5}', Control.ModifierKeys='{6}',)", e.KeyCode, e.Alt, e.Control, e.Modifiers, e.Shift, e.SuppressKeyPress, Control.ModifierKeys);
            
            if (e.KeyData.Equals(Keys.F2) || e.KeyData.Equals(Keys.Alt) || Control.ModifierKeys == Keys.Alt)
            {
                logger.Info("HookManager_KeyDown2(e.KeyCode='{0}')", e.KeyCode);
            }
        }

        private  void SettingsApplicationModel_ConfirmEvent(SettingsApplicationModel settingsApplicationModel)
        {
            SettingsApplicationModelApplication = settingsApplicationModel;
        }
     
        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {        
            try
            {
                logger.Info("HookManager_KeyPress(key='{0}')", e.KeyChar);

                if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != '/') && (e.KeyChar != '-'))
                {
                    barcode = string.Empty;
                    return;
                }
                else if (e.KeyChar != (char)Keys.Enter)
                {
                    barcode += e.KeyChar;                    
                }

                var patternOrders = @"^7000\d{6}/\d{5}";
                
                var parser = new Regex(patternOrders);
                var match = parser.Match(barcode);

                if(match.Success)
                {
                    resultOperation = true;
                }

                var patternMaterials = @"^500\d{7}/\d{4}";
                parser = new Regex(patternMaterials);
                match = parser.Match(barcode);                    

                if (match.Success)
                {
                    resultOperation = true;
                }

                if(SettingsApplicationModelApplication.PatternRegexList!=null && SettingsApplicationModelApplication.PatternRegexList.Count > 0)
                {
                    for (int i = 0; i < SettingsApplicationModelApplication.PatternRegexList.Count; i++)
                    {
                        if(!string.IsNullOrEmpty(SettingsApplicationModelApplication.PatternRegexList[i].NamePattern) 
                            && !string.IsNullOrEmpty(SettingsApplicationModelApplication.PatternRegexList[i].PatternValue))
                        {
                            var patternValue = SettingsApplicationModelApplication.PatternRegexList[i].PatternValue;

                            parser = new Regex(patternValue);
                            match = parser.Match(barcode);
                                
                            if (match.Success)
                            {
                                resultOperation = true;
                                defineTheSequencePatternBarcode = SettingsApplicationModelApplication.PatternRegexList[i].DefineTheSequence;
                            }
                        }
                    }
                }

                if (!resultOperation)
                {
                    if (!string.IsNullOrEmpty(barcode) && barcode.Length > 30)
                    {
                        barcode = string.Empty;
                    }
                    else if ((e.KeyChar == (char)Keys.Enter))
                    {
                        barcode = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("HookManager_KeyPressNew(ex='{0}')", ex.StackTrace);
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

        private string GetValueFromSequenceFirst(string analyzeSequence)
        {
            string toFind1 = "\"";
            string toFind2 = "\"";
            int start = analyzeSequence.IndexOf(toFind1) + toFind1.Length;
            int end = analyzeSequence.IndexOf(toFind2, start); //Start after the index of 'my' since 'is' appears twice
            string stringReturn = analyzeSequence.Substring(start, end - start);
            return stringReturn;
        }

        private string GetValueFromSequenceSecond(string analyzeSequence)
        {
            string toFind1 = "“";
            string toFind2 = "”";
            int start = analyzeSequence.IndexOf(toFind1) + toFind1.Length;
            int end = analyzeSequence.IndexOf(toFind2, start); //Start after the index of 'my' since 'is' appears twice
            string stringReturn = analyzeSequence.Substring(start, end - start);
            return stringReturn;
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
                    string analyzeSequence = listCollection[i];
                    if(analyzeSequence.Contains("\""))
                    {
                        analyzeSequence = listCollectionCopy[i];
                        valuesString = GetValueFromSequenceFirst(analyzeSequence);
                        analyzeSequence = "VALUE";
                    }
                    else if (analyzeSequence.Contains("“"))
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
            catch(Exception ex)
            {
                logger.Fatal("StartSending(ex='{0}')", ex.StackTrace);
            }            
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            notifyIconObject.Dispose();
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
