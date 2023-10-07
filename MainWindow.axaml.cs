using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ZapApp1;

public partial class MainWindow : Window
{
    SecondWindow window2 = new SecondWindow();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Btn1_Click(object? sender, RoutedEventArgs e)
    {
        this.Close();
        window2.Show();
    }
}