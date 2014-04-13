using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
        }

        [TestMethod]
        public void Can_Register_User()
        {
            string chromeDriverDirectory = string.Format(@"{0}\..\..\..\tools", Directory.GetCurrentDirectory());

            IWebDriver driver = new ChromeDriver(chromeDriverDirectory);
            driver.Navigate().GoToUrl("http://localhost:64872/Account/Register");

            string username = string.Format("testuser{0}", DateTime.Now.Ticks);

            IWebElement userNameField = driver.FindElement(By.Id("UserName"));
            userNameField.SendKeys(username);

            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("P@ssw0rd");

            IWebElement confirmPassword = driver.FindElement(By.Id("ConfirmPassword"));
            confirmPassword.SendKeys("P@ssw0rd");

            IWebElement registerButton = driver.FindElement(By.ClassName("btn"));
            registerButton.Click();

            IWebElement loginName = driver.FindElement(By.LinkText(string.Format("Hello {0}!", username)));

            Assert.IsTrue(loginName.Displayed);

            driver.Quit();
        }

        [TestMethod]
        public void Cannot_Register_User_With_Empty_Username()
        {
            string chromeDriverDirectory = string.Format(@"{0}\..\..\..\tools", Directory.GetCurrentDirectory());

            IWebDriver driver = new ChromeDriver(chromeDriverDirectory);
            driver.Navigate().GoToUrl("http://localhost:64872/Account/Register");

            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("P@ssw0rd");

            IWebElement confirmPassword = driver.FindElement(By.Id("ConfirmPassword"));
            confirmPassword.SendKeys("P@ssw0rd");

            IWebElement registerButton = driver.FindElement(By.ClassName("btn"));
            registerButton.Click();

            ReadOnlyCollection<IWebElement> errorMessages = driver.FindElements(By.XPath("//div[@class='validation-summary-errors']/ul/li"));

            IWebElement errorMessage = errorMessages.FirstOrDefault();

            Assert.IsNotNull(errorMessage);
            Assert.AreEqual("The User name field is required.", errorMessage.Text);

            driver.Quit();
        }
    }
}