using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using System.Xml;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using SoftwareProjectManager.Views;
namespace SoftwareProjectManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand LogOut { get; }

    public MainWindowViewModel()
    {
        LogOut = ReactiveCommand.Create(() =>
        {
            /*
            Console.WriteLine("LogOut successful");
            var window = new LoginWindow();
            window.Show();
                
            var mainWindow = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
            if (mainWindow != null)
            {
                Console.WriteLine(mainWindow.Title);
                mainWindow.Close();
            }
            */
            
            var mainWindow = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
            if (mainWindow != null)
            {
                Console.WriteLine(mainWindow.Title);
                mainWindow.Hide();
            }

                
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new LoginWindow()
                {
                    DataContext = new LoginWindowViewModel()
                };
                    
                desktop.MainWindow.Show();
            }
        });
    }
}