using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutismBehaviourTracker
{
    public partial class journalEntry : Form
    {
        public journalEntry()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // Get the current date and time
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss");

            // Add the date to the top of each journal post
            string entryWithDate = $"Date: {currentDate}\n{newEntryTextBox.Text}\n\n" + "\n\n ---------------------------------------------------------------------------------------";

            // when the user hits submit, the entry is saved to the previous entries page
            previousEntryTextBox.Text += entryWithDate;

            // clear the journal entry text box for the next entry
            newEntryTextBox.Clear();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
