namespace RentCarApp.Data.Entities
{
    public class Borrower : EntityBase
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
    }
}
