using RentCarApp.Data;
using RentCarApp.Entities;
using RentCarApp.Repositories;
using RentCarApp.Repositories.Extension;

SqlRepoitory<Car> carRepository = new(new RentCarDbContext(), CarAdded);
carRepository.ItemAdded += CarRepositoryOnItemAdded;

//AddCars(carRepository);
WriteAllToConsole(carRepository);

static void CarRepositoryOnItemAdded(object? sender, Car e)
{
    Console.WriteLine($"Car added => {e.Brand} from {sender?.GetType().Name}");
}
static void CarAdded(object item)
{
    Car car = (Car)item;
    Console.WriteLine($"{car.Brand} added.");
}

static void AddCars(IRepository<Car> carRepository)
{
    Car[] employees = new[]
    {
        new Car { Brand = "Ford", Model = "Focus"},
        new Car { Brand = "Dacia", Model = "Duster"},
        new Car { Brand = "Dacia", Model = "Lodgy"},
        new Car { Brand = "Fiat", Model = "Panda"},
        new Car { Brand = "Citroen", Model = "Xara"},
    };

    carRepository.AddBatch(employees);
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}