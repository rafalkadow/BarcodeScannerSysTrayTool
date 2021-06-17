using Common.BusinessLogic.Utilities;
using Common.BusinessModels.Modules.Models;
using Common.BusinessModels.Modules.Settings.Constants;
using Common.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Common.BusinessLogic.Modules.Settings.Utilities
{
    public class SettingsApplicationUtility
    {
        
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        #region SaveSettingsElements
        public ResponseOperation SaveSettingsElements(SettingsApplicationModel settingsApplicationModel)
        {
            logger.Info("SaveSettingsElements(settingsApplicationModel=({0})", settingsApplicationModel.ToString());
            ResponseOperation responseOperation = new ResponseOperation();
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(settingsApplicationModel.ExecutablePath);

                config.AppSettings.Settings.Remove(SettingsApplicationConstants.Delay1);
                config.AppSettings.Settings.Add(SettingsApplicationConstants.Delay1, settingsApplicationModel.Delay1.ToString());

                config.AppSettings.Settings.Remove(SettingsApplicationConstants.Delay2);
                config.AppSettings.Settings.Add(SettingsApplicationConstants.Delay2, settingsApplicationModel.Delay2.ToString());

                config.AppSettings.Settings.Remove(SettingsApplicationConstants.Delay3);
                config.AppSettings.Settings.Add(SettingsApplicationConstants.Delay3, settingsApplicationModel.Delay3.ToString());

                config.AppSettings.Settings.Remove(SettingsApplicationConstants.AskedClosing);
                config.AppSettings.Settings.Add(SettingsApplicationConstants.AskedClosing, settingsApplicationModel.AskedClosing.ToString());

                
                config.AppSettings.Settings.Remove(SettingsApplicationConstants.IsPasswordOnApplication);
                config.AppSettings.Settings.Add(SettingsApplicationConstants.IsPasswordOnApplication, settingsApplicationModel.IsPasswordOnApplication.ToString());

                config.AppSettings.Settings.Remove(SettingsApplicationConstants.PasswordSettings);
                config.AppSettings.Settings.Add(SettingsApplicationConstants.PasswordSettings, settingsApplicationModel.PasswordSettings != null ? ApplicationEncrypterDecrypt.Encrypt(settingsApplicationModel.PasswordSettings.ToString()) : string.Empty);

                config.AppSettings.Settings.Remove(SettingsApplicationConstants.PatternRegexCollection);
                config.AppSettings.Settings.Add(SettingsApplicationConstants.PatternRegexCollection, settingsApplicationModel.PatternRegexCollection != null ? settingsApplicationModel.PatternRegexCollection.ToString() : string.Empty);

                config.AppSettings.Settings.Remove(SettingsApplicationConstants.DefineTheSequence);
                config.AppSettings.Settings.Add(SettingsApplicationConstants.DefineTheSequence, settingsApplicationModel.DefineTheSequence != null ? settingsApplicationModel.DefineTheSequence.ToString() : string.Empty);


                config.Save(ConfigurationSaveMode.Modified);

                responseOperation.OperationStatus = true;
            }
            catch (Exception ex)
            {
                logger.Error("SaveSettingsElements(ex=({0})", ex.StackTrace.ToString());
                responseOperation.Exception = ex.ToString();
                return responseOperation;
            }
            return responseOperation;
        }
        #endregion

        #region LoadDataSettings
        public SettingsApplicationModel LoadDataSettings(string executablePath)
        {
            logger.Info("LoadDataSettings(executablePath=({0})", executablePath);
            var settingsApplicationModel = new SettingsApplicationModel();
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(executablePath);
                string Delay1;
                if (config.AppSettings.Settings[SettingsApplicationConstants.Delay1] != null)
                {
                    Delay1 = config.AppSettings.Settings[SettingsApplicationConstants.Delay1].Value;
                }
                else
                {
                    Delay1 = "0,1";
                }

                string Delay2;
                if (config.AppSettings.Settings[SettingsApplicationConstants.Delay2] != null)
                {
                    Delay2 = config.AppSettings.Settings[SettingsApplicationConstants.Delay2].Value;
                }
                else
                {
                    Delay2 = "0,3";
                }

                string Delay3;
                if (config.AppSettings.Settings[SettingsApplicationConstants.Delay3] != null)
                {
                    Delay3 = config.AppSettings.Settings[SettingsApplicationConstants.Delay3].Value;
                }
                else
                {
                    Delay3 = "2,0";
                }
                
                string AskedClosing = string.Empty;
                if (config.AppSettings.Settings[SettingsApplicationConstants.AskedClosing] != null)
                {
                    AskedClosing = config.AppSettings.Settings[SettingsApplicationConstants.AskedClosing].Value;
                }
                else
                {
                    AskedClosing = "false";
                }

                bool parsedValueAskedClosing;
                if (Boolean.TryParse(AskedClosing, out parsedValueAskedClosing))
                {
                   
                }

                //<!--------------------------------------------------------------------------------------
                string IsPasswordOnApplication = string.Empty;
                if (config.AppSettings.Settings[SettingsApplicationConstants.IsPasswordOnApplication] != null)
                {
                    IsPasswordOnApplication = config.AppSettings.Settings[SettingsApplicationConstants.IsPasswordOnApplication].Value;
                }
                else
                {
                    IsPasswordOnApplication = "false";
                }

                bool parsedValueIsPasswordOnApplication;
                if (Boolean.TryParse(IsPasswordOnApplication, out parsedValueIsPasswordOnApplication))
                {

                }

                string PasswordSettings;
                if (config.AppSettings.Settings[SettingsApplicationConstants.PasswordSettings] != null)
                {
                    PasswordSettings = config.AppSettings.Settings[SettingsApplicationConstants.PasswordSettings].Value;
                }
                else
                {
                    PasswordSettings = "Password";
                }

                string DefineTheSequence;
                if (config.AppSettings.Settings[SettingsApplicationConstants.DefineTheSequence] != null)
                {
                    DefineTheSequence = config.AppSettings.Settings[SettingsApplicationConstants.DefineTheSequence].Value;
                }
                else
                {
                    DefineTheSequence = @"Barcode + Return + delay2 + F7 + delay2 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + “020” + delay1 + Tab + delay1 + Return + delay2";
                }
                
                string PatternRegexCollection;
                if (config.AppSettings.Settings[SettingsApplicationConstants.PatternRegexCollection] != null)
                {
                    PatternRegexCollection = config.AppSettings.Settings[SettingsApplicationConstants.PatternRegexCollection].Value;

                    if (string.IsNullOrEmpty(PatternRegexCollection))
                    {
                        var patternRegexApplicationModel1 = new PatternRegexApplicationModel
                        {
                            Guid = Guid.NewGuid().ToString(),
                            NamePattern = "7000XXXXXX/XXXXX",
                            PatternValue = @"^7000\d{6}/\d{5}",
                            DefineTheSequence = @"Barcode + Return + delay2 + F7 + delay2 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + “020” + delay1 + Tab + delay1 + Return + delay2",
                        };
                        var patternRegexApplicationModel2 = new PatternRegexApplicationModel
                        {
                            Guid = Guid.NewGuid().ToString(),
                            NamePattern = "500XXXXXXX/XXXX",
                            PatternValue = @"^500\d{7}/\d{4}",
                            DefineTheSequence = @"Barcode + Return + delay2 + F7 + delay2 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + “020” + delay1 + Tab + delay1 + Return + delay2",
                        };

                        List<PatternRegexApplicationModel> listModels = new List<PatternRegexApplicationModel>();
                        listModels.Add(patternRegexApplicationModel1);
                        listModels.Add(patternRegexApplicationModel2);
                        string result = "";
                        foreach (PatternRegexApplicationModel item in listModels)
                        {
                            if (!string.IsNullOrEmpty(result))
                            {
                                result += "~";
                            }

                            var tagValue = item;
                            result += item.Guid + "|" + item.NamePattern + "|" + item.PatternValue + "|" + item.DefineTheSequence;
                        }
                        PatternRegexCollection = result;
                    }
                }
                else
                {
                    var patternRegexApplicationModel1 = new PatternRegexApplicationModel
                    {
                        Guid = Guid.NewGuid().ToString(),
                        NamePattern = "7000XXXXXX/XXXXX",
                        PatternValue = @"^7000\d{6}/\d{5}",
                        DefineTheSequence = @"Barcode + Return + delay2 + F7 + delay2 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + “020” + delay1 + Tab + delay1 + Return + delay2",
                    };
                    var patternRegexApplicationModel2 = new PatternRegexApplicationModel
                    {
                        Guid = Guid.NewGuid().ToString(),
                        NamePattern = "500XXXXXXX/XXXX",
                        PatternValue = @"^500\d{7}/\d{4}",
                        DefineTheSequence = @"Barcode + Return + delay2 + F7 + delay2 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + Tab + delay1 + “020” + delay1 + Tab + delay1 + Return + delay2",
                    };

                    List<PatternRegexApplicationModel> listModels = new List<PatternRegexApplicationModel>();
                    listModels.Add(patternRegexApplicationModel1);
                    listModels.Add(patternRegexApplicationModel2);
                    string result = "";
                    foreach (PatternRegexApplicationModel item in listModels)
                    {
                        if (!string.IsNullOrEmpty(result))
                        {
                            result += "~";
                        }

                        var tagValue = item;
                        result += item.Guid + "|" + item.NamePattern + "|" + item.PatternValue + "|" + item.DefineTheSequence;
                    }
                    PatternRegexCollection = result;                    
                }

                settingsApplicationModel.Delay1 = Convert.ToDouble(Delay1);
                settingsApplicationModel.Delay2 = Convert.ToDouble(Delay2);
                settingsApplicationModel.Delay3 = Convert.ToDouble(Delay3);

                settingsApplicationModel.PasswordSettings = ApplicationEncrypterDecrypt.Decrypt(PasswordSettings);
                settingsApplicationModel.AskedClosing = parsedValueAskedClosing;
                settingsApplicationModel.IsPasswordOnApplication = parsedValueIsPasswordOnApplication;
                
                settingsApplicationModel.ExecutablePath = executablePath;
                settingsApplicationModel.PatternRegexList = new List<PatternRegexApplicationModel>();
                settingsApplicationModel.DefineTheSequence = DefineTheSequence;
                    
                if (!string.IsNullOrEmpty(PatternRegexCollection))
                {
                    string[] tabCollection = PatternRegexCollection.Split('~');

                    if (tabCollection != null)
                        for (int i = 0; i < tabCollection.Length; i++)
                        {
                            string element = tabCollection[i];
                            if (!string.IsNullOrEmpty(element))
                            {
                                string[] tabElements = element.Split('|');

                                if (tabElements.Length == 4)
                                {
                                    var patternRegexApplicationModel = new PatternRegexApplicationModel
                                    {
                                        Guid = tabElements[0],
                                        NamePattern = tabElements[1],
                                        PatternValue = tabElements[2],
                                        DefineTheSequence = tabElements[3]
                                    };

                                    settingsApplicationModel.PatternRegexList.Add(patternRegexApplicationModel);
                                }
                            }
                        }

                }

            }
            catch (Exception ex)
            {
                logger.Fatal("LoadDataForm(ex='{0}')", ex.StackTrace);
            }
            return settingsApplicationModel;
        }
        #endregion
    }
}
