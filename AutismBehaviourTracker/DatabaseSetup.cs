using System;
using System.Collections.Generic;
using System.Data.SQLite;

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

                string query = "SELECT date, entryText FROM journalEntries ORDER BY Id ASC";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string date = reader.GetString(0);
                        string entryText = reader.GetString(1);
                        entries.Add($"Date: {date}\n{entryText}\n\n---------------------------------------------------------------------------------------");
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

                // create table for journal entries
                string createJournalTableQuery = @"
        CREATE TABLE IF NOT EXISTS journalEntries (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            date TEXT NOT NULL,
            entryText TEXT NOT NULL
        );";

                using (SQLiteCommand cmd = new SQLiteCommand(createJournalTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // create table for storing responses to daily questions
                string createQuestionsTableQuery = @"
        CREATE TABLE IF NOT EXISTS questionsResponses (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            question TEXT NOT NULL,
            answer TEXT NOT NULL,
            responseDate TEXT NOT NULL
        );";

                using (SQLiteCommand cmd = new SQLiteCommand(createQuestionsTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}