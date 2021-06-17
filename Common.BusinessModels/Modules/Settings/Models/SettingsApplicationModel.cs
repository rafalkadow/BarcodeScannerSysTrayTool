

using System.Collections.Generic;

namespace Common.BusinessModels.Modules.Models
{
    public class SettingsApplicationModel
    {
        #region Variables
        public double Delay1 { get; set; }
        public double Delay2 { get; set; }
        public double Delay3 { get; set; }
        public string ExecutablePath { get; set; }
        public bool AskedClosing { get; set; }
        public bool IsPasswordOnApplication { get; set; }
        public string PasswordSettings { get; set; } = "";
        public string PatternRegexCollection { get; set; } = "";
        public List<PatternRegexApplicationModel> PatternRegexList { get; set; }
        public string DefineTheSequence { get; set; }
        #endregion

        public override string ToString()
        {
            return $"[Delay1 = ({Delay1}), Delay2 = ({Delay2}), Delay3 = ({Delay3}), ExecutablePath=({ExecutablePath}), AskedClosing=({AskedClosing}), DefineTheSequence=({DefineTheSequence}),IsPasswordOnApplication=({IsPasswordOnApplication})]";
        }
    }
}
