using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class AccountUsingPageObjectPatternTests
    {
        private ChromeDriver _driver;

        [TestInitialize]
        public void Setup()
        {
            string chromeDriverDirectory = string.Format(@"{0}\..\..\..\tools", Directory.GetCurrentDirectory());
            this._driver = new ChromeDriver(chromeDriverDirectory);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this._driver.Quit();
        }

        [TestMethod]
        public void Can_Register_User()
        {
            RegisterPage registerPage = new RegisterPage(this._driver)
            .Navigate()
            .EnterUsername(string.Format("testuser{0}", DateTime.Now.Ticks))
            .EnterPassword("P@ssw0rd")
            .EnterConfirmPassword("P@ssw0rd");

            HomePage homePage = registerPage.Submit();

            Assert.IsNotNull(homePage);
            Assert.IsTrue(homePage.LoggedIn);
        }

        [TestMethod]
        public void Cannot_Register_User_With_Empty_Username()
        {
            RegisterPage registerPage = new RegisterPage(this._driver)
            .Navigate()
            .EnterUsername(string.Empty)
            .EnterPassword("P@ssw0rd")
            .EnterConfirmPassword("P@ssw0rd");

            HomePage homePage = registerPage.Submit();

            Assert.IsNull(homePage);
            Assert.AreEqual("The User name field is required.", registerPage.ErrorMessage);
        }
    }
}