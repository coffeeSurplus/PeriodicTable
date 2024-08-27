using PeriodicTable.Source.Enums;

namespace PeriodicTable.Source.Models;

internal record ElementModel
(
	string Name,
	string Symbol,
	int AtomicNumber,
	double AtomicMass,
	Group Group,
	Period Period,
	Category Category,
	Block Block,
	State RoomTemperatureState,
	string Appearance,
	double? MeltingPoint,
	double? BoilingPoint,
	double? Density,
	double? AtomicRadius,
	string ElectronConfiguration,
	double? Electronegativity,
	double? IonisationEnergy,
	OxidationState[]? OxidationStates,
	string Isotopes,
	string KeyIsotopes,
	string Etymology,
	int? DiscoveryYear,
	string? Discoverer,
	string[] Uses
);