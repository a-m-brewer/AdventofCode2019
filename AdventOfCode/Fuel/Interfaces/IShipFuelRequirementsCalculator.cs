namespace AdventOfCode.Fuel.Interfaces
{
    public interface IShipFuelRequirementsCalculator
    {
        decimal CalculateShipFuelRequirements(IShip ship);
    }
}