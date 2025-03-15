using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AutismBehaviourTracker
{
    public partial class visualizeData : Form
    {
        public visualizeData()
        {
            InitializeComponent();
            LoadSleepChart();
            LoadSocialChart();
            LoadEyeContactChart();
            LoadMeltdownChart();
        }

        private void visualizeData_Load(object sender, EventArgs e)
        {

        }

        private void LoadSleepChart()
        {
            List<Tuple<DateTime, int>> sleepData = DatabaseSetup.GetSleepDataLast7Days();

            // clear existing series
            sleepChart.Series.Clear();

            // create a new series for sleep hours
            Series sleepSeries = new Series("Sleep Hours")
            {
                ChartType = SeriesChartType.Line, 
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            // add data points 
            foreach (var data in sleepData)
            {
                sleepSeries.Points.AddXY(data.Item1.ToString("MM/dd/yyyy"), data.Item2);
            }

            // add series to chart
            sleepChart.Series.Add(sleepSeries);

            // chart appearance
            sleepChart.ChartAreas[0].AxisX.Title = "Submission Date";
            sleepChart.ChartAreas[0].AxisY.Title = "Sleep Hours";
            sleepChart.ChartAreas[0].RecalculateAxesScale();
        }

        private void LoadSocialChart()
        {
            List<Tuple<string, int>> socialData = DatabaseSetup.GetSocialDataLast7Submissions();

            // clear existing series
            socialChart.Series.Clear();

            // create a new series for social interactions
            Series socialSeries = new Series("Social Interactions")
            {
                ChartType = SeriesChartType.Column, 
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            // add data points
            foreach (var data in socialData)
            {
                socialSeries.Points.AddXY(data.Item1, data.Item2);
            }

            // add series to chart
            socialChart.Series.Add(socialSeries);

            // chart appearance
            socialChart.ChartAreas[0].AxisX.Title = "Submission Date";
            socialChart.ChartAreas[0].AxisY.Title = "Social Interaction Score";
            socialChart.ChartAreas[0].RecalculateAxesScale();
        }

        private void LoadEyeContactChart()
        {
            List<Tuple<string, int>> eyeContactData = DatabaseSetup.GetEyeContactDataLast7Submissions();

            // clear existing series
            eyeContactChart.Series.Clear();

            // create a new series 
            Series eyeContactSeries = new Series("Eye Contact Interactions")
            {
                ChartType = SeriesChartType.Line, 
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            // add data points to the series
            foreach (var data in eyeContactData)
            {
                eyeContactSeries.Points.AddXY(data.Item1, data.Item2);
            }

            // add series to chart
            eyeContactChart.Series.Add(eyeContactSeries);

            // customize chart
            eyeContactChart.ChartAreas[0].AxisX.Title = "Submission Date";
            eyeContactChart.ChartAreas[0].AxisY.Title = "Eye Contact Score";
            eyeContactChart.ChartAreas[0].RecalculateAxesScale();
        }

        private void LoadMeltdownChart()
        {
            List<Tuple<string, int>> meltdownData = DatabaseSetup.GetMeltdownDataLast7Submissions();

            // clear existing series
            meltdownChart.Series.Clear();

            // create a new series 
            Series meltdownSeries = new Series("Meltdowns that occurred")
            {
                ChartType = SeriesChartType.Line, 
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            // add data points to the series
            foreach (var data in meltdownData)
            {
                meltdownSeries.Points.AddXY(data.Item1, data.Item2);
            }

            // add series to chart
            meltdownChart.Series.Add(meltdownSeries);

            // customize chart 
            meltdownChart.ChartAreas[0].AxisX.Title = "Submission Date";
            meltdownChart.ChartAreas[0].AxisY.Title = "Meltdowns that Occured Score";
            meltdownChart.ChartAreas[0].RecalculateAxesScale();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
