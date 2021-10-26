using App.Chat.ViewModels;
using System;
using System.Windows;
using System.Windows.Threading;

namespace App.Chat.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatViewModel context;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = context = new ChatViewModel();
            new Login(context).ShowDialog();
            context.ChatConfig = new ChatConfig(context);
        }

        private void LoadNotification() =>
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var workingArea = SystemParameters.WorkArea;
                var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice;
                var corner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));

                context.NotifyLeft = corner.X - 400;
                context.NotifyTop = corner.Y - 150;
            }));

        private void btnSend_Click(object sender, RoutedEventArgs e) =>
            context.SendMessage("In maintenence!");
    }
}
