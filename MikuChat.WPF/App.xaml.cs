namespace MikuChat.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public new static App Current => (App)Application.Current;
    public IServiceProvider ServiceProvider { get; }
    private static IServiceProvider ConfigureServices()
    {
        var serviceColletion = new ServiceCollection()
            .AddSingleton<LoginPageViewModel>()
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<LoginPage>()
            .AddSingleton<ChatPage>()
            .AddSingleton<MainWindow>();
        return serviceColletion.BuildServiceProvider();
    }
    public App()
    {
        ServiceProvider = ConfigureServices();
        InitializeComponent();
    }
    protected override void OnStartup(StartupEventArgs e)
        => ServiceProvider.GetRequiredService<MainWindow>().Show();
}
