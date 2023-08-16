using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MikuChat.WPF;

class StringToBrushConverter : IValueConverter
{
    readonly BrushConverter _brushConverter = new();
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string hex)
            return (SolidColorBrush?)_brushConverter.ConvertFrom(hex) ?? throw new NotImplementedException();
        throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush brush)
        {
            return (string?)_brushConverter.ConvertTo(brush, typeof(string)) ?? throw new NotImplementedException();
        }
        throw new NotImplementedException();
    }
}

