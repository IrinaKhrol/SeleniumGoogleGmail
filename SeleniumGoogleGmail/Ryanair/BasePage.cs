using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace Ryanair
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected Actions _action;
        protected readonly LoggerService _logger;
        const int WAITTIME = 30;

        public BasePage(IWebDriver driver, LoggerService logger)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAITTIME));
            _action = new Actions(_driver);
            _logger = logger;
        }

        protected void GoToUrl(string url)
        {
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
        }

        protected void ScrollToElementAndClick(string xPath)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            _action.MoveToElement(_driver.FindElement(By.XPath(xPath)));
            _action.Perform();
            _driver.FindElement(By.XPath(xPath)).Click();
        }
        protected void ScrollToElement(string xPath)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            _action.MoveToElement(_driver.FindElement(By.XPath(xPath)));
            _action.Perform();
        }

        protected IWebElement FindElementWithWaiter(string xpath)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        protected ReadOnlyCollection<IWebElement> FindElementsWithWaiter(string xpath)
        {
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath)));
        }
    }
}
