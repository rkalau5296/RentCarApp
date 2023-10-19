using RentCarApp.Data;
using RentCarApp.Entities;
using RentCarApp.Repositories;

var carRepository = new SqlRepoitory<Car>(new RentCarDbContext());
AddCars(carRepository);
WriteAllToConsole(carRepository);

static void AddCars(IRepository<Car> carRepository)
{
    carRepository.Add(new Car { Brand = "Fiat", Model = "Panda" });
    carRepository.Add(new Car { Brand = "Ford", Model = "Sierra" });
    carRepository.Add(new Car { Brand = "BMW", Model = "750" });
    carRepository.Add(new Car { Brand = "Dacia", Model = "Duster" });
    carRepository.Save();
}

var borrowerRepository = new SqlRepoitory<Borrower>(new RentCarDbContext());
AddBorrower(borrowerRepository);
AddLenders(borrowerRepository);
WriteAllToConsole(borrowerRepository);



static void AddBorrower(IWriteRepository<Borrower> borrowerRepository)
{
    borrowerRepository.Add(new Borrower { FirstName = "Przemek" });
    borrowerRepository.Add(new Borrower { FirstName = "Tomek" });
    borrowerRepository.Save();
}

static void AddLenders(IWriteRepository<Lender> lenderRepository)
{
    lenderRepository.Add(new Lender { FirstName = "Robert" });
    lenderRepository.Add(new Lender { FirstName = "Rafał" });
    lenderRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}