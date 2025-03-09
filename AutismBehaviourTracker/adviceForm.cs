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
            generateSleepAdvice();
            generateSocialAdvice();
            generateSensoryAdvice();
        }



        // generate advice based on the average sleep value
        private void generateSleepAdvice()
        {
            // get the average sleep values frm the database setup class
            double averageSleep = DatabaseSetup.AverageSleepLast7Days();
            double averageAwakenings = DatabaseSetup.AverageAwakenings(); 
            double averageFallAsleepQuality = DatabaseSetup.AverageDifficultyFallingAsleep(); 


            // display the avrage amount of sleep the child is getting
            richTextBox1.Text += $"Your child is getting an average of {averageSleep:F1} hours of sleep per night.\n";

            if (averageSleep < 3)
            {
                richTextBox1.Text += "This is significantly below the recommended amount of sleep. Less than 3 hours per night is extremely low and can be dangerous for your child's health and development. Consider seeking medical advice and help with sleep issues immediately. ";
            }
            else if (averageSleep < 5)
            {
                richTextBox1.Text += "Your child is getting very little sleep. 4-5 hours per night is below the recommended amount for healthy development. Consider implementing a stricter bedtime routine and reducing screen time and stimulants like caffeine in the evening (for teens). Melatonin could be helpful as well, consider asking your doctor or pharmacist about this option. ";
            }
            else if (averageSleep < 7)
            {
                richTextBox1.Text += "Your child is getting a bit more sleep, but 6-7 hours per night is still considered insufficient for their growth and cognitive development. Focus on establishing a more consistent sleep schedule and creating a relaxing pre-bedtime routine. ";
            }
            else if (averageSleep < 9)
            {
                richTextBox1.Text += "Your child is getting good sleep, but there is still room for improvement. 8-9 hours per night is great, but try to ensure that the sleep is uninterrupted and of high quality. A consistent sleep routine will help maintain and even improve this quality. ";
            }
            else if (averageSleep <= 12)
            {
                richTextBox1.Text += "Your child is getting excellent sleep! 10-12 hours per night is ideal for healthy growth and development. Keep maintaining this routine for optimal health and well-being. ";
            }
            else
            {
                richTextBox1.Text += "It seems your child is getting more than the recommended amount of sleep. While sleep is essential, ensure your child is also engaging in activities during the day to promote their physical and mental development. ";
            }

            //questionSublabels[1] = "Question 2 of 29:\n 1 meaning no awakenings during the night, 2 meaning woke up once and fell back asleep quickly, 3 meaning woke up once and took awhile to fall back asleep, 4 meaning woke up at least twice, 5 meaning several awakenings";
            // feedback on average awakenings
            if (averageAwakenings >= 4.5 && averageAwakenings <= 5)
            {
                richTextBox1.Text += "\nYour child is on average experiencing frequent and multiple awakenings throughout the night, which can significantly disrupt their sleep. Consider reviewing their sleep environment for potential disruptions such as noise, light, or temperature. You might also want to explore any underlying issues such as anxiety, nightmares, or night terrors.";
            }
            else if (averageAwakenings >= 3.5 && averageAwakenings < 4.5)
            {
                richTextBox1.Text += "\nYour child is waking up on average at least twice during the night, which can interrupt their sleep cycle. Try creating a more comfortable and quiet sleep environment, and consider reviewing their evening routine to minimize disturbances.";
            }
            else if (averageAwakenings >= 2.5 && averageAwakenings < 3.5)
            {
                richTextBox1.Text += "\nYour child is waking up once on average during the night and taking some time to fall back asleep. It might help to ensure that they have a relaxing bedtime routine, with activities such as reading or listening to calming music. Also, make sure their bedroom is conducive to sleep with minimal distractions.";
            }
            else if (averageAwakenings >= 1.5 && averageAwakenings < 2.5)
            {
                richTextBox1.Text += "\nYour child wakes up once on average during the night but falls back asleep quickly, which is fairly normal for many children. If this is disrupting their sleep quality, consider ensuring that their room is comfortable and quiet during the night.";
            }
            else if (averageAwakenings >= 1 && averageAwakenings < 1.5)
            {
                richTextBox1.Text += "\nYour child is not waking up during the night, which is great for their sleep quality and development. Keep maintaining a consistent bedtime and a calming pre-sleep routine to continue promoting restful, uninterrupted sleep.";
            }
            else
            {
                richTextBox1.Text += "\nThere seems to be an issue with the awakenings data. Please verify if the recorded information is accurate.";
            }

            // provide advice based on the average difficulty falling asleep
            richTextBox1.Text += $"\nAverage difficulty falling asleep: {averageFallAsleepQuality:F1} (Scale 1-5, where 1 is easy and 5 is very difficult).";

            if (averageFallAsleepQuality >= 4.5 && averageFallAsleepQuality <= 5)
            {
                richTextBox1.Text += "\nYour child is having trouble falling asleep. This could be due to anxiety, overstimulation, or irregular bedtime routines. Consider reducing screen time before bed, using calming activities like reading, and ensuring a consistent bedtime.";
            }
            else if (averageFallAsleepQuality >= 3.5 && averageFallAsleepQuality < 4.5)
            {
                richTextBox1.Text += "\nYour child takes some time to fall asleep. Creating a calming pre-sleep routine, such as a warm bath or quiet reading time, may help ease this process.";
            }
            else if (averageFallAsleepQuality >= 2.5 && averageFallAsleepQuality < 3.5)
            {
                richTextBox1.Text += "\nYour child is having some difficulty falling asleep, but it’s not extreme. Continue fostering a peaceful environment for sleep and a regular bedtime routine to make falling asleep easier.";
            }
            else if (averageFallAsleepQuality >= 1.5 && averageFallAsleepQuality < 2.5)
            {
                richTextBox1.Text += "\nYour child is able to fall asleep fairly easily, which is a good sign. Continue with the consistent bedtime routine to promote relaxation and sleep readiness.";
            }
            else if (averageFallAsleepQuality >= 1 && averageFallAsleepQuality < 1.5)
            {
                richTextBox1.Text += "\nYour child is falling asleep very easily, which is excellent for their overall sleep quality. Keep up the positive bedtime routine to maintain this good habit.";
            }
            else
            {
                richTextBox1.Text += "\nThere seems to be an issue with the sleep data. Please verify if the recorded information is accurate.";
            }
        }

        private void generateSocialAdvice()
        {
            // get the average social value from the database setup class
            double averageSocialInteractions = DatabaseSetup.AverageSocialInteractions();  
            double averageEyeContact = DatabaseSetup.AverageEyeContact();  
            double averageViolence = DatabaseSetup.AverageViolence(); 
            double averageDaysWithMeltdown = DatabaseSetup.AverageDaysWithMeltdown();  
            double averageDifficultyTransitioning = DatabaseSetup.AverageDifficultyTransitioning();  
            double averageSocializationAmount = DatabaseSetup.AverageSocializationAmount();

            // feedback on the social interaction score
            richTextBox2.Text += $"Average social interaction score over the past 7 days: {averageSocialInteractions:F1} (1 means no problems, 5 means great difficulty interacting with others).\n";

            if (averageSocialInteractions >= 4.5 && averageSocialInteractions <= 5)
            {
                richTextBox2.Text += "Your child is having great difficulty interacting with others. You may want to consider seeking support from a professional to help them with social skills and interaction strategies.\n";
            }
            else if (averageSocialInteractions >= 3.5 && averageSocialInteractions < 4.5)
            {
                richTextBox2.Text += "Your child seems to be facing challenges with social interactions. Encouraging group activities and providing opportunities to practice social skills can help improve these interactions.\n";
            }
            else if (averageSocialInteractions >= 2.5 && averageSocialInteractions < 3.5)
            {
                richTextBox2.Text += "Your child is engaging in social interactions at an average level. It may be beneficial to continue facilitating social play and modeling positive social behaviors.\n";
            }
            else if (averageSocialInteractions >= 1.5 && averageSocialInteractions < 2.5)
            {
                richTextBox2.Text += "Your child is having some difficulties interacting with others. Consider using games and structured social activities to help them build confidence and improve their social skills.\n";
            }
            else if (averageSocialInteractions >= 1 && averageSocialInteractions < 1.5)
            {
                richTextBox2.Text += "Your child has no significant problems interacting with others, which is a great sign for their social development. Keep encouraging social experiences and interactions with peers.\n";
            }
            else
            {
                richTextBox2.Text += "Monitoring your child’s interactions more closely can help identify any underlying social challenges.\n";
            }

            // feedback on the eye contact score
            richTextBox2.Text += $"Average eye contact score over the past 7 days: {averageEyeContact:F1} (1 means no problems, 5 means great difficulty making eye contact).\n";

            if (averageEyeContact >= 4.5 && averageEyeContact <= 5)
            {
                richTextBox2.Text += "Your child is having great difficulty making eye contact. This could indicate challenges with communication or social anxiety. Practicing eye contact in a comfortable setting can help, and seeking advice from a professional might be useful.\n";
            }
            else if (averageEyeContact >= 3.5 && averageEyeContact < 4.5)
            {
                richTextBox2.Text += "Your child has difficulty with eye contact. Encouraging them to make eye contact during conversations or interactions, and providing positive reinforcement when they do, can help improve this skill.\n";
            }
            else if (averageEyeContact >= 2.5 && averageEyeContact < 3.5)
            {
                richTextBox2.Text += "Your child is able to make eye contact some of the time. This is normal, but continuing to encourage this behavior during conversations can help reinforce it.\n";
            }
            else if (averageEyeContact >= 1.5 && averageEyeContact < 2.5)
            {
                richTextBox2.Text += "Your child is doing well with eye contact, which is great for their communication skills. Continue encouraging them to engage in this way during interactions.\n";
            }
            else if (averageEyeContact >= 1 && averageEyeContact < 1.5)
            {
                richTextBox2.Text += "Your child is making excellent eye contact, which indicates strong social communication skills. Keep reinforcing this positive behavior during interactions.\n";
            }
            else
            {
                richTextBox2.Text += "Observing and providing gentle reminders can help encourage more eye contact during social interactions.\n";
            }

            // feedback on the violence score
            richTextBox2.Text += $"Average violence score over the past 7 days: {averageViolence:F1} (1 means no violence whatsoever, 5 means very violent).\n";

            if (averageViolence >= 4.5 && averageViolence <= 5)
            {
                richTextBox2.Text += "Your child has been very violent recently. This is a serious concern and should be addressed. It may be helpful to speak with a behavioral specialist to identify triggers and manage these behaviors.\n";
            }
            else if (averageViolence >= 3.5 && averageViolence < 4.5)
            {
                richTextBox2.Text += "Your child has been showing violent behavior. Try to identify any triggers and provide appropriate outlets for frustration. Consulting with a professional may also help manage these behaviors.\n";
            }
            else if (averageViolence >= 2.5 && averageViolence < 3.5)
            {
                richTextBox2.Text += "Your child has occasional violent outbursts. Encourage calming techniques like deep breathing, and work on conflict resolution skills to help reduce these behaviors.\n";
            }
            else if (averageViolence >= 1.5 && averageViolence < 2.5)
            {
                richTextBox2.Text += "Your child rarely exhibits violent behavior, but it’s important to continue promoting healthy emotional expression and managing frustration constructively.\n";
            }
            else if (averageViolence >= 1 && averageViolence < 1.5)
            {
                richTextBox2.Text += "Your child shows little to no violence, which is a positive sign. Reinforcing positive behavior and promoting effective communication can help maintain this progress.\n";
            }
            else
            {
                richTextBox2.Text += "Keeping track of behavior and identifying patterns will help in addressing this concern more effectively.\n";
            }

            // feedback on the days with meltdowns
            richTextBox2.Text += $"Average number of days with meltdowns over the past 7 days: {averageDaysWithMeltdown:F1} (1 means no meltdowns, 5 means frequent meltdowns).\n";

            if (averageDaysWithMeltdown >= 4.5 && averageDaysWithMeltdown <= 5)
            {
                richTextBox2.Text += "Your child has had frequent meltdowns, which could indicate difficulties with emotional regulation. Consider using strategies such as calming exercises or speaking with a therapist to help manage these situations.\n";
            }
            else if (averageDaysWithMeltdown >= 3.5 && averageDaysWithMeltdown < 4.5)
            {
                richTextBox2.Text += "Your child is experiencing meltdowns more often than usual. You might want to explore triggers for these meltdowns and implement strategies like structured routines and emotional regulation techniques.\n";
            }
            else if (averageDaysWithMeltdown >= 2.5 && averageDaysWithMeltdown < 3.5)
            {
                richTextBox2.Text += "Your child is having occasional meltdowns. Offering reassurance, teaching calming techniques, and identifying stressors can help reduce the frequency of these meltdowns.\n";
            }
            else if (averageDaysWithMeltdown >= 1.5 && averageDaysWithMeltdown < 2.5)
            {
                richTextBox2.Text += "Your child rarely has meltdowns. Keeping a consistent routine and providing positive reinforcement when they manage frustration well can continue to support their emotional regulation.\n";
            }
            else if (averageDaysWithMeltdown >= 1 && averageDaysWithMeltdown < 1.5)
            {
                richTextBox2.Text += "Your child has minimal meltdowns, which is great. Continue to provide a supportive environment and teach them constructive ways to cope with difficult emotions.\n";
            }
            else
            {
                richTextBox2.Text += "More consistent tracking can help identify patterns and provide more accurate insights into how your child is coping with emotions.\n";
            }

            // feedback on the difficulty transitioning score
            richTextBox2.Text += $"Average difficulty transitioning score over the past 7 days: {averageDifficultyTransitioning:F1} (1 means no problems, 5 means great difficulty transitioning between activities).\n";

            if (averageDifficultyTransitioning >= 4.5 && averageDifficultyTransitioning <= 5)
            {
                richTextBox2.Text += "Your child has significant difficulty transitioning between activities. Visual cues, advanced warnings, and clear routines can help ease these transitions. It might also be helpful to work with a professional to address these challenges.\n";
            }
            else if (averageDifficultyTransitioning >= 3.5 && averageDifficultyTransitioning < 4.5)
            {
                richTextBox2.Text += "Your child has some difficulty transitioning between activities. You can help them by providing clear expectations, offering warnings before transitions, and using visual schedules to aid in the process.\n";
            }
            else if (averageDifficultyTransitioning >= 2.5 && averageDifficultyTransitioning < 3.5)
            {
                richTextBox2.Text += "Your child has an average ability to transition between activities. Try to offer support during transitions, and encourage patience and flexibility to help them adjust more easily.\n";
            }
            else if (averageDifficultyTransitioning >= 1.5 && averageDifficultyTransitioning < 2.5)
            {
                richTextBox2.Text += "Your child transitions with little difficulty, but providing consistency and clear cues will continue to support smooth transitions.\n";
            }
            else if (averageDifficultyTransitioning >= 1 && averageDifficultyTransitioning < 1.5)
            {
                richTextBox2.Text += "Your child transitions easily, which is a great sign of adaptability. Maintaining routines and providing clear expectations will help reinforce this positive behavior.\n";
            }
            else
            {
                richTextBox2.Text += "Tracking transitions more consistently can help provide a clearer picture of how your child is coping with changes in activities.\n";
            }

            // feedback on the socialization level
            richTextBox2.Text += $"Average socialization score over the past 7 days: {averageSocializationAmount:F1} (1 means more socialized than usual, 3 means average, 5 means less socialized than usual).\n";

            if (averageSocializationAmount >= 4.5 && averageSocializationAmount <= 5)
            {
                richTextBox2.Text += "Your child is socializing less than usual. It may help to encourage more social activities and engage them in group play or other opportunities to interact with peers.\n";
            }
            else if (averageSocializationAmount >= 2.5 && averageSocializationAmount < 4.5)
            {
                richTextBox2.Text += "Your child’s socialization level is average. Encouraging social playdates or activities might help increase their social engagement.\n";
            }
            else if (averageSocializationAmount >= 1 && averageSocializationAmount < 2.5)
            {
                richTextBox2.Text += "Your child is socializing more than usual, which is a positive sign for their social development. Continue to encourage and support their interactions with others.\n";
            }
            else
            {
                richTextBox2.Text += "Observing social interactions more consistently can provide a better understanding of your child's social habits.\n";
            }

        }

        private void generateSensoryAdvice()
        {
            // get the average sensory value from the database setup class
            double averageRefusalScore = DatabaseSetup.AverageMealRefusedScore();
            double averageAppetiteScore = DatabaseSetup.AverageAmountEaten();
            double averageLoudStimuliAvoidance = DatabaseSetup.AverageLoudStimuliAvoided();
            double averageVisualStimuliAvoidance = DatabaseSetup.AverageVisualStimuliAvoided();
            double averageTactileStimuliAvoidance = DatabaseSetup.AverageTactileStimuliAvoided();

            // clear the RichTextBox before adding new content
            richTextBox3.Clear();

            // meal refusal score feedback
            richTextBox3.Text += $"Average meal refusal score over the past 7 days: {averageRefusalScore:F1} (1 means no meal refusal, 5 means refused all meals).\n";
            if (averageRefusalScore <= 5 && averageRefusalScore >= 4.00)
            {
                richTextBox3.Text += "Your child has been refusing meals frequently. It might be helpful to explore any underlying causes, such as sensory sensitivities, and consult with a professional if needed.\n";
            }
            else if (averageRefusalScore <= 3.99 && averageRefusalScore >= 3.00)
            {
                richTextBox3.Text += "Your child has been refusing meals often. It may help to offer smaller portions, provide a calm mealtime environment, and observe if certain foods trigger this behavior.\n";
            }
            else if (averageRefusalScore <= 2.99 && averageRefusalScore >= 2.00)
            {
                richTextBox3.Text += "Your child’s meal refusal is moderate. Continue to encourage a positive mealtime experience and try to make meals more engaging.\n";
            }
            else if (averageRefusalScore <= 1.99 && averageRefusalScore >= 1.50)
            {
                richTextBox3.Text += "Your child is refusing meals occasionally. Consider diversifying the food options and ensuring the environment is relaxing during mealtime.\n";
            }
            else if (averageRefusalScore < 1.49)
            {
                richTextBox3.Text += "Your child has little to no meal refusal, which is a good sign. Keep offering a variety of foods and encourage family meals to reinforce this positive behavior.\n";
            }
            else
            {
                richTextBox3.Text += "Tracking meal refusals more closely may help identify any triggers for this behavior.\n";
            }

            // appetite score feedback
            richTextBox3.Text += $"Average appetite score over the past 7 days: {averageAppetiteScore:F1} (1 means ate more than usual, 3 means ate an average amount, 5 means ate less than usual).\n";
            if (averageAppetiteScore <= 5 && averageAppetiteScore >= 4)
            {
                richTextBox3.Text += "Your child has been eating less than usual. It may help to monitor their eating habits closely and consult with a healthcare provider to rule out any underlying health issues.\n";
            }
            else if (averageAppetiteScore <= 3.99 && averageAppetiteScore >= 3)
            {
                richTextBox3.Text += "Your child’s appetite seems normal. Continue to provide nutritious meals and maintain a structured mealtime routine.\n";
            }
            else if (averageAppetiteScore < 2.99)
            {
                richTextBox3.Text += "Your child is eating more than usual, which could indicate emotional or sensory-related issues. You may want to monitor this and seek advice from a professional if necessary.\n";
            }
            else
            {
                richTextBox3.Text += "Observing appetite changes consistently can provide better insights into your child’s eating behavior.\n";
            }

            // loud stimuli avoidance score feedback
            richTextBox3.Text += $"Average loud stimuli avoidance score over the past 7 days: {averageLoudStimuliAvoidance:F1} (1 means no avoidance, 5 means frequent avoidance).\n";
            if (averageLoudStimuliAvoidance <= 5 && averageLoudStimuliAvoidance >= 4)
            {
                richTextBox3.Text += "Your child avoids loud stimuli frequently. This could indicate sensory sensitivities to noise. It might be helpful to create a quiet space or use noise-canceling headphones.\n";
            }
            else if (averageLoudStimuliAvoidance <= 3.99 && averageLoudStimuliAvoidance >= 3)
            {
                richTextBox3.Text += "Your child shows moderate avoidance of loud stimuli. Gradual exposure to louder environments could help them build tolerance.\n";
            }
            else if (averageLoudStimuliAvoidance < 2.99)
            {
                richTextBox3.Text += "Your child seems to tolerate loud stimuli well. Continue to offer varied environments for sensory development.\n";
            }

            // visual stimuli avoidance score feedback
            richTextBox3.Text += $"Average visual stimuli avoidance score over the past 7 days: {averageVisualStimuliAvoidance:F1} (1 means no avoidance, 5 means frequent avoidance).\n";
            if (averageVisualStimuliAvoidance <= 5 && averageVisualStimuliAvoidance >= 4)
            {
                richTextBox3.Text += "Your child avoids bright lights frequently. This could indicate sensitivity to visual stimuli. You might want to provide shaded areas or consider dimming the lights in certain situations.\n";
            }
            else if (averageVisualStimuliAvoidance <= 3.99 && averageVisualStimuliAvoidance >= 3)
            {
                richTextBox3.Text += "Your child moderately avoids bright lights. Consider gradually introducing them to brighter environments in a controlled manner.\n";
            }
            else if (averageVisualStimuliAvoidance < 2.99)
            {
                richTextBox3.Text += "Your child is comfortable with bright lights. Encourage them to explore different lighting situations to support sensory adaptation.\n";
            }

            // tactile stimuli avoidance score feedback
            richTextBox3.Text += $"Average tactile stimuli avoidance score over the past 7 days: {averageTactileStimuliAvoidance:F1} (1 means no avoidance, 5 means frequent avoidance).\n";
            if (averageTactileStimuliAvoidance <= 5 && averageTactileStimuliAvoidance >= 4)
            {
                richTextBox3.Text += "Your child avoids certain textures frequently. They may be sensitive to tactile stimuli. Consider providing a variety of textures for exploration in a gentle manner.\n";
            }
            else if (averageTactileStimuliAvoidance <= 3.99 && averageTactileStimuliAvoidance >= 3)
            {
                richTextBox3.Text += "Your child shows moderate avoidance of certain textures. Offering a range of textured materials can help them gradually adjust to different sensations.\n";
            }
            else if (averageTactileStimuliAvoidance < 2.99)
            {
                richTextBox3.Text += "Your child is comfortable with a variety of textures. Continue providing new tactile experiences to encourage sensory exploration.\n";
            }

            // finish the rest of the sensory advice later
        }



        private void adviceForm_Load(object sender, EventArgs e)
        {
            // load the advice from the database
            generateSleepAdvice();
            generateSocialAdvice();
            generateSensoryAdvice();
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void adviceForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
