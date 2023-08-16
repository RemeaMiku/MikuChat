using System.Globalization;
using System.Windows.Data;

namespace MikuChat.WPF;

class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolean)
            if (boolean)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
            if (visibility == Visibility.Visible)
                return true;
            else
                return false;
        throw new NotImplementedException();
    }
}
