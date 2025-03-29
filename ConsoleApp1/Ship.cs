namespace ConsoleApp1;

public class Ship
{
    private List<Container> _allContainers;
    private double _maxSpeed;
    private int _maxContainerCount;
    private double _maxLoad;
    private double _cargoMass;

    public Ship(double maxSpeed, int maxContainerCount, double maxLoad, double cargoMass)
    {
        _allContainers = new List<Container>();
        _maxSpeed = maxSpeed;
        _maxContainerCount = maxContainerCount;
        _maxLoad = maxLoad;
        _cargoMass = 0;
    }

    public void addContainer(Container container)
    {
        if (container.ContainerWeight + _cargoMass > _maxLoad)
        {
            throw new Exception("OverfillException");
        }
        else
        {
            _allContainers.Add(container);
        }
    }
    public void removeContainer(Container container)
    {
        if (_allContainers.Contains(container))
        {
            _allContainers.Remove(container);
        }
        else
        {
            throw new Exception("No such container");
        }
    }
    
}