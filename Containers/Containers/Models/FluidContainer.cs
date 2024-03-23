using Containers.Interfaces;

namespace Containers.Models;

public class FluidContainer : Container, IHazardNotifier
{
    public bool IsCargoHazardous { get; set; }

    public FluidContainer(double maxCargoMass, double height, double ownWeight, double depth, bool isCargoHazardous)
        : base(maxCargoMass, height, ownWeight, depth, 'L')
    {
        IsCargoHazardous = isCargoHazardous;
    }

    public override void LoadCargo(double cargoMass)
    {
        var maxCapacity = IsCargoHazardous ? 0.5 : 0.9;
        if (cargoMass > maxCapacity * MaxCargoMass)
        {
            SendHazardWarning();
        }
        
        base.LoadCargo(cargoMass);
    }
    
    public void SendHazardWarning()
    {
        Console.WriteLine("Dangerous situation with container no. " + SerialNumber + "!!");
    }
    
    public override string ToString()
    {
        return base.ToString() + $", isCargoHazardous={IsCargoHazardous})";
    }
}