using Microsoft.EntityFrameworkCore;
using SonicEar_Backend.Classes;
using SonicEar_Backend.Data;
using SonicEar_Backend.Interfaces;
using System.Globalization;

namespace SonicEar_Backend.Models
{
    public class MeasurementsRepository : IMeasurementsRepository

    {
        //private readonly List<Measurement> _measurements;
        private readonly ApplicationDbContext _context;
        private readonly IDevicesRepository _devicesRepository;
        public MeasurementsRepository(ApplicationDbContext context, IDevicesRepository devicesRepository) 
        {
            _context = context;
            _devicesRepository = devicesRepository;
            //_measurements = new List<Measurement>();
        }

        public List<Measurement> GetAll(string? sortBy)
        {
            List<Measurement> measurements = new(_context.Measurements);

            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    default:
                        break;
                    case "id_desc":
                        measurements = measurements.OrderByDescending(m => m.Id).ToList();
                        break;
                    case "time_desc":
                        measurements = measurements.OrderByDescending(m => m.TimeStamp).ToList();
                        break;
                    case "time_asc":
                        measurements = measurements.OrderBy(m => m.TimeStamp).ToList();
                        break;
                    case "noise_desc":
                        measurements = measurements.OrderByDescending(m => m.NoiseLevel).ToList();
                        break;
                    case "noise_asc":
                        measurements = measurements.OrderBy(m => m.NoiseLevel).ToList();
                        break;


                }
            }
            return measurements;
            
        }

      

        public Measurement? GetById(int id)
        {

            Measurement? result = _context.Measurements.FirstOrDefault(m => m.Id == id);
            return result;
            
        }

        public List<Measurement> GetByDevice(int deviceId)
        {
            List<Measurement> result = new List<Measurement>( _context.Measurements.Where(m => m.DeviceId == deviceId).Include(m => m.Device).ToList());
            return result;

        }

        //public List<Measurement> GetByDate(DateTime date)
        //{
        //    List<Measurement> result = new List<Measurement>(_context.Measurements.Where(m => m.TimeStamp.Date == date.Date).Include(m => m.Device).ToList());
        //    return result;
        //}

        public Measurement Create (Measurement measurement)
        {
            measurement.Verify();
            
            Device? device = _devicesRepository.GetById(measurement.DeviceId);
            if(device != null)
            {
                measurement.Device = device;
                _context.Measurements.Add(measurement);
                _context.SaveChanges();
            }


            return measurement;
        }

     

        public Measurement? Update(Measurement measurement, int id)
        {
            measurement.Verify();
            Measurement? measurementToUpdate = _context.Measurements.FirstOrDefault(m => m.Id == id);
            if (measurementToUpdate != null)
            {
                

                measurementToUpdate.DeviceId = measurement.DeviceId;
                measurementToUpdate.TimeStamp = measurement.TimeStamp;
                measurementToUpdate.NoiseLevel = measurement.NoiseLevel;
                _context.Measurements.Update(measurementToUpdate);
                _context.SaveChanges();
            }
            return measurementToUpdate;
        }

        public Measurement? Delete(int id)
        {
            Measurement? measurementToDelete = _context.Measurements.FirstOrDefault(m => m.Id == id);
            if (measurementToDelete != null)
            {
                _context.Measurements.Remove(measurementToDelete);
                _context.SaveChanges();
            }
            return measurementToDelete;
        }
    }
}
