namespace MotorbikeAPI.Data
{
    public class Rating
    {
        public int Id { get; set; }

        public int Motorbikeid { get; set; }
        public virtual Motorbike MotorbikeModel { get; set; }

        public int Userid { get; set; }
        public virtual User UserName { get; set; }

        public int Value { get; set; }
    }
}
