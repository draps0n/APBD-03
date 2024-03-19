using Containers.Exceptions;
using Containers.Interfaces;

namespace Containers.Models;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public enum Product
    {
        Bananas = 13,
        Chocolate = 18,
        Fish = 2,
        Meat = -15,
        IceCream = -18,
        FrozenPizza = -30,
        Cheese = 7,
        Sausages = 5,
        Butter = 20,
        Eggs = 19
    }

    public Product StoredProduct { get; set; }
    public double InsideTemp { get; set; }

    public RefrigeratedContainer(double maxCargoMass, double height, double ownWeight, double depth,
        Product storedProduct, double insideTemp) : base(maxCargoMass, height, ownWeight, depth, 'C')
    {
        if (insideTemp < (int) storedProduct)
        {
            throw new InappropriateTempException("Temperature is too low for " + storedProduct);
        }
        
        StoredProduct = storedProduct;
        InsideTemp = insideTemp;
    }

    public void SendHazardWarning()
    {
        Console.WriteLine("Dangerous situation with container no. " + SerialNumber + "!!");
    }
    
    public override string ToString()
    {
        return base.ToString() + $", typeOfProduct={StoredProduct}, insideTemp={InsideTemp}C)";
    }
}