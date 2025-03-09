namespace AutismBehaviourTracker
{
    partial class adviceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adviceForm));
            this.mainLabel = new System.Windows.Forms.Label();
            this.sleepLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.socialLabel = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(440, 39);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(298, 37);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Your Child\'s Week";
            // 
            // sleepLabel
            // 
            this.sleepLabel.AutoSize = true;
            this.sleepLabel.BackColor = System.Drawing.Color.Transparent;
            this.sleepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sleepLabel.Location = new System.Drawing.Point(84, 151);
            this.sleepLabel.Name = "sleepLabel";
            this.sleepLabel.Size = new System.Drawing.Size(217, 26);
            this.sleepLabel.TabIndex = 1;
            this.sleepLabel.Text = "Your Child\'s Sleep:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(343, 101);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(759, 133);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // socialLabel
            // 
            this.socialLabel.AutoSize = true;
            this.socialLabel.BackColor = System.Drawing.Color.Transparent;
            this.socialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socialLabel.Location = new System.Drawing.Point(84, 317);
            this.socialLabel.Name = "socialLabel";
            this.socialLabel.Size = new System.Drawing.Size(215, 52);
            this.socialLabel.TabIndex = 3;
            this.socialLabel.Text = "Your Child\'s Social\r\n Interactions:";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(343, 281);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(759, 131);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(65, 485);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 52);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your Child\'s Sensory\r\n            Needs:";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(343, 463);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(759, 131);
            this.richTextBox3.TabIndex = 6;
            this.richTextBox3.Text = "";
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.DarkSalmon;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(13, 613);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(151, 36);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Back to Home";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // adviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.socialLabel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.sleepLabel);
            this.Controls.Add(this.mainLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "adviceForm";
            this.Text = "adviceForm";
            this.Load += new System.EventHandler(this.adviceForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Label sleepLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label socialLabel;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button cancelButton;
    }
}