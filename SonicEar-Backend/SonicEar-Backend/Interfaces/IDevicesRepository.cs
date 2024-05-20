﻿using SonicEar_Backend.Models;



namespace SonicEar_Backend.Interfaces
{
    public interface IDevicesRepository 
    {
        // Interface for DevicesRepository
        public Task<List<Device>> GetAllAsync();
        public Device GetById (int id);
        public Device Create(Device device);
        public Device Update(Device device, int id);
        public Device Delete(int id);
    }
}
