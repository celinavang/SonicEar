using SonicEar_Backend.Data;
using SonicEar_Backend.Interfaces;

namespace SonicEar_Backend.Models
{
    public class DevicesRepository : IDevicesRepository
    {
        private static readonly List<Device> Data = new()
        {

        };
        
        // Vi opretter en liste af devices 
        // private readonly List<Device> _devices;

        protected readonly ApplicationDbContext _context;

        // Constructor
        public DevicesRepository(ApplicationDbContext context)
        {
            // _devices = new List<Device>();
            _context = context;
        }

        // Create metode
        public Device Create(Device device)
        {
            device.Verify();
            _context.Devices.Add(device);
            _context.SaveChanges();
            return device;
        }

        // GetAll metode, der returnerer listen af devices
        public List<Device> GetAll(string sortBy = null)
        {
            List<Device> devices = new(Data);
            
            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "id":
                        devices = devices.OrderBy(d => d.Id).ToList();
                        break;
                   
                }
            }
            return devices;

            //return new List<Device>(_context.Devices);
        }

        // GetById metode, der returnerer et device ud fra et id
        public Device? GetById(int id)
        {
            return _context.Devices.FirstOrDefault(d => d.Id == id);
        }

        // Update metode, der opdaterer et device ud fra et id
        public Device? Update(Device device, int id)
        {
            device.Verify();
            Device? deviceToUpdate = _context.Devices.FirstOrDefault(d => d.Id == id);
            if (deviceToUpdate != null)
            {
                deviceToUpdate.Location = device.Location;
                _context.Devices.Update(deviceToUpdate);
                _context.SaveChanges();
            }
            return deviceToUpdate;
        }

        // Delete metode, der sletter et device ud fra et id
        public Device Delete(int id)
        { 
            Device? device = _context.Devices.FirstOrDefault(d => d.Id == id);
            if (device != null)
            {
                _context.Devices.Remove(device);
                _context.SaveChanges();
            }
            return device;
        }
    }
}
