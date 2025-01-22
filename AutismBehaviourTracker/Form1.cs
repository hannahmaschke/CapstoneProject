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
            journalEntry journalEntry = new journalEntry();
            this.Hide();
            journalEntry.ShowDialog();
            this.Show();
        }

        private void aboutAutism_Click(object sender, EventArgs e)
        {
            aboutAutismForm aboutAutism = new aboutAutismForm();
            this.Hide();
            aboutAutism.ShowDialog();
            this.Show();
        }
    }
}
