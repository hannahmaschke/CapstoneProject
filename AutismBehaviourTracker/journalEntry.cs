using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AutismBehaviourTracker
{
    public partial class journalEntry : Form
    {
        public journalEntry()
        {
            InitializeComponent();
        }

        // lists to hold entries and dates
        private List<string> journalEntries = new List<string>();
        private List<string> journalEntryDates = new List<string>();

        private void LoadPreviousEntries()
        {
            // retrieve the journal entries from the database
            List<string> entries = DatabaseSetup.LoadJournalEntries();

            // clear previous items in the comboBox and richTextBox
            comboBox.Items.Clear();
            richTextBox.Clear();

            // loop through each entry and add it to the comboBox and richTextBox
            foreach (string entry in entries)
            {
                // extract dates from the entries (the first line contains the date)
                string date = entry.Split('\n')[0].Replace("Date: ", "").Trim();

                // add the date to ComboBox
                journalEntryDates.Add(date);
                comboBox.Items.Add(date);

                // add the entry to the journalEntries list
                journalEntries.Add(entry);
            }

            // loop through each entry and add it to the textbox
            foreach (string entry in entries)
            {
                richTextBox.AppendText(entry + "\n------------------------------\n");
            }
        }

        private void journalEntry_Load(object sender, EventArgs e)
        {
            // load the journal entries from the database when the form loads
            LoadPreviousEntries();
            DatabaseSetup.InitializeDatabase();

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // get the current date and time
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy HH:mm");

            // get the journal entry text
            string entryText = newEntryTextBox.Text;

            if (!string.IsNullOrEmpty(entryText))
            {
                // save the journal entry to the database
                DatabaseSetup.SaveJournalEntry(entryText, currentDate);

                // format the entry with date and entry text
                string entryWithDate = $"Date: {currentDate}\n{entryText}\n";

                // add the new entry to the journalEntries list and comboBox
                journalEntries.Add(entryWithDate);
                journalEntryDates.Add(currentDate);
                comboBox.Items.Add(currentDate);

                // reload the RichTextBox with the updated list of entries
                ReloadRichTextBox();

                // clear the new entry text box
                newEntryTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a journal entry.");
            }
        }

        private void ReloadRichTextBox()
        {
            // clear the textbox
            richTextBox.Clear();

            // add the full entries to the textbox and format them
            for (int i = journalEntries.Count - 1; i >= 0; i--)  // iterate backwards to show the newest entries first
            {
                richTextBox.AppendText(journalEntries[i] + "\n\n-----------------------------------------------------------------------------\n\n");
            }
        }


        private string GetEntryDate(string entry)
        {
            // find the newline, \n is what separates date and entry text
            int dateEndIndex = entry.IndexOf('\n');
            // return the date part only- this is what the user will see in the combobox
            return entry.Substring(0, dateEndIndex); 
        }

        private void ReloadComboBox()
        {
            // clear the comboBox items
            comboBox.Items.Clear();

            // retrieve the updated list of entries 
            List<string> updatedEntries = DatabaseSetup.LoadJournalEntries();

            // loop through each updated entry and add it to the comboBox
            foreach (string entry in updatedEntries)
            {
                string entryDate = GetEntryDate(entry);
                comboBox.Items.Add(entryDate);
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected date from the ComboBox
            string selectedDate = comboBox.SelectedItem.ToString();

            // find the corresponding entry by matching the date
            foreach (var entry in journalEntries)
            {
                if (entry.Contains(selectedDate))
                {
                    // display the full entry in the RichTextBox
                    richTextBox.Text = entry;
                    return;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void journalEntry_Load_1(object sender, EventArgs e)
        {
            // initialize database and load entries when the form loads
            DatabaseSetup.InitializeDatabase();
            LoadPreviousEntries();

        }



        // delete button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select an entry to delete.");
                    return;
                }

                string selectedDate = comboBox.SelectedItem.ToString();

                // use the selectedDate for database deletion
                DatabaseSetup.DeleteJournalEntry(selectedDate);

                // remove from in-memory lists. this is important for immediate UI update
                // find the entry by its date
                int entryIndex = journalEntryDates.IndexOf(selectedDate); 
                if (entryIndex != -1)
                {
                    journalEntries.RemoveAt(entryIndex);
                    journalEntryDates.RemoveAt(entryIndex);
                    comboBox.Items.RemoveAt(entryIndex);
                }

                // refresh the textBox
                ReloadRichTextBox();

                MessageBox.Show("Entry deleted successfully.");
            }
            // if there is an error the system will tell us why
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
    
