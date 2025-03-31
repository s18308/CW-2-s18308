namespace ConsoleApp1;

public class CoolingContainer : Container, IHazardNotifier
{
    private string? _productType;
    private double? _temperature {get; set;} = default;
    private static readonly Dictionary<string, double> _cargoTypeAndTemperMinimalTemperature = 
        new() 
        { 
            {"bananas", 13.3},
            {"chocolate", 18},
            {"fish", 2},
            {"meat", -15},
            {"iceCream", -18},
            {"frozenPizza", -30},
            {"cheese", 7.2},
            {"sausages", 5},
            {"butter", 20.5},
            {"eggs", 19}
        };

    public CoolingContainer(int height, int depth, int weight, int maxLoad) : base(height, depth, weight, maxLoad)
    {
        _productType = null;
        _temperature = null;
        SerialNumber = $"KON-C{CurrentCodeNumber++}";
    }
    private void Notify(string? message)
    {
        Console.WriteLine(
            $@"Dangerous operation with container: {SerialNumber}
                {message}") ;
    }

    public void LoadContainer(double mass, string type)
    {
        if (_productType == type)
        {
            if (CargoMass + mass > ContainerMaxLoad)
            {
                throw new OverfillException("Cargo mass exceeds container max load");
            }
            CargoMass += mass;
        }
        else if (_productType != null)
        {
            Notify("Cargo incorrect type");
        }
        else if (_productType == null && _cargoTypeAndTemperMinimalTemperature.ContainsKey(type))
        {
            if (CargoMass + mass > ContainerMaxLoad)
            {
                throw new OverfillException("Cargo mass exceeds container max load");
            }
            _productType = type;
            _temperature = _cargoTypeAndTemperMinimalTemperature[type];
            CargoMass += mass;
        }
    }
}