using System.Windows.Controls;

namespace MikuChat.WPF;

/// <summary>
/// LoginPage.xaml 的交互逻辑
/// </summary>
public partial class LoginPage : Page
{
    #region Public Constructors

    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        Loaded += OnPageLoaded;
        ViewModel = viewModel;
        DataContext = this;
    }

    #endregion Public Constructors

    #region Public Properties

    public LoginPageViewModel ViewModel { get; }

    #endregion Public Properties

    #region Private Methods

    private async void OnPageLoaded(object sender, RoutedEventArgs e)
    {
        await LoginPanel.DisplaySlideFadeAsync(39, FlowDirection.RightToLeft, FadeMode.FadeIn, new(TimeSpan.FromSeconds(0.39)));
    }

    private async void OnLoginButtonClicked(object sender, RoutedEventArgs e)
    {
        await LoginPanel.DisplaySlideFadeAsync(39, FlowDirection.RightToLeft, FadeMode.FadeOut, new(TimeSpan.FromSeconds(0.39)));
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    => ViewModel.Password = ((PasswordBox)sender).SecurePassword;

    #endregion Private Methods

    private async void OnNavigateToRegisterButtonClicked(object sender, RoutedEventArgs e)
    {
        await LoginPanel.DisplaySlideFadeAsync(39, FlowDirection.RightToLeft, FadeMode.FadeOut, new(TimeSpan.FromSeconds(0.39)));
        LoginPanel.Visibility = Visibility.Hidden;
        RegisterPanel.Visibility = Visibility.Visible;
        await RegisterPanel.DisplaySlideFadeAsync(39, FlowDirection.RightToLeft, FadeMode.FadeIn, new(TimeSpan.FromSeconds(0.39)));
    }
}