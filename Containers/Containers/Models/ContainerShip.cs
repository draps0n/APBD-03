using System.Text;

namespace Containers.Models;

public class ContainerShip
{
    private static int _number = 0;
    private int Id { get; }
    public List<Container> Cargo { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxContainersAmount { get; set; }
    public double MaxContainersWeight { get; set; }
    public double ContainersAmount { get; set; }
    public double ContainersWeight { get; set; }

    public ContainerShip(double maxSpeed, int maxContainersAmount, double maxContainersWeight)
    {
        Id = ++_number;
        Cargo = new List<Container>(maxContainersAmount);
        MaxSpeed = maxSpeed;
        MaxContainersAmount = maxContainersAmount;
        MaxContainersWeight = maxContainersWeight;
    }

    public void LoadContainer(Container container)
    {
        Cargo.Add(container);
        container.LoadedOn = this;
        ContainersAmount++;
        ContainersWeight += container.GrossWeight;
    }

    public void LoadContainerList(List<Container> containers)
    {
        foreach (var c in containers)
        {
            LoadContainer(c);
        }
    }

    public Container UnloadContainer(Container container)
    {
        Cargo.Remove(container);
        container.LoadedOn = null;
        ContainersAmount--;
        ContainersWeight -= container.GrossWeight;
        return container;
    }

    public void SwapContainers(string serialNumberOnShip, Container container)
    {
        var idx = -1;
        for (var i = 0; i < Cargo.Count; i++)
        {
            if (Cargo[i].SerialNumber == serialNumberOnShip)
            {
                idx = i;
            }
        }

        if (idx < 0)
        {
            throw new ArgumentException("No such container on ship!");
        }

        UnloadContainer(Cargo[idx]);
        LoadContainer(container);
    }

    public static void TransferContainers(ContainerShip fromShip, ContainerShip toShip, string containerSerialNo)
    {
        var idx = -1;
        for (var i = 0; i < fromShip.Cargo.Count; i++)
        {
            if (fromShip.Cargo[i].SerialNumber == containerSerialNo)
            {
                idx = i;
            }
        }

        if (idx < 0)
        {
            throw new ArgumentException("No such container on ship!");
        }

        var unloaded = fromShip.UnloadContainer(fromShip.Cargo[idx]);
        toShip.LoadContainer(unloaded);
    }

    public override string ToString()
    {
        // return
        //     $"[Max speed: {MaxSpeed} knots, Containers amount: {ContainersAmount}, Max containers amount: {MaxContainersAmount}, " +
        //     $"Containers weight: {ContainersWeight} kg, Max containers weight: {MaxContainersWeight} t, Loaded cargo: [{string.Join(", ", Containers)}]]";
        var tmp = $"Statek {Id} (speed={MaxSpeed}, maxContainerNum={MaxContainersAmount}, maxWeight={MaxContainersWeight}, cargo=[";

        foreach (var container in Cargo)
        {
            tmp += container.SerialNumber + ", ";
        }

        tmp += "])";
        return tmp;
    }
}