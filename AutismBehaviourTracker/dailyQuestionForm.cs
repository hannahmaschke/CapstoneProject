using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
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
        // parallel array for sublabels- this is to change the subLabel for question1
        private string[] questionSublabels = new string[dailyQuestionsClass.questions.Length];

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

            // initialize sublabels- set values for each question
            InitializeQuestionSublabels();

            // initialize ComboBox for sleep hours
            InitializeSleepHoursComboBox();

            // display the first question when the form is loaded
            DisplayNextQuestion();
        }

        // variables
        // keep track of the current question index
        private int currentQuestionIndex = 0;

        // function to change the subLabel depending on the question asked
        // this is to change the subLabel for questions that need a specific input and also to add the question the user is currently on
        private void InitializeQuestionSublabels()
        {
            // initialize sublabels - set the sublabel for question 1
            questionSublabels[0] = "Question 1 of 29:\n Select the number of hours your child slept last night.";

            questionSublabels[1] = "Question 2 of 29:\n 1 meaning no awakenings during the night, 2 meaning woke up once and fell back asleep quickly, 3 meaning woke up once and took awhile to fall back asleep, 4 meaning woke up at least twice, 5 meaning several awakenings";

            questionSublabels[2] = "Question 3 of 29: \n 1 meaning no problems, 5 meaning great difficulty falling asleep";

            questionSublabels[3] = "Question 4 of 29: \n 1 meaning no problems, 5 meaning great difficulty staying asleep";

            questionSublabels[4] = "Question 5 of 29: \n 1 meaning yes they were given meds to help fall asleep, 5 meaning they were not given meds";

            questionSublabels[5] = "Question 6 of 29: \n 1 meaning no problems, 5 meaning great difficulty interacting with others";

            questionSublabels[6] = "Question 7 of 29: \n 1 meaning no problems, 5 meaning great difficulty making eye contact";

            questionSublabels[7] = "Question 8 of 29: \n 1 meaning no violence whatsoever, 5 meaning your child was very violent today";

            questionSublabels[8] = "Question 9 of 29: \n 1 meaning no meltdowns, 5 meaning your child had a meltdown";

            questionSublabels[9] = "Question 10 of 29: \n 1 meaning no problems, 5 meaning great difficulty transitioning between activities";

            questionSublabels[10] = "Question 11 of 29: \n 1 meaning socialized more than usual, 3 meaning socialized an average amount, 5 meaning socialized less than usual";

            questionSublabels[11] = "Question 12 of 29: \n 1 meaning refused no meals, 5 meaning refused all meals";

            questionSublabels[12] = "Question 13 of 29: \n 1 meaning ate more than usual, 3 meaning ate an average amount, 5 meaning ate less than usual";

            questionSublabels[13] = "Question 14 of 29: \n 1 meaning they did NOT avoid loud noise, 5 meaning that they often avoided loud stimuli";

            questionSublabels[14] = "Question 15 of 29: \n 1 meaning they did not avoid bright lights, 5 meaning they often avoided bright lights";

            questionSublabels[15] = "Question 16 of 29: \n 1 meaning they did not avoid touching certain textures, 5 meaning they often avoided touching certain textures";

            questionSublabels[16] = "Question 17 of 29: \n 1 meaning they did not stim more than usual, 5 meaning they stimmed more than usual";

            questionSublabels[17] = "Question 18 of 29: \n 1 meaning they did not exhibit sensory overload symptoms, 5 meaning they did exhibit sensory overload symptoms";

            questionSublabels[18] = "Question 19 of 29: \n 1 meaning they did not climb furniture, 5 meaning they climbed furniture frequently";

            questionSublabels[19] = "Question 20 of 29: \n 1 meaning they did not spin in circles, 5 meaning they spun in circles frequently";

            questionSublabels[20] = "Question 21 of 29: \n 1 meaning they did not jump up and down, 5 meaning they jumped up and down frequently";

            questionSublabels[21] = "Question 22 of 29: \n 1 meaning they did not seek tactile stimulation, 5 meaning they sought tactile stimulation frequently";

            questionSublabels[22] = "Question 23 of 29: \n 1 meaning they did not seek vestibular stimulation, 5 meaning they sought vestibular stimulation frequently";

            questionSublabels[23] = "Question 24 of 29: \n 1 meaning they did not seek proprioceptive stimulation, 5 meaning they sought proprioceptive stimulation frequently";

            questionSublabels[24] = "Question 25 of 29: \n 1 meaning they did not seek oral stimulation, 5 meaning they sought oral stimulation frequently";

            questionSublabels[25] = "Question 26 of 29: \n 1 meaning they did not seek auditory stimulation, 5 meaning they sought auditory stimulation frequently";

            questionSublabels[26] = "Question 27 of 29: \n 1 meaning they did not seek visual stimulation, 5 meaning they sought visual stimulation frequently";

            questionSublabels[27] = "Question 28 of 29: \n 1 meaning they did not seek olfactory stimulation, 5 meaning they sought olfactory stimulation frequently";

            questionSublabels[28] = "Question 29 of 29: \n 1 meaning they did not stomp and crash into things, 5 meaning they stomped and crashed into things frequently";
        }

        // function to initialize the ComboBox for sleep hours
        private void InitializeSleepHoursComboBox()
        {
            ComboBox sleepHoursComboBox = new ComboBox();
            sleepHoursComboBox.Name = "sleepHoursComboBox";
            sleepHoursComboBox.Location = new Point(150, 150); 
            sleepHoursComboBox.Size = new Size(100, 20); 

            // add items to the ComboBox
            for (int i = 1; i <= 12; i++)
            {
                sleepHoursComboBox.Items.Add(i.ToString() + " hours");
            }

            sleepHoursComboBox.SelectedIndexChanged += new EventHandler(sleepHoursComboBox_SelectedIndexChanged);
            this.Controls.Add(sleepHoursComboBox);
        }

        // function to display the current question
        private void DisplayNextQuestion()
        {
            if (currentQuestionIndex < dailyQuestionsClass.questions.Length)
            {
                // display the current question
                questionLabel.Text = dailyQuestionsClass.questions[currentQuestionIndex];

                // update the sublabel
                subLabel.Text = questionSublabels[currentQuestionIndex];

                if (currentQuestionIndex == 0) // check if it's the sleep hours question
                {
                    // hide radio buttons if on the first question
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;
                    radioButton5.Visible = false;

                    // show the ComboBox for sleep hours
                    if (this.Controls.Find("sleepHoursComboBox", true).FirstOrDefault() is ComboBox sleepHoursComboBox)
                    {
                        sleepHoursComboBox.Visible = true;
                    }
                }
                else
                {
                    // show radio buttons for other questions
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                    radioButton4.Visible = true;
                    radioButton5.Visible = true;

                    // hide ComboBox for sleep hours
                    if (this.Controls.Find("sleepHoursComboBox", true).FirstOrDefault() is ComboBox sleepHoursComboBox)
                    {
                        sleepHoursComboBox.Visible = false;
                    }
                }
            }
            else
            {
                // display a popup when all questions are answered
                MessageBox.Show("Questions Submitted!");

                // get the date
                string currentDate = DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss");

                // close the form after submission
                this.Close();
            }
        }

        //public void SaveResponse()
        //{
        //    // array to hold the selected answers for each question
        //    int[] responses = new int[dailyQuestionsClass.questions.Length];

        //    // collect the selected answer for the current question 
        //    if (currentQuestionIndex == 0)
        //    {
        //        // Directly access the ComboBox from the designer
        //        if (Controls.Find("sleepHoursComboBox", true)[0] is ComboBox sleepHoursComboBoxControl)
        //        {

        //            // Extract the number of hours from the selected string (e.g., "1 hour", "2 hours")
        //            int hoursSlept = sleepHoursComboBoxControl.SelectedIndex + 1;
        //            Debug.WriteLine($"Hours Slept: {hoursSlept}");
        //            // Set the response based on the selected number of hours
        //            responses[currentQuestionIndex] = hoursSlept; // Map directly to the response as hours slept
        //        }
        //    }
        //    else
        //    {
        //        // handle radio button selection for other questions
        //        responses[currentQuestionIndex] = GetSelectedAnswer();
        //    }


        //    // save the responses array to the database
        //    DatabaseSetup.SaveResponse(responses);

        //    // move to the next question
        //    currentQuestionIndex++;

        //    // check if all questions have been answered otherwise continue showing the next question
        //    if (currentQuestionIndex < dailyQuestionsClass.questions.Length)
        //    {
        //        DisplayNextQuestion();
        //    }
        //    else
        //    {
        //        // show msg when all questions are submitted
        //        MessageBox.Show("Questions Submitted!");
        //        this.Close();
        //    }

        //    // clear the radio buttons and ComboBox for the next question
        //    radioButton1.Checked = false;
        //    radioButton2.Checked = false;
        //    radioButton3.Checked = false;
        //    radioButton4.Checked = false;
        //    radioButton5.Checked = false;

        //    // Reset the ComboBox selection for the next question
        //    ComboBox sleepHoursComboBox = this.Controls.Find("sleepHoursComboBox", true).FirstOrDefault() as ComboBox;
        //    if (sleepHoursComboBox != null)
        //    {
        //        sleepHoursComboBox.SelectedIndex = -1;  // reset the selection
        //    }

        //    // disable the submit button until the next answer is selected
        //    submitButton.Enabled = false;
        //}

        private void submitButton_Click(object sender, EventArgs e)
        {
            // check if there is already a submission for today's date
            CheckForExistingSubmission();

            // get the selected answer from the radio buttons
            int selectedAnswer = GetSelectedAnswer();

            // store the selected answer in the responses array
            if (currentQuestionIndex == 0)
            {
                // Directly access the ComboBox from the designer
                if (Controls.Find("sleepHoursComboBox", true)[0] is ComboBox sleepHoursComboBoxControl)
                {

                    // Extract the number of hours from the selected string 
                    int hoursSlept = sleepHoursComboBoxControl.SelectedIndex + 1;
                    Debug.WriteLine($"Hours Slept: {hoursSlept}");
                    // Set the response based on the selected number of hours
                    responses[currentQuestionIndex] = hoursSlept; 
                }
            }
            else
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
                //MessageBox.Show("Selected Answer: 1");
                return 1;
            }
            if (radioButton2.Checked)
            {
                //MessageBox.Show("Selected Answer: 2");
                return 2;
            }
            if (radioButton3.Checked)
            {
                //MessageBox.Show("Selected Answer: 3");
                return 3;
            }
            if (radioButton4.Checked)
            {
                //MessageBox.Show("Selected Answer: 4");
                return 4;
            }
            if (radioButton5.Checked)
            {
                //MessageBox.Show("Selected Answer: 5");
                return 5;
            }

            return 0;
        }

        // function that checks if there is already a submission for today's date
        public void CheckForExistingSubmission()
        {
            // get the current date
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            // check if there is already a submission for today's date
            using (SQLiteConnection conn = new SQLiteConnection(DatabaseSetup.connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM questionResponses WHERE date = @date";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", currentDate);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // show a popup asking the user if they want to overwrite the submission
                            DialogResult result = MessageBox.Show("There is already a submission for today's date. Do you want to overwrite it?", "Overwrite Submission", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                // delete the existing submission
                                string deleteQuery = "DELETE FROM questionResponses WHERE date = @date";
                                using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, conn))
                                {
                                    deleteCmd.Parameters.AddWithValue("@date", currentDate);
                                    deleteCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // close the form if the user chooses not to overwrite the submission
                                this.Close();
                            }
                        }
                    }
                }
            }
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

        private void sleepHoursComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = true;
        }
    }
}
