using App.Chat.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace App.Chat.Client
{
    /// <summary>
    /// Interaction logic for ChatConfig.xaml
    /// </summary>
    public partial class ChatConfig : UserControl
    {
        private string username = string.Empty;
        private string name = string.Empty;

        private ChatViewModel context;

        public ChatConfig(ChatViewModel context)
        {
            InitializeComponent();

            DataContext = this.context = context;

            username = this.context.CurrentUser.Username;
            name = this.context.CurrentUser.Name;
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            

            
        }

        private void btnChatBg_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnUserPic_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            context.CurrentUser.Username = username;
            context.CurrentUser.Name = name;

            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e) =>
            DialogHost.CloseDialogCommand.Execute(null, null);
    }
}
