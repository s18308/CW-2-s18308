namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _isCargoDangerous;
    public LiquidContainer(int height, int depth, int maxLoad, int containerMass,bool isCargoDangerous ) : base(height, depth, containerMass, maxLoad)
    {
        this._isCargoDangerous = isCargoDangerous;
        SerialNumber = $"KON-L{CurrentCodeNumber++}"  ;
    }

    private void Notify()
    {
        Console.WriteLine(
            $"Dangerous operation with container: {SerialNumber}") ;
    }

    public override void LoadContainer(double load)
    {
            if (_isCargoDangerous &&  ContainerWeight + load > ContainerMaxLoad / 2)
            {
                Notify();
            }
            else if (!_isCargoDangerous && ContainerWeight + load > ContainerWeight * 0.9)
            {
                Notify();
            }
            else
            {
                base.LoadContainer(load);
            }
    }
    
}