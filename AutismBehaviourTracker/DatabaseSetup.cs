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
                                                question24, question25, question26, question27, question28, question29)
                VALUES (@date, @question1, @question2, @question3, @question4, @question5, 
                        @question6, @question7, @question8, @question9, @question10, @question11, 
                        @question12, @question13, @question14, @question15, @question16, @question17, 
                        @question18, @question19, @question20, @question21, @question22, @question23, 
                        @question24, @question25, @question26, @question27, @question28, @question29)";

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

        // average aggression score
        public static double AverageViolence()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalViolenceScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question8 FROM questionResponses WHERE date = @date"; // select question8- asks about the daily violence committed
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalViolenceScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question8 is not a valid integer for this date
                                Console.WriteLine($"Invalid violence score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageViolenceScore = totalViolenceScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average violence score over the past 7 days: {averageViolenceScore}");

                    return averageViolenceScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average number of days in which the child had a meltdown
        public static double AverageDaysWithMeltdown()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalDaysWithMeltdowns = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question9 FROM questionResponses WHERE date = @date"; // select question9- asks about the number of days a meltdown was had
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalDaysWithMeltdowns += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question9 is not a valid integer for this date
                                Console.WriteLine($"Invalid meltdown count for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageDaysWithMeltdowns = totalDaysWithMeltdowns / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average violence score over the past 7 days: {averageDaysWithMeltdowns}");

                    return averageDaysWithMeltdowns;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average score for transitioning between activities
        public static double AverageDifficultyTransitioning()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalTransitionScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question10 FROM questionResponses WHERE date = @date"; // select question10- asks about the difficulty transitioning between activities
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalTransitionScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question10 is not a valid integer for this date
                                Console.WriteLine($"Invalid transition score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageTransitionScore = totalTransitionScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average violence score over the past 7 days: {averageTransitionScore}");

                    return averageTransitionScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average socialization level
        public static double AverageSocializationAmount()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSocializationScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question11 FROM questionResponses WHERE date = @date"; // select question11- asks about the level of socialization per day
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSocializationScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question11 is not a valid integer for this date
                                Console.WriteLine($"Invalid socialization count for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSocializationScore = totalSocializationScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average violence score over the past 7 days: {averageSocializationScore}");

                    return averageSocializationScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average number of days in which a meal was refused
        public static double AverageMealRefusedScore()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalRefusalScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question12 FROM questionResponses WHERE date = @date"; // select question12- asks about meals refused
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalRefusalScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question12 is not a valid integer for this date
                                Console.WriteLine($"Invalid meal refusal score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageRefusalScore = totalRefusalScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average meal refusal score over the past 7 days: {averageRefusalScore}");

                    return averageRefusalScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average amount eaten 
        public static double AverageAmountEaten()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalAppetiteScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question13 FROM questionResponses WHERE date = @date"; // select question13- asks about amount eaten
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalAppetiteScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question13 is not a valid integer for this date
                                Console.WriteLine($"Invalid appetite score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageAppetiteScore = totalAppetiteScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average appetite score over the past 7 days: {averageAppetiteScore}");

                    return averageAppetiteScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // Average stimuli functions

        // average loud stimuli avoidance score 
        public static double AverageLoudStimuliAvoided()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalAvoidanceScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question14 FROM questionResponses WHERE date = @date"; // select question14- asks about days that the child avoided loud noise
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalAvoidanceScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question14 is not a valid integer for this date
                                Console.WriteLine($"Invalid avoidance score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageAvoidanceScore = totalAvoidanceScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average loud stimuli avoidance score over the past 7 days: {averageAvoidanceScore}");

                    return averageAvoidanceScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average bright light stimuli avoidance score 
        public static double AverageVisualStimuliAvoided()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalAvoidanceScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question15 FROM questionResponses WHERE date = @date"; // select question15- asks about days that the child avoided bright lights
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalAvoidanceScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question15 is not a valid integer for this date
                                Console.WriteLine($"Invalid avoidance score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageAvoidanceScore = totalAvoidanceScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average visual stimuli avoidance score over the past 7 days: {averageAvoidanceScore}");

                    return averageAvoidanceScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average bright light stimuli avoidance score 
        public static double AverageTactileStimuliAvoided()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalAvoidanceScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question16 FROM questionResponses WHERE date = @date"; // select question16- asks about days that the child avoided certain textures
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalAvoidanceScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question16 is not a valid integer for this date
                                Console.WriteLine($"Invalid avoidance score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageAvoidanceScore = totalAvoidanceScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average tactile stimuli avoidance score over the past 7 days: {averageAvoidanceScore}");

                    return averageAvoidanceScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average stim score 
        public static double AverageStimScore()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalStimScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question17 FROM questionResponses WHERE date = @date"; // select question17- asks about the level of stimming each day
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalStimScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question17 is not a valid integer for this date
                                Console.WriteLine($"Invalid stim score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageStimScore = totalStimScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average stim score over the past 7 days: {averageStimScore}");

                    return averageStimScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average sensory overload score
        public static double AverageSensoryOverload()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalOverloadScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question18 FROM questionResponses WHERE date = @date"; // select question18- asks about the days with sensory overload
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalOverloadScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question18 is not a valid integer for this date
                                Console.WriteLine($"Invalid sensory overload score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageOverloadScore = totalOverloadScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average sensory overload score over the past 7 days: {averageOverloadScore}");

                    return averageOverloadScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average hyperactivity score- combines questions 19, 20,21, 29
        public static double AverageHyperactivity()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalClimbScore = 0;
                double totalSpinScore = 0;
                double totalJumpScore = 0;
                double totalCrashScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries- climb score
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question19 FROM questionResponses WHERE date = @date"; // select question19- asks about the days the child climbed furniture
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalClimbScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question19 is not a valid integer for this date
                                Console.WriteLine($"Invalid climb score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                // loop through the past 7 entries for spin score
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question20 FROM questionResponses WHERE date = @date"; // select question20- asks about the days the child spun in circles
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSpinScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question20 is not a valid integer for this date
                                Console.WriteLine($"Invalid spin score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                // loop through the past 7 entries for jump score
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question21 FROM questionResponses WHERE date = @date"; // select question21- asks about the days the child jumped around
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalJumpScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question21 is not a valid integer for this date
                                Console.WriteLine($"Invalid jump score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                // loop through the past 7 entries for crashing score
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question29 FROM questionResponses WHERE date = @date"; // select question29- asks about the days the child crashed into things
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalCrashScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question29 is not a valid integer for this date
                                Console.WriteLine($"Invalid crash score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageClimbScore = totalClimbScore / validEntryCount;
                double averageSpinScore = totalSpinScore / validEntryCount;
                double averageJumpScore = totalJumpScore / validEntryCount;
                double averageCrashScore = totalCrashScore / validEntryCount;

                double averageHyperactivityScore = (averageClimbScore + averageSpinScore + averageJumpScore + averageCrashScore) / 4;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average hyperactivity score over the past 7 days: {averageHyperactivityScore}");

                    return averageHyperactivityScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // seeking out sensory stimuli functions

        // average tactile stimuli seeked score
        public static double AverageTactileStimulationSeeked()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSeekedScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question22 FROM questionResponses WHERE date = @date"; // select question22- asks about the days the child seeked out tactile stimulation
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSeekedScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question22 is not a valid integer for this date
                                Console.WriteLine($"Invalid tactile stimulation seeking score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSeekedScore = totalSeekedScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average tactile stimulation seeking score over the past 7 days: {averageSeekedScore}");

                    return averageSeekedScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average vestibular stimuli seeked score
        public static double AverageVestibularStimulationSeeked()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSeekedScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question23 FROM questionResponses WHERE date = @date"; // select question23- asks about the days the child seeked out vestibular stimulation
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSeekedScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question23 is not a valid integer for this date
                                Console.WriteLine($"Invalid vestibular stimulation seeking score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSeekedScore = totalSeekedScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average vestibular stimulation seeking score over the past 7 days: {averageSeekedScore}");

                    return averageSeekedScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average proprioceptive stimuli seeked score
        public static double AverageProprioceptiveStimulationSeeked()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSeekedScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question24 FROM questionResponses WHERE date = @date"; // select question24- asks about the days the child seeked out proprioceptive stimulation
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSeekedScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question24 is not a valid integer for this date
                                Console.WriteLine($"Invalid proprioceptive stimulation seeking score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSeekedScore = totalSeekedScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average proprioceptive stimulation seeking score over the past 7 days: {averageSeekedScore}");

                    return averageSeekedScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average oral stimuli seeked score
        public static double AverageOralStimulationSeeked()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSeekedScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question25 FROM questionResponses WHERE date = @date"; // select question25- asks about the days the child seeked out oral stimulation
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSeekedScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question25 is not a valid integer for this date
                                Console.WriteLine($"Invalid oral stimulation seeking score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSeekedScore = totalSeekedScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average oral stimulation seeking score over the past 7 days: {averageSeekedScore}");

                    return averageSeekedScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average auditory stimuli seeked score
        public static double AverageAuditoryStimulationSeeked()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSeekedScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question26 FROM questionResponses WHERE date = @date"; // select question26- asks about the days the child seeked out auditory stimulation
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSeekedScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question26 is not a valid integer for this date
                                Console.WriteLine($"Invalid auditory stimulation seeking score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSeekedScore = totalSeekedScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average auditory stimulation seeking score over the past 7 days: {averageSeekedScore}");

                    return averageSeekedScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average visual stimuli seeked score
        public static double AverageVisualStimulationSeeked()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSeekedScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question27 FROM questionResponses WHERE date = @date"; // select question27- asks about the days the child seeked out visual stimulation
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSeekedScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question27 is not a valid integer for this date
                                Console.WriteLine($"Invalid visual stimulation seeking score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSeekedScore = totalSeekedScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average visual stimulation seeking score over the past 7 days: {averageSeekedScore}");

                    return averageSeekedScore;
                }
                else
                {
                    return 0;
                }
            }
        }

        // average olfactory stimuli seeked score
        public static double AverageOlfactoryStimulationSeeked()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                DateTime currentDate = DateTime.Now;
                double totalSeekedScore = 0;
                int validEntryCount = 0;

                // loop through the past 7 entries
                for (int i = 0; i < 7; i++)
                {
                    DateTime dateToCheck = currentDate.AddDays(-i);
                    string formattedDate = dateToCheck.ToString("yyyy-MM-dd");

                    string query = "SELECT question28 FROM questionResponses WHERE date = @date"; // select question28- asks about the days the child seeked out olfactory stimulation
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", formattedDate);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // need to check for null and DBNull
                        {
                            if (int.TryParse(result.ToString(), out int dailyInteraction))
                            {
                                totalSeekedScore += dailyInteraction;
                                validEntryCount++;
                            }
                            else
                            {
                                // handle cases where question28 is not a valid integer for this date
                                Console.WriteLine($"Invalid visual stimulation seeking score for {formattedDate}: {result}");
                            }
                        }
                        // if result is null or DBNull, no data for that date, so we skip it
                    }
                }

                double averageSeekedScore = totalSeekedScore / validEntryCount;

                if (validEntryCount > 0)
                {
                    MessageBox.Show($"Average olfactory stimulation seeking score over the past 7 days: {averageSeekedScore}");

                    return averageSeekedScore;
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
    