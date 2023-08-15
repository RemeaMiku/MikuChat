using System.Windows.Media;

namespace MikuChat.WPF;

public partial class ChatItemViewModel : ObservableObject
{
    [ObservableProperty]
    string _name = string.Empty;
    [ObservableProperty]
    string _message = string.Empty;
    [ObservableProperty]
    string _initialText = string.Empty;
    [ObservableProperty]
    Brush _background = new SolidColorBrush(new()
    {
        R = 0x39,
        G = 0xc5,
        B = 0xbb
    });
}
