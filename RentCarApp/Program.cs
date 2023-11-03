using Microsoft.Extensions.DependencyInjection;
using RentCarApp;
using RentCarApp.DataProviders;
using RentCarApp.Entities;
using RentCarApp.Repositories;

var service = new ServiceCollection();
service.AddSingleton<IApp, App>();
service.AddSingleton<IRepository<Car>, ListRepository<Car>>();
service.AddSingleton<IRepository<Client>, ListRepository<Client>>();
service.AddSingleton<IClientProvider, ClientProvider>();

var serviceProvider = service.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();


//using RentCarApp.Data;
//using RentCarApp.Entities;
//using RentCarApp.Repositories;
//using RentCarApp.Repositories.Extension;
//using System.Reflection;
//using System.Text.Json;


//string auditFilePath = @"C:\RentCarApp\RentCarApp\RentCarApp\bin\Debug\net7.0\AuditLog.txt";
//using (StreamWriter writer = File.AppendText(auditFilePath))
//{
//    writer.WriteLine("Rozpoczęto logowanie: " + DateTime.Now);
//}

//Console.WriteLine("Witam w programie RentCarApp.");
//Console.WriteLine("Aplikacja służy do dodawania samochodów do wypożyczalni.");
//Console.WriteLine("===========================================");

//SqlRepoitory<Car> carRepository = new(new RentCarDbContext(), CarAdded, CarRemoved);
//carRepository.ItemAdded += (sender, e) => CarRepositoryOnItemAdded(sender, e, auditFilePath);
//carRepository.ItemRemoved += (sender, e) => CarRepositoryOnItemRemoved(sender, e, auditFilePath);
//static void CarRepositoryOnItemAdded(object? sender, Car e, string auditFilePath)
//{
//    Console.WriteLine($"Car added => {e.Brand} from {sender?.GetType().Name}");
//    using StreamWriter writer = File.AppendText(auditFilePath);
//    string auditMessage = $"{DateTime.Now}: Car added => {e.Brand} from {sender?.GetType().Name}";
//    writer.WriteLine(auditMessage);
//}

//static void CarRepositoryOnItemRemoved(object? sender, Car e, string auditFilePath)
//{
//    Console.WriteLine($"Car removed => {e.Brand} from {sender?.GetType().Name}");
//    using StreamWriter writer = File.AppendText(auditFilePath);
//    string auditMessage = $"{DateTime.Now}: Car removed => {e.Brand} from {sender?.GetType().Name}";
//    writer.WriteLine(auditMessage);
//}

//static void CarAdded(object item)
//{
//    Car car = (Car)item;
//    Console.WriteLine($"{car.Brand} added.");
//}
//static void CarRemoved(object item)
//{
//    Car car = (Car)item;
//    Console.WriteLine($"{car.Brand} removed.");
//}
//static void AddCars(IRepository<Car> carRepository)
//{
//    string path = @"C:\RentCarApp\RentCarApp\RentCarApp\bin\Debug\net7.0\inputData.json";
//    if (File.Exists(path))
//    {
//        List<Car> cars = new()
//        {
//            new Car { Brand = "Ford", Model = "Focus"},
//            new Car { Brand = "Dacia", Model = "Duster"},
//            new Car { Brand = "Dacia", Model = "Lodgy"},
//            new Car { Brand = "Fiat", Model = "Panda"},
//            new Car { Brand = "Citroen", Model = "Xara"},
//        };
//        var objectsSerialized = JsonSerializer.Serialize<IEnumerable<Car>>(cars);
//        File.WriteAllText(path, objectsSerialized);
//        var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<Car>>(objectsSerialized);
//        carRepository.AddBatch(deserializedObjects);
//    }   
//}

//static void RemoveCar(IRepository<Car> carRepository, Car car)
//{   
//    carRepository.RemoveItem(car);
//}
//static void WriteAllToConsole(IReadRepository<IEntity> repository, string auditFilePath)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//    using StreamWriter writer = File.AppendText(auditFilePath);
//    string auditMessage = $"Wyświetlono listę wszystkich samochodów z bazy.";
//    writer.WriteLine(auditMessage);
//}

//bool running = true;

//while (running)
//{
//    Console.WriteLine("Wybierz opcję:");
//    Console.WriteLine();
//    Console.WriteLine("1. Dodaj samochód do listy.");
//    Console.WriteLine("2. Wczytaj listę samochodów.");
//    Console.WriteLine("3. Usuń dany samochód.");
//    Console.WriteLine("4. Wyjście");

//    string imput = Console.ReadLine();

//    switch (imput)
//    {
//        case "1":
//            Console.Clear();
//            AddCars(carRepository);
//            Console.WriteLine();
//            break;

//        case "2":
//            Console.Clear();
//            WriteAllToConsole(carRepository, auditFilePath);
//            break;

//        case "3":
//            Console.Clear();
//            string path = @"C:\RentCarApp\RentCarApp\RentCarApp\bin\Debug\net7.0\inputData.json";
//            List<Car>? deserializedObjects = JsonSerializer.Deserialize<IEnumerable<Car>>(File.ReadAllText(path))?.ToList();
//            RemoveCar(carRepository, deserializedObjects[0]);
//            break;

//        case "4":
//            running = false;
//            break;

//        default:
//            Console.WriteLine("Nieprawidłowy wybór. Wybierz 1, 2 lub 3.");
//            break;
//    }

//    File.AppendAllText(auditFilePath, "Zakończono działanie aplikacji.");
//}