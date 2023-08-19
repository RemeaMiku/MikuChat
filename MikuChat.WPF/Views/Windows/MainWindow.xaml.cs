using System.Windows.Controls;
using System.Windows.Input;
using AngleSix;

namespace MikuChat.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    #region Public Constructors

    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        StateChanged += OnWindowStateChanged;
        DataContext = this;
        ViewModel = viewModel;
        _ = new WindowResizeHelper(this);
    }

    #endregion Public Constructors

    #region Public Properties

    public MainWindowViewModel ViewModel { get; }

    #endregion Public Properties

    #region Public Methods

    public static Point GetMouseScreenPosition(Window window)
    {
        var result = Mouse.GetPosition(window);
        result.X += window.Left;
        result.Y += window.Top;
        return result;
    }

    #endregion Public Methods

    #region Private Methods

    private void OnWindowStateChanged(object? sender, EventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            ViewModel.OuterMarginSize = 0;
            ViewModel.WindowRadius = 0;
        }
        else
        {
            ViewModel.OuterMarginSize = MainWindowViewModel.OuterMarginSizeCommon;
            ViewModel.WindowRadius = MainWindowViewModel.WindowRadiusCommon;
        }
    }
    private void OnMinimizeButtonClicked(object sender, RoutedEventArgs e)
        => WindowState = WindowState.Minimized;



    private void OnMaximizeButtonClicked(object sender, RoutedEventArgs e)
    {
        const string chromeMaximizeGlyph = "\uE922";
        const string chromeRestoreGlyph = "\uE923";
        var button = sender as Button;
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
            button!.Content = chromeMaximizeGlyph;
        }
        else
        {
            WindowState = WindowState.Maximized;
            button!.Content = chromeRestoreGlyph;
        }
    }
    private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        => Close();
    private void OnIconButtonClicked(object sender, RoutedEventArgs e)
        => SystemCommands.ShowSystemMenu(this, GetMouseScreenPosition(this));

    #endregion Private Methods
}
