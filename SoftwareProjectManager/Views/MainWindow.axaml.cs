using Avalonia.Controls;
using SoftwareProjectManager.ViewModels;

namespace SoftwareProjectManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var vm = new MainWindowViewModel();
        DataContext = vm;
    }
}