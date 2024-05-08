using SonicEar_Backend.Classes;
using SonicEar_Backend.Interfaces;

namespace SonicEar_Backend.Models
{
    public class MeasurementsRepository : IMeasurementsRepository
    {
        private readonly List<Measurement> _measurements;
        public MeasurementsRepository() 
        {
            _measurements = new List<Measurement>();
        }

        public List<Measurement> GetAll()
        {
            return new List<Measurement>(_measurements);
        }

        public Measurement? GetById(int id)
        {

            Measurement? result = _measurements.Find(m => m.Id == id);
            return result;
            
        }

        public List<Measurement> GetByDevice(int deviceId)
        {
            List<Measurement> result = new List<Measurement>( _measurements.Where(m => m.DeviceId == deviceId).ToList());
            return result;

        }

        public List<Measurement> GetByDate(DateTime date)
        {
            List<Measurement> result = new List<Measurement>(_measurements.Where(m => m.TimeStamp.Date == date.Date).ToList());
            return result;
        }

        public Measurement Create (Measurement measurement)
        {
            measurement.Verify();
            _measurements.Add(measurement);
            return measurement;
        }

     

        public Measurement? Update(Measurement measurement, int id)
        {
            measurement.Verify();
            Measurement? measurementToUpdate = _measurements.Find(m => m.Id == id);
            if (measurementToUpdate != null)
            {
                measurementToUpdate.DeviceId = measurement.DeviceId;
                measurementToUpdate.TimeStamp = measurement.TimeStamp;
                measurementToUpdate.NoiseLevel = measurement.NoiseLevel;
            }
            return measurementToUpdate;
        }

        public Measurement? Delete(int id)
        {
            Measurement? measurementToDelete = _measurements.Find(m => m.Id == id);
            if (measurementToDelete != null)
            {
                _measurements.Remove(measurementToDelete);
            }
            return measurementToDelete;
        }
    }
}
