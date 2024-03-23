using Containers.Interfaces;

namespace Containers.Models;

public class GasContainer : Container, IHazardNotifier
{
    private double Pressure { get; set; }

    public GasContainer(double maxCargoMass, double height, double ownWeight, double depth) : base(
        maxCargoMass, height, ownWeight, depth, 'G')
    {
        Pressure = new Random().Next(1, 10);
    }

    public override void UnloadCargo()
    {
        CargoMass *= 0.05;
    }

    public void SendHazardWarning()
    {
        Console.WriteLine("Dangerous situation with container no. " + SerialNumber + "!!");
    }

    public override string ToString()
    {
        return base.ToString() + $", pressure={Pressure}atm)";
    }
}