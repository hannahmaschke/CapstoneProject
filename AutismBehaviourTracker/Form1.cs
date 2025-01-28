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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void journalEntries_Click(object sender, EventArgs e)
        {
            // Create an instance of the journalEntry form
            journalEntry journalEntryForm = new journalEntry();

            // Hide the main menu form
            this.Hide();

            // Show the journal entry form as a dialog
            journalEntryForm.ShowDialog();

            // After the journal entry form is closed, show the main menu again
            this.Show();
        }

        private void aboutAutism_Click(object sender, EventArgs e)
        {
            aboutAutismForm aboutAutism = new aboutAutismForm();
            this.Hide();
            aboutAutism.ShowDialog();
            this.Show();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
