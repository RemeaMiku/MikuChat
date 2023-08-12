using System.Windows.Media.Animation;

namespace MikuChat.WPF;

static class FadeSlideAnimation
{
    #region Public Methods

    public static ThicknessAnimation GetFadeInSlideAnimation(Thickness oldMargin, double offset, FlowDirection flowDirection, Duration duration)
    {
        var startMargin = new Thickness(oldMargin.Left - offset, oldMargin.Top, oldMargin.Right + offset, oldMargin.Bottom);
        if (flowDirection == FlowDirection.RightToLeft)
            (startMargin.Left, startMargin.Right) = (startMargin.Right, startMargin.Left);
        var ease = new QuadraticEase
        {
            EasingMode = EasingMode.EaseInOut
        };
        var slideAnimation = new ThicknessAnimation(startMargin, oldMargin, duration)
        {
            EasingFunction = ease
        };
        return slideAnimation;
    }

    public static ThicknessAnimation GetFadeOutSlideAnimation(Thickness oldMargin, double offset, FlowDirection flowDirection, Duration duration)
    {
        var endMargin = new Thickness(oldMargin.Left + offset, oldMargin.Top, oldMargin.Right - offset, oldMargin.Bottom);
        if (flowDirection == FlowDirection.RightToLeft)
            (endMargin.Left, endMargin.Right) = (endMargin.Right, endMargin.Left);
        var ease = new QuadraticEase
        {
            EasingMode = EasingMode.EaseInOut
        };
        var slideAnimation = new ThicknessAnimation(oldMargin, endMargin, duration)
        {
            EasingFunction = ease
        };
        return slideAnimation;
    }

    public static DoubleAnimation GetFadeAnimation(FadeMode fadeMode, Duration duration)
    {
        var startOpacity = fadeMode == FadeMode.FadeIn ? 0 : 1;
        return new(startOpacity, startOpacity ^ 1, duration);
    }

    #endregion Public Methods
}

