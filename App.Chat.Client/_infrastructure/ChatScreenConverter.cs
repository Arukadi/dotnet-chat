using System;
using System.Globalization;
using System.Windows.Data;

namespace App.Chat.Client
{
    public class ChatScreenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new UnselectedUser();

            return new ChatBody();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
