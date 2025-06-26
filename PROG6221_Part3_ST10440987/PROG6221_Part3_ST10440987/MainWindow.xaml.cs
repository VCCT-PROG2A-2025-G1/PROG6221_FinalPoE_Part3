using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6221_Part3_ST10440987
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Chatbot chatbot;
        private bool validName = false;
        private bool taskDeleted = true;
        private bool taskCompleted = true;
        public MainWindow()
        {
            InitializeComponent();
            chatbot = new Chatbot();
            Loaded += ChatBotGreeting;
            UserInput.Focus();
        }

        private async void ChatBotGreeting(object sender, RoutedEventArgs e)
        {
            ChatHistory.AppendText(chatbot.ChatBotFace() + "\n");
            ChatHistory.ScrollToEnd();
            await Task.Delay(11000);
            ChatHistory.AppendText("PERSONALIZATION\n");
            ChatHistory.AppendText("Chatbot: What is your name?\n");
            ChatHistory.ScrollToEnd();
            this.validName = true;
        }

        public void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return;
            }
            ChatHistory.AppendText($"You: {userInput}\n");

            if (this.validName)
            {
                chatbot.name = userInput;
                this.validName = false;

                ChatHistory.AppendText(chatbot.Greeting() + "\n");
                ChatHistory.AppendText("You may now start a conversation with the chatbot\n\n");
                ChatHistory.ScrollToEnd();
                UserInput.Clear();
                UserInput.Focus();
                return;
            }

            if (UserInput.Text.Trim().ToLower() == "mark as complete" && chatbot.tasks.Count > 0)
            {
                this.taskCompleted = false;
                ChatHistory.AppendText("\nChatbot: Please enter the task number you would like to mark as complete (E.g: 1, 2 or 3)\n");
                ChatHistory.ScrollToEnd();
                UserInput.Clear();
                UserInput.Focus();
                return;
            }

            if (!this.taskCompleted)
            {
                this.taskCompleted = true;
                if (int.TryParse(UserInput.Text.Trim(), out int taskNumber))
                {
                    if (taskNumber >= 1 && taskNumber <= chatbot.tasks.Count)
                    {
                        var completedTask = chatbot.tasks[taskNumber - 1];
                        completedTask.taskCompleted = "Completed";
                        ChatHistory.AppendText($"Chatbot: Task {taskNumber} with title {completedTask.title} has been marked as complete successfully\n\n");
                        //chatbot.activityLog.Add($"Task: Task {taskNumber} marked as complete");
                    }
                    else
                    {
                        this.taskCompleted = false;
                        ChatHistory.AppendText("Chatbot: Invalid task number. Please enter a valid task number\n");
                    }
                }
                ChatHistory.ScrollToEnd();
                UserInput.Clear();
                UserInput.Focus();
                return;
            }

            if (UserInput.Text.Trim().ToLower() == "delete" && chatbot.tasks.Count > 0)
            {
                this.taskDeleted = false;
                ChatHistory.AppendText("\nChatbot: Please enter the task number you would like to delete (E.g: 1, 2 or 3)\n");
                ChatHistory.ScrollToEnd();
                UserInput.Clear();
                UserInput.Focus();
                return;
            }

            if (!this.taskDeleted)
            {
                this.taskDeleted = true;
                if (int.TryParse(UserInput.Text.Trim(), out int taskNumber))
                {
                    if (taskNumber >= 1 && taskNumber <= chatbot.tasks.Count)
                    {
                        var deletedTask = chatbot.tasks[taskNumber - 1];
                        chatbot.tasks.RemoveAt(taskNumber - 1);
                        ChatHistory.AppendText($"Chatbot: Task {taskNumber} with title {deletedTask.title} has been deleted successfully\n\n");
                        //chatbot.activityLog.Add($"Task: Task {taskNumber} deleted");
                    }
                    else
                    {
                        this.taskDeleted = false;
                        ChatHistory.AppendText("Chatbot: Invalid task number. Please enter a valid task number\n");
                    }
                }
                ChatHistory.ScrollToEnd();
                UserInput.Clear();
                UserInput.Focus();
                return;
            }

            string botResponse = chatbot.ChatBotConversation(userInput);
            ChatHistory.AppendText($"{botResponse}\n\n");
            ChatHistory.ScrollToEnd();
            UserInput.Clear();
            UserInput.Focus();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))
            {
                e.Handled = true;
                SendButton_Click(null, null);
            }
        }

        public void ViewTasksButton_Click(object sender, RoutedEventArgs e)
        {
            if (chatbot.tasks.Count == 0)
            {
                ChatHistory.AppendText("Chatbot: You currently do not have any existing tasks");
            }
            else
            {
                ChatHistory.AppendText($"Chatbot: These are your existing tasks below:\n");

                int count = 1;
                foreach (var task in chatbot.tasks)
                {
                    ChatHistory.AppendText($"Task {count}:\n");
                    ChatHistory.AppendText($"{task.title}\n{task.taskDescription}\n{task.reminderText}\n{task.taskCompleted}\n\n");
                    count++;
                }
                ChatHistory.AppendText("To mark a task as Complete, please type in mark as complete\n");
                ChatHistory.AppendText("If you would like to delete any tasks, just type in the word delete\n");
            }
            ChatHistory.ScrollToEnd();
            UserInput.Clear();
            UserInput.Focus();
        }
    }
}