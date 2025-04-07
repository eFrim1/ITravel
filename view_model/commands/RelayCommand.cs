namespace TravelAgency.view_model.commands;
using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
    public void Execute(object parameter) => _execute(parameter);

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
//make a summary of the class and put attributes it they are public with + and private with - eg -Action _execute
//  -Action _execute;
//  -Predicate _canExecute;
// +bool CanExecute(object parameter);
// +void Execute(object parameter);
// +event EventHandler CanExecuteChanged;
