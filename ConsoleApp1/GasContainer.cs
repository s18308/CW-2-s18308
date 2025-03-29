namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    private double _pressure;

    public GasContainer(int height, int depth, int weight, int maxLoad, double pressure) : base(height, depth, weight, maxLoad)
    {
        this.SerialNumber = $"KON-G{CurrentCodeNumber++}";
        this._pressure = 0;
    }
    private void Notify()
    {
        Console.WriteLine(
            $"Dangerous operation with container: {SerialNumber}") ;
    }

    public void EmptyContainer()
    {
        this.ContainerWeight *= 0.05;
    }
    public override void LoadContainer(double mass)
    {
        try
        {
            base.LoadContainer(mass);
        }
        catch (Exception ex)
        {
            throw new Exception("OverfillException");
        }
    }
}