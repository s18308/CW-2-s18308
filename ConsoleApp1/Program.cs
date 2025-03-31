
using ConsoleApp1;
// Stworzenie kontenera danego typu
var liquidContainer = new LiquidContainer(2, 5, 10000, 1000);
var gasContainer = new GasContainer(2, 5, 10000, 1000);
var coolingContainer = new CoolingContainer(2, 5, 10000, 1000);
var containers = new List<Container>
{
 new LiquidContainer(2, 5, 10000, 1000),
 new GasContainer(2, 5, 10000, 1000),
 new CoolingContainer(2, 5, 10000, 1000)
};
//Załadowanie ładunku do danego kontenera
 liquidContainer.LoadContainer(200);
 gasContainer.LoadContainer(20); 
coolingContainer.LoadContainer(200,"bananas");
//Załadowanie kontenera na statek
var ship = new Ship(14, 100, 100);
ship.addContainer(liquidContainer );
ship.addContainer(gasContainer);
ship.addContainer(coolingContainer);
//Załadowanie listy kontenerów na statek
ship.addContainer(containers);
// Usunięcie kontenera ze statku
ship.removeContainer(coolingContainer);
//Rozładowanie kontenera
liquidContainer.EmptyContainer();
//Zastąpienie kontenera na statku o danym numerze innym kontenerem
var gasContainer2 = new GasContainer(2, 5, 10000, 1000);
ship.swapContainers("KON-G5", gasContainer2);
//Możliwość przeniesienie kontenera między dwoma statkami
var ship2 = new Ship(14, 100, 100);
Ship.moveContainerBetweenShips(ship,ship2,gasContainer);
// Wypisanie informacji o danym kontenerze
Console.WriteLine(gasContainer.ToString());
//Wypisanie informacji o danym statku i jego ładunku
Console.WriteLine(ship.ToString());



Console.WriteLine("bananas");