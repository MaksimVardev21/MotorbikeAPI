using System.Security.Cryptography.X509Certificates;

namespace MotorbikeAPI.Data
{
    public class RentalBooking
    {
        public int Id { get; set; }

         public int MotorbikeID { get; set; }
         public virtual Motorbike MotorbikeName { get; set; }
        
         public int Userid { get; set; }
         public virtual User UserName { get; set; }
 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 

        public double TotalPrice { get; set; }
        public string Status { get; set; }

    }
}
