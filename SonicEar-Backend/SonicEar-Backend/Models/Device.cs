using System.ComponentModel.DataAnnotations;

namespace SonicEar_Backend.Models
{
    public class Device
    {
        // Properties
        [Key]
        public int Id { get; set; }
        public string? Location { get; set; }


        // ToString metode
        public override string ToString()
        {
            return $"Device: {Id}, Location: {Location}";
        }

        // VerifyLocation metode
        public void VerifyLocation()
        {
            if (Location == null)
            {
                throw new ArgumentNullException("Location cannot be null");
            }
        }

        public void Verify()
        {

            VerifyLocation();
        }
    }
}
