using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonicEar_Backend.Data;
using SonicEar_Backend.Interfaces;
using SonicEar_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicEar_BackendTests.Models
{
    [TestClass()]
    public class DeviceRepositoryTests
    {
        private IDevicesRepository _devicesRepository;

        [TestInitialize]
        public void TestInitialize(IDevicesRepository devicesRepository) 
        {
        }

        [TestMethod()]
        public void CreateDeviceTest()
        {
            int currentCount = _devicesRepository.GetAll(null).Count();
            Device d1 = new Device { Location = "Lokale 3" };
            Assert.AreEqual(_devicesRepository.Create(d1).Location, "Lokale 3");
            Assert.AreEqual(_devicesRepository.GetAll(null).Count(), currentCount + 1);
        }
    }
}
