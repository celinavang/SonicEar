using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonicEar_Backend.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicEar_Backend.Classes.Tests
{
    [TestClass()]
    public class MeasurementTests
    {

        private readonly Measurement _m1 = new() { Id = 1, DeviceId = 1, NoiseLevel = 50, TimeStamp = DateTime.Now };
        private readonly Measurement _m3 = new() { Id = 1, DeviceId = 1, NoiseLevel = -50, TimeStamp = DateTime.Now };
        private readonly Measurement _m4 = new() { Id = 1, DeviceId = 1, NoiseLevel = 0, TimeStamp = DateTime.Now };
        private readonly Measurement _m5 = new() { Id = 1, DeviceId = 1, NoiseLevel = 50 };



        [TestMethod()]
        public void VerifyNoiseLevelTest()
        {
           _m1.VerifyNoiseLevel();
           Assert.ThrowsException<ArgumentOutOfRangeException>(() => _m3.VerifyNoiseLevel());
           Assert.ThrowsException<ArgumentOutOfRangeException>(() => _m4.VerifyNoiseLevel());

        }

    

        [TestMethod()]
        public void VerifyTest()
        {
            _m1.Verify();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _m3.Verify());

        }
    }
}