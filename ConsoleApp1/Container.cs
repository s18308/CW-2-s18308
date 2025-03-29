namespace ConsoleApp1;

public class Container()
{
    public static int CurrentCodeNumber = 1;
    protected double CargoMass { get; set; }
    private double _containerHeight { get; set; }
    private double _containerDepth { get; set; }
    protected double ContainerMaxLoad { get; set; }
    public double ContainerWeight { get; set; }
    public string SerialNumber { get; set; }

    public Container(int height, int depth, int weight, int maxLoad) : this()
    {
        ContainerWeight = weight;
        _containerDepth = depth;
        ContainerMaxLoad = maxLoad;
        _containerHeight = height;
        CargoMass = 0;
    }


    public void EmptyCargo()
    {
        this.CargoMass = 0;
    }

    public virtual void LoadContainer(double cargoMass)
    {
        if (cargoMass + CargoMass > ContainerWeight)
        {
            throw new Exception("OverfillException");
        }
        else
        {
            this.CargoMass += cargoMass;
        }
    }
    
    
}