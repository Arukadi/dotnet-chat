﻿using App.Chat.ViewModels;
using System;
using System.Collections.Generic;
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

namespace App.Chat.Client
{
    /// <summary>
    /// Interaction logic for ChatBottomBar.xaml
    /// </summary>
    public partial class ChatBottomBar : UserControl
    {
        public ChatBottomBar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((ChatViewModel)DataContext).SendMessage(txtMessage.Text);
            txtMessage.Text = string.Empty;
        }
    }
}
