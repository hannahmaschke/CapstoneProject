using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutismBehaviourTracker
{
    internal class questionLogicClass
    {
        // function to check if the user has submitted a journal entry every day for the past 7 days
        // do not implement this until I have a weeks worth of responses for debugging purposes
        public static bool CheckWeeklyEntry()
        {
            // get the current date
            DateTime currentDate = DateTime.Now;
            // check if there are journal entries for the past 7 days
            for (int i = 0; i < 7; i++)
            {
                DateTime dateToCheck = currentDate.AddDays(-i);
                string formattedDate = dateToCheck.ToString("yyyy-MM-dd");
                // check if there is a journal entry for the current date
                if (!DatabaseSetup.CheckJournalEntryExists(formattedDate))
                {
                    return false;
                }
            }
            return true;
        }

        // 

    
        }
    }

