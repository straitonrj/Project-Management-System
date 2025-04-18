using System.Collections.ObjectModel;

namespace SoftwareProjectManager.ViewModels;

public class WelcomeViewModel : ViewModelBase
{
    private string? _userName;
    public ObservableCollection<string>? Projects { get; } = new();

    public WelcomeViewModel()
    {
        //Projects.Add();
    }
}