using System.Windows.Forms;

namespace AutismBehaviourTracker
{
    partial class previousGraphs
    {
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.textBoxResponses = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(332, 44);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(324, 36);
            this.label.TabIndex = 0;
            this.label.Text = "Previous Responses";
            // 
            // textBoxResponses
            // 
            this.textBoxResponses.Location = new System.Drawing.Point(34, 113);
            this.textBoxResponses.Multiline = true;
            this.textBoxResponses.Name = "textBoxResponses";
            this.textBoxResponses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResponses.Size = new System.Drawing.Size(975, 480);
            this.textBoxResponses.TabIndex = 1;
            this.textBoxResponses.WordWrap = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.NavajoWhite;
            this.cancelButton.Location = new System.Drawing.Point(13, 611);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(199, 32);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Go Back to Main Menu";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // previousGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(1043, 655);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.textBoxResponses);
            this.Controls.Add(this.label);
            this.Name = "previousGraphs";
            this.Text = "previousGraphs";
            this.Load += new System.EventHandler(this.previousGraphs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //#endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBoxResponses;
        private Button cancelButton;
    }
}