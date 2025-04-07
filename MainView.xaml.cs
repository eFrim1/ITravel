using System.Windows;
using TravelAgency.model;
using TravelAgency.model.repository;
using TravelAgency.view_model;

namespace TravelAgency;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainView : Window
{   
    MainViewModel vm;
    public MainView()
    {
        InitializeComponent();
        vm = new MainViewModel();
        this.DataContext = vm;
    }
}