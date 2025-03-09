namespace AutismBehaviourTracker
{
    partial class journalEntry
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
            this.journalEntryLabel = new System.Windows.Forms.Label();
            this.enterEntryLabel = new System.Windows.Forms.Label();
            this.newEntryTextBox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.previousEntryLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // journalEntryLabel
            // 
            this.journalEntryLabel.AutoSize = true;
            this.journalEntryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.journalEntryLabel.Font = new System.Drawing.Font("Tw Cen MT", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.journalEntryLabel.Location = new System.Drawing.Point(273, 38);
            this.journalEntryLabel.Name = "journalEntryLabel";
            this.journalEntryLabel.Size = new System.Drawing.Size(200, 37);
            this.journalEntryLabel.TabIndex = 1;
            this.journalEntryLabel.Text = "Journal Entries";
            // 
            // enterEntryLabel
            // 
            this.enterEntryLabel.AutoSize = true;
            this.enterEntryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.enterEntryLabel.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterEntryLabel.Location = new System.Drawing.Point(31, 145);
            this.enterEntryLabel.Name = "enterEntryLabel";
            this.enterEntryLabel.Size = new System.Drawing.Size(301, 28);
            this.enterEntryLabel.TabIndex = 2;
            this.enterEntryLabel.Text = "Type your journal entry here: ";
            // 
            // newEntryTextBox
            // 
            this.newEntryTextBox.Location = new System.Drawing.Point(36, 194);
            this.newEntryTextBox.Name = "newEntryTextBox";
            this.newEntryTextBox.Size = new System.Drawing.Size(655, 336);
            this.newEntryTextBox.TabIndex = 3;
            this.newEntryTextBox.Text = "";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.submitButton.Location = new System.Drawing.Point(1087, 648);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(141, 36);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit Entry";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.cancelButton.Location = new System.Drawing.Point(12, 648);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(135, 38);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Back to Home";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox);
            this.panel1.Location = new System.Drawing.Point(744, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 336);
            this.panel1.TabIndex = 6;
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(3, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(443, 330);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // previousEntryLabel
            // 
            this.previousEntryLabel.AutoSize = true;
            this.previousEntryLabel.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousEntryLabel.Location = new System.Drawing.Point(833, 145);
            this.previousEntryLabel.Name = "previousEntryLabel";
            this.previousEntryLabel.Size = new System.Drawing.Size(224, 28);
            this.previousEntryLabel.TabIndex = 7;
            this.previousEntryLabel.Text = "Read previous entries:";
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.deleteButton.Location = new System.Drawing.Point(1074, 536);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(116, 29);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete entry";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(744, 536);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(324, 28);
            this.comboBox.TabIndex = 9;
            // 
            // journalEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1240, 696);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.previousEntryLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newEntryTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.enterEntryLabel);
            this.Controls.Add(this.journalEntryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "journalEntry";
            this.Text = "journalEntry";
            this.Load += new System.EventHandler(this.journalEntry_Load_1);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label journalEntryLabel;
        private System.Windows.Forms.Label enterEntryLabel;
        private System.Windows.Forms.RichTextBox newEntryTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label previousEntryLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ComboBox comboBox;
    }
}