using Containers.Interfaces;

namespace Containers.Models;

public class FluidContainer : Container, IHazardNotifier
{
    private bool IsCargoHazardous { get; set; }

    public FluidContainer(double cargoMass, double height, double ownWeight, double depth, bool isCargoHazardous)
        : base(cargoMass, height, ownWeight, depth, 'L')
    {
        IsCargoHazardous = isCargoHazardous;
    }

    public override void LoadCargo(double cargoMass)
    {
        var maxCapacity = IsCargoHazardous ? 0.5 : 0.9;
        if (cargoMass > maxCapacity * CargoMass)
        {
            SendHazardWarning();
        }
        
        base.LoadCargo(cargoMass);
    }
    
    public void SendHazardWarning()
    {
        Console.WriteLine("Dangerous situation with container no. " + SerialNumber + "!!");
    }
}