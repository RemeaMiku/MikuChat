
namespace MikuChat.WPF;

public class Contact
{
    #region Public Constructors

    public Contact(string avatarUrl, string remarkName, string latestMessage)
    {
        AvatarUrl = avatarUrl;
        RemarkName = remarkName;
        LatestMessage = latestMessage;
    }

    #endregion Public Constructors

    #region Public Properties

    public string AvatarUrl { get; set; }
    public string RemarkName { get; set; }
    public string LatestMessage { get; set; }

    #endregion Public Properties
}
