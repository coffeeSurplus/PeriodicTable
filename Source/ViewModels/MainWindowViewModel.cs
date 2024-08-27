using PeriodicTable.Properties;
using PeriodicTable.Source.Enums;
using PeriodicTable.Source.Models;
using PeriodicTable.Source.MVVM;
using System.Text.Json;

namespace PeriodicTable.Source.ViewModels;

internal class MainWindowViewModel : ViewModelBase
{
	private ElementModel elementModel;
	private bool? categoryMode = true;
	private int? temperature = null;
	private Category? category = null;
	private Block? block = null;
	private Group? group = null;
	private Period? period = null;

	public ElementModel ElementModel
	{
		get => elementModel;
		set => SetValue(ref elementModel, value);
	}
	public bool? CategoryMode
	{
		get => categoryMode;
		set
		{
			SetValue(ref categoryMode, value);
			if (value != null)
			{
				Temperature = null;
				Category = null;
				Block = null;
				Group = null;
				Period = null;
			}
		}
	}
	public int? Temperature
	{
		get => temperature;
		set
		{
			SetValue(ref temperature, value);
			if (value != null)
			{
				CategoryMode = null;
				Category = null;
				Block = null;
				Group = null;
				Period = null;
			}

		}
	}
	public Category? Category
	{
		get => category;
		set
		{
			SetValue(ref category, value);
			if (value != null)
			{
				CategoryMode = null;
				Temperature = null;
				Block = null;
				Group = null;
				Period = null;
			}
		}
	}
	public Block? Block
	{
		get => block;
		set
		{
			SetValue(ref block, value);
			if (value != null)
			{
				CategoryMode = null;
				Temperature = null;
				Category = null;
				Group = null;
				Period = null;
			}

		}
	}
	public Group? Group
	{
		get => group;
		set
		{
			SetValue(ref group, value);
			if (value != null)
			{
				CategoryMode = null;
				Temperature = null;
				Category = null;
				Block = null;
				Period = null;
			}

		}
	}
	public Period? Period
	{
		get => period;
		set
		{
			SetValue(ref period, value);
			if (value != null)
			{
				CategoryMode = null;
				Temperature = null;
				Category = null;
				Block = null;
				Group = null;
			}

		}
	}

	public ElementModel[] ElementModels { get; } = JsonSerializer.Deserialize<ElementModel[]>(Resources.Data)!;

	public RelayCommand<ElementModel> SetElementCommand { get; }
	public RelayCommand PageLeftCommand { get; }
	public RelayCommand PageRightCommand { get; }

	public MainWindowViewModel()
	{
		elementModel = ElementModels[0];
		SetElementCommand = new(SetElement);
		PageLeftCommand = new(PageLeft);
		PageRightCommand = new(PageRight);
	}

	private void SetElement(ElementModel elementModel) => ElementModel = elementModel;
	private void PageLeft() => ElementModel = ElementModels[ElementModel.AtomicNumber != 1 ? ElementModel.AtomicNumber - 2 : 117];
	private void PageRight() => ElementModel = ElementModels[ElementModel.AtomicNumber != 118 ? ElementModel.AtomicNumber : 0];
}