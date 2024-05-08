namespace SonicEar_Backend.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string? Location { get; set; }

        public override string ToString()
        {
            return $"Device: {Id}, Location: {Location}";
        }

        public void VerifyLocation()
        {
            if (Location == null)
            {
                throw new ArgumentNullException("Location cannot be null");
            }
        }
    }
}
