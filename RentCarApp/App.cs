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
            CreateXml();
            QueryXml();
        }
        private void CreateXml()
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
                        new XAttribute("Manufacturer", x.Manufacturer))));
            document.Add(cars);
            document.Save("fuel.xml");
        }
        private void QueryXml()
        {
            var document = XDocument.Load("fuel.xml");
            var names = document
                .Element("Cars")?
                .Elements("Car")
                .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
                .Select(x => x.Attribute("Name")?.Value);
                
            foreach ( var name in names)
            {
                Console.WriteLine(name);
            }
            
        }
    }
}

