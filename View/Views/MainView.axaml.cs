using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace View.Views;

public partial class MainView : UserControl
{
    public static readonly StyledProperty<bool> IsPaneOpenProperty =
        AvaloniaProperty.Register<MainView, bool>(nameof(IsPaneOpen), defaultValue: false);

    public bool IsPaneOpen
    {
        get => GetValue(IsPaneOpenProperty);
        set => SetValue(IsPaneOpenProperty, value);
    }

    public MainView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs args) => IsPaneOpen = !IsPaneOpen;
}
