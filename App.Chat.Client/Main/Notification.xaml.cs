using App.Chat.Models;
using System;
using System.Windows;
using System.Windows.Threading;

namespace App.Chat.Client
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public Notification(double left, double top, string title, string content)
        {
            InitializeComponent();
            Left = left;
            Top = top;

            NotifyTitle.Text = title;
            NotifyContent.Text = content;
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            Close();
    }
}
