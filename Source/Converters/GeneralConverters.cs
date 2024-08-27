using System.Globalization;
using System.Windows.Data;

namespace PeriodicTable.Source.Converters;

internal class GeneralNullableBoolToBool : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture) => (bool?)value ?? false;
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value;
}

internal class GeneralNullableBoolToBoolInverted : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture) => !(bool?)value ?? false;
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
}