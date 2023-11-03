using System.Drawing;
using System.Text;

namespace RentCarApp.Entities
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public int PenaltyPoints { get; set; }        

        #region ToString Override
        public override string ToString()
        {
            StringBuilder sb = new(1024);
            sb.AppendLine($"{Name} {Surname} ID: {Id}");
            sb.AppendLine($"    DateOfBirth: {DateOfBirth.ToString("yyyy.MM.dd")}  TelephoneNumber: {TelephoneNumber}");
            sb.AppendLine($"    DrivingLicenceNumber: {DrivingLicenceNumber}  PenaltyPoints: {PenaltyPoints}");
            
            return sb.ToString();
        }
    }
    #endregion
}

