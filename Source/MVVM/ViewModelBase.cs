using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PeriodicTable.Source.MVVM;

internal class ViewModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void SetValue<T>(ref T field, T value, [CallerMemberName] string? name = null)
	{
		field = value;
		PropertyChanged?.Invoke(this, new(name));
	}
}