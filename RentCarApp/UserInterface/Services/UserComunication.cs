using RentCarApp.Data.Entities;
using RentCarApp.Data.Entities.Repositories;

namespace RentCarApp.UserInterface.Services
{
    public class UserComunication : IUserComunication
    {
        private readonly IRepository<Car> _carRepository;        

        public UserComunication(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;            
        }
        public void Communication()
        {
            Console.WriteLine("Welcome to the RentACar program.The program stores information about cars and clients.");
            Console.WriteLine("====================================================================");
            Console.WriteLine();

            bool isCloseApp = false;
            while (!isCloseApp)
            {
                Console.WriteLine("1 - View all cars.");
                Console.WriteLine("2 - Add new car.");
                Console.WriteLine("3 - Remove car.");
                Console.WriteLine("4 - Find car by id.");
                Console.WriteLine("Q - Close App.");

                CheckCars();

                var userInput = GetInputFromUser("Chose key: ").ToUpper();

                switch (userInput)
                {
                    case "1":
                        ReadAllCars();
                        break;
                    case "2":
                        AddCars();
                        break;
                    case "3":
                        DeleteCar();
                        break;
                    case "4":
                        FindCarByID("Enter the number of books to display (intiger): ");
                        break;
                    case "Q":
                        isCloseApp = true;
                        break;

                    default:
                        Console.WriteLine("Invalid operation.");
                        continue;
                }
            }
        }
        private void CheckCars()
        {
            if (!_carRepository.GetAll().Any())
            {
                Console.WriteLine("List cars is empty.");
            }
        }
        private string GetInputFromUser(string comment)
        {
            Console.Write(comment);
            var userInput = Console.ReadLine();
            return userInput;
        }
        private T GetValueFromUser<T>(string comment) where T : struct
        {
            while (true)
            {
                var input = GetInputFromUser(comment);

                try
                {
                    if (typeof(T) == typeof(int))
                    {
                        return (T)(object)int.Parse(input);
                    }
                    else if (typeof(T) == typeof(double))
                    {
                        return (T)(object)double.Parse(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter correct value.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter correct value.");
                }
            }
        }
        private void ReadAllCars()
        {
            var carsFromDb = _carRepository.GetAll();

            foreach (var carFromDb in carsFromDb)
            {
                Console.WriteLine($"\t{carFromDb.Brand}: {carFromDb.Model}");
            }
        }
        private void AddCars()
        {
            Car car = new()
            {
                Model = GetInputFromUser("Enter the brand of the car: "),
                Brand = GetInputFromUser("Enter the model of the car: ")
            };

            _carRepository.Add(car);
            _carRepository.Save();
        }
        private Car? FindCarByID(string comment)
        {
            var userInput = GetValueFromUser<int>(comment);

            var entity = _carRepository.GetById((int)userInput);
            if (entity != null)
            {
                Console.WriteLine(entity.ToString());
            }

            return entity;
        }
        private void DeleteCar()
        {
            var car = FindCarByID("Enter the id of the car to be deleted: ");
            if (car != null)
            {
                while (true)
                {
                    Console.WriteLine($"Do you really want to remove this {car.Brand}?");
                    var choice = GetInputFromUser("Press Y if YES or N if NO").ToUpper();
                    if (choice == "Y")
                    {
                        _carRepository.Remove(car);
                        break;
                    }
                    else if (choice == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please choose Y or N:");
                    }
                }
            }
        }
    }
}
