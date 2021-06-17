using Common.BusinessModels.Modules.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeScannerSysTrayTool.Forms
{
    public partial class PatternRegexAdd : Form
    {
        public event Action<PatternRegexApplicationModel> PatternRegexAddConfirmOk;
        PatternRegexApplicationModel PatternRegexForm;
        public PatternRegexAdd(PatternRegexApplicationModel patternRegexApplicationModel)
        {
            InitializeComponent();
            textBoxNamePattern.Text = patternRegexApplicationModel.NamePattern;
            textBoxPatternValue.Text = patternRegexApplicationModel.PatternValue;
            richTextBoxDefineTheSequence.Text = patternRegexApplicationModel.DefineTheSequence;
            PatternRegexForm = patternRegexApplicationModel;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPatternSave_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(textBoxNamePattern.Text) || string.IsNullOrEmpty(textBoxPatternValue.Text) || string.IsNullOrEmpty(richTextBoxDefineTheSequence.Text))
            {
                MessageBox.Show("Enter values : Name pattern and Pattern value and Define the sequence (send string)");
                return;
            }

            PatternRegexForm.NamePattern = textBoxNamePattern.Text;
            PatternRegexForm.PatternValue = textBoxPatternValue.Text;
            PatternRegexForm.DefineTheSequence = richTextBoxDefineTheSequence.Text;
            PatternRegexAddConfirmOk(PatternRegexForm);
            this.Close();
        }
        
    }
}
