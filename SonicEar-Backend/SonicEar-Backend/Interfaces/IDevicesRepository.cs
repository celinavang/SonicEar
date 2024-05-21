using SonicEar_Backend.Models;



namespace SonicEar_Backend.Interfaces
{
    public interface IDevicesRepository 
    {
        // Interface for DevicesRepository
        public List<Device> GetAll(string sortBy);
        public Device GetById (int id);
        public Device Create(Device device);
        public Device Update(Device device, int id);
        public Device Delete(int id);
    }
}
