using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutismBehaviourTracker
{
    public partial class dailyQuestionForm : Form
    {
        RadioButton[] radioButtonOptions = new RadioButton[5];

        public dailyQuestionForm()
        {
            InitializeComponent();

            // radiobuttons
            radioButtonOptions[0] = radioButton1;
            radioButtonOptions[1] = radioButton2;
            radioButtonOptions[2] = radioButton3;
            radioButtonOptions[3] = radioButton4;
            radioButtonOptions[4] = radioButton5;

            // display the first question when the form is loaded
            DisplayNextQuestion();
        }

        // variables
        // keep track of the current question index
        private int currentQuestionIndex = 0;


        // function to display the current question
        private void DisplayNextQuestion()
        {

            if (currentQuestionIndex < dailyQuestionsClass.questions.Length)
            {
                // display the current question
                questionLabel.Text = dailyQuestionsClass.questions[currentQuestionIndex];
            }
            else
            {
                // display a popup when all questions are answered
                MessageBox.Show("Questions Submitted!");

                // Get the date
                // get the current date and time
                string currentDate = DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss");

                // close the form after submission
                this.Close();
            }

        }


        public void SaveResponse(string question, string answer)
        {
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss");

            using (System.Data.SQLite.SQLiteConnection conn = new SQLiteConnection(DatabaseSetup.connectionString))
            {
                conn.Open();

                string query = "INSERT INTO questionsResponses (question, answer, responseDate) VALUES (@question, @answer, @responseDate)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@question", question);
                    cmd.Parameters.AddWithValue("@answer", answer);
                    cmd.Parameters.AddWithValue("@responseDate", currentDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
           
            // get the selected answer from the radio buttons
            string selectedAnswer = GetSelectedAnswer();

            // save the response to the database
            SaveResponse(dailyQuestionsClass.questions[currentQuestionIndex], selectedAnswer);

            // move to the next question
            currentQuestionIndex++;

            // display the next question
            DisplayNextQuestion();

            // clear the radio buttons
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;

            submitButton.Enabled = false;
        }

        // get the selected answer based on the radio buttons
        private string GetSelectedAnswer()
        {
            if (radioButton1.Checked) return radioButton1.Text;
            if (radioButton2.Checked) return radioButton2.Text;
            if (radioButton3.Checked) return radioButton3.Text;
            if (radioButton4.Checked) return radioButton4.Text;
            if (radioButton5.Checked) return radioButton5.Text;
            return string.Empty; 
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           submitButton.Enabled = true; 
        }
    }
}
