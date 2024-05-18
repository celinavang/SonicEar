using SonicEar_Backend.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonicEar_Backend.Classes
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Enheds ID")]
        public int DeviceId { get; set; }

        [ForeignKey(nameof(DeviceId))]
        [DisplayName("Enhed")]
        public Device? Device { get; set; }

        [DisplayName("Tidspunkt")]
        public DateTime? TimeStamp { get; set; }

        [DisplayName("Måling")]
        public float NoiseLevel { get; set; }


        public void VerifyNoiseLevel()
        {
            if (NoiseLevel <= 0)
            {
                throw new ArgumentOutOfRangeException("Noise level cannot be below 0");
            }
        }

        public void Verify()
        {
            VerifyNoiseLevel();
        }

    }
}


