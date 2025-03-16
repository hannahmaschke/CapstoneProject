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
            this.btnSaveSleepChart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.savedChartsButton = new System.Windows.Forms.Button();
            this.saveAppBtnSleep = new System.Windows.Forms.Button();
            this.saveAppBtnSocial = new System.Windows.Forms.Button();
            this.saveAppBtnEye = new System.Windows.Forms.Button();
            this.saveAppBtnMeltdown = new System.Windows.Forms.Button();
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
            this.socialChart.Size = new System.Drawing.Size(543, 300);
            this.socialChart.TabIndex = 3;
            this.socialChart.Text = "chart1";
            // 
            // eyeContactChart
            // 
            chartArea3.Name = "ChartArea1";
            this.eyeContactChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.eyeContactChart.Legends.Add(legend3);
            this.eyeContactChart.Location = new System.Drawing.Point(31, 400);
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
            this.meltdownChart.Location = new System.Drawing.Point(588, 400);
            this.meltdownChart.Name = "meltdownChart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.meltdownChart.Series.Add(series4);
            this.meltdownChart.Size = new System.Drawing.Size(512, 382);
            this.meltdownChart.TabIndex = 5;
            this.meltdownChart.Text = "chart2";
            // 
            // btnSaveSleepChart
            // 
            this.btnSaveSleepChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSaveSleepChart.Location = new System.Drawing.Point(428, 151);
            this.btnSaveSleepChart.Name = "btnSaveSleepChart";
            this.btnSaveSleepChart.Size = new System.Drawing.Size(181, 41);
            this.btnSaveSleepChart.TabIndex = 7;
            this.btnSaveSleepChart.Text = "Save Chart as JPG";
            this.btnSaveSleepChart.UseVisualStyleBackColor = false;
            this.btnSaveSleepChart.Click += new System.EventHandler(this.btnSaveChart_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(992, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 41);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save Chart as JPG";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(417, 457);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 46);
            this.button2.TabIndex = 9;
            this.button2.Text = "Save Chart as JPG";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(968, 457);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 46);
            this.button3.TabIndex = 10;
            this.button3.Text = "Save Chart as JPG";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // savedChartsButton
            // 
            this.savedChartsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.savedChartsButton.Location = new System.Drawing.Point(862, 37);
            this.savedChartsButton.Name = "savedChartsButton";
            this.savedChartsButton.Size = new System.Drawing.Size(177, 38);
            this.savedChartsButton.TabIndex = 11;
            this.savedChartsButton.Text = "View saved charts";
            this.savedChartsButton.UseVisualStyleBackColor = false;
            this.savedChartsButton.Click += new System.EventHandler(this.savedChartsButton_Click);
            // 
            // saveAppBtnSleep
            // 
            this.saveAppBtnSleep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.saveAppBtnSleep.Location = new System.Drawing.Point(428, 210);
            this.saveAppBtnSleep.Name = "saveAppBtnSleep";
            this.saveAppBtnSleep.Size = new System.Drawing.Size(181, 40);
            this.saveAppBtnSleep.TabIndex = 12;
            this.saveAppBtnSleep.Text = "Save in app";
            this.saveAppBtnSleep.UseVisualStyleBackColor = false;
            this.saveAppBtnSleep.Click += new System.EventHandler(this.saveAppBtnSleep_Click);
            // 
            // saveAppBtnSocial
            // 
            this.saveAppBtnSocial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.saveAppBtnSocial.Location = new System.Drawing.Point(992, 210);
            this.saveAppBtnSocial.Name = "saveAppBtnSocial";
            this.saveAppBtnSocial.Size = new System.Drawing.Size(183, 40);
            this.saveAppBtnSocial.TabIndex = 13;
            this.saveAppBtnSocial.Text = "Save in app";
            this.saveAppBtnSocial.UseVisualStyleBackColor = false;
            this.saveAppBtnSocial.Click += new System.EventHandler(this.saveAppBtnSocial_Click);
            // 
            // saveAppBtnEye
            // 
            this.saveAppBtnEye.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.saveAppBtnEye.Location = new System.Drawing.Point(417, 520);
            this.saveAppBtnEye.Name = "saveAppBtnEye";
            this.saveAppBtnEye.Size = new System.Drawing.Size(181, 43);
            this.saveAppBtnEye.TabIndex = 14;
            this.saveAppBtnEye.Text = "Save in app";
            this.saveAppBtnEye.UseVisualStyleBackColor = false;
            this.saveAppBtnEye.Click += new System.EventHandler(this.saveAppBtnEye_Click);
            // 
            // saveAppBtnMeltdown
            // 
            this.saveAppBtnMeltdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.saveAppBtnMeltdown.Location = new System.Drawing.Point(968, 520);
            this.saveAppBtnMeltdown.Name = "saveAppBtnMeltdown";
            this.saveAppBtnMeltdown.Size = new System.Drawing.Size(181, 43);
            this.saveAppBtnMeltdown.TabIndex = 15;
            this.saveAppBtnMeltdown.Text = "Save in app";
            this.saveAppBtnMeltdown.UseVisualStyleBackColor = false;
            this.saveAppBtnMeltdown.Click += new System.EventHandler(this.saveAppBtnMeltdown_Click);
            // 
            // visualizeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1224, 831);
            this.Controls.Add(this.saveAppBtnMeltdown);
            this.Controls.Add(this.saveAppBtnEye);
            this.Controls.Add(this.saveAppBtnSocial);
            this.Controls.Add(this.saveAppBtnSleep);
            this.Controls.Add(this.savedChartsButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSaveSleepChart);
            this.Controls.Add(this.meltdownChart);
            this.Controls.Add(this.eyeContactChart);
            this.Controls.Add(this.socialChart);
            this.Controls.Add(this.visualizeDataLabel);
            this.Controls.Add(this.sleepChart);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "visualizeData";
            this.Text = "View your child\'s progress";
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
        private System.Windows.Forms.Button btnSaveSleepChart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button savedChartsButton;
        private System.Windows.Forms.Button saveAppBtnSleep;
        private System.Windows.Forms.Button saveAppBtnSocial;
        private System.Windows.Forms.Button saveAppBtnEye;
        private System.Windows.Forms.Button saveAppBtnMeltdown;
    }
}