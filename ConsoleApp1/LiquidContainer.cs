namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(int height, int depth, int maxLoad, int containerMass ) : base(height, depth, containerMass, maxLoad)
    {
        SerialNumber = $"KON-L{CurrentCodeNumber++}"  ;
    }

    private void Notify(string msg)
    {
        Console.WriteLine(
            $@"Dangerous operation with container: {SerialNumber}
                {msg}") ;
    }

    public override void LoadContainer(double load)
    {
        double tmp = ContainerWeight + load;
        
        if (tmp > ContainerMaxLoad)
        {
            throw new OverfillException("Cargo mass exceeds container max load");
        }

        base.LoadContainer(load);
        if (tmp > ContainerMaxLoad * 0.9)
        {
            Notify("Max capacity for normal cargo exceeded");
        }
        else if (tmp > ContainerMaxLoad / 2)
        {
            Notify("Max capacity for dangerous cargo exceeded");
        }
    }
    
}