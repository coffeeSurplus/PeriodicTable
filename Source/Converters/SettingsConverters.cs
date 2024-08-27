using PeriodicTable.Source.Enums;
using System.Globalization;
using System.Windows.Data;

namespace PeriodicTable.Source.Converters;

internal class SettingsBlockConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value ?? 1;
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (Block)(int)(double)value;
}

internal class SettingsBlockTextConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (Block?)value switch { Block.SBlock => "s block", Block.PBlock => "p block", Block.DBlock => "d block", Block.FBlock => "f block", _ => "block" };
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class SettingsCategoryConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value ?? 1;
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (Category)(int)(double)value;
}

internal class SettingsCategoryTextConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (Category?)value switch { Category.AlkaliMetal => "alkali metal", Category.AlkalineEarthMetal => "alkaline earth metal", Category.TransitionMetal => "transition metal", Category.PostTransitionMetal => "post-transition metal", Category.Metalloid => "metalloid", Category.NonMetal => "non-metal", Category.Halogen => "halogen", Category.NobleGas => "noble gas", Category.Lanthanide => "lanthanide", Category.Actinide => "actinide", _ => "category" };
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class SettingsGroupConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value ?? 1;
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (Group)(int)(double)value;
}

internal class SettingsGroupTextConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is not null ? (int)value switch { <= 18 => $"group {(int)value}", 19 => "lanthanide", _ => "actinide" } : "group";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class SettingsPeriodConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value ?? 1;
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (Period)(int)(double)value;
}

internal class SettingsPeriodTextConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"period{(value is not null ? $" {(int)value}" : string.Empty)}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}
internal class SettingsTemperatureConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value ?? -273;
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
}

internal class SettingsTemperatureTextConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is not null ? $"{value} °C • {(int)value + 273} K" : "temperature";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}