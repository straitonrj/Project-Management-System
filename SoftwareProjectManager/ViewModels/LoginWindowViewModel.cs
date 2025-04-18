using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using System.Xml;
using Avalonia;
using ReactiveUI;
using SoftwareProjectManager.Views;
using src.Models;

namespace SoftwareProjectManager.ViewModels;

public class LoginWindowViewModel : ViewModelBase
{
    public ObservableCollection<Employee?> Users { get; } = new();
    private string? username = "pcox";
    private string? pword = "password";
    public string? _inputUsername;
    public string? _inputPassword;

    
    public Interaction<LoginWindowViewModel, MainWindowViewModel> CloseWindowInteraction { get; } = new();

    public ReactiveCommand<Unit, Unit> CloseCommand { get; set; }

    public string? InputUsername
    {
        get => _inputUsername;
        set => this.RaiseAndSetIfChanged(ref _inputUsername, value);

    }

    public string? InputPassword
    {
        get => _inputPassword;
        set => this.RaiseAndSetIfChanged(ref _inputPassword, value);

    }
    public ICommand VerifyLogin { get; }
    
    

    public LoginWindowViewModel()
    {
        VerifyLogin = ReactiveCommand.Create(() =>
        {
            if (_inputUsername == username && _inputPassword == pword)
            {
                Console.WriteLine("Login successful");
                var window = new MainWindow();
                window.Show();
            }
            
            CloseCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await CloseWindowInteraction.Handle(new LoginWindowViewModel());
            });
        });

    }
}