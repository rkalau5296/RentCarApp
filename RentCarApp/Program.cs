using RentCarApp.Data;
using RentCarApp.Entities;
using RentCarApp.Repositories;

var carRepository = new SqlRepoitory<Car>(new RentCarDbContext());
AddCars(carRepository);
AddTruck(carRepository);
WriteAllToConsole(carRepository);

static void AddCars(IRepository<Car> carRepository)
{
    carRepository.Add(new Car { Brand = "Fiat", Model = "Panda" });
    carRepository.Add(new Car { Brand = "Ford", Model = "Sierra" });
    carRepository.Add(new Car { Brand = "BMW", Model = "750" });
    carRepository.Add(new Car { Brand = "Dacia", Model = "Duster" });
    carRepository.Save();
}
static void AddTruck(IWriteRepository<Truck> truckRepository)
{
    truckRepository.Add(new Truck { Brand = "Mercedes", Model = "Mercedes Benz" });
    truckRepository.Add(new Truck { Brand = "Renault", Model = "Renault Trucks" });
    truckRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
