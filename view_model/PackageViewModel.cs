using TravelAgency.model;
using TravelAgency.model.repository;
using TravelAgency.view_model.commands;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using NPOI.XWPF.UserModel;

namespace TravelAgency.view_model;
public class PackageViewModel : INotifyPropertyChanged
{
    private PackageRepository _repository;
    private Package _selectedPackage;
    private List<Package> _allPackages;

    public ObservableCollection<Package> Packages { get; set; }

    private string _selectedFilterBy;
    public string SelectedFilterBy
    {
        get => _selectedFilterBy;
        set { _selectedFilterBy = value; OnPropertyChanged(); }
    }

    private string _filterValue;
    public string FilterValue
    {
        get => _filterValue;
        set { _filterValue = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string> FilterByOptions { get; } = new ObservableCollection<string>
    {
        "Destination",
        "Price",
        "Period"
    };

    private string _selectedSortBy;
    public string SelectedSortBy
    {
        get => _selectedSortBy;
        set { _selectedSortBy = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string> SortByOptions { get; } = new ObservableCollection<string>
    {
        "Destination",
        "Price",
        "Period"
    };

    public Package SelectedPackage
    {
        get => _selectedPackage;
        set { _selectedPackage = value; OnPropertyChanged(); }
    }

    public ICommand AddPackageCommand { get; }
    public ICommand UpdatePackageCommand { get; }
    public ICommand DeletePackageCommand { get; }
    public ICommand ExportToCsvCommand { get; }
    public ICommand ExportToWordCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand SortCommand { get; }

    public PackageViewModel()
    {
        _selectedPackage = new Package();
        _repository = new PackageRepository(new AppDbContext());
        _allPackages = new List<Package>();
        Packages = new ObservableCollection<Package>();

        AddPackageCommand = new RelayCommand(AddPackage);
        UpdatePackageCommand = new RelayCommand(UpdatePackage, CanModifyPackage);
        DeletePackageCommand = new RelayCommand(DeletePackage, CanModifyPackage);
        ExportToCsvCommand = new RelayCommand(ExportToCsv);
        ExportToWordCommand = new RelayCommand(ExportToWord);
        FilterCommand = new RelayCommand(ApplyFilter);
        SortCommand = new RelayCommand(ApplySort);

        LoadPackages();
    }

    private void LoadPackages(object obj = null)
    {
        try
        {
            _allPackages = _repository.GetAllAsync().Result.ToList();
            SelectedFilterBy = null;
            FilterValue = string.Empty;
            SelectedSortBy = null;
            UpdateObservableCollection(_allPackages);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading packages: {ex.Message}");
            _allPackages.Clear();
            Packages.Clear();
        }
    }

    private void ApplyFilter(object obj)
    {
        IEnumerable<Package> filteredPackages = _allPackages;

        if (!string.IsNullOrEmpty(SelectedFilterBy) && !string.IsNullOrWhiteSpace(FilterValue))
        {
            string trimmedValue = FilterValue.Trim();

            switch (SelectedFilterBy)
            {
                case "Destination":
                    filteredPackages = _allPackages.Where(p => p.Destination != null &&
                                                               p.Destination.Contains(trimmedValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "Price":
                    filteredPackages = FilterNumeric<decimal>(filteredPackages, p => p.Price, trimmedValue);
                    break;
                case "Period":
                    filteredPackages = FilterNumeric<int>(filteredPackages, p => p.Period, trimmedValue);
                    break;
            }
        }

        if (!string.IsNullOrEmpty(SelectedSortBy))
        {
             filteredPackages = SortPackages(filteredPackages.ToList(), SelectedSortBy);
        }

        UpdateObservableCollection(filteredPackages.ToList());
    }

    private IEnumerable<Package> FilterNumeric<T>(IEnumerable<Package> source, Func<Package, T> selector, string filterInput) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        var match = Regex.Match(filterInput, @"^\s*(>=|<=|>|<|=)?\s*(.*)");
        if (!match.Success) return source;

        string op = match.Groups[1].Value;
        string valueString = match.Groups[2].Value;

        if (string.IsNullOrWhiteSpace(valueString)) return source;

        T? parsedValue = TryParseValue<T>(valueString);
        if (!parsedValue.HasValue)
        {
             Console.WriteLine($"Invalid numeric format for {typeof(T).Name}: {valueString}");
             return Enumerable.Empty<Package>();
        }

        T value = parsedValue.Value;

        switch (op)
        {
            case ">":  return source.Where(p => selector(p).CompareTo(value) > 0);
            case "<":  return source.Where(p => selector(p).CompareTo(value) < 0);
            case ">=": return source.Where(p => selector(p).CompareTo(value) >= 0);
            case "<=": return source.Where(p => selector(p).CompareTo(value) <= 0);
            default:   return source.Where(p => selector(p).Equals(value));
        }
    }

     private T? TryParseValue<T>(string valueString) where T : struct
     {
         try
         {
            return (T)Convert.ChangeType(valueString, typeof(T), CultureInfo.InvariantCulture);
         }
         catch
         {
            return null;
         }
     }

    private void ApplySort(object obj)
    {
        var packagesToSort = Packages.ToList();

        if (!string.IsNullOrEmpty(SelectedSortBy))
        {
            var sortedPackages = SortPackages(packagesToSort, SelectedSortBy);
            UpdateObservableCollection(sortedPackages);
        }
    }

    private List<Package> SortPackages(List<Package> packages, string sortBy)
    {
         switch (sortBy)
            {
                case "Destination":
                    return packages.OrderBy(p => p.Destination).ToList();
                case "Price":
                    return packages.OrderBy(p => p.Price).ToList();
                case "Period":
                    return packages.OrderBy(p => p.Period).ToList();
                default:
                    return packages;
            }
    }

    private void UpdateObservableCollection(List<Package> packagesToShow)
    {
        Packages.Clear();
        foreach (var package in packagesToShow)
        {
            Packages.Add(package);
        }
        OnPropertyChanged(nameof(Packages));
    }

    private void AddPackage(object obj)
    {
        if (_selectedPackage == null || _selectedPackage.Id == 0) return;
        try
        {
            var newPackage = new Package(_selectedPackage.Destination, _selectedPackage.Period, _selectedPackage.Price, _selectedPackage.Image1, _selectedPackage.Image2, _selectedPackage.Image3);
            _repository.AddAsync(newPackage).Wait();
            LoadPackages();
        }
        catch (Exception ex)
        {
             Console.WriteLine($"Error adding package: {ex.Message}");
        }
    }

    private void UpdatePackage(object obj)
    {
        if (_selectedPackage == null || _selectedPackage.Id == 0) return;

        try
        {
            _repository.UpdateAsync(_selectedPackage).Wait();
            LoadPackages();
        }
         catch (Exception ex)
        {
             Console.WriteLine($"Error updating package: {ex.Message}");
        }
    }

    private void DeletePackage(object obj)
    {
         if (_selectedPackage == null || _selectedPackage.Id == 0) return;

        try
        {
            var deletedId = _selectedPackage.Id;
            _repository.DeleteAsync(_selectedPackage).Wait();
            SelectedPackage = null;

            var packageToRemove = _allPackages.FirstOrDefault(p => p.Id == deletedId);
            if(packageToRemove != null) _allPackages.Remove(packageToRemove);

            ApplyFilter(null);
        }
         catch (Exception ex)
        {
             Console.WriteLine($"Error deleting package: {ex.Message}");
        }
    }

    private void ExportToCsv(object obj)
    {
        Utility.ExportToCsv<Package>("Packages_Export", Packages.ToList());
    }

    private void ExportToWord(object obj)
    {
        Utility.ExportToDoc<Package>("Packages_Export", Packages.ToList());
    }

    private bool CanModifyPackage(object obj) => SelectedPackage != null && SelectedPackage.Id != 0;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
