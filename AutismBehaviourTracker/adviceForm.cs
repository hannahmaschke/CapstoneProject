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
    public partial class adviceForm : Form
    {
        public adviceForm()
        {
            InitializeComponent();
            generatedAdvice();
        }

        private void generatedAdvice()
        {
            // generate advice based on the averages calculated in DatabaseSetup.cs
            // sleep advice
            // change the description for sleep responses 
            // 1 for 1-3 hours slept, 2 for 4-5 hours slept, 3 for 6-7 hours slept, 4 for 8-9 hours slept, or 5 for 10+ hours slept
            if (DatabaseSetup.AverageSleepLast7Days() < 1.99)
            {
                richTextBox1.Text += "Your child is not getting enough sleep per night. This is a dangerously low amount of sleep.\n" +
                    "Consider giving your child an appropriate dose of melatonin and following a strict bed time and morning routine. Lower liquid intake and screen intake an hour before bed. ";
            }
            else if (DatabaseSetup.AverageSleepLast7Days() < 2.99 && DatabaseSetup.AverageSleepLast7Days() > 2.00)
            {
                richTextBox1.Text += "The amount of sleep your child is getting per night is too low. \n" + "Consider giving your child an appropriate dose of melatonin and following a strict bed time and morning routine. Lower liquid intake and screen intake an hour before bed. "; ;
            }
            else if (DatabaseSetup.AverageSleepLast7Days() < 3.99 && DatabaseSetup.AverageSleepLast7Days() > 3.00)
            {
                richTextBox1.Text += "Your child is getting an average amount of sleep per night. It could be better. ";
            }
            else if (DatabaseSetup.AverageSleepLast7Days() < 4.99 && DatabaseSetup.AverageSleepLast7Days() > 4.00)
            {
                richTextBox1.Text += ". ";
            }
            else
            {
                richTextBox1.Text += "You are getting the right amount of sleep. ";
            };
        }

        private void adviceForm_Load(object sender, EventArgs e)
        {
            // load the advice from the database

        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
