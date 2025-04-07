using System.IO;
using NPOI.XWPF.UserModel;

namespace TravelAgency.view_model;

using model;
using model.repository;
using commands;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class ClientViewModel : INotifyPropertyChanged
{   
    private ClientRepository _repository;
    private Client _selectedClient;
    public ObservableCollection<Client> Clients { get; set; }

    public Client SelectedClient
    {
        get => _selectedClient;
        set
        {
            _selectedClient = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddClientCommand { get; set; }
    public ICommand UpdateClientCommand { get; set; }
    public ICommand DeleteClientCommand { get; set; }
    public ICommand ExportToCsvCommand { get; set; }
    public ICommand ExportToWordCommand { get; set; }

    public ClientViewModel()
    {
        _selectedClient = new Client();
        _repository = new ClientRepository(new AppDbContext());
        Clients = new ObservableCollection<Client>();

        AddClientCommand = new RelayCommand(AddClient, CanModifyClient);
        UpdateClientCommand = new RelayCommand(UpdateClient, CanModifyClient);
        DeleteClientCommand = new RelayCommand(DeleteClient, CanModifyClient);
        ExportToCsvCommand = new RelayCommand(ExportToCsv, CanModifyClient);
        ExportToWordCommand = new RelayCommand(ExportToWord, CanModifyClient);

        LoadClients();
    }

    private void LoadClients()
    {
        try
        {
            var clients = _repository.GetAllAsync().Result;
            Clients.Clear();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }
        finally { }
    }

    private void AddClient(object obj)
    {
        try
        {
            var newClient = new Client(_selectedClient.Name, _selectedClient.Email, _selectedClient.Phone);
            _repository.AddAsync(newClient).Wait();
            LoadClients();
        }
        finally { }
    }

    private void UpdateClient(object obj)
    {
        try
        {
            _repository.UpdateAsync(_selectedClient).Wait();
            LoadClients();
        }
        finally { }
    }

    private void DeleteClient(object obj)
    {
        try
        {
            _repository.DeleteAsync(_selectedClient).Wait();
            LoadClients();
        }
        finally { }
    }
    
    private void ExportToCsv(object obj)
    {
        var clients = _repository.GetAllAsync().Result;
        Utility.ExportToCsv<Client>("Clients", clients);
    }
    
    private void ExportToWord(object obj)
    {
        var clients = _repository.GetAllAsync().Result;
        Utility.ExportToDoc("Clients", clients);
    }

    private bool CanModifyClient(object obj) => SelectedClient != null;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}



