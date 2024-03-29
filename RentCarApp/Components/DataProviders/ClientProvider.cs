﻿using RentCarApp.Data.Entities;
using RentCarApp.Data.Entities.Repositories;
using System.Text;

namespace RentCarApp.Components.DataProviders
{
    public class ClientProvider : IClientProvider
    {
        private readonly IRepository<Client> _clientsRepository;

        public ClientProvider(IRepository<Client> clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
        public string AnonymousCLass()
        {

            var clients = _clientsRepository.GetAll().Select(client => new
            {
                Identifier = client.Id,
                ClientName = client.Name,
                ClientSurname = client.Surname,
                ClientDateOfBirth = client.DateOfBirth,
                ClientTelephoneNumber = client.TelephoneNumber,
                ClientDrivingLicenceNumber = client.DrivingLicenceNumber,
                ClientPenaltyPoints = client.PenaltyPoints
            }).ToList();

            StringBuilder sb = new();
            foreach (var client in clients)
            {
                sb.AppendLine($"Product Identifier: {client.Identifier}");
                sb.AppendLine($"    Product ClientName: {client.ClientName}");
                sb.AppendLine($"    Product ClientSurname: {client.ClientSurname}");
                sb.AppendLine($"    Product ClientDateOfBirth: {client.ClientDateOfBirth}");
                sb.AppendLine($"    Product ClientTelephoneNumber: {client.ClientTelephoneNumber}");
                sb.AppendLine($"    Product ClientDrivingLicenceNumber: {client.ClientDrivingLicenceNumber}");
                sb.AppendLine($"    Product ClientPenaltyPoints: {client.ClientPenaltyPoints}");

            }
            return sb.ToString();
        }
        public decimal GetTheYoungestClient()
        {
            return _clientsRepository.GetAll().Max(c => c.DateOfBirth.Year);
        }
        public List<Client> OrderBySurnameAndAge()
        {
            return _clientsRepository.GetAll().OrderBy(x => x.Surname).ThenBy(x => x.DateOfBirth.Year).ToList();
        }
        public List<Client> OrderBySurnameAndAgeDesc()
        {
            return _clientsRepository.GetAll().OrderByDescending(x => x.Surname).ThenBy(x => x.DateOfBirth.Year).ToList();
        }
        public List<Client> OrderByNameDescending()
        {
            return _clientsRepository.GetAll().OrderByDescending(x => x.Surname).ToList();
        }
        public List<Client> OrderByName()
        {
            return _clientsRepository.GetAll().OrderBy(x => x.Surname).ToList();
        }
        public List<Client> WhereStartsWith(string prefix)
        {
            return _clientsRepository.GetAll().Where(x => x.Surname.StartsWith(prefix)).ToList();
        }
        public List<Client> WhereStartsWithAndPenaltyPointIsGreaterThan(string prefix, int minPenaltyPoint)
        {
            return _clientsRepository.GetAll().Where(x => x.Surname.StartsWith(prefix) && x.PenaltyPoints > minPenaltyPoint).ToList();
        }
        public List<Client> WhereSurnameIs(string surname)
        {
            return _clientsRepository.GetAll().Where(c => c.Surname == surname).ToList();
        }
        public Client FirstByPenaltyPoint(int penaltyPoint)
        {
            return _clientsRepository.GetAll().First(x => x.PenaltyPoints == penaltyPoint);
        }
        public Client? FirstOrDefaultByPenaltyPoints(int penaltyPoint)
        {
            return _clientsRepository.GetAll().FirstOrDefault(x => x.PenaltyPoints == penaltyPoint);
        }
        public Client? FirstOrDefaultByPenaltyPointsWithDefault(int penaltyPoint)
        {
            return _clientsRepository.GetAll().FirstOrDefault(x => x.PenaltyPoints == penaltyPoint, new Client { Id = -1, Name = "NOT FOUND" });
        }
        public Client LastByPenaltyPoints(int penaltyPoint)
        {
            return _clientsRepository.GetAll().Last(x => x.PenaltyPoints == penaltyPoint);
        }
        public Client SingleById(int id)
        {
            return _clientsRepository.GetAll().Single(x => x.Id == id);
        }
        public Client? SingleOrDefaultById(int id)
        {
            return _clientsRepository.GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
