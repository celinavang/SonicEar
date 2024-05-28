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
            if (Location.Length < 1)
            {
                throw new ArgumentOutOfRangeException("Location must be at least 1 char");
            }
        }

        public void Verify()
        {

            VerifyLocation();
        }
    }
}
