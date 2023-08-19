using System.Windows.Controls;

namespace MikuChat.WPF;

public partial class MainWindowViewModel : ObservableObject
{
    #region Public Fields

    public const int OuterMarginSizeCommon = 10;

    public const int WindowRadiusCommon = 5;

    #endregion Public Fields

    #region Public Properties

    public GridLength CaptionHeightGridLength => new(CaptionHeight + ResizeBorder);

    public Thickness ResizeBorderThickness => new(ResizeBorder + OuterMarginSize);

    public Thickness OuterMarginSizeThickness => new(OuterMarginSize);

    public CornerRadius WindowCornerRadius => new(WindowRadius);

    public Thickness InnerContentPadding => new(ResizeBorder);

    #endregion Public Properties

    #region Private Fields
    [ObservableProperty]
    public string _maximizeButtonContent = "\uE922";
    [ObservableProperty]
    Page _currentPage = App.Current.ServiceProvider.GetRequiredService<ChatPage>();
    [ObservableProperty]
    int _resizeBorder = 0;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ResizeBorderThickness))]
    [NotifyPropertyChangedFor(nameof(OuterMarginSizeThickness))]
    int _outerMarginSize = OuterMarginSizeCommon;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(WindowCornerRadius))]
    int _windowRadius = WindowRadiusCommon;
    [ObservableProperty]
    int _captionHeight = 39;
    [ObservableProperty]
    double _windowMinWidth = 400;
    [ObservableProperty]
    double _windowMaxHeight = 400;

    #endregion Private Fields
}
