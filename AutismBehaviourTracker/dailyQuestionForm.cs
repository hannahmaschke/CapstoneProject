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
        private int[] responses = new int[dailyQuestionsClass.questions.Length];

        //  note to self: add function to check if there is already
        // a response for the current date and if so ask the user if they 
        // want to overwrite the response or not
        public dailyQuestionForm()
        {
            InitializeComponent();
            DatabaseSetup.InitializeDatabase();

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


        public void SaveResponse()
        {
            // array to hold the selected answers for each question
            int[] responses = new int[dailyQuestionsClass.questions.Length];

            // collect the selected answer for the current question 
            responses[currentQuestionIndex] = GetSelectedAnswer();

            // save the responses array to the database
            DatabaseSetup.SaveResponse(responses);  

            // move to the next question
            currentQuestionIndex++;

            // check if all questions have been answered otherwise continue showing the next question
            if (currentQuestionIndex < dailyQuestionsClass.questions.Length)
            {
                DisplayNextQuestion();
            }
            else
            {
                // show msg when all questions are submitted
                MessageBox.Show("Questions Submitted!");
                this.Close();
            }

            // clear the radio buttons for the next question
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;

            // disable the submit button until the next answer is selected
            submitButton.Enabled = false;
        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            // get the selected answer from the radio buttons
            int selectedAnswer = GetSelectedAnswer();

            // store the selected answer in the responses array
            responses[currentQuestionIndex] = selectedAnswer;

            // if it's the last question, save the responses to the database
            if (currentQuestionIndex == dailyQuestionsClass.questions.Length - 1)
            {
                // save all the responses to the database when the last question is reached
                DatabaseSetup.SaveResponse(responses);
            }

            // move to the next question
            currentQuestionIndex++;

            // display the next question
            DisplayNextQuestion();

            // clear the radio buttons for the next question
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;

            submitButton.Enabled = false;
        }

        // get the selected answer based on the radio buttons
        private int GetSelectedAnswer()
        {
            if (radioButton1.Checked)
            {
                MessageBox.Show("Selected Answer: 1");
                return 1;
            }
            if (radioButton2.Checked)
            {
                MessageBox.Show("Selected Answer: 2");
                return 2;
            }
            if (radioButton3.Checked)
            {
                MessageBox.Show("Selected Answer: 3");
                return 3;
            }
            if (radioButton4.Checked)
            {
                MessageBox.Show("Selected Answer: 4");
                return 4;
            }
            if (radioButton5.Checked)
            {
                MessageBox.Show("Selected Answer: 5");
                return 5;
            }

            return 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           submitButton.Enabled = true; 
        }

        private void dailyQuestionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
