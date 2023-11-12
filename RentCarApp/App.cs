using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using RentCarApp.Components.CsvReader;
using RentCarApp.Components.CsvReader.Models;
using System.Linq;
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
            CreateNewXml();
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
        private void CreateNewXml()
        {
            List<Car> carRecords = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");
            List<Manufacturer> manufacturersRecords = _csvReader.ProcessManufacturer(@"Resources\Files\manufacturers.csv");            

            var document = new XDocument();
            var manufacturers = new XElement("Manufacturers", manufacturersRecords
                .Select(m =>
                    new XElement("Manufacturer",
                        new XAttribute("Name", m.Name),
                        new XAttribute("Country", m.Country),
                        carRecords
                            .Where(c => c.Manufacturer == m.Name)
                            .GroupBy(c => c.Manufacturer)
                            .Select(combined =>
                            new XElement("Cars",
                                new XAttribute("country", m.Country),
                                new XAttribute("CombinedSum", combined.Sum(c => c.Combined)),
                                combined.Select(c =>
                                    new XElement("Car",
                                        new XAttribute("Name", c.Name),
                                        new XAttribute("Combined", c.Combined)
                                )))))));

            document.Add(manufacturers);
            document.Save("combined.xml");
        }
    }
}

