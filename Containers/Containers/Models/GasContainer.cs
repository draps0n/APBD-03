using Containers.Interfaces;

namespace Containers.Models;

public class GasContainer : Container, IHazardNotifier
{
    private double Pressure { get; set; }
    
    public GasContainer(double cargoMass, double height, double ownWeight, double depth) : base(
        cargoMass, height, ownWeight, depth, 'G')
    {
    }

    public override void UnloadCargo()
    {
        CargoMass *= 0.05;
    }

    public void SendHazardWarning()
    {
        Console.WriteLine("Dangerous situation with container no. " + SerialNumber + "!!");
    }
}