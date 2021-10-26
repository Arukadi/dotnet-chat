using App.Chat.Models;
using App.Chat.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;

namespace App.Chat.Client
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ChatViewModel context;

        public Login(ChatViewModel context)
        {
            InitializeComponent();
            DataContext = this.context = context;
        }

        private async void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || 
                string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Porfavor, preencha todos os campos!", "Aviso", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var user = new User
            {
                Name = txtName.Text,
                Username = txtUsername.Text,
                Key = Guid.NewGuid(),
                ConnectionOn = DateTime.Now
            };

            bool result = await context.LoadUser(user);
            if (result)
                Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) =>
            Application.Current.Shutdown();

        private void ToggleButton_Checked(object sender, RoutedEventArgs e) =>
            ChatApp.SetTheme(Theme.Dark);

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e) =>
            ChatApp.SetTheme(Theme.Light);
    }
}
