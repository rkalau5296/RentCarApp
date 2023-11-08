using Microsoft.Extensions.DependencyInjection;
using RentCarApp;
using RentCarApp.Components.CsvReader;
using RentCarApp.Components.DataProviders;
using RentCarApp.Data.Entities;
using RentCarApp.Data.Entities.Repositories;
using System.Formats.Asn1;

var service = new ServiceCollection();
service.AddSingleton<IApp, App>();
service.AddSingleton<IRepository<Car>, ListRepository<Car>>();
service.AddSingleton<IRepository<Client>, ListRepository<Client>>();
service.AddSingleton<IClientProvider, ClientProvider>();
service.AddSingleton<ICsvReader, CsvReader>();

var serviceProvider = service.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();

