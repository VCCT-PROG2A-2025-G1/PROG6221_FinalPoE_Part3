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
using System.Windows.Shapes;

namespace PROG6221_Part3_ST10440987
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        public Chatbot chatbot;
        private MainWindow mainWindow;
        public List<string> questions;
        public List<string> answers;
        public List<string> explanations;
        public List<int> remainingQuestionsIndex;
        public int currentQuestionIndex;
        private int totalScore = 0;
        public QuizWindow(MainWindow mainWindow, Chatbot chatbot)
        {
            InitializeComponent();
            this.chatbot = chatbot;
            this.questions = chatbot.questions;
            this.answers = chatbot.answers;
            this.explanations = chatbot.explanations;
            this.currentQuestionIndex = -1;
            this.remainingQuestionsIndex = Enumerable.Range(0, this.questions.Count).ToList();
            UserAnswer.Focus();
            this.mainWindow = mainWindow;
        }

        public void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentQuestionIndex == -1)
            {
                //this.chatbot.activityLog.Add("Quiz: Quiz Started");
                this.NextQuestion();
            }
        }

        public void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentQuestionIndex == -1)
            {
                QuizHistory.AppendText("Click 'Start Quiz' Button to start Quiz");
                return;
            }

            if (UserAnswer.Text.Trim().ToLower() == this.answers[this.currentQuestionIndex].ToLower())
            {
                QuizHistory.AppendText("That is the Correct Answer. Well done!");
                this.totalScore++;
            }
            else
            {
                QuizHistory.AppendText($"Unlucky there, that was not the correct answer. The answer is {this.answers[this.currentQuestionIndex].ToLower()}." +
                    $"\n{this.explanations[this.currentQuestionIndex]}");
            }

            UserAnswer.Clear();
            this.NextQuestion();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))
            {
                e.Handled = true;
                SubmitAnswerButton_Click(null, null);
            }
        }

        public void BackToChatbotButton_Click(object sender, RoutedEventArgs e)
        {
            //this.chatbot.activityLog.Add($"Quiz Ended or Completed: {10 - this.remainingQuestionsIndex.Count} questions answered. {this.totalScore} out " +
            //$"of {10 - this.remainingQuestionsIndex.Count}");
            this.Close();
            mainWindow.Show();
            mainWindow.UserInput.Focus();
        }

        private void NextQuestion()
        {
            if (this.remainingQuestionsIndex.Count == 0)
            {
                QuizHistory.AppendText($"\n\nWell done! You achieved a score of {this.totalScore} out of 10.");
                if (this.totalScore <= 3)
                {
                    QuizHistory.AppendText("\nYou need to keep learning to stay safe online, technology can be dangerous if in the wrong hands.");
                }
                else if (this.totalScore >= 4 && this.totalScore <= 7)
                {
                    QuizHistory.AppendText("\nThat is not a bad score but you should still do some learning about cybersecurity tips and how to stay safe online");
                }
                else
                {
                    QuizHistory.AppendText("\nWell done on your score. You clearly know your Cybersecurity stuff. Keep it up!");
                }
                QuizHistory.ScrollToEnd();
                AnswerButton.IsEnabled = false;
                return;
            }

            Random random = new Random();
            int randomIndex = random.Next(this.remainingQuestionsIndex.Count);
            this.currentQuestionIndex = this.remainingQuestionsIndex[randomIndex];
            this.remainingQuestionsIndex.RemoveAt(randomIndex);
            QuizHistory.AppendText($"\n\nQuestion: {this.questions[this.currentQuestionIndex]}\n");
            UserAnswer.Clear();
            UserAnswer.Focus();
            QuizHistory.ScrollToEnd();
        }
    }
}
