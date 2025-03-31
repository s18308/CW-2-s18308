namespace ConsoleApp1;

public class Ship
{
    private List<Container> _allContainers;
    private double _maxSpeed { get; set; }
    private int _maxContainerCount  { get; set; }
    private double _maxCargoMass  { get; set; } 

    public Ship(double maxSpeed, int maxContainerCount, double maxLoad)
    {
        _allContainers = new List<Container>();
        _maxSpeed = maxSpeed;
        _maxContainerCount = maxContainerCount;
        _maxCargoMass = maxLoad;
    }

    public void addContainer(Container container)
    {
        var tmpContainerMass = _allContainers.Sum(x => x.CargoMass);
        
        if (_allContainers.Count + 1 > _maxContainerCount || container.ContainerWeight + tmpContainerMass > _maxCargoMass*1000)
        {
            throw new Exception("OverfillException");
        }
        else
        {
            _allContainers.Add(container);
        }
    }
    public void addContainer(List<Container> containers)
    {
        var tmpContainerMass = _allContainers.Sum(x => x.CargoMass);

        foreach (var container in containers)
        {
            if (_allContainers.Count + 1 > _maxContainerCount || container.ContainerWeight + tmpContainerMass > _maxCargoMass*1000)
            {
                throw new Exception("OverfillException");
            }
            else
            {
                _allContainers.Add(container);
                tmpContainerMass += container.ContainerWeight;
            }
        }
    }

    public static void moveContainerBetweenShips(Ship ship1, Ship ship2, Container container)
    {
        ship1.removeContainer(container);
        ship2.addContainer(container);
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

    public void swapContainers(string container1, Container container2)
    {
        var tmpContainer1 = _allContainers.FirstOrDefault(c => c.SerialNumber.Equals(container1));
    
        if (tmpContainer1 != null)
        {
            removeContainer(tmpContainer1);
            addContainer(container2);
        }
        else
        {
            throw new Exception("Container not found");
        }
    }
    public override string ToString()
    {
        var containerDetails = string.Join("\n", _allContainers.Select(c => c.ToString()));

        return $@"Ship Details:
                - Max Speed: {_maxSpeed} knots
                - Max Container Count: {_maxContainerCount}
                - Max Cargo Mass: {_maxCargoMass*1000} tons
                - Current Containers: {_allContainers.Count}
                - Current Cargo Mass: {_allContainers.Sum(c => c.CargoMass) } tons
                - Container Details:
                {containerDetails}";
    }
}