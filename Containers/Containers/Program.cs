// See https://aka.ms/new-console-template for more information

using Containers.Models;

public class Program
{
    private static List<ContainerShip> _containerShips = new();
    private static List<Container> _containerList = new();
    private static int _loadedContainers = 0;
    private static int _containersOnShips = 0;
    
    
    public static void Main(string[] args)
    {
        Tests();

        while (true)
        {
            PrintLists();
            var actions = PrintPossibleActions();
            var input = GetInput(actions.Count);

            if (input == 0)
            {
                break;
            }
            
            DecideWhatToDo(actions, input);
        }
        
        
    }

    public static void DecideWhatToDo(Dictionary<int, string> actions, int input)
    {
        switch (actions[input])
        {
            case "Dodaj kontenerowiec":
                AddContainerShip();
                break;
            case "Usun kontenerowiec":
                RemoveContainerShip();
                break;
            case "Dodaj kontener":
                AddContainer();
                break;
            case "Zaladuj kontener":
                LoadContainer();
                break;
            case "Rozladuj kontener":
                UnloadContainer();
                break;
            case "Zaladuj kontener na statek":
                LoadContainerOnShip();
                break;
            case "Rozladuj kontener ze statku":
                UnloadContainerFromShip();
                break;
            case "Usun kontener":
                RemoveContainer();
                break;
            case "Zastap kontener na statku":
                SwapContainersShip();
                break;
            case "Przenies kontener pomiedzy statkami":
                MoveContainerBetweenShips();
                break;
            
        }
    }

    public static void PrintLists()
    {
        Console.WriteLine("TESTY POWYŻEJ - TUI NIE JEST ZAIMPLEMENTOWANE - SAM SZKIELET");
        Console.WriteLine("Lista kontenerowców:");
        if (_containerShips.Count == 0)
        {
            Console.WriteLine("Brak");
        }
        else
        {
            _containerShips.ForEach(Console.WriteLine);
        }
        
        Console.WriteLine("\nLista kontenerów:");
        if (_containerList.Count == 0)
        {
            Console.WriteLine("Brak");
        }
        else
        {
            _containerShips.ForEach(Console.WriteLine);
        }
        Console.WriteLine();
        
    }

    public static void Tests()
    {
        // stworzenie kontenera i załadowanie go
        Console.WriteLine("Stworzenie kontenerów i ładowanie ich");
        Container refContainer =
            new RefrigeratedContainer(22000, 400, 1000, 1000, RefrigeratedContainer.Product.Butter, 22);
        Console.WriteLine(refContainer);
        refContainer.LoadCargo(1200);
        Console.WriteLine(refContainer + "\n");

        Container gasContainer = new GasContainer(22000, 400, 1000, 1000);
        gasContainer.LoadCargo(5215);
        Console.WriteLine(gasContainer + "\n");

        Container fluidContainer = new FluidContainer(22000, 400, 1000, 1000, true);
        fluidContainer.LoadCargo(12000);
        Console.WriteLine(fluidContainer + "\n");

        // stworzenie statku i załadunek
        Console.WriteLine("Tworzenie statku i załadunek");
        ContainerShip containerShip = new ContainerShip(10, 100, 30000);
        Console.WriteLine(containerShip + "\n");
        containerShip.LoadContainer(refContainer);
        containerShip.LoadContainer(gasContainer);
        containerShip.LoadContainer(fluidContainer);
        Console.WriteLine(containerShip + "\n");

        // Usunięcie kontenera ze statku
        Console.WriteLine("Usunięcie kontenera ze statku");
        containerShip.UnloadContainer(refContainer);
        containerShip.UnloadContainer(gasContainer);
        containerShip.UnloadContainer(fluidContainer);
        Console.WriteLine(containerShip + "\n");

        // załadunek listą
        Console.WriteLine("Załadunek listą");
        var tmpList = new List<Container>();
        tmpList.Add(refContainer);
        tmpList.Add(gasContainer);
        tmpList.Add(fluidContainer);
        containerShip.LoadContainerList(tmpList);
        Console.WriteLine(containerShip + "\n");

        containerShip.UnloadContainer(refContainer);
        containerShip.UnloadContainer(gasContainer);
        containerShip.UnloadContainer(fluidContainer);

        // Zastąpienie kontenera na statku innym
        Console.WriteLine("Zastąpienie kontenera na statku innym");
        containerShip.LoadContainer(refContainer);
        Console.WriteLine(containerShip);
        string serialNo = refContainer.SerialNumber;
        containerShip.SwapContainers(serialNo, gasContainer);
        Console.WriteLine(containerShip + "\n");

        // Przeładunek ze statku A na statek B
        ContainerShip cs2 = new ContainerShip(2, 10, 1231);
        Console.WriteLine(containerShip);
        Console.WriteLine(cs2);
        ContainerShip.TransferContainers(containerShip, cs2, gasContainer.SerialNumber);
        Console.WriteLine(containerShip);
        Console.WriteLine(cs2);
    }

    private static void AddContainerShip()
    {
        throw new NotImplementedException();
    }
    
    private static void AddContainer()
    {
        throw new NotImplementedException();
    }
    
    private static void RemoveContainerShip()
    {
        throw new NotImplementedException();
    }

    private static void LoadContainer()
    {
        throw new NotImplementedException();
    }
    
    private static void UnloadContainer()
    {
        throw new NotImplementedException();
    }
    
    private static void LoadContainerOnShip()
    {
        throw new NotImplementedException();
    }
    
    private static void UnloadContainerFromShip()
    {
        throw new NotImplementedException();
    }
    
    private static void RemoveContainer()
    {
        throw new NotImplementedException();
    }
    
    private static void SwapContainersShip()
    {
        throw new NotImplementedException();
    }
    
    private static void MoveContainerBetweenShips()
    {
        throw new NotImplementedException();
    }

    public static Dictionary<int, string> PrintPossibleActions()
    {
        Console.WriteLine("Mozliwe akcje:");
        Console.WriteLine("0. Wyjdz");
        
        var number = 0;
        var actions = new Dictionary<int, string>();
        Console.WriteLine(++number + ". Dodaj kontenerowiec");
        actions.Add(number, "Dodaj kontenerowiec");
        
        if (_containerShips.Count == 0)
        {
            return actions;
        }
        
        Console.WriteLine(++number + ". Usun kontenerowiec");
        actions.Add(number, "Usun kontenerowiec");
        Console.WriteLine(++number + ". Dodaj kontener");
        actions.Add(number, "Dodaj kontener");

        if (_containerList.Count == 0)
        {
            return actions;
        }

        if (_loadedContainers < _containerList.Count)
        {
            Console.WriteLine(++number + ". Zaladuj kontener");
            actions.Add(number, "Zaladuj kontener");
        }

        if (_loadedContainers > 0)
        {
            Console.WriteLine(++number + ". Rozladuj kontener");
            actions.Add(number, "Rozladuj kontener");
        }
        
        if (_containersOnShips < _containerList.Count)
        {
            Console.WriteLine(++number + ". Zaladuj kontener na statek");
            actions.Add(number, "Zaladuj kontener na statek");
        }

        if (_containersOnShips > 0)
        {
            Console.WriteLine(++number + ". Rozladuj kontener ze statku");
            actions.Add(number, "Rozladuj kontener ze statku");
        }
        
        Console.WriteLine(++number + ". Usun kontener");
        actions.Add(number, "Usun kontener");

        if (_containersOnShips > 0 && _containersOnShips < _containerList.Count)
        {
            Console.WriteLine(++number + ". Zastap kontener na statku");
            actions.Add(number, "Zastap kontener na statku");
        }
        
        if (_containerShips.Count > 1 && _containersOnShips > 0)
        {
            Console.WriteLine(++number + ". Przenies kontener pomiedzy statkami");
            actions.Add(number, "Przenies kontener pomiedzy statkami");
        }

        return actions;
    }

    private static int GetInput(int noOfActions)
    {
        var a = -1;
        while (a < 0 || a > noOfActions)
        {
            a = Convert.ToInt32(Console.ReadLine());
        }

        return a;
    }
}