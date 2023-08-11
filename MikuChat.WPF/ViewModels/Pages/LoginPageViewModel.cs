using System.Security;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MikuChat.WPF;

public partial class LoginPageViewModel : ObservableObject
{
    #region Private Fields

    [ObservableProperty]
    string _username = "在此输入昵称或邮箱...";

    [ObservableProperty]
    SecureString? _password;

    #endregion Private Fields

    #region Private Methods

    [RelayCommand]
    async Task Login()
    {
        if (string.IsNullOrEmpty(Username))
        {
            MessageBox.Show("账户名不能为空", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (Password is null || Password.Length == 0)
        {
            MessageBox.Show("密码不能为空", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        await Task.Delay(5000);
    }

    #endregion Private Methods
}
