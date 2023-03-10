using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGoogleGmail
{
    public class HomePage
    {
        protected IWebDriver _driverGoogle;

        const string SITE_EMAIL_XPATH = "//a[@data-action='sign in']";

        protected WebDriverWait _wait;


        public HomePage(IWebDriver driverGoogle)
        {
            _driverGoogle = driverGoogle;
            _driverGoogle.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driverGoogle, TimeSpan.FromSeconds(3000));
        }

        public void GoToUrl(string url)
        {
            _driverGoogle.Navigate().GoToUrl(url);
        }

        public void OpenLoginPage()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_EMAIL_XPATH)));
            _driverGoogle.FindElement(By.XPath(SITE_EMAIL_XPATH)).Click();
        }
    }
}
