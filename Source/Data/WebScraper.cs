using PeriodicTable.Source.Enums;
using PeriodicTable.Source.Models;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace PeriodicTable.Source.Data;

internal static class WebScraper
{
	public static void FetchData()
	{
		List<ElementModel> data = [];
		HttpClient httpClient = new();
		for (int atomicNumber = 1; atomicNumber <= 118; atomicNumber++)
		{
			IEnumerable<string> content = httpClient.GetStringAsync($"https://www.rsc.org/periodic-table/element/{atomicNumber}/").Result.Split('\n').SkipWhile(x => x.StartsWith("<body")).TakeWhile(x => !x.StartsWith("</body>"));
			data.Add(new
			(
				content.MatchText("class=\"symbol_name\""),
				content.MatchText("class=\"symbol_font\""),
				atomicNumber,
				content.MatchText("class=\"trbox_ca tdlast_ca text_bold border_right_none\"", skip: 1).AsAtomicMass(),
				content.MatchText("class=\"trbox_ca tdfirst_ca text_bold\"").AsGroup(),
				content.MatchText("class=\"trbox_ca tlbox_even_ca text_bold\"").AsPeriod(),
				content.MatchText("class=\"trbox_ca tdfirst_ca text_bold\"").AsCategory(),
				content.MatchText("class=\"trbox_ca text_bold\"").AsBlock(),
				content.MatchText("class=\"trbox_ca text_bold\"", occurence: 1, skip: 1).AsState(),
				content.MatchText("class=\"accordian_details\"", occurence: 1),
				content.MatchText("class=\"trbox_ca tdfirst_ca text_bold border_right_none\"").AsTemperature(),
				content.MatchText("class=\"trbox_ca tlbox_even_ca text_bold border_right_none\"").AsTemperature(),
				content.MatchText("class=\"trbox_ca text_bold border_right_none\"").AsDensity(),
				content.MatchText("class=\"col_2_4 text_bold\"", skip: 1).AsDouble(),
				content.MatchText("class=\"trbox_ca tdlast_ca text_bold\"", occurence: 1),
				content.MatchText("class=\" col_2_4 text_bold border_right_none\"").AsDouble(),
				content.MatchText("class=\"atomic_inner_grid_cell text_bold\"").AsDouble(),
				content.MatchText("class=\"col1 bullet_space\"", skip: 4).AsOxidationStates(),
				string.Join(", ", content.Select((x, i) => (x, i)).Where(x => x.x.Contains("class=\"col1 col1b\"")).Select(x => content.Skip(x.i + 4).First().AsIsotope())),
				content.MatchText("class=\"trbox_ca text_bold border_right_none\"", occurence: 1).AsIsotope(),
				content.MatchText("class=\"trbox_he text_bold\""),
				content.MatchText("class=\"trbox_he  text_bold\"").AsInt(),
				content.MatchText("class=\"trbox_he tlbox_even_he text_bold\"").AsDiscoverer(),
				content.MatchText("class=\"accordian_details\"", occurence: 2).AsUses()
			));
		}
		File.WriteAllText("Data.json", JsonSerializer.Serialize(data));
	}

	private static string MatchText(this IEnumerable<string> values, string filter, int occurence = 0, int skip = 0) => occurence == 0 ? values.SkipWhile(x => !x.Contains(filter)).Skip(skip + 1).First().Trim().Replace("&nbsp;", string.Empty).Replace("<div>", string.Empty).Replace("</div>", string.Empty).Replace("SUP", "sup").Replace("<sup>0</sup>", "⁰").Replace("<sup>1</sup>", "¹").Replace("<sup>2</sup>", "²").Replace("<sup>3</sup>", "³").Replace("<sup>4</sup>", "⁴").Replace("<sup>5</sup>", "⁵").Replace("<sup>6</sup>", "⁶").Replace("<sup>7</sup>", "⁷").Replace("<sup>8</sup>", "⁸").Replace("<sup>9</sup>", "⁹") : values.SkipWhile(x => !x.Contains(filter)).Skip(1).MatchText(filter, occurence - 1, skip);
	private static int? AsInt(this string value) => value is not "Prehistoric" and not "Ancient" ? !value.SkipWhile(x => !"0123456789".Contains(x)).TakeWhile(x => x is not ' ').Contains('B') ? int.Parse(string.Concat(value.SkipWhile(x => !"0123456789".Contains(x)).TakeWhile("0123456789".Contains))) : int.Parse(string.Concat(value.SkipWhile(x => !"0123456789".Contains(x)).TakeWhile("0123456789".Contains))) * -1 : null;
	private static double? AsDouble(this string value) => value is not "Unknown" and not "-" ? double.Parse(value) : null;
	private static double AsAtomicMass(this string value) => double.Parse(value.Replace("[", string.Empty).Replace("]", string.Empty));
	private static Group AsGroup(this string value) => int.TryParse(value, out int group) ? (Group)group : value == "Lanthanides" ? Group.Lanthanides : Group.Actinides;
	private static Period AsPeriod(this string value) => (Period)int.Parse(value);
	private static Category AsCategory(this string value) => (int)value.AsGroup() switch { 1 => Category.AlkaliMetal, 2 => Category.AlkalineEarthMetal, <= 12 => Category.TransitionMetal, 17 => Category.Halogen, 18 => Category.NobleGas, 19 => Category.Lanthanide, _ => Category.Actinide };
	private static Block AsBlock(this string value) => value switch { "s" => Block.SBlock, "p" => Block.PBlock, "d" => Block.DBlock, _ => Block.FBlock };
	private static State AsState(this string value) => value switch { "Solid" => State.Solid, "Liquid" => State.Liquid, "Gas" => State.Gas, _ => State.Unknown };
	private static double? AsTemperature(this string value) => value is not "Unknown" ? double.Parse(string.Concat(value.TakeWhile(x => x != '&')).Replace('−', '-').Replace("Sublimes at ", string.Empty)) : null;
	private static double? AsDensity(this string value) => value is not "Unknown" ? double.Parse(string.Concat(value.TakeWhile(x => x != '('))) : null;
	private static OxidationState[]? AsOxidationStates(this string value) => !value.StartsWith("Unknown") ? !value.StartsWith("<br>", StringComparison.CurrentCultureIgnoreCase) ? value.Replace("<strong>", string.Empty).Replace("</strong>", string.Empty).Replace(" ", string.Empty).Split(",").Select(x => (OxidationState)int.Parse(x)).ToArray() : [] : null;
	private static string AsIsotope(this string value) => value.Trim().Replace("SUP", "sup").Replace("<sup>", string.Empty).Replace("</sup>", string.Empty).Replace('0', '⁰').Replace('1', '¹').Replace('2', '²').Replace('3', '³').Replace('4', '⁴').Replace('5', '⁵').Replace('6', '⁶').Replace('7', '⁷').Replace('8', '⁸').Replace('9', '⁹');
	private static string? AsDiscoverer(this string value) => value is not "-" ? value : null;
	private static string[] AsUses(this string value) => value.Replace("<div>", string.Empty).Replace("</div>", string.Empty).Split("<br/>").Select(x => x.Trim()).ToArray();
}