using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonicEar_Backend.Data;
using SonicEar_Backend.Interfaces;
using SonicEar_Backend.Models;


namespace SonicEar_BackendTests.Models
{
    [TestClass()]
    public class ApplicationUserTests
    {
        [TestMethod()]
        //Creating a unit test for the FName property - can it be used to set a value and get the same value?
        public void FNameTest()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser();
            //Act
            user.FName = "Jesper";
            //Assert
            Assert.AreEqual("Jesper", user.FName);
        }

        [TestMethod()]
        //Creating a unit test for the LName property - can it be used to set a value and get the same value?
        public void LNameTest()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser();
            //Act
            user.LName = "Nordentoft";
            //Assert
            Assert.AreEqual("Nordentoft", user.LName);
        }
    }
}
