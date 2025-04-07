namespace TravelAgency.view_model;

public class MainViewModel
{
    public object Package { get; }
    public object Client { get; }
    public object BoughtPackage { get; }

    public MainViewModel()
    {
        Package = new view.PackageTab { DataContext = new PackageViewModel() };
        Client = new view.ClientTab { DataContext = new ClientViewModel() };
        BoughtPackage = new view.BoughtPackageTab { DataContext = new BoughtPackageViewModel() };
    }
}
