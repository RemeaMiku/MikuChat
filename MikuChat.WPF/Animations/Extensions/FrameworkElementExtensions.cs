using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace MikuChat.WPF;

internal static class FrameworkElementExtensions
{
    #region Public Methods

    public static async Task DisplaySlideFadeAsync(this FrameworkElement element, double offset, FlowDirection flowDirection, FadeMode fadeMode, Duration duration)
    {
        var storyboard = new Storyboard();
        storyboard.AddSlideFadeAnimation(element.Margin, offset, flowDirection, fadeMode, duration).Begin(element);
        await Task.Delay(duration.TimeSpan);
    }

    #endregion Public Methods
}