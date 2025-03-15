namespace AutismBehaviourTracker
{
    partial class visualizeData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(visualizeData));
            this.cancelButton = new System.Windows.Forms.Button();
            this.sleepChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.visualizeDataLabel = new System.Windows.Forms.Label();
            this.socialChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.eyeContactChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.meltdownChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.sleepChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.socialChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyeContactChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meltdownChart)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cancelButton.Location = new System.Drawing.Point(12, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(131, 35);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Back to Home";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // sleepChart
            // 
            chartArea1.Name = "ChartArea1";
            this.sleepChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.sleepChart.Legends.Add(legend1);
            this.sleepChart.Location = new System.Drawing.Point(12, 104);
            this.sleepChart.Name = "sleepChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.sleepChart.Series.Add(series1);
            this.sleepChart.Size = new System.Drawing.Size(555, 300);
            this.sleepChart.TabIndex = 1;
            this.sleepChart.Text = "chart1";
            // 
            // visualizeDataLabel
            // 
            this.visualizeDataLabel.AutoSize = true;
            this.visualizeDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualizeDataLabel.Location = new System.Drawing.Point(391, 37);
            this.visualizeDataLabel.Name = "visualizeDataLabel";
            this.visualizeDataLabel.Size = new System.Drawing.Size(465, 32);
            this.visualizeDataLabel.TabIndex = 2;
            this.visualizeDataLabel.Text = "Graphs of the past 7 submissions";
            // 
            // socialChart
            // 
            chartArea2.Name = "ChartArea1";
            this.socialChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.socialChart.Legends.Add(legend2);
            this.socialChart.Location = new System.Drawing.Point(599, 94);
            this.socialChart.Name = "socialChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.socialChart.Series.Add(series2);
            this.socialChart.Size = new System.Drawing.Size(555, 300);
            this.socialChart.TabIndex = 3;
            this.socialChart.Text = "chart1";
            // 
            // eyeContactChart
            // 
            chartArea3.Name = "ChartArea1";
            this.eyeContactChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.eyeContactChart.Legends.Add(legend3);
            this.eyeContactChart.Location = new System.Drawing.Point(40, 410);
            this.eyeContactChart.Name = "eyeContactChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.eyeContactChart.Series.Add(series3);
            this.eyeContactChart.Size = new System.Drawing.Size(515, 372);
            this.eyeContactChart.TabIndex = 4;
            this.eyeContactChart.Text = "chart1";
            // 
            // meltdownChart
            // 
            chartArea4.Name = "ChartArea1";
            this.meltdownChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.meltdownChart.Legends.Add(legend4);
            this.meltdownChart.Location = new System.Drawing.Point(599, 400);
            this.meltdownChart.Name = "meltdownChart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.meltdownChart.Series.Add(series4);
            this.meltdownChart.Size = new System.Drawing.Size(512, 382);
            this.meltdownChart.TabIndex = 5;
            this.meltdownChart.Text = "chart2";
            // 
            // visualizeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1224, 831);
            this.Controls.Add(this.meltdownChart);
            this.Controls.Add(this.eyeContactChart);
            this.Controls.Add(this.socialChart);
            this.Controls.Add(this.visualizeDataLabel);
            this.Controls.Add(this.sleepChart);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "visualizeData";
            this.Text = "s";
            this.Load += new System.EventHandler(this.visualizeData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sleepChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.socialChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyeContactChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meltdownChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart sleepChart;
        private System.Windows.Forms.Label visualizeDataLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart socialChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart eyeContactChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart meltdownChart;
    }
}