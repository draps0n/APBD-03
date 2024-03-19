namespace Containers.Models;

public class ContainerShip
{
    public List<Container> Containers { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxContainersAmount { get; set; }
    public double MaxContainersWeight { get; set; }
    public double ContainersAmount { get; set; }
    public double ContainersWeight { get; set; }

    public ContainerShip(double maxSpeed, int maxContainersAmount, double maxContainersWeight)
    {
        Containers = new List<Container>(maxContainersAmount);
        MaxSpeed = maxSpeed;
        MaxContainersAmount = maxContainersAmount;
        MaxContainersWeight = maxContainersWeight;
    }

    public void LoadContainer(Container container)
    {
        Containers.Add(container);
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
        Containers.Remove(container);
        ContainersAmount--;
        ContainersWeight -= container.GrossWeight;
        return container;
    }

    public void SwapContainers(string serialNumberOnShip, Container container)
    {
        var idx = -1;
        for (var i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].SerialNumber == serialNumberOnShip)
            {
                idx = i;
            }
        }

        if (idx < 0)
        {
            throw new ArgumentException("No such container on ship!");
        }

        UnloadContainer(Containers[idx]);
        LoadContainer(container);
    }

    public static void TransferContainers(ContainerShip fromShip, ContainerShip toShip, string containerSerialNo)
    {
        var idx = -1;
        for (var i = 0; i < fromShip.Containers.Count; i++)
        {
            if (fromShip.Containers[i].SerialNumber == containerSerialNo)
            {
                idx = i;
            }
        }

        if (idx < 0)
        {
            throw new ArgumentException("No such container on ship!");
        }

        var unloaded = fromShip.UnloadContainer(fromShip.Containers[idx]);
        toShip.LoadContainer(unloaded);
    }

    public override string ToString()
    {
        return
            $"[Max speed: {MaxSpeed}, Containers amount {ContainersAmount}, Max containers amount: {MaxContainersAmount}, " +
            $"Containers Weight {MaxContainersWeight}, Max containers Weight: {MaxContainersWeight}, Loaded cargo: {Containers}]";
    }
}