namespace ConsoleApp1;

public class CoolingContainer : Container, IHazardNotifier
{
    private static int _containerAmount;
    private string? _productType;
    private double _temp;
    private static readonly Dictionary<string, double> _minimalTemp = 
        new Dictionary<string, double>{ 
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

    public CoolingContainer(int height, int depth, int weight, int maxLoad, string? productType) : base(height, depth, weight, maxLoad)
    {
        _productType = null;
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
        if(_productType != null && _productType == type)
        {
            try
            {
                if (_minimalTemp[type] < _temp)
                {
                    Notify("Container temperature too high.");
                    return;
                }

                _productType = type;
                base.LoadContainer(mass);
            }
            catch (Exception e)
            {
                
            }
        }
        else
        {
            Notify("Incorrect cargo ");
        }
    }

}