using System.Windows.Controls;
using System.Windows.Media;

namespace MikuChat.WPF;

internal partial class TextBoxAttachedProperties
{
    #region Public Fields

    // Using a DependencyProperty as the backing store for PlaceholderText. This enables animation,
    // styling, binding, etc...
    public static readonly DependencyProperty PlaceholderTextProperty =
        DependencyProperty.RegisterAttached("PlaceholderText", typeof(string), typeof(TextBoxAttachedProperties), new(string.Empty, OnPlaceholderTextChanged));

    #endregion Public Fields

    #region Public Methods

    public static string GetPlaceholderText(DependencyObject obj)
    {
        return (string)obj.GetValue(PlaceholderTextProperty);
    }

    public static void SetPlaceholderText(DependencyObject obj, string value)
    {
        if (GetPlaceholderText(obj) == value)
            return;
        obj.SetValue(PlaceholderTextProperty, value);
    }

    #endregion Public Methods

    #region Private Methods

    public static void OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
        {
            textBox.Tag = ("Placeholder", textBox.Foreground);
            textBox.Foreground = GetPlaceholderForeground(textBox);
            textBox.Text = GetPlaceholderText(textBox);
        }
    }

    internal static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not TextBox textBox)
            return;
        textBox.GotFocus -= OnGotFocus;
        textBox.LostFocus -= OnLostFocus;
        if (!string.IsNullOrEmpty((string)e.NewValue))
        {
            SetPlaceholderText(textBox, (string)e.NewValue);
            textBox.GotFocus += OnGotFocus;
            textBox.LostFocus += OnLostFocus;
            if (!textBox.IsFocused)
                OnLostFocus(textBox, new());
        }
    }

    private static void OnGotFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox && textBox.Tag is (string label, Brush foreGround) && label == "Placeholder")
        {
            textBox.Clear();
            textBox.Foreground = foreGround;
            textBox.Tag = null;
        }
    }
    #endregion Private Methods
}