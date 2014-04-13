using OpenQA.Selenium;

namespace SeleniumDemo.Tests
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public bool LoggedIn
        {
            get
            {
                IWebElement loginName = this._driver.FindElement(By.PartialLinkText("Hello"));
                return loginName.Displayed;
            }
        }
    }
}