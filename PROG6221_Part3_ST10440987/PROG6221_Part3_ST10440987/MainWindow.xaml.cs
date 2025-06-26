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
    }
}