namespace SonicEar_Backend.Models
{
    public class DevicesRepository
    {
        
        // Vi opretter en liste af devices 
        private readonly List<Device> _devices;

        // Constructor
        public DevicesRepository()
        {
            _devices = new List<Device>();
        }

        // Create metode
        public Device Create(Device device)
        {
            _devices.Add(device);
            return device;
        }

        // GetAll metode, der returnerer listen af devices
        public List<Device> GetAll()
        {
            return new List<Device>(_devices);
        }

        // GetById metode, der returnerer et device ud fra et id
        public Device? GetById(int id)
        {
            return _devices.FirstOrDefault(d => d.Id == id);
        }

        // Update metode, der opdaterer et device ud fra et id
        public Device? Update(Device device, int id)
        {
            Device? deviceToUpdate = _devices.FirstOrDefault(d => d.Id == id);
            if (deviceToUpdate != null)
            {
                deviceToUpdate.Location = device.Location;
            }
            return deviceToUpdate;
        }

        // Delete metode, der sletter et device ud fra et id
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
