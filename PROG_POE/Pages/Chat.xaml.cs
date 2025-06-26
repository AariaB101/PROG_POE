using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PROG_POE.Pages
{
    public partial class Chat : Page
    {
        // ✅ Keyword tips dictionary
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>
        {
            { "passwords", new List<string> {
                "Use long, complex passwords that include letters, numbers, and symbols.",
                "Avoid using the same password across multiple sites.",
                "Consider using a password manager to keep your credentials safe."
            }},
            { "phishing", new List<string> {
                "Watch out for emails with urgent requests or unfamiliar links.",
                "Don't click on suspicious attachments or download links.",
                "Check sender email addresses closely — scammers spoof trusted contacts."
            }},
            { "privacy", new List<string> {
                "Review your social media privacy settings regularly.",
                "Avoid sharing sensitive info publicly.",
                "Use encrypted apps when discussing personal matters."
            }},
            { "scam", new List<string> {
                "Scams may promise rewards or threaten penalties — stay skeptical.",
                "Verify unexpected messages via a second method.",
                "Never send personal data or money to unknown sources."
            }},
            { "safe browsing", new List<string> {
                "Use HTTPS websites and avoid suspicious pop-ups.",
                "Install browser security extensions and keep them updated.",
                "Clear cookies and cache regularly to maintain privacy."
            }}
        };


        public Chat()
        {
            InitializeComponent();
        }

        // ✅ Send button click handler
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = ChatTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please type a message.");
                return;
            }

            // Show user message
            ChatHistoryListBox.Items.Add($"You: {userInput}");

            // Get and show bot response
            string botResponse = GetBotResponse(userInput);
            ChatHistoryListBox.Items.Add($"Bot: {botResponse}");

            // Scroll to bottom
            ChatHistoryListBox.ScrollIntoView(ChatHistoryListBox.Items[ChatHistoryListBox.Items.Count - 1]);

            // Clear input box
            ChatTextBox.Clear();
        }

        // ✅ Chatbot response generator
        private string GetBotResponse(string input)
        {
            input = input.ToLower();


            // Check for keyword tips
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    return $"Here are some tips on {keyword}:\n- " + string.Join("\n- ", keywordResponses[keyword]);
                }
            }

            // Basic responses
            if (input.Contains("hello"))
                return "Hi there! How can I help you today?";

            if (input.Contains("worried"))
                return "It's okay to feel that way. Cybersecurity can be overwhelming, but I'm here to help.\n";

            if (input.Contains("frustrated"))
            return "I understand. Let's take it step by step.\n";

            if (input.Contains("curious"))
            
                return "Curiosity is good! Let’s explore online safety together.\n";

            else if (input.Contains("help"))
                return "You can ask about passwords, phishing, scams, safe browsing, or privacy.";
            else
                return "I'm not sure how to help with that. Try asking about cybersecurity topics like 'passwords' or 'phishing'.";
        }
    }
}
