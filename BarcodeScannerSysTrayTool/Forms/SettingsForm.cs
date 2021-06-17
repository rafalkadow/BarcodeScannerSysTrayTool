using Common.BusinessLogic.Modules.Settings.Utilities;
using Common.BusinessModels.Modules.Models;
using Common.Utilities.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using BarcodeScannerSysTrayTool.Forms;
using System.Linq;
using System.Collections.Generic;
using Common.BusinessLogic.Utilities;

namespace BarcodeScannerSysTrayTool
{
    public partial class SettingsForm : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public event Action<SettingsApplicationModel> SettingsApplicationModelConfirmOk;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public void LoadDataForm()
        {
            logger.Info("LoadDataForm()");

            try
            {
                var settingsApplicationUtility = new SettingsApplicationUtility();
                var settingsApplicationModel = settingsApplicationUtility.LoadDataSettings(Application.ExecutablePath);
                textBoxDelay1.Text = settingsApplicationModel.Delay1.ToString();
                textBoxDelay2.Text = settingsApplicationModel.Delay2.ToString();
                textBoxDelay3.Text = settingsApplicationModel.Delay3.ToString();

                textBoxPassword.Text = settingsApplicationModel.PasswordSettings.ToString();
                
                checkBoxAskedClosing.Checked = settingsApplicationModel.AskedClosing;

                listViewPatterns.Items.Clear();
                foreach (var element in settingsApplicationModel.PatternRegexList)
                {
                    ListViewItem item = new ListViewItem(element.NamePattern);
                    item.SubItems.Add(element.PatternValue);
                    item.SubItems.Add(element.DefineTheSequence);
                    item.Tag = element;
                    listViewPatterns.Items.Add(item);
                }

                richTextBoxDefineTheSequence.Text = settingsApplicationModel.DefineTheSequence;
            }
            catch (Exception ex)
            {
                logger.Fatal("LoadDataForm(ex='{0}')", ex.StackTrace);
            }
        }

        private void buttonSettingsCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateDelay(TextBox textBoxDelay)
        {
            bool bStatus = true;
            if (textBoxDelay.Text == "")
            {
                errorProvider1.SetError(textBoxDelay, "Please enter value");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textBoxDelay, "");
                try
                {
                    double number;
                    errorProvider1.SetError(textBoxDelay, "");

                    if (!Double.TryParse(textBoxDelay.Text, out number))
                    {
                        errorProvider1.SetError(textBoxDelay, "Please enter valid decimal value");
                        bStatus = false;
                    }
                    else
                    {
                        errorProvider1.SetError(textBoxDelay, "");
                    }
                }
                catch
                {
                    errorProvider1.SetError(textBoxDelay, "Please enter valid decimal value");
                    bStatus = false;
                }
            }
            return bStatus;
        }

        private bool ValidatePassword(TextBox textBoxPassword, bool checkBoxPassword)
        {
            bool bStatus = true;
            if (!checkBoxPassword)
            {
                errorProvider1.SetError(textBoxPassword, "");
                return bStatus;
            }

            if (textBoxPassword.Text == "")
            {
                errorProvider1.SetError(textBoxPassword, "Please enter value");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textBoxPassword, "");
                try
                {
                    errorProvider1.SetError(textBoxPassword, "");

                    if (string.IsNullOrEmpty(textBoxPassword.Text) || textBoxPassword.Text.Length < 5)
                    {
                        errorProvider1.SetError(textBoxPassword, "Please enter valid password value, min length is 5 chars");
                        bStatus = false;
                    }
                    else
                    {
                        errorProvider1.SetError(textBoxPassword, "");
                    }
                }
                catch
                {
                    errorProvider1.SetError(textBoxPassword, "Please enter valid password");
                    bStatus = false;
                }
            }
            return bStatus;
        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword(textBoxPassword, checkBoxPassword.Checked);
        }
        
        #region Events Validation
        private void textBoxDelay1_Validating(object sender, CancelEventArgs e)
        {
            ValidateDelay(textBoxDelay1);
        }

        private void textBoxDelay2_Validating(object sender, CancelEventArgs e)
        {
            ValidateDelay(textBoxDelay2);
        }

        private void textBoxDelay3_Validating(object sender, CancelEventArgs e)
        {
            ValidateDelay(textBoxDelay3);
        }
        #endregion

        private void buttonPatternAdd_Click(object sender, EventArgs e)
        {
            var patternRegexApplicationModel = new PatternRegexApplicationModel
            {
                Guid = Guid.NewGuid().ToString(),
                DefineTheSequence = richTextBoxDefineTheSequence.Text
            };

            var patternRegexAdd = new PatternRegexAdd(patternRegexApplicationModel);
            patternRegexAdd.PatternRegexAddConfirmOk += PatternRegexAdd_PatternRegexAddConfirmOk;
            patternRegexAdd.ShowDialog();
        }

        private void PatternRegexAdd_PatternRegexAddConfirmOk(PatternRegexApplicationModel patternRegexApplicationModel)
        {
            bool updateRecord = false;
            foreach (ListViewItem item in listViewPatterns.Items)
            {
                PatternRegexApplicationModel tagValue = (PatternRegexApplicationModel)item.Tag;

                if (tagValue.Guid == patternRegexApplicationModel.Guid)
                {
                    item.Text = patternRegexApplicationModel.NamePattern;
                    ListViewItem.ListViewSubItem patternValueItem = item.SubItems[1];
                    patternValueItem.Text = patternRegexApplicationModel.PatternValue;
                    ListViewItem.ListViewSubItem defineTheSequenceItem = item.SubItems[2];
                    defineTheSequenceItem.Text = patternRegexApplicationModel.DefineTheSequence;
                    item.Tag = patternRegexApplicationModel;
                    updateRecord = true;
                }
            }  

            if(!updateRecord)
            {
                ListViewItem item = new ListViewItem(patternRegexApplicationModel.NamePattern);
                item.SubItems.Add(patternRegexApplicationModel.PatternValue);
                item.SubItems.Add(patternRegexApplicationModel.DefineTheSequence);
                item.Tag = patternRegexApplicationModel;
                listViewPatterns.Items.Add(item);
            }
        }

        private void buttonPatternRemove_Click(object sender, EventArgs e)
        {
            string dateTimeStr = DateTimeToStringUtility.AddDateTime("");

            if (listViewPatterns.SelectedItems == null || listViewPatterns.SelectedItems.Count == 0)
            {
                toolStripStatusLabelSettings.Text = dateTimeStr + " Select the record to be delete" ;
                return;
            }

            if (MessageBox.Show("Are you sure you want remove the selected record?", "Barcode scanner", MessageBoxButtons.YesNo)
               == DialogResult.Yes)
            {
                ListViewItem empChosen = new ListViewItem();

                empChosen = listViewPatterns.SelectedItems[0];

                int rowChosen = empChosen.Index;

                listViewPatterns.Items[rowChosen].Remove();
            }
        }

        private string GetPatternRegexCollection()
        {
            string result = "";
            foreach (ListViewItem item in listViewPatterns.Items)
            {
                if(!string.IsNullOrEmpty(result))
                {
                    result += "~";
                }

                var tagValue = (PatternRegexApplicationModel)item.Tag;
                result += tagValue.Guid + "|" + tagValue.NamePattern + "|" + tagValue.PatternValue + "|" + tagValue.DefineTheSequence;
            }
            return result;
        }

        private List<PatternRegexApplicationModel> GetPatternRegexList()
        {
            List<PatternRegexApplicationModel> result = new List<PatternRegexApplicationModel>();
            foreach (ListViewItem item in listViewPatterns.Items)
            {
                var tagValue = (PatternRegexApplicationModel)item.Tag;
                result.Add(tagValue);
            }
            return result;
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string dateTimeStr = DateTimeToStringUtility.AddDateTime("");
                if (ValidateDelay(textBoxDelay1) && ValidateDelay(textBoxDelay2) && ValidateDelay(textBoxDelay3) && ValidatePassword(textBoxPassword,checkBoxPassword.Checked))
                {
                    var settingsApplicationModel = new SettingsApplicationModel
                    {
                        Delay1 = Convert.ToDouble(textBoxDelay1.Text),
                        Delay2 = Convert.ToDouble(textBoxDelay2.Text),
                        Delay3 = Convert.ToDouble(textBoxDelay3.Text),
                        PasswordSettings = textBoxPassword.Text,
                        AskedClosing = checkBoxAskedClosing.Checked,
                        IsPasswordOnApplication = checkBoxPassword.Checked,
                        ExecutablePath = Application.ExecutablePath,
                        PatternRegexCollection = GetPatternRegexCollection(),
                        PatternRegexList = GetPatternRegexList(),
                        DefineTheSequence = richTextBoxDefineTheSequence.Text,
                    };
                    
                    var settingsApplicationUtility = new SettingsApplicationUtility();
                    ResponseOperation responseOperation = settingsApplicationUtility.SaveSettingsElements(settingsApplicationModel);
                    if (responseOperation.OperationStatus)
                    {
                        toolStripStatusLabelSettings.Text = dateTimeStr + " Settings have saved";
                        if (settingsApplicationModel != null)
                        {
                            SettingsApplicationModelConfirmOk(settingsApplicationModel);
                        }
                    }
                    else
                    {
                        toolStripStatusLabelSettings.Text = dateTimeStr + " Settings haven't saved" ;
                    }
                }
                else
                {
                    toolStripStatusLabelSettings.Text = "Settings (errors validation) haven't saved at " + dateTimeStr;
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("buttonGeneralSave_Click(ex='{0}')", ex.StackTrace);
            }
        }

        private void buttonPatternUpdate_Click(object sender, EventArgs e)
        {
            if (listViewPatterns.SelectedItems == null || listViewPatterns.SelectedItems.Count == 0)
            {
                MessageBox.Show("No selected record");
                return;
            }

            ListViewItem selectedItem = listViewPatterns.SelectedItems[0];
            var patternRegexApplicationModel = (PatternRegexApplicationModel)selectedItem.Tag;

            var patternRegexAdd = new PatternRegexAdd(patternRegexApplicationModel);
            patternRegexAdd.PatternRegexAddConfirmOk += PatternRegexAdd_PatternRegexAddConfirmOk;
            patternRegexAdd.ShowDialog();
        }
    }
}
