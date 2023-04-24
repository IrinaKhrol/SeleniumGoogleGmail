using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumGoogleGmail
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver _driverGoogle) : base(_driverGoogle)
        {
            GoToUrl("https://www.google.com/intl/ru/gmail/about/");
        }
        public string GetNamePost()
        {
            return FindElementWithWaiter(XPathGmail.SITE_NAME_POST_XPATH).Text;
        }
        public IWebElement CheckSignInButton()
        {
            return FindElementWithWaiter(XPathGmail.SITE_EMAIL_LOGIN_XPATH);
        }
        public LoginPage OpenLoginPage()
        {
            FindElementWithWaiter(XPathGmail.SITE_EMAIL_LOGIN_XPATH).Click();
            return new LoginPage(_driverGoogle);
        }
        public AccountMail OpenAccountMailPage()
        {
            return new AccountMail(_driverGoogle);
        }
    }
}
