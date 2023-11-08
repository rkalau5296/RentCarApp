using RentCarApp.Components.DataProviders;
using RentCarApp.Data.Entities;
using RentCarApp.Data.Entities.Repositories;

namespace RentCarApp
{
    internal class App : IApp
    {
        private readonly IRepository<Car> _carsRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly IClientProvider _clientProvider;

        public App(IRepository<Car> carsRepository, IRepository<Client> clientRepository, IClientProvider clientProvider)
        {
            _carsRepository = carsRepository;
            _clientRepository = clientRepository;
            _clientProvider = clientProvider;
        }
        public void Run()
        {
            Console.WriteLine("I'm here in run method.");

            Car[] cars = new[]
            {
                new Car { Brand = "Fiat", Model="Panda" },
                new Car { Brand = "Ford", Model="Sierra"},
                new Car { Brand = "Dacia", Model="Panda"},
            };

            foreach (var item in cars)
            {
                _carsRepository.Add(item);
            }

            _carsRepository.Save();

            var items = _carsRepository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            
            var clientList = GenerateSampleClients();
            foreach (var client in clientList)
            {
                _clientRepository.Add(client);
            }

            Console.WriteLine();
            Console.WriteLine("GetTheYoungestClient");
            Console.WriteLine(_clientProvider.GetTheYoungestClient());

            Console.WriteLine();
            Console.WriteLine("OrderBySurnameAndAge");           
            foreach (var client in _clientProvider.OrderBySurnameAndAge())
            {
                Console.WriteLine(client);
            };

            Console.WriteLine();
            Console.WriteLine("OrderBySurnameAndAgeDesc");
            foreach (var client in _clientProvider.OrderBySurnameAndAgeDesc())
            {
                Console.WriteLine(client);
            };            

            Console.WriteLine();
            Console.WriteLine("OrderByNameDescending");
            foreach (var client in _clientProvider.OrderByNameDescending())
            {
                Console.WriteLine(client);
            };            

            Console.WriteLine();
            Console.WriteLine("OrderByName");
            foreach (var client in _clientProvider.OrderByName())
            {
                Console.WriteLine(client);
            };
            
            Console.WriteLine();
            Console.WriteLine("WhereStartsWith");
            foreach (var client in _clientProvider.WhereStartsWith("Ro"))
            {
                Console.WriteLine(client);
            };

            Console.WriteLine();
            Console.WriteLine("WhereStartsWithAndPenaltyPointIsGreaterThan");
            foreach (var client in _clientProvider.WhereStartsWithAndPenaltyPointIsGreaterThan("Ro",0))
            {
                Console.WriteLine(client);
            };

            Console.WriteLine();
            Console.WriteLine("WhereSurnameIs");
            foreach (var client in _clientProvider.WhereSurnameIs("Kowalski"))
            {
                Console.WriteLine(client);
            };

            Console.WriteLine();
            Console.WriteLine("FirstByPenaltyPoint");
            Console.WriteLine(_clientProvider.FirstByPenaltyPoint(10));

            Console.WriteLine();
            Console.WriteLine("FirstOrDefaultByPenaltyPoints");
            Console.WriteLine(_clientProvider.FirstOrDefaultByPenaltyPoints(10));

            Console.WriteLine();
            Console.WriteLine("FirstOrDefaultByPenaltyPointsWithDefault");
            Console.WriteLine(_clientProvider.FirstOrDefaultByPenaltyPointsWithDefault(10));

            Console.WriteLine();
            Console.WriteLine("LastByPenaltyPoints");
            Console.WriteLine(_clientProvider.LastByPenaltyPoints(3));

            Console.WriteLine();
            Console.WriteLine("SingleById");
            Console.WriteLine(_clientProvider.SingleById(1));

            Console.WriteLine();
            Console.WriteLine("SingleOrDefaultById");
            Console.WriteLine(_clientProvider.SingleOrDefaultById(1));           

        }

        public List<Client> GenerateSampleClients()
        {
            return new List<Client>
            {
                new Client
                {
                    Id= 1,
                    Name = "Adam",
                    Surname = "Kowalski",
                    DateOfBirth = new DateTime(1990,03,15),
                    TelephoneNumber = "85258522",
                    DrivingLicenceNumber = "AB123456",
                    PenaltyPoints = 0
                },
                new Client
                {
                    Id= 1,
                    Name = "Piotr",
                    Surname = "Kwiatkowski",
                    DateOfBirth = new DateTime(1970,05,15),
                    TelephoneNumber = "852585221",
                    DrivingLicenceNumber = "AB1234562",
                    PenaltyPoints = 10
                },
                new Client
                {
                    Id= 1,
                    Name = "Pawel",
                    Surname = "Zdziech",
                    DateOfBirth = new DateTime(1992,03,15),
                    TelephoneNumber = "852583522",
                    DrivingLicenceNumber = "AB1233456",
                    PenaltyPoints = 5
                },
                new Client
                {
                    Id= 1,
                    Name = "Rafał",
                    Surname = "Brom",
                    DateOfBirth = new DateTime(1971,03,15),
                    TelephoneNumber = "852585232",
                    DrivingLicenceNumber = "AB1523456",
                    PenaltyPoints = 3
                },
                new Client
                {
                    Id= 1,
                    Name = "Robert",
                    Surname = "Wel",
                    DateOfBirth = new DateTime(1985,03,15),
                    TelephoneNumber = "852558522",
                    DrivingLicenceNumber = "AB1273456",
                    PenaltyPoints = 0
                },
                new Client
                {
                    Id= 1,
                    Name = "Adam",
                    Surname = "Roberts",
                    DateOfBirth = new DateTime(1950,03,15),
                    TelephoneNumber = "85258522",
                    DrivingLicenceNumber = "AB123456",
                    PenaltyPoints = 8
                },
                new Client
                {
                    Id= 1,
                    Name = "Robert",
                    Surname = "Adams",
                    DateOfBirth = new DateTime(1940,03,15),
                    TelephoneNumber = "85258522",
                    DrivingLicenceNumber = "AB123456",
                    PenaltyPoints = 10
                },
                new Client
                {
                    Id= 1,
                    Name = "John",
                    Surname = "Smith",
                    DateOfBirth = new DateTime(2000,03,15),
                    TelephoneNumber = "85258522",
                    DrivingLicenceNumber = "AB123456",
                    PenaltyPoints = 3
                },
                new Client
                {
                    Id= 1,
                    Name = "Jack",
                    Surname = "Coleman",
                    DateOfBirth = new DateTime(2001,03,15),
                    TelephoneNumber = "85258522",
                    DrivingLicenceNumber = "AB123456",
                    PenaltyPoints = 0
                },
                new Client
                {
                    Id= 1,
                    Name = "Blake",
                    Surname = "Carrington",
                    DateOfBirth = new DateTime(1999,03,15),
                    TelephoneNumber = "85258522",
                    DrivingLicenceNumber = "AB123456",
                    PenaltyPoints = 0
                },
                new Client
                {
                    Id= 1,
                    Name = "Julia",
                    Surname = "Robertson",
                    DateOfBirth = new DateTime(1998,03,15),
                    TelephoneNumber = "85258522",
                    DrivingLicenceNumber = "AB123456",
                    PenaltyPoints = 0
                },
                new Client
                {
                    Id= 1,
                    Name = "Mike",
                    Surname = "Tyson",
                    DateOfBirth = new DateTime(1982,03,15),
                    TelephoneNumber = "85258522",
                    DrivingLicenceNumber = "AB123456",
                    PenaltyPoints = 4
                },

            };
        }
    }
}

