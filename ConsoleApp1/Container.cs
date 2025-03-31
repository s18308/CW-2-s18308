namespace ConsoleApp1;

public class Container
{
    public static List<Container>  containers = new List<Container>();
    public static int CurrentCodeNumber = 1;
    public double CargoMass { get; set; }
    private double _containerHeight { get; set; }
    private double _containerDepth { get; set; }
    protected double ContainerMaxLoad { get; set; }
    public double ContainerWeight { get; set; }
    public string SerialNumber { get; set; }

    public Container(int height, int depth, int weight, int maxLoad)
    {
        ContainerWeight = weight;
        _containerDepth = depth;
        ContainerMaxLoad = maxLoad;
        _containerHeight = height;
        CargoMass = 0;
        containers.Add(this);
    }


    public void EmptyCargo()
    {
        this.CargoMass = 0;
    }

    public virtual void LoadContainer(double cargoMass)
    {
        if (cargoMass + CargoMass > ContainerMaxLoad)
        {
            throw new OverfillException("Cargo mass exceeds container max load");
        }
        else
        {
            this.CargoMass += cargoMass;
        }
    }
    public virtual void EmptyContainer()
    {
        this.ContainerWeight = 0;
    }
    public override string ToString()
    {
        return $@"Container Serial Number: {SerialNumber}
               Height: {_containerHeight},  Depth: {_containerDepth}
               Weight: {ContainerWeight}, Max Load: {ContainerMaxLoad}  
               Current Cargo Mass: {CargoMass}";

    }
}