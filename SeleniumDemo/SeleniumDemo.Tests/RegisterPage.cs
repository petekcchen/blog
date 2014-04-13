using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace SeleniumDemo.Tests
{
    public class RegisterPage
    {
        private IWebDriver _driver;
        private string _username;

        public RegisterPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public RegisterPage Navigate()
        {
            this._driver.Navigate().GoToUrl("http://localhost:64872/Account/Register");
            return this;
        }

        public RegisterPage EnterUsername(string username)
        {
            this._username = username;
            IWebElement userNameField = this._driver.FindElement(By.Id("UserName"));
            userNameField.SendKeys(username);
            return this;
        }

        public RegisterPage EnterPassword(string password)
        {
            IWebElement passwordField = this._driver.FindElement(By.Id("Password"));
            passwordField.SendKeys(password);
            return this;
        }

        public RegisterPage EnterConfirmPassword(string password)
        {
            IWebElement confirmPassword = this._driver.FindElement(By.Id("ConfirmPassword"));
            confirmPassword.SendKeys(password);
            return this;
        }

        public HomePage Submit()
        {
            IWebElement registerButton = this._driver.FindElement(By.ClassName("btn"));
            registerButton.Click();

            if (this._driver.Url.Contains("Register"))
            {
                return null;
            }

            HomePage homePage = new HomePage(this._driver);
            return homePage;
        }

        public string ErrorMessage
        {
            get
            {
                ReadOnlyCollection<IWebElement> errorMessages = this._driver.FindElements(By.XPath("//div[@class='validation-summary-errors']/ul/li"));
                IWebElement errorMessage = errorMessages.FirstOrDefault();
                return errorMessage == null ? string.Empty : errorMessage.Text;
            }
        }
    }
}