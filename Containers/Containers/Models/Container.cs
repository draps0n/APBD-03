using Containers.Exceptions;

namespace Containers.Models;

public abstract class Container : IEquatable<Container>
{
    private static int _number = 0;
    public ContainerShip? LoadedOn { get; set; }
    public double CargoMass { get; set; }
    public double MaxCargoMass { get; set; }
    public double Height { get; set; }
    public double OwnWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; }

    public double GrossWeight => OwnWeight + CargoMass;

    protected Container(double maxCargoMass, double height, double ownWeight, double depth, char typeOfContainer)
    {
        CargoMass = 0;
        MaxCargoMass = maxCargoMass;
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
            $"serialNo={SerialNumber} (cargoMass={CargoMass}kg, maxCargoMass={MaxCargoMass}kg, height={Height}cm, depth={Depth}cm, ownWeight={OwnWeight}kg";
        
    }

    public bool Equals(Container? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return SerialNumber == other.SerialNumber;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Container)obj);
    }

    public override int GetHashCode()
    {
        return SerialNumber.GetHashCode();
    }
}