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
    public partial class previousGraphs : Form
    {

        public previousGraphs()
        {
            InitializeComponent();
        }

        public static List<string> LoadQuestionResponses()
        {
            List<string> entries = new List<string>();

            using (SQLiteConnection conn = new SQLiteConnection(DatabaseSetup.connectionString))
            {
                conn.Open();

                string query = "SELECT date, Id, question1, question2, question3, question4, question5, question6, question7, question8, question9, question10, question11, question12, question13, question14, question15, question16, question17, question18, question19, question20, question21, question22, question23, question24, question25, question26 FROM questionResponses ORDER BY Id ASC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string date = reader.GetString(0);
                        int id = reader.GetInt32(1);
                        StringBuilder entry = new StringBuilder();

                        entry.AppendLine(date);
                        entry.AppendLine($"ID: {id}");

                        for (int i = 2; i <= 27; i++)
                        {
                            string question = dailyQuestionsClass.questions[i - 2];
                            int answer = reader.GetInt32(i);
                            entry.AppendLine($"Question {i - 1}: {question} Response: {answer}");
                        }

                        entries.Add(entry.ToString() + "\n---------------------------------------------------------------------------------------");
                    }
                }
            }

            return entries;
        }

        public void previousGraphs_Load(object sender, EventArgs e)
        {
            // debug: show the average amount of sleep over the past 7 entries
            DatabaseSetup.AverageSleepLast7Days();
            List<string> responses = LoadQuestionResponses();
            textBoxResponses.Clear(); 
            textBoxResponses.Text = string.Join(Environment.NewLine, responses); 
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
   

