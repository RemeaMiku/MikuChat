using System.Windows.Media.Animation;

namespace MikuChat.WPF;

internal static class StoryboardExtensions
{
    #region Public Methods

    public static Storyboard AddSlideFadeAnimation(this Storyboard storyboard, Thickness oldMargin, double offset, FlowDirection flowDirection, FadeMode fadeMode, Duration duration)
    {
        var slideAnimation = fadeMode == FadeMode.FadeIn ? FadeSlideAnimation.GetFadeInSlideAnimation(oldMargin, offset, flowDirection, duration) : FadeSlideAnimation.GetFadeOutSlideAnimation(oldMargin, offset, flowDirection, duration);
        var fadeAnimation = FadeSlideAnimation.GetFadeAnimation(fadeMode, duration);
        Storyboard.SetTargetProperty(slideAnimation, new("Margin"));
        Storyboard.SetTargetProperty(fadeAnimation, new("Opacity"));
        storyboard.Children.Add(slideAnimation);
        storyboard.Children.Add(fadeAnimation);
        return storyboard;
    }

    #endregion Public Methods
}