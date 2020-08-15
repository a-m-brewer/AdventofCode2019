namespace AdventOfCode.Fuel.Interfaces
{
    public interface IModuleFuelRequirementsCalculator
    {
        decimal CalculateFuelRequirements(IModule module);
    }
}