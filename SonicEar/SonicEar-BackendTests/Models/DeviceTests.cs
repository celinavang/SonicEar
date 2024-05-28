using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SonicEar_Backend.Models.Tests
{
    [TestClass()]
    public class DeviceTests
    {
        private readonly Device _d1 = new() { Id = 1, Location = "TestLocation" };
        private readonly Device _d2 = new() { Id = 1, Location = null };
        private readonly Device _d3 = new() { Id = 1, Location = "" };


        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            string expected = "Device: 1, Location: TestLocation";

            // Act
            string actual = _d1.ToString();

            // Assert
            Assert.AreEqual(expected, actual);

        }


        [TestMethod()]
        public void VerifyLocationTest()
        {
            // Arrange
            _d1.VerifyLocation();

            // Act & assert
            Assert.ThrowsException<ArgumentNullException>(() => _d2.VerifyLocation());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _d3.VerifyLocation());
        }
    }
}