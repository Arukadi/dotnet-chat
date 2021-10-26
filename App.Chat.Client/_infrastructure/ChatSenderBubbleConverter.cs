using App.Chat.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace App.Chat.Client
{
    public class ChatReciverBubbleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = value as User;

            if (user.Equals(ChatApp.CurrentUser))
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }

    public class ChatSenderBubbleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = value as User;

            if (user.Equals(ChatApp.CurrentUser))
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
