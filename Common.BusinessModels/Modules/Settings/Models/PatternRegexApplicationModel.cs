using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessModels.Modules.Models
{
    public class PatternRegexApplicationModel
    {
        #region Variables
        public string Guid { get; set; }
        public string NamePattern { get; set; }
        public string PatternValue { get; set; }
        public string DefineTheSequence { get; set; }

        #endregion

        public override string ToString()
        {
            return $"[NamePattern = ({NamePattern}), PatternValue = ({PatternValue}), DefineTheSequence = ({DefineTheSequence})]";
        }
    }
}
