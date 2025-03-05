using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace AutismBehaviourTracker
{
    public static class DatabaseSetup
    {

        public static string connectionString = "Data Source=library.db;Version=3;";

        // save journal entry to the database
        public static void SaveJournalEntry(string entryText, string date)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO journalEntries (date, entryText) VALUES (@date, @entryText)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@entryText", entryText);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // load all journal entries from the database
        public static List<string> LoadJournalEntries()
        {
            List<string> entries = new List<string>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT date, entryText FROM journalEntries ORDER BY date DESC"; // order by date descending so that the newest entries are shown first
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string date = reader.GetString(0);
                        string entryText = reader.GetString(1);

                        // combine the date and entryText to be displayed in the textbx
                        string formattedEntry = $"Date: {date} \n\r {entryText}";  
                        entries.Add(formattedEntry);
                    }
                }
            }

            return entries;
        }


        public static void InitializeDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // check if the table exists and create it 
                string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='questionResponses';";
                using (SQLiteCommand cmd = new SQLiteCommand(checkTableQuery, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        // if the table doesn't exist create it
                        string createQuestionsTableQuery = @"
                CREATE TABLE IF NOT EXISTS questionResponses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    date TEXT NOT NULL,
                    question1 INTEGER,
                    question2 INTEGER,
                    question3 INTEGER,
                    question4 INTEGER,
                    question5 INTEGER,
                    question6 INTEGER,
                    question7 INTEGER,
                    question8 INTEGER,
                    question9 INTEGER,
                    question10 INTEGER,
                    question11 INTEGER,
                    question12 INTEGER,
                    question13 INTEGER,
                    question14 INTEGER,
                    question15 INTEGER,
                    question16 INTEGER,
                    question17 INTEGER,
                    question18 INTEGER,
                    question19 INTEGER,
                    question20 INTEGER,
                    question21 INTEGER,
                    question22 INTEGER,
                    question23 INTEGER,
                    question24 INTEGER,
                    question25 INTEGER,
                    question26 INTEGER
                );";

                        using (SQLiteCommand createCmd = new SQLiteCommand(createQuestionsTableQuery, conn))
                        {
                            createCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        // Delete a journal entry from the database by date
        public static void DeleteJournalEntry(string date)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM journalEntries WHERE date = @date";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void SaveResponse(int[] responses)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            using (SQLiteConnection conn = new SQLiteConnection(DatabaseSetup.connectionString))
            {
                conn.Open();

                string query = @"
        INSERT INTO questionResponses (date, question1, question2, question3, question4, question5, 
                                        question6, question7, question8, question9, question10, question11, 
                                        question12, question13, question14, question15, question16, question17, 
                                        question18, question19, question20, question21, question22, question23, 
                                        question24, question25, question26)
        VALUES (@date, @question1, @question2, @question3, @question4, @question5, 
                @question6, @question7, @question8, @question9, @question10, @question11, 
                @question12, @question13, @question14, @question15, @question16, @question17, 
                @question18, @question19, @question20, @question21, @question22, @question23, 
                @question24, @question25, @question26)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    // add the date
                    cmd.Parameters.AddWithValue("@date", currentDate);

                    // add responses for each question 
                    for (int i = 0; i < responses.Length; i++)
                    {
                        cmd.Parameters.AddWithValue($"@question{i + 1}", responses[i]);
                    }

                    // execute the query to insert the row into the table
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static double AverageSleepLast7Days()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSleep = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question1 FROM questionResponses WHERE date = @date"; // select question1- asks about sleep hours
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int sleepHours)) 
                            {
                                totalSleep += sleepHours;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question1 is not a valid integer for this date
                                Console.WriteLine($"Invalid sleep hours value for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSleep = totalSleep / validEntryCount;

                if (validEntryCount > 0)
                {
                    //return totalSleep / validEntryCount;
                    MessageBox.Show($"Average sleep hours for the past 7 days: {averageSleep}");
                    return averageSleep;
                }
                else
                {
                    return 0; 
                }
            }
        }

        public static double AverageAwakenings()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalAwakenings = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question2 FROM questionResponses WHERE date = @date"; // select question2- asks about times the child woke up
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int sleepAwakenings))
                            {
                                totalAwakenings += sleepAwakenings;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question1 is not a valid integer for this date
                                Console.WriteLine($"Invalid awakening value for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageAwakenings = totalAwakenings / validEntryCount;

                if (validEntryCount > 0)
                {
                    //return totalSleep / validEntryCount;
                    MessageBox.Show($"Average number of times your child has woken up in the night over the past 7 days: {averageAwakenings}");
                    return averageAwakenings;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average sleep quality- questions 3
        public static double AverageDifficultyFallingAsleep()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalFallAsleep = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question3 FROM questionResponses WHERE date = @date"; // select question2- asks about times the child woke up
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int fallAsleep))
                            {
                                totalFallAsleep += fallAsleep;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question3 is not a valid integer for this date
                                Console.WriteLine($"Invalid awakening value for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageFallAsleepQuality = totalFallAsleep / validEntryCount;

                if (validEntryCount > 0)
                {
                    //return totalSleep / validEntryCount;
                    MessageBox.Show($"Average difficulty falling asleep over the past 7 days: {averageFallAsleepQuality}");

                    return averageFallAsleepQuality;
                }
                else
                {
                    return 0;
                }
            }
        }

        // averages for social interactions
        public static double AverageSocialInteractions()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalInteractionCount = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question6 FROM questionResponses WHERE date = @date"; // select question6- asks about the daily social interactions
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalInteractionCount += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question4 is not a valid integer for this date
                                Console.WriteLine($"Invalid value for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSocialInteraction = totalInteractionCount / validEntryCount;

                if (validEntryCount > 0)
                {
                    //return totalSleep / validEntryCount;
                    MessageBox.Show($"Average social interaction score over the past 7 days: {averageSocialInteraction}");

                    return averageSocialInteraction;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average eye contact score
        // averages for social interactions
        public static double AverageEyeContact()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalEyeContactScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question7 FROM questionResponses WHERE date = @date"; // select question7- asks about the daily eye contact
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalEyeContactScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question7 is not a valid integer for this date
                                Console.WriteLine($"Invalid eye contact value for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageEyeContactScore = totalEyeContactScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    //return totalSleep / validEntryCount;
                    MessageBox.Show($"Average eye contact score over the past 7 days: {averageEyeContactScore}");

                    return averageEyeContactScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static bool CheckJournalEntryExists(string date)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM journalEntries WHERE date = @date";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date);
                    long count = (long)cmd.ExecuteScalar();  // use ExecuteScalar to get the count

                    return count > 0; // return true if count > 0 which means thee entry exists
                }
            }
        }
    }
        }
    