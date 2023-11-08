namespace RentCarApp.Data.Entities
{
    public class Truck : Car
    {
        public int Id { get; set; }
        public override string ToString() => base.ToString() + " (Truck)";
    }
}
