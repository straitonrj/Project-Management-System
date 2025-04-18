using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using src.ViewModels;

namespace src.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    
}