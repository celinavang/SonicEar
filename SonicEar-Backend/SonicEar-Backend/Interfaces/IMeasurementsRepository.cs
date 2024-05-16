using SonicEar_Backend.Classes;

namespace SonicEar_Backend.Interfaces
{
    public interface IMeasurementsRepository
    {
        public List<Measurement> GetAll();
        public Measurement? GetById (int id);
        public List<Measurement> GetByDevice (int deviceId);
        //public List <Measurement> GetByDate (DateTime date);
        public Measurement Create(Measurement measurement);
        public Measurement? Update(Measurement measurement, int id);
        public Measurement? Delete(int id);
        


    }
}
