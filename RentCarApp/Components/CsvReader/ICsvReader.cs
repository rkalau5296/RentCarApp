using RentCarApp.Components.CsvReader.Models;

namespace RentCarApp.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Car> ProcessCars(string filePath);
        List<Manufacturer> ProcessManufacturer(string filePath);
    }
}
