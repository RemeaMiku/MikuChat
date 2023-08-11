using System.Windows;
using System.Windows.Media.Animation;

namespace MikuChat.WPF;

internal static class StoryboardExtensions
{
    #region Public Methods

    public static Storyboard AddSlideFadeAnimation(this Storyboard storyboard, Thickness oldMargin, double offset, FlowDirection flowDirection, FadeMode fadeMode, Duration duration)
    {
        var slideAnimation = fadeMode == FadeMode.FadeIn ? Animations.GetFadeInSlideAnimation(oldMargin, offset, flowDirection, duration) : Animations.GetFadeOutSlideAnimation(oldMargin, offset, flowDirection, duration);
        var fadeAnimation = Animations.GetFadeAnimation(fadeMode, duration);
        Storyboard.SetTargetProperty(slideAnimation, new("Margin"));
        Storyboard.SetTargetProperty(fadeAnimation, new("Opacity"));
        storyboard.Children.Add(slideAnimation);
        storyboard.Children.Add(fadeAnimation);
        return storyboard;
    }

    #endregion Public Methods
}