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
            // create an instance of the journalEntry form
            journalEntry journalEntryForm = new journalEntry();

            // hide the main menu form
            this.Hide();

            // show the journal entry form as a dialog
            journalEntryForm.ShowDialog();

            // close the journal entry form 
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

        private void dailyQuestions_Click(object sender, EventArgs e)
        {
            dailyQuestionForm dailyQuestionForm = new dailyQuestionForm();
            this.Hide();
            dailyQuestionForm.ShowDialog();
            this.Show();
        }
    }
}
