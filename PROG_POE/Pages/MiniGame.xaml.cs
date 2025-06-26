using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG_POE.Pages
{
    /// <summary>
    /// Interaction logic for MiniGame.xaml
    /// </summary>
    public partial class MiniGame : Page
    {
        private class QuizQuestion
        {
            public string Question { get; set; }
            public List<string> Options { get; set; }
            public int CorrectIndex { get; set; }
            public string Explanation { get; set; }
        }

        private List<QuizQuestion> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;

        public MiniGame()
        {
            InitializeComponent();
            LoadQuestions();
            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What should you do if you receive an email asking for your password?",
                    Options = new List<string> { "Reply with your password", "Delete the email", "Report the email as phishing", "Ignore it" },
                    CorrectIndex = 2,
                    Explanation = "Correct! Reporting phishing emails helps prevent scams."
                },
                new QuizQuestion
                {
                    Question = "True or False: Using '123456' as a password is secure.",
                    Options = new List<string> { "True", "False" },
                    CorrectIndex = 1,
                    Explanation = "Correct! Simple passwords like '123456' are very easy to guess."
                },
                new QuizQuestion
                {
                    Question = "What is a good way to create a strong password?",
                    Options = new List<string> { "Use your birthdate", "Use a mix of letters, numbers, and symbols", "Use the word 'password'", "Use the same password everywhere" },
                    CorrectIndex = 1,
                    Explanation = "Correct! Strong passwords use a mix of letters, numbers, and symbols."
                },
                new QuizQuestion
                {
                    Question = "True or False: You should click unknown links to see what they are.",
                    Options = new List<string> { "True", "False" },
                    CorrectIndex = 1,
                    Explanation = "Correct! Unknown links may lead to malicious sites."
                },
                new QuizQuestion
                {
                    Question = "Which is a sign of a phishing attempt?",
                    Options = new List<string> { "Personalized greeting", "Perfect spelling", "Urgency and threats", "Secure HTTPS link" },
                    CorrectIndex = 2,
                    Explanation = "Correct! Phishing emails often create urgency or threats to trick users."
                },
                new QuizQuestion
                {
                    Question = "Which of these is a safe practice?",
                    Options = new List<string> { "Sharing passwords with coworkers", "Using two-factor authentication", "Using the same password for all accounts", "Clicking pop-ups" },
                    CorrectIndex = 1,
                    Explanation = "Correct! Two-factor authentication adds extra protection."
                },
                new QuizQuestion
                {
                    Question = "True or False: Antivirus software is unnecessary if you're careful online.",
                    Options = new List<string> { "True", "False" },
                    CorrectIndex = 1,
                    Explanation = "Correct! Antivirus adds an extra layer of protection."
                },
                new QuizQuestion
                {
                    Question = "What should you do if a website looks suspicious?",
                    Options = new List<string> { "Enter fake info", "Leave the site immediately", "Click around to explore", "Buy something to check" },
                    CorrectIndex = 1,
                    Explanation = "Correct! Leaving suspicious websites helps avoid scams."
                },
                new QuizQuestion
                {
                    Question = "Which is a form of social engineering?",
                    Options = new List<string> { "Firewall", "Antivirus", "Phishing email", "Encryption" },
                    CorrectIndex = 2,
                    Explanation = "Correct! Phishing is a type of social engineering."
                },
                new QuizQuestion
                {
                    Question = "True or False: It's okay to use public Wi-Fi for banking.",
                    Options = new List<string> { "True", "False" },
                    CorrectIndex = 1,
                    Explanation = "Correct! Public Wi-Fi is not secure for sensitive transactions."
                }
            };
        }

        private void DisplayQuestion()
        {
            FeedbackText.Text = "";
            NextButton.IsEnabled = false;
            AnswerPanel.Children.Clear();

            if (currentQuestionIndex >= questions.Count)
            {
                QuestionText.Text = "Quiz Complete!";
                ScoreText.Text = $"Final Score: {score}/{questions.Count}";
                FeedbackText.Text = score >= 8 ? "Great job! You're a cybersecurity pro!" : "Keep learning to stay safe online!";
                return;
            }

            var q = questions[currentQuestionIndex];
            QuestionText.Text = q.Question;

            for (int i = 0; i < q.Options.Count; i++)
            {
                var btn = new RadioButton
                {
                    Content = q.Options[i],
                    GroupName = "Answers",
                    Tag = i
                };
                btn.Checked += Answer_Checked;
                AnswerPanel.Children.Add(btn);
            }
        }

        private void Answer_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selected = (RadioButton)sender;
            int selectedIndex = (int)selected.Tag;
            QuizQuestion current = questions[currentQuestionIndex];

            if (selectedIndex == current.CorrectIndex)
            {
                FeedbackText.Text = current.Explanation;
                FeedbackText.Foreground = System.Windows.Media.Brushes.Green;
                score++;
            }
            else
            {
                FeedbackText.Text = $"Incorrect. {current.Explanation}";
                FeedbackText.Foreground = System.Windows.Media.Brushes.Red;
            }

            NextButton.IsEnabled = true;
            foreach (var child in AnswerPanel.Children)
            {
                if (child is RadioButton rb)
                    rb.IsEnabled = false;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex++;
            DisplayQuestion();
        }
    }

}