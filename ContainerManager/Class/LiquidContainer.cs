namespace ContainerManager.Class;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(int height, int depth, int maxLoad, int containerMass) : base(height, depth, containerMass, maxLoad)
        {
            SerialNumber = "KON-L-" + CurrentCodeNumber++;
        }

    private void Notify()
    {
        Console.WriteLine(
            $"Dangerous operation with container: " +
            $"{SerialNumber}") ;
    }

    public override void LoadContainer(double cargoMass)
    {
        base.LoadContainer(cargoMass);
        if (this.CargoMass + cargoMass > this.ContainerMaxLoad/2)
        {
            
        }
    }
}


    
