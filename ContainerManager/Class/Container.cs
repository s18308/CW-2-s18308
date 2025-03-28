namespace ContainerManager.Class;

public class Container()
{
    public static int CurrentCodeNumber = 1;
    protected double CargoMass { get; set; }
    private double ContainerHeight { get; set; }
    private double ContainerDepth { get; set; }
    protected double ContainerMaxLoad { get; set; }
    private double ContainerWeight { get; set; }
    public string SerialNumber { get; set; }

    public Container(int height, int depth, int weight, int maxLoad) : this()
    {
        ContainerWeight = weight;
        ContainerDepth = depth;
        ContainerMaxLoad = maxLoad;
        ContainerHeight = height;
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