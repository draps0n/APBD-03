using Containers.Exceptions;

namespace Containers.Models;

public abstract class Container
{
    private static int number = 0;
    public double CargoMass { get; set; }
    public double MaxCargoMass { get; set; }
    public double Height { get; set; }
    public double OwnWeight { get; set; }
    public double Depth { get; set; }
    protected string SerialNumber { get; }

    protected Container(double cargoMass, double height, double ownWeight, double depth, char typeOfContainer)
    {
        CargoMass = cargoMass;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        SerialNumber = "KON-" + typeOfContainer + "-" + (++number);
    }

    public virtual void UnloadCargo()
    {
        CargoMass = 0;
    }

    public virtual void LoadCargo(double cargoMass)
    {
        if (cargoMass > CargoMass)
        {
            throw new OverfillException();
        }

        CargoMass = cargoMass;
    }
}