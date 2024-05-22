using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace SonicEarUITest
{
    [TestClass]
    public class UnitTest1
    {

        // Providing the path to the chrome driver
        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver _driver;


        [ClassInitialize]
        // Setting up the chrome driver
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TestCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void TestWebsite()
        {
            //Navigating to the website
            _driver.Navigate().GoToUrl("https://localhost:7039/");

            //Verifying the title of the page
            Assert.AreEqual("Home page - SonicEar_Frontend", _driver.Title);

        }

    }
}