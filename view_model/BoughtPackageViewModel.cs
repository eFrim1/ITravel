using System.IO;

namespace TravelAgency.view_model;

using model;
using model.repository;
using commands;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NPOI.XWPF.UserModel;

public class BoughtPackageViewModel : INotifyPropertyChanged
{   
    private const String BASE_PATH = "..\\..\\..\\exports\\";
    private BoughtPackageRepository _repository;
    private ClientRepository _clientRepository;
    private BoughtPackage _selectedBoughtPackage;
    private String _clientName;
    public ObservableCollection<BoughtPackage> BoughtPackages { get; set; }

    public BoughtPackage SelectedBoughtPackage
    {
        get => _selectedBoughtPackage;
        set
        {
            _selectedBoughtPackage = value;
            OnPropertyChanged();
        }
    }
    
    public String ClientName
    {
        get => _clientName;
        set
        {
            _clientName = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddBoughtPackageCommand { get; set; }
    public ICommand UpdateBoughtPackageCommand { get; set; }
    public ICommand DeleteBoughtPackageCommand { get; set; }
    public ICommand SearchCommand { get; set; }
    public ICommand ExportToCsvCommand { get; set; }
    public ICommand ExportToWordCommand { get; set; }

    public BoughtPackageViewModel()
    {
        _selectedBoughtPackage = new BoughtPackage(
            0, 0, DateTime.Now, DateTime.Now, DateTime.Now);
        _repository = new BoughtPackageRepository(new AppDbContext());
        _clientRepository = new ClientRepository(new AppDbContext());
        BoughtPackages = new ObservableCollection<BoughtPackage>();

        AddBoughtPackageCommand = new RelayCommand(AddBoughtPackage, CanModifyBoughtPackage);
        UpdateBoughtPackageCommand = new RelayCommand(UpdateBoughtPackage, CanModifyBoughtPackage);
        DeleteBoughtPackageCommand = new RelayCommand(DeleteBoughtPackage, CanModifyBoughtPackage);
        SearchCommand = new RelayCommand(Search, CanModifyBoughtPackage);
        ExportToCsvCommand = new RelayCommand(ExportToCsv, CanModifyBoughtPackage);
        ExportToWordCommand = new RelayCommand(ExportToWord, CanModifyBoughtPackage);

        LoadBoughtPackages();
    }

    private void LoadBoughtPackages()
    {
        try
        {
            var boughtPackages = _repository.GetAllAsync().Result;
            BoughtPackages.Clear();
            foreach (var boughtPackage in boughtPackages)
            {
                BoughtPackages.Add(boughtPackage);
            }
        }
        catch (Exception e){}
    }

    private void AddBoughtPackage(object obj)
    {
        try
        {
            var newBoughtPackage = new BoughtPackage(_selectedBoughtPackage.ClientId, _selectedBoughtPackage.PackageId, _selectedBoughtPackage.BoughtDate, _selectedBoughtPackage.Departure, _selectedBoughtPackage.Arrival);
            _repository.AddAsync(newBoughtPackage).Wait();
            LoadBoughtPackages();
        }
        catch (Exception e){}
    }

    private void UpdateBoughtPackage(object obj)
    {
        try
        {
            _repository.UpdateAsync(_selectedBoughtPackage).Wait();
            LoadBoughtPackages();
        }
        catch (Exception e){}
    }

    private void DeleteBoughtPackage(object obj)
    {
        try
        {
            _repository.DeleteAsync(_selectedBoughtPackage).Wait();
            LoadBoughtPackages();
        }
        catch (Exception e){}
    }
    
    private void Search(object obj)
    {
        try
        {
            
            var boughtPackages = _repository.GetAllAsync().Result;
            var clients = _clientRepository.GetAllAsync().Result;
            
            BoughtPackages.Clear();
            var result = from boughtPackage in boughtPackages
                         join client in clients on boughtPackage.ClientId equals client.Id
                         where client.Name.Contains(ClientName)
                         select new BoughtPackage(boughtPackage.Id, boughtPackage.PackageId, boughtPackage.ClientId, boughtPackage.BoughtDate, boughtPackage.Departure, boughtPackage.Arrival);
            
            foreach (var boughtPackage in result)
            {
                BoughtPackages.Add(boughtPackage);
            }
            
        }
        catch (Exception e){}
    }
    
    private void ExportToCsv(object obj)
    {
        var boughtPackages = _repository.GetAllAsync().Result;
        Utility.ExportToCsv<BoughtPackage>("BoughtPackages", boughtPackages);
    }
    
    private void ExportToWord(object obj)
    {
        var boughtPackages = _repository.GetAllAsync().Result;
        Utility.ExportToDoc("BoughtPackages", boughtPackages);
    }

    private bool CanModifyBoughtPackage(object obj) => SelectedBoughtPackage != null;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

//make a summary of the class and put attributes it they are public with + and private with - eg: -BoughtPackageRepository _repository

