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
using PROG_POE.Pages;


namespace PROG_POE.Pages
{
    /// <summary>
    /// Interaction logic for TaskAssistant.xaml
    /// </summary>
    public partial class TaskAssistant : Page
    {

        
        
            // A simple model class to hold task details
            public class TaskItem
            {
                public string Title { get; set; }
                public string Description { get; set; }
                public DateTime? ReminderDate { get; set; }

                public override string ToString()
                {
                    return $"{Title} - {Description}" +
                           (ReminderDate.HasValue ? $" (Reminder: {ReminderDate.Value.ToShortDateString()})" : "");
                }
            }

            private List<TaskItem> tasks = new List<TaskItem>();

            public TaskAssistant()
            
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleTextBox.Text.Trim();
            string description = TaskDescriptionTextBox.Text.Trim();
            DateTime? reminderDate = ReminderDatePicker.SelectedDate;

            // Basic validation
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please enter both a title and a description for the task.",
                    "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create and store task
            var task = new TaskItem
            {
                Title = title,
                Description = description,
                ReminderDate = reminderDate
            };

            tasks.Add(task);
            TasksListBox.Items.Add(task);

          
            }
        }

     }
