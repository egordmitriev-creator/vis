using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace hw2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void ButtonArePressed(object? sender, RoutedEventArgs args)
    {
        var button = args.Source as Button;
        if(button != null && Rectangle != null){
            Rectangle.Fill = button.Background;
        }
    }
}