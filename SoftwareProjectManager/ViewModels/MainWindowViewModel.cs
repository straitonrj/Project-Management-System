using SoftwareProjectManager.Views;

namespace SoftwareProjectManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private void OpenLogin()
    {
        var window = new LoginWindow();
        window.Show();
        
        
    }
}