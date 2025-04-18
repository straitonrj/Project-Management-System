using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using src.Models;

namespace src.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    private string username;
    private string password;

    public string Username
    {
        get => username;
        set => SetProperty(ref username, value);
    }

    public string Password
    {
        get => password;
        set => SetProperty(ref password, value);
    }

    public ICommand loginCommand { get; }

    public MainWindowViewModel()
    {
      loginCommand = new RelayCommand(Login);
    }

    public void Login()
    {
        OrgUser orgUser = new OrgUser(username, password);
        string databasePassword = orgUser.GetDatabasePassword();
        if (orgUser.Login(databasePassword))
        {
         Console.WriteLine("Login Successful");
         return;
        }
        Console.WriteLine("Login Failure");
    }



}
