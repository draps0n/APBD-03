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

    public RefrigeratedContainer(double cargoMass, double height, double ownWeight, double depth, char typeOfContainer,
        Product storedProduct, double insideTemp) : base(cargoMass, height, ownWeight, depth, typeOfContainer)
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
}