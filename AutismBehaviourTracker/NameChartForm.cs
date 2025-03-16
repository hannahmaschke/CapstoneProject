using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutismBehaviourTracker
{
    public partial class NameChartForm : Form
    {
        public string ChartName { get; private set; }

        public NameChartForm()
        {
            InitializeComponent();
            //txtChartName.Text = defaultName; 
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NameChartForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ChartName = string.IsNullOrWhiteSpace(txtChartName.Text) ? txtChartName.Text : txtChartName.Text.Trim();
            //ChartName = txtChartName.Text.Trim();
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }
    }
}
