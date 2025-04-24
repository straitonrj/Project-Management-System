using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;

public class MainWindow : Window
{
    public MainWindow()
    {
        Width = 900;
        Height = 600;
        Title = "Project Management System";

        var grid = new Grid
        {
            Padding = new Thickness(20),
            ColumnDefinitions = new ColumnDefinitions("2*, 3*")
        };

        // LEFT PANEL
        var leftPanel = new StackPanel
        {
            Spacing = 20
        };
        Grid.SetColumn(leftPanel, 0);

        leftPanel.Children.Add(new TextBlock
        {
            Text = "Welcome, <User>!",
            FontSize = 24,
            FontWeight = FontWeight.Bold
        });

        leftPanel.Children.Add(new TextBlock
        {
            Text = "Continue:",
            FontSize = 16,
            Margin = new Thickness(0, 20, 0, 0)
        });

        var lastProject = new Border
        {
            Background = new SolidColorBrush(Color.Parse("#EEE")),
            Padding = new Thickness(10),
            CornerRadius = new CornerRadius(8),
            Child = new StackPanel
            {
                Children =
                {
                    new TextBlock { Text = "Title: Project A", FontWeight = FontWeight.Bold },
                    new TextBlock { Text = "Description: Last opened project", FontStyle = FontStyle.Italic }
                }
            }
        };

        leftPanel.Children.Add(lastProject);

        // RIGHT PANEL
        var rightPanel = new StackPanel
        {
            Spacing = 10
        };
        Grid.SetColumn(rightPanel, 1);

        rightPanel.Children.Add(new TextBlock
        {
            Text = "Projects",
            FontSize = 20,
            FontWeight = FontWeight.Bold
        });

        var itemsControl = new ItemsControl
        {
            ItemTemplate = new FuncDataTemplate<object>((item, _) =>
                new Border
                {
                    BorderBrush = new SolidColorBrush(Color.Parse("#CCC")),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(4),
                    Padding = new Thickness(8),
                    Margin = new Thickness(0, 5, 0, 5),
                    Child = new StackPanel
                    {
                        Children =
                        {
                            new TextBlock { Text = "Project Title", FontWeight = FontWeight.Bold },
                            new TextBlock { Text = "Description of the project", FontStyle = FontStyle.Italic }
                        }
                    }
                }, true)
        };

        var scrollViewer = new ScrollViewer
        {
            Height = 500,
            Content = itemsControl
        };

        rightPanel.Children.Add(scrollViewer);

        grid.Children.Add(leftPanel);
        grid.Children.Add(rightPanel);

        Content = grid;
    }
}
