using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MikuChat.WPF;

partial class TextBoxAttachedProperties
{
    #region Public Fields

    // Using a DependencyProperty as the backing store for PlaceholderForeground.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PlaceholderForegroundProperty =
        DependencyProperty.RegisterAttached("PlaceholderForeground", typeof(Brush), typeof(TextBoxAttachedProperties), new PropertyMetadata(SystemColors.GrayTextBrush, OnPlaceholderForegroundChanged));

    #endregion Public Fields

    #region Public Methods

    public static Brush GetPlaceholderForeground(DependencyObject obj)
    {
        return (Brush)obj.GetValue(PlaceholderForegroundProperty);
    }

    public static void SetPlaceholderForeground(DependencyObject obj, Brush value)
    {
        if (value == GetPlaceholderForeground(obj))
            return;
        obj.SetValue(PlaceholderForegroundProperty, value);
    }

    #endregion Public Methods

    #region Private Methods

    private static void OnPlaceholderForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is TextBox textBox && textBox.Tag is (string label, Brush) && label == "Placeholder")
            textBox.Foreground = e.NewValue as Brush;
    }

    #endregion Private Methods
}
