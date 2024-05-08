namespace SonicEar_Backend.Models
{
    public class DevicesRepository
    {
        
        private readonly List<Device> _devices;

        public DevicesRepository()
        {
            _devices = new List<Device>();
        }

        public Device Create(Device device)
        {
            _devices.Add(device);
            return device;
        }

        public List<Device> GetAll()
        {
            return new List<Device>(_devices);
        }

        public Device? GetById(int id)
        {
            return _devices.FirstOrDefault(d => d.Id == id);
        }

        public Device? Update(Device device, int id)
        {
            Device? deviceToUpdate = _devices.FirstOrDefault(d => d.Id == id);
            if (deviceToUpdate != null)
            {
                deviceToUpdate.Location = device.Location;
            }
            return deviceToUpdate;
        }

        public Device Delete(int id)
        { 
            Device? device = _devices.Find(d => d.Id == id);
            if (device != null)
            {
                _devices.Remove(device);
            }
            return device;
        }
    }
}
