using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentCarApp;
using RentCarApp.Components.CsvReader;
using RentCarApp.Components.DataProviders;
using RentCarApp.Data;
using RentCarApp.Data.Entities;
using RentCarApp.Data.Entities.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<IRepository<Client>, ListRepository<Client>>();
services.AddSingleton<IClientProvider, ClientProvider>();
services.AddSingleton<ICsvReader, CsvReader>();

services.AddDbContext<RentCarDbContext>(options => options
.UseSqlServer("Server=DESKTOP-6QU5KCP;Database=RentCarDb;Trusted_Connection=True; TrustServerCertificate=True;"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();

