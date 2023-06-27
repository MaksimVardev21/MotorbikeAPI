namespace MotorbikeAPI.Data
{
    public class Motorbike
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public double EngineCapacity { get; set; }
        public double RentalPrice { get; set; }
        public bool Availability { get; set; }
        public string Location { get; set; }
    }
}
