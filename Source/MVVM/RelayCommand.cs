using System.Windows.Input;

namespace PeriodicTable.Source.MVVM;

internal class RelayCommand(Action execute) : ICommand
{
	private readonly Action execute = execute;
	private readonly Func<bool> canExecute = () => true;

	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public RelayCommand(Action execute, Func<bool> canExecute) : this(execute) => this.canExecute = canExecute;

	public void Execute(object? parameter) => execute.Invoke();
	public bool CanExecute(object? parameter) => canExecute.Invoke();
}

internal class RelayCommand<T>(Action<T> execute) : ICommand
{
	private readonly Action<T> execute = execute;
	private readonly Func<T, bool> canExecute = (T parameter) => true;

	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public RelayCommand(Action<T> execute, Func<T, bool> canExecute) : this(execute) => this.canExecute = canExecute;

	public void Execute(T parameter) => execute.Invoke(parameter);
	public bool CanExecute(T parameter) => canExecute.Invoke(parameter);
	public void Execute(object? parameter) => execute.Invoke((T)parameter!);
	public bool CanExecute(object? parameter) => canExecute.Invoke((T)parameter!);
}