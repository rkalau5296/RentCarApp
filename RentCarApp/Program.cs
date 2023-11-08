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

