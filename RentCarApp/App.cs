using RentCarApp.Components.CsvReader;
using RentCarApp.Components.CsvReader.Models;
using System.Xml.Linq;

namespace RentCarApp
{
    internal class App : IApp
    {
        private readonly ICsvReader _csvReader;
        public App(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }
        public void Run()
        {
            List<Car> records = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");
            //var manufacturers = _csvReader.ProcessManufacturer(@"Resources\Files\manufacturers.csv");

            XDocument document = new();
            XElement cars = new("Cars", 
                records
                .Select(x => 
                    new XElement("Car", 
                        new XAttribute("Name", x.Name),
                        new XAttribute("Combined", x.Combined),
                        new XAttribute("Mnufacturer", x.Manufacturer))));
            document.Add(cars);
            document.Save("fuel.xml");
        }
    }
}

