using System.Collections.Generic;
using System.Windows.Controls;


namespace MikuChat.WPF;

/// <summary>
/// ChatPage.xaml 的交互逻辑
/// </summary>
public partial class ChatPage : Page
{
    #region Public Constructors

    public ChatPage()
    {
        InitializeComponent();
        DataContext = this;
    }

    #endregion Public Constructors

    #region Public Properties

    public List<Contact> Contacts { get; } = new()
    {
       new("https://static.wikia.nocookie.net/projectsekai/images/7/7b/Miku_Avatar_Costume.png/revision/latest?cb=20220425182751","Hatsune Miku","Hello!"),
       new("https://static.wikia.nocookie.net/projectsekai/images/7/7b/Miku_Avatar_Costume.png/revision/latest?cb=20220425182751","Kagane Rin","Hello!"),
       new("https://static.wikia.nocookie.net/projectsekai/images/7/7b/Miku_Avatar_Costume.png/revision/latest?cb=20220425182751","Kagane Len","Hello!"),
       new("https://static.wikia.nocookie.net/projectsekai/images/7/7b/Miku_Avatar_Costume.png/revision/latest?cb=20220425182751","Megurine Luka","Hello!"),
       new("https://static.wikia.nocookie.net/projectsekai/images/7/7b/Miku_Avatar_Costume.png/revision/latest?cb=20220425182751","MEIKO","Hello"),
    };

    #endregion Public Properties
}
