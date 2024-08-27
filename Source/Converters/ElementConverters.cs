using PeriodicTable.Source.Enums;
using System.Globalization;
using System.Windows.Data;

namespace PeriodicTable.Source.Converters;

internal class ElementAppearanceConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Appearance: {value}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementAtomicMassConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Atomic mass: {((double)value % 1 is not 0 ? $"{value:n3}" : $"[{value}]")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementAtomicNumberConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Atomic number: {value}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementAtomicRadiusConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Atomic radius: {(value is not null ? $"{value:g3} Å" : "unknown")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementBlockConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Block: {(Block)value switch { Block.SBlock => "s", Block.PBlock => "p", Block.DBlock => "d", _ => "f" }} block";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementBoilingPointConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Boiling point: {(value is not null ? $"{value:n1} °C • {(double)value + 273:n1} K" : "unknown")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementCategoryConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Category: {(Category)value switch { Category.AlkaliMetal => "alkali metal", Category.AlkalineEarthMetal => "alkaline earth metal", Category.TransitionMetal => "transition metal", Category.PostTransitionMetal => "post-transition metal", Category.Metalloid => "metalloid", Category.NonMetal => "non-metal", Category.Halogen => "halogen", Category.NobleGas => "noble gas", Category.Lanthanide => "lanthanide", _ => "actinide" }}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementDensityConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Density: {(value is not null ? $"{value:g3} g cm⁻³" : "unknown")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementDiscovererConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Discoverer: {value ?? "unknown"}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementDiscoveryYearConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Discovery year: {(value is not null ? $"{value} {((int)value is not < 0 ? "CE" : "BCE")}" : "prehistoric")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementElectronConfigurationConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Electron configuration: {value}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementElectronegativityConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Electronegativity: {(value is not null ? $"{value:n2}" : "Unknown")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementEtymologyConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Etymology: {value}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementGroupConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Group: {(int)value switch { <= 18 => (int)value, 19 => "lanthanide", _ => "actinide" }}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementIonisationEnergyConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Ionisation energy: {(value is not null ? $"{value:n3} kJ mol⁻¹" : "unknown")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementIsotopesConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Isotopes: {value}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementKeyIsotopesConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Key isotopes: {value}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementMeltingPointConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Melting point: {(value is not null ? $"{value:n1} °C • {(double)value + 273:n1} K" : "unknown")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementNameSymbolConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => $"{values[0]} ({values[1]})";
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [Binding.DoNothing, Binding.DoNothing];
}

internal class ElementOxidationStatesConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Oxidation states: {(value is not null ? (OxidationState[])value is not [] ? string.Join(", ", ((OxidationState[])value).Select(x => (int)x).OrderBy(x => x).Select(x => $"{(x is not <= 0 ? "+" : string.Empty)}{x}")) : "n/a" : "unknown")}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementPeriodConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Period: {(int)value}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementRoomTemperatureStateConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Room temperature state: {(State)value switch { State.Solid => "solid", State.Liquid => "liquid", State.Gas => "gas", _ => "unknown" }}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}

internal class ElementUsesConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"• Uses: {string.Join("\n\n", (string[])value)}";
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}