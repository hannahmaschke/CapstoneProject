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

        private void LoadPreviousEntries()
        {
            // retrieve the journal entries from the database
            List<string> entries = DatabaseSetup.LoadJournalEntries();

            // display the entries in the previous entries text box
            previousEntryTextBox.Clear(); // clear previous entries
            foreach (string entry in entries)
            {
                previousEntryTextBox.Text += entry;
            }
        }

        private void journalEntry_Load(object sender, EventArgs e)
        {
            // load the journal entries from the database when the form loads
            LoadPreviousEntries();

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // get the current date and time
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss");

            // get the journal entry text
            string entryText = newEntryTextBox.Text;

            if (!string.IsNullOrEmpty(entryText))
            {
                // save the journal entry to the database
                DatabaseSetup.SaveJournalEntry(entryText, currentDate);

                // add the date and entry to the previous entries section
                string entryWithDate = $"Date: {currentDate}\n{entryText}\n\n---------------------------------------------------------------------------------------";
                previousEntryTextBox.Text += entryWithDate;

                // clear the journal entry text box for the next entry
                newEntryTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a journal entry.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadPreviousEntries()
        {
            // retrieve the journal entries from the database
            List<string> entries = DatabaseSetup.LoadJournalEntries();

            // display the entries in the previous entries text box
            previousEntryTextBox.Clear(); // clear previous entries
            foreach (string entry in entries)
            {
                previousEntryTextBox.Text += entry;
            }
        }

        private void journalEntry_Load_1(object sender, EventArgs e)
        {
            // initialize database (if the table doesn't exist)
            DatabaseSetup.InitializeDatabase();

            // load previous entries from the database and display them in the TextBox
            LoadPreviousEntries();
        }
    }
}
