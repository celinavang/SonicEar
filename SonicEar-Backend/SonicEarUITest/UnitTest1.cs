using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using OpenQA.Selenium.Support.UI;

namespace SonicEarUITest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new EdgeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TestCleanup()
        {
            _driver.Dispose(); 
        }

        [TestMethod]
        public void TestWebsite()
        {
            //Navigating to the website
            _driver.Navigate().GoToUrl("https://localhost:7039/");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //Verifying the title of the page
            Assert.AreEqual("SonicEar", _driver.Title);

            // Finding the Login button by ID
            IWebElement login = _driver.FindElement(By.Id("loginButtonId"));

            // Clicking said button, seeing if the login button works
            login.Click();
            WebDriverWait waitt = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            
        }





    }
}
