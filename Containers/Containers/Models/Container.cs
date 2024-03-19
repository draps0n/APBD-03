using Containers.Exceptions;

namespace Containers.Models;

public abstract class Container
{
    private static int _number = 0;
    public double CargoMass { get; set; }
    public double MaxCargoMass { get; set; }
    public double Height { get; set; }
    public double OwnWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; }

    public double GrossWeight => OwnWeight + CargoMass;

    protected Container(double cargoMass, double height, double ownWeight, double depth, char typeOfContainer)
    {
        CargoMass = cargoMass;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        SerialNumber = "KON-" + typeOfContainer + "-" + (++_number);
    }

    public virtual void UnloadCargo()
    {
        CargoMass = 0;
    }

    public virtual void LoadCargo(double cargoMass)
    {
        if (cargoMass > MaxCargoMass)
        {
            throw new OverfillException();
        }

        CargoMass = cargoMass;
    }

    public override string ToString()
    {
        return
            $"Serial no.: {SerialNumber}, Cargo mass: {CargoMass}, Max cargo mass: {MaxCargoMass}, Height: {Height}, Depth: {Depth}, Own weight: {OwnWeight}";
    }
}