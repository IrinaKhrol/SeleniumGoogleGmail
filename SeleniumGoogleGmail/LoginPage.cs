using OpenQA.Selenium;

namespace SeleniumGoogleGmail
{
    public class LoginPage : HomePage
    {
        const string SITE_LOGIN_EMAIL_XPATH = "//input[@type='email']";
        const string SITE_LOGIN_NEXT_XPATH = "//div[@id='identifierNext']";
        const string SITE_LOGIN_PASSWORD_XPATH = "//input[@type='password']";
        const string SITE_LOGIN_PASSWORD_NEXT_XPATH = "//div[@id='passwordNext']";



        public LoginPage(IWebDriver driverGoogle) : base(driverGoogle)
        {

        }

        public void InputEmailInLogin(string address)
        {
            _driverGoogle.Manage().Cookies.DeleteCookieNamed("ACCOUNT_CHOOSER");
            _driverGoogle.Navigate().Refresh();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_LOGIN_EMAIL_XPATH)));
            var emailInput = _driverGoogle.FindElement(By.XPath(SITE_LOGIN_EMAIL_XPATH));
            emailInput.Click();
            emailInput.SendKeys(address);
            _driverGoogle.FindElement(By.XPath(SITE_LOGIN_NEXT_XPATH)).Click();
        }

        public void InputPasswordInLogin(string password)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_LOGIN_PASSWORD_XPATH)));
            var passwordInput = _driverGoogle.FindElement(By.XPath(SITE_LOGIN_PASSWORD_XPATH));
            passwordInput.Click();
            passwordInput.SendKeys(password);
            _driverGoogle.FindElement(By.XPath(SITE_LOGIN_PASSWORD_NEXT_XPATH)).Click();
        }
    }
}
