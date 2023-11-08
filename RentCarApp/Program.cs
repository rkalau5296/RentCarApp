using Microsoft.Extensions.DependencyInjection;
using RentCarApp;
using RentCarApp.Components.DataProviders;
using RentCarApp.Data.Entities;
using RentCarApp.Data.Entities.Repositories;

var service = new ServiceCollection();
service.AddSingleton<IApp, App>();
service.AddSingleton<IRepository<Car>, ListRepository<Car>>();
service.AddSingleton<IRepository<Client>, ListRepository<Client>>();
service.AddSingleton<IClientProvider, ClientProvider>();

var serviceProvider = service.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();

