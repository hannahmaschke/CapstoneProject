namespace AutismBehaviourTracker
{
    partial class SavedCharts
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
            this.listViewCharts = new System.Windows.Forms.ListView();
            this.pictureBoxChart = new System.Windows.Forms.PictureBox();
            this.btnLoadCharts = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.savedChartsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewCharts
            // 
            this.listViewCharts.FullRowSelect = true;
            this.listViewCharts.GridLines = true;
            this.listViewCharts.HideSelection = false;
            this.listViewCharts.Location = new System.Drawing.Point(32, 100);
            this.listViewCharts.Name = "listViewCharts";
            this.listViewCharts.Size = new System.Drawing.Size(276, 194);
            this.listViewCharts.TabIndex = 0;
            this.listViewCharts.UseCompatibleStateImageBehavior = false;
            this.listViewCharts.SelectedIndexChanged += new System.EventHandler(this.listViewCharts_SelectedIndexChanged);
            // 
            // pictureBoxChart
            // 
            this.pictureBoxChart.Location = new System.Drawing.Point(353, 81);
            this.pictureBoxChart.Name = "pictureBoxChart";
            this.pictureBoxChart.Size = new System.Drawing.Size(551, 412);
            this.pictureBoxChart.TabIndex = 1;
            this.pictureBoxChart.TabStop = false;
            // 
            // btnLoadCharts
            // 
            this.btnLoadCharts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnLoadCharts.Location = new System.Drawing.Point(32, 312);
            this.btnLoadCharts.Name = "btnLoadCharts";
            this.btnLoadCharts.Size = new System.Drawing.Size(276, 44);
            this.btnLoadCharts.TabIndex = 2;
            this.btnLoadCharts.Text = "Load Chart";
            this.btnLoadCharts.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cancelButton.Location = new System.Drawing.Point(13, 544);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(136, 37);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Go Back";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // savedChartsLabel
            // 
            this.savedChartsLabel.AutoSize = true;
            this.savedChartsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savedChartsLabel.Location = new System.Drawing.Point(316, 24);
            this.savedChartsLabel.Name = "savedChartsLabel";
            this.savedChartsLabel.Size = new System.Drawing.Size(305, 37);
            this.savedChartsLabel.TabIndex = 4;
            this.savedChartsLabel.Text = "Your Saved Charts";
            // 
            // SavedCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(951, 593);
            this.Controls.Add(this.savedChartsLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.btnLoadCharts);
            this.Controls.Add(this.pictureBoxChart);
            this.Controls.Add(this.listViewCharts);
            this.Name = "SavedCharts";
            this.Text = "SavedCharts";
            this.Load += new System.EventHandler(this.SavedCharts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewCharts;
        private System.Windows.Forms.PictureBox pictureBoxChart;
        private System.Windows.Forms.Button btnLoadCharts;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label savedChartsLabel;
    }
}