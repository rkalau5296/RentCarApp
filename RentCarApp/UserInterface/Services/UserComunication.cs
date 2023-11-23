using RentCarApp.Components.DataProviders;
using RentCarApp.Data.Entities;
using RentCarApp.Data.Entities.Repositories;

namespace RentCarApp.UserInterface.Services
{
    public class UserComunication : IUserComunication
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly IClientProvider _clientProvider;

        public UserComunication(IRepository<Car> carRepository, IRepository<Client> clientRepository, IClientProvider clientProvider)
        {
            _carRepository = carRepository;
            _clientRepository = clientRepository;
            _clientProvider = clientProvider;
        }

        public void Communication()
        {
            throw new NotImplementedException();
        }
    }
}
