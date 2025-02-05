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


        // load all journal entries from the database
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
                        List<string> answers = new List<string>();

                        // start from index 2 because the first two fields in db are date and id
                        for (int i = 2; i <= 27; i++)  
                        {
                            answers.Add($"Question {i - 1}: {reader.GetInt32(i)} \n");  // format is Question X: Answer
                        }

                        entries.Add($"Date: {date}\n{string.Join("\n", answers)}\n\n---------------------------------------------------------------------------------------");
                    }
                }
            }

            return entries;
        }

        private void previousGraphs_Load(object sender, EventArgs e)
        {
            // load the question responses
            List<string> responses = LoadQuestionResponses();

          // display the previous responses in listbox
            foreach (string response in responses)
            {
                listBoxResponses.Items.Add(response);
            }
        }
    }
    }

