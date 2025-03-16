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
    public partial class SavedCharts : Form
    {
        public SavedCharts()
        {
            InitializeComponent();
            LoadCharts();
            DatabaseSetup.CreateSavedChartsTable();
        }

        private void SavedCharts_Load(object sender, EventArgs e)
        {

        }

        private void LoadCharts()
        {
            listViewCharts.Items.Clear();

            List<Tuple<int, string, Image>> savedCharts = DatabaseSetup.GetSavedCharts();

            foreach (var chart in savedCharts)
            {
                ListViewItem item = new ListViewItem(chart.Item2);
                item.Tag = chart;
                listViewCharts.Items.Add(item);
            }
        }

        private void listViewCharts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCharts.SelectedItems.Count > 0)
            {
                var selectedChart = (Tuple<int, string, Image>)listViewCharts.SelectedItems[0].Tag;
                pictureBoxChart.Image = selectedChart.Item3;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
