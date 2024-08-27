using PeriodicTable.Source.Enums;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PeriodicTable.Source.Converters;

internal class PeriodicTableAtomicMassConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (double)value % 1 is not 0 ? $"{value:n3}" : $"[{value}]";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class PeriodicTableBackgroundConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => Application.Current.FindResource($"Colour{(((bool?)values[0]) != null ? (bool)values[0] ? (int)(Category?)values[6] : ((int)(Block?)values[9] * 2 - 1) : values[1] != null ? ((int?)values[1]) < ((double?)values[7]) ? values[7] != null ? 1 : 0 : values[8] != null ? ((int?)values[1]) < ((double?)values[8]) ? 3 : 5 : 0 : values[2] != null ? ((Category?)values[2]) == ((Category?)values[6]) ? (int)(Category?)values[6] : 0 : values[3] != null ? ((Block?)values[3]) == ((Block?)values[9]) ? (int)(Block?)values[9] * 2 - 1 : 0 : values[4] != null ? ((Group?)values[4]) == ((Group?)values[10]) ? 1 : 0 : (((Period?)values[5]) == ((Period?)values[11]) ? 1 : 0))}");
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [Binding.DoNothing, Binding.DoNothing, Binding.DoNothing, Binding.DoNothing, Binding.DoNothing, Binding.DoNothing, Binding.DoNothing, Binding.DoNothing, Binding.DoNothing, Binding.DoNothing];
}

internal class PeriodicTableBlockKeyVisibilityConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => (bool?)values[0] is false || values[1] is not null ? Visibility.Visible : Visibility.Collapsed;
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [Binding.DoNothing, Binding.DoNothing];
}

internal class PeriodicTableCategoryKeyVisibilityConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => (bool?)values[0] is true || values[1] is not null ? Visibility.Visible : Visibility.Collapsed;
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [Binding.DoNothing, Binding.DoNothing];
}

internal class PeriodicTableColumnConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => (Category)values[0] is not Category.Lanthanide and not Category.Actinide ? (int)(Group)values[1] : (int)values[2] switch { 57 or 89 or 58 or 90 => 3, 59 or 91 => 4, 60 or 92 => 5, 61 or 93 => 6, 62 or 94 => 7, 63 or 95 => 8, 64 or 96 => 9, 65 or 97 => 10, 66 or 98 => 11, 67 or 99 => 12, 68 or 100 => 13, 69 or 101 => 14, 70 or 102 => 15, _ => 16 };
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [Binding.DoNothing, Binding.DoNothing, Binding.DoNothing];
}

internal class PeriodicTableRowConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => (Category)values[0] is not Category.Lanthanide and not Category.Actinide ? (int)(Period)values[1] : values[2] is not 57 and not 89 ? (int)(Category)values[0] : values[2] is not 57 ? 7 : 6;
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [Binding.DoNothing, Binding.DoNothing, Binding.DoNothing];
}

internal class PeriodicTableStateKeyVisibilityConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is not null ? Visibility.Visible : Visibility.Collapsed;
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}