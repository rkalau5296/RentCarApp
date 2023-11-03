using RentCarApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.DataProviders
{
    public interface IClientProvider
    {
        decimal GetTheYoungestClient();
        List<Client> OrderBySurnameAndAge();
        List<Client> OrderBySurnameAndAgeDesc();
        List<Client> OrderByNameDescending();
        List<Client> OrderByName();
        List<Client> WhereStartsWith(string prefix);
        List<Client> WhereStartsWithAndPenaltyPointIsGreaterThan(string prefix, int minPenaltyPoint);
        List<Client> WhereSurnameIs(string surname);
        Client FirstByPenaltyPoint(int penaltyPoint);
        Client? FirstOrDefaultByPenaltyPoints(int penaltyPoint);
        Client? FirstOrDefaultByPenaltyPointsWithDefault(int penaltyPoint);
        Client LastByPenaltyPoints(int penaltyPoint);
        Client SingleById(int id);
        Client? SingleOrDefaultById(int id);        
    }
}
