namespace RentCarApp.Entities
{
    public class Car : EntityBase
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }        
        public override string ToString() => $"Id: {Id}, Brand: {Brand}, Model: {Model}.";
    }
}
