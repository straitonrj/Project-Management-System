using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SoftwareProjectManager.ViewModels;

namespace SoftwareProjectManager.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        
        var vm = new LoginWindowViewModel();
        DataContext = vm;
        
    }
}