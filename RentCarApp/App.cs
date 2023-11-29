using RentCarApp.Data;
using RentCarApp.UserInterface.Services;

namespace RentCarApp
{
    internal class App : IApp
    {
        private readonly IUserComunication _userCommunication;
        private readonly IEventHandler _eventHandler;
        private readonly RentCarDbContext _rentCarAppDbContext;
        public App(IUserComunication userCommunication, IEventHandler eventHandler, RentCarDbContext rentCarDbContext)
        {
            _userCommunication = userCommunication;
            _eventHandler = eventHandler;
            _rentCarAppDbContext = rentCarDbContext;
            _rentCarAppDbContext.Database.EnsureCreated();
        }
        public void Run()
        {
            _eventHandler.Subscribe();
            _userCommunication.Communication();
        }
    }
}

