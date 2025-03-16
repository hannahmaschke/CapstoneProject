namespace AutismBehaviourTracker
{
    partial class NameChartForm
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
            this.txtChartName = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter a name for your chart:";
            // 
            // txtChartName
            // 
            this.txtChartName.Location = new System.Drawing.Point(122, 94);
            this.txtChartName.Name = "txtChartName";
            this.txtChartName.Size = new System.Drawing.Size(351, 26);
            this.txtChartName.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.SandyBrown;
            this.cancelButton.Location = new System.Drawing.Point(12, 184);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(113, 37);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.SandyBrown;
            this.btnOK.Location = new System.Drawing.Point(457, 184);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 37);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Submit";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // NameChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(582, 233);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.txtChartName);
            this.Controls.Add(this.label1);
            this.Name = "NameChartForm";
            this.Text = "Name Chart";
            this.Load += new System.EventHandler(this.NameChartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChartName;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button btnOK;
    }
}