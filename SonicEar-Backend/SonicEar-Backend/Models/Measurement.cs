using System.ComponentModel.DataAnnotations;

namespace SonicEar_Backend.Classes
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public int DeviceId { get; set; }
        // Not implemented foreign key device 08/05-24
        public DateTime TimeStamp { get; set; }
        public float NoiseLevel { get; set; }



        public void VerifyDeviceId()
        {
            if (DeviceId == 0 || DeviceId == null) 
            {
                throw new ArgumentNullException("Device Id cannot be 0 or null");
            }
        }

        public void VerifyNoiseLevel()
        {
            if (NoiseLevel <= 0)
            {
                throw new ArgumentOutOfRangeException("Noise level cannot be below 0");
            }
        }

       

        public void Verify()
        {
            VerifyDeviceId();
            VerifyNoiseLevel();
        }

    }
}


