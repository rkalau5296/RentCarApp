using RentCarApp.Data.Entities.Repositories;
using RentCarApp.Data.Entities;

namespace RentCarApp.UserInterface.Services
{
    internal class EventHandler : IEventHandler
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Client> _clientOwnerRepository;

        public EventHandler(IRepository<Car> bookRepository, IRepository<Client> clientOwnerRepository)
        {
            _carRepository = bookRepository;
            _clientOwnerRepository = clientOwnerRepository;
        }

        public void Subscribe()
        {
            _carRepository.ItemAdded += OnItemAddedSubscribeEvent;
            _carRepository.ItemRemoved += OnItemRemovedSubscribeEvent;
            _clientOwnerRepository.ItemAdded += OnItemAddedSubscribeEvent;
            _clientOwnerRepository.ItemRemoved += OnItemRemovedSubscribeEvent;
        }

        static void OnItemRemovedSubscribeEvent(object? sender, IEntity e)
        {
            if (sender is not null)
            {
                var senderName = sender.GetType().Name;
                SaveToLogFile($"{senderName.Substring(0, senderName.Length - 2)}", $"{e.GetType().Name}Removed", e.ToString() ?? "");
            }
        }

        static void OnItemAddedSubscribeEvent(object? sender, IEntity e)
        {
            if (sender is not null)
            {
                var senderName = sender.GetType().Name;
                SaveToLogFile($"{senderName.Substring(0, senderName.Length - 2)}", $"{e.GetType().Name}Added", e.ToString() ?? "");
            }
        }

        static void SaveToLogFile(string repositoryType, string action, string comment)
        {
            using (var writer = File.AppendText($"RentCarAppLog.txt"))
            {
                writer.WriteLine($"[{DateTime.Now}]-{repositoryType}-{action}-[{comment}]");
            }
        }
    }
}
