using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Can_Display_Register_Page()
        {
            string chromeDriverDirectory = string.Format(@"{0}\..\..\..\tools", Directory.GetCurrentDirectory());

            IWebDriver driver = new ChromeDriver(chromeDriverDirectory);
            driver.Navigate().GoToUrl("http://localhost:64872/");

            IWebElement registerLink = driver.FindElement(By.Id("registerLink"));
            registerLink.Click();

            Assert.AreEqual("http://localhost:64872/Account/Register", driver.Url);

            driver.Quit();

            //
        }
    }
}