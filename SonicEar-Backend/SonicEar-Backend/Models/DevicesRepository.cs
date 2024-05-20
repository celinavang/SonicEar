using Microsoft.EntityFrameworkCore;
using SonicEar_Backend.Data;
using SonicEar_Backend.Interfaces;

namespace SonicEar_Backend.Models
{
    public class DevicesRepository : IDevicesRepository
    {
        
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
        public async Task<List<Device>> GetAllAsync()
        {
            List<Device> result = await _context.Devices.ToListAsync();
            return new List<Device>(result);
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
