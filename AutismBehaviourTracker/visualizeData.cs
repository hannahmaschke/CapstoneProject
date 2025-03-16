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
using Microsoft.VisualBasic;

namespace AutismBehaviourTracker
{
    public partial class visualizeData : Form
    {
        private string chartName;

        public visualizeData()
        {
            InitializeComponent();
            LoadSleepChart();
            LoadSocialChart();
            LoadEyeContactChart();
            LoadMeltdownChart();
            DatabaseSetup.CreateSavedChartsTable();
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

        // this function allows the user to save a chart as an image
        private void btnSaveChart_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Chart Image";
                saveFileDialog.FileName = "chart.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // determine which chart to save
                    Chart selectedChart = sleepChart; // default to sleepChart


                    // save the chart as an image
                    selectedChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    MessageBox.Show("Chart saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // save the socialize chart as an image
        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Chart Image";
                saveFileDialog.FileName = "chart.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // determine which chart to save
                    Chart selectedChart = socialChart;


                    // save the chart as an image
                    selectedChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    MessageBox.Show("Chart saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // save the eye contact chart as an image
        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Chart Image";
                saveFileDialog.FileName = "chart.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // determine which chart to save
                    Chart selectedChart = eyeContactChart;


                    // save the chart as an image
                    selectedChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    MessageBox.Show("Chart saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // save the meltdown chart as an image
        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Chart Image";
                saveFileDialog.FileName = "chart.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // determine which chart to save
                    Chart selectedChart = meltdownChart;


                    // save the chart as an image
                    selectedChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    MessageBox.Show("Chart saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // allows user to save the chart in the app
        private void saveAppBtnSleep_Click(object sender, EventArgs e)
        {
            Chart selectedChart = sleepChart;

            // get the most recent submission date from db
            string latestDate = DatabaseSetup.GetLatestSubmissionDate();

            string defaultChartName = "Sleep Chart: " + latestDate;

            // open the input form for the user to enter a name
            using (NameChartForm inputForm = new NameChartForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string chartName = string.IsNullOrWhiteSpace(inputForm.ChartName) ? defaultChartName : inputForm.ChartName;
                    DatabaseSetup.SaveChartToDatabase(selectedChart, chartName);
                }
            }

        }

        // button for saving the socialize chart in the app
        private void saveAppBtnSocial_Click(object sender, EventArgs e)
        {
            Chart selectedChart = socialChart;

            // get the most recent submission date from db
            string latestDate = DatabaseSetup.GetLatestSubmissionDate();

            string defaultChartName = "Socialize Chart: " + latestDate;

            // open the input form for the user to enter a name
            using (NameChartForm inputForm = new NameChartForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string chartName = string.IsNullOrWhiteSpace(inputForm.ChartName) ? defaultChartName : inputForm.ChartName;
                    DatabaseSetup.SaveChartToDatabase(selectedChart, chartName);
                }
            }
        }

        // save the eye contact chart in the app
        private void saveAppBtnEye_Click(object sender, EventArgs e)
        {
            Chart selectedChart = eyeContactChart;

            // get the most recent submission date from db
            string latestDate = DatabaseSetup.GetLatestSubmissionDate();

            string defaultChartName = "Eye Contact Chart: " + latestDate;

            // open the input form for the user to enter a name
            using (NameChartForm inputForm = new NameChartForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string chartName = string.IsNullOrWhiteSpace(inputForm.ChartName) ? defaultChartName : inputForm.ChartName;
                    DatabaseSetup.SaveChartToDatabase(selectedChart, chartName);
                }
            }
        }

        // save the meltdown chart in the app
        private void saveAppBtnMeltdown_Click(object sender, EventArgs e)
        {
            Chart selectedChart = meltdownChart;

            // get the most recent submission date from db
            string latestDate = DatabaseSetup.GetLatestSubmissionDate();

            string defaultChartName = "Meltdown Chart: " + latestDate;

            // open the input form for the user to enter a name
            using (NameChartForm inputForm = new NameChartForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string chartName = string.IsNullOrWhiteSpace(inputForm.ChartName) ? defaultChartName : inputForm.ChartName;
                    DatabaseSetup.SaveChartToDatabase(selectedChart, chartName);
                }
            }
        }

        private void savedChartsButton_Click(object sender, EventArgs e)
        {
            SavedCharts savedChartsForm = new SavedCharts();
            savedChartsForm.ShowDialog();
        }

    }
}
