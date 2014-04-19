using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Tests
{
    public class RegisterPageUsingPageFactory
    {
        private IWebDriver _driver;
        private string _username;

#pragma warning disable 649

        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement _usernameField;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement _passwordField;

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        private IWebElement _confirmPassword;

        [FindsBy(How = How.ClassName, Using = "btn")]
        private IWebElement _registerButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='validation-summary-errors']/ul/li")]
        private IList<IWebElement> _errorMessages;

#pragma warning restore 649

        public RegisterPageUsingPageFactory(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public RegisterPageUsingPageFactory Navigate()
        {
            this._driver.Navigate().GoToUrl("http://localhost:64872/Account/Register");
            return this;
        }

        public RegisterPageUsingPageFactory EnterUsername(string username)
        {
            this._username = username;
            this._usernameField.SendKeys(username);
            return this;
        }

        public RegisterPageUsingPageFactory EnterPassword(string password)
        {
            this._passwordField.SendKeys(password);
            return this;
        }

        public RegisterPageUsingPageFactory EnterConfirmPassword(string password)
        {
            this._confirmPassword.SendKeys(password);
            return this;
        }

        public HomePage Submit()
        {
            this._registerButton.Click();

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
                IWebElement errorMessage = this._errorMessages.FirstOrDefault();
                return errorMessage == null ? string.Empty : errorMessage.Text;
            }
        }
    }
}