namespace AutismBehaviourTracker
{
    partial class mainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainMenu));
            this.mainMenuLabel = new System.Windows.Forms.Label();
            this.subHeading = new System.Windows.Forms.Label();
            this.dailyQuestions = new System.Windows.Forms.Label();
            this.journalEntries = new System.Windows.Forms.Label();
            this.previousGraphs = new System.Windows.Forms.Label();
            this.aboutAutism = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenuLabel
            // 
            this.mainMenuLabel.AutoSize = true;
            this.mainMenuLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainMenuLabel.Font = new System.Drawing.Font("Tw Cen MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuLabel.Location = new System.Drawing.Point(296, 55);
            this.mainMenuLabel.Name = "mainMenuLabel";
            this.mainMenuLabel.Size = new System.Drawing.Size(188, 42);
            this.mainMenuLabel.TabIndex = 0;
            this.mainMenuLabel.Text = "Main Menu";
            // 
            // subHeading
            // 
            this.subHeading.AutoSize = true;
            this.subHeading.BackColor = System.Drawing.Color.Transparent;
            this.subHeading.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subHeading.Location = new System.Drawing.Point(259, 97);
            this.subHeading.Name = "subHeading";
            this.subHeading.Size = new System.Drawing.Size(244, 28);
            this.subHeading.TabIndex = 1;
            this.subHeading.Text = "Autism Behaviour Tracking";
            // 
            // dailyQuestions
            // 
            this.dailyQuestions.AutoSize = true;
            this.dailyQuestions.BackColor = System.Drawing.Color.Transparent;
            this.dailyQuestions.Font = new System.Drawing.Font("Tw Cen MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyQuestions.Location = new System.Drawing.Point(287, 185);
            this.dailyQuestions.Name = "dailyQuestions";
            this.dailyQuestions.Size = new System.Drawing.Size(197, 23);
            this.dailyQuestions.TabIndex = 2;
            this.dailyQuestions.Text = "Answer Daily Questions";
            // 
            // journalEntries
            // 
            this.journalEntries.AutoSize = true;
            this.journalEntries.BackColor = System.Drawing.Color.Transparent;
            this.journalEntries.Font = new System.Drawing.Font("Tw Cen MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.journalEntries.Location = new System.Drawing.Point(287, 226);
            this.journalEntries.Name = "journalEntries";
            this.journalEntries.Size = new System.Drawing.Size(182, 23);
            this.journalEntries.TabIndex = 3;
            this.journalEntries.Text = "Make a Journal Entry";
            this.journalEntries.Click += new System.EventHandler(this.journalEntries_Click);
            // 
            // previousGraphs
            // 
            this.previousGraphs.AutoSize = true;
            this.previousGraphs.BackColor = System.Drawing.Color.Transparent;
            this.previousGraphs.Font = new System.Drawing.Font("Tw Cen MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousGraphs.Location = new System.Drawing.Point(287, 271);
            this.previousGraphs.Name = "previousGraphs";
            this.previousGraphs.Size = new System.Drawing.Size(187, 23);
            this.previousGraphs.TabIndex = 4;
            this.previousGraphs.Text = "View Previous Graphs";
            // 
            // aboutAutism
            // 
            this.aboutAutism.AutoSize = true;
            this.aboutAutism.BackColor = System.Drawing.Color.Transparent;
            this.aboutAutism.Font = new System.Drawing.Font("Tw Cen MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutAutism.Location = new System.Drawing.Point(317, 313);
            this.aboutAutism.Name = "aboutAutism";
            this.aboutAutism.Size = new System.Drawing.Size(113, 23);
            this.aboutAutism.TabIndex = 5;
            this.aboutAutism.Text = "About Autism";
            this.aboutAutism.Click += new System.EventHandler(this.aboutAutism_Click);
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutAutism);
            this.Controls.Add(this.previousGraphs);
            this.Controls.Add(this.journalEntries);
            this.Controls.Add(this.dailyQuestions);
            this.Controls.Add(this.subHeading);
            this.Controls.Add(this.mainMenuLabel);
            this.Name = "mainMenu";
            this.Text = "Autism Behaviour Tracking";
            this.Load += new System.EventHandler(this.mainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainMenuLabel;
        private System.Windows.Forms.Label subHeading;
        private System.Windows.Forms.Label dailyQuestions;
        private System.Windows.Forms.Label journalEntries;
        private System.Windows.Forms.Label previousGraphs;
        private System.Windows.Forms.Label aboutAutism;
    }
}

