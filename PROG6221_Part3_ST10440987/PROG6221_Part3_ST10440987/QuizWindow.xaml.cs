﻿using System;
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
        public List<string> activityLog;
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
            this.activityLog = chatbot.activityLog;
            this.remainingQuestionsIndex = Enumerable.Range(0, this.questions.Count).ToList();
            UserAnswer.Focus();
            this.mainWindow = mainWindow;
        }

        // this method is called when the user clicks the "Start Quiz" button
        public void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentQuestionIndex == -1)
            {
                this.chatbot.activityLog.Add("Quiz: Quiz Started");
                this.NextQuestion();
            }
        }

        // this method is called when the user clicks the "Submit Answer" button
        public void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            // if the user has not started the quiz, the chatbot then informs the user to start the quiz first
            if (this.currentQuestionIndex == -1)
            {
                QuizHistory.AppendText("Click 'Start Quiz' Button to start Quiz");
                return;
            }

            // if the user answers question correctly, the chatbot informs the user that the answer is correct and increments the score and if not, then informs
            // the user of the correct answer and explanation
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

        // this method is called when the user presses the Enter key in the UserAnswer TextBox
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))
            {
                e.Handled = true;
                SubmitAnswerButton_Click(null, null);
            }
        }

        // this method is called when the user clicks the "Back to Chatbot" button
        public void BackToChatbotButton_Click(object sender, RoutedEventArgs e)
        {
            this.chatbot.activityLog.Add($"Quiz Ended or Completed: {10 - this.remainingQuestionsIndex.Count} questions answered. {this.totalScore} out " +
            $"of {10 - this.remainingQuestionsIndex.Count}");
            this.Close();
            mainWindow.Show();
            mainWindow.UserInput.Focus();
        }

        // this method is called to get the next question from the list of remaining questions
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
