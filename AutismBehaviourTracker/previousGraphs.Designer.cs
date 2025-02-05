namespace AutismBehaviourTracker
{
    partial class previousGraphs
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxResponses = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(78, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // listBoxResponses
            // 
            this.listBoxResponses.FormattingEnabled = true;
            this.listBoxResponses.ItemHeight = 20;
            this.listBoxResponses.Location = new System.Drawing.Point(3, 19);
            this.listBoxResponses.Name = "listBoxResponses";
            this.listBoxResponses.Size = new System.Drawing.Size(785, 424);
            this.listBoxResponses.TabIndex = 1;
            // 
            // previousGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxResponses);
            this.Controls.Add(this.label1);
            this.Name = "previousGraphs";
            this.Text = "previousGraphs";
            this.Load += new System.EventHandler(this.previousGraphs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxResponses;
    }
}