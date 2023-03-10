using OpenQA.Selenium;

namespace SeleniumGoogleGmail
{
    public class MailPage : LoginPage
    {
        IList<IWebElement> loginOut;
        IList<IWebElement> letter;

        const string SITE_RELOAD_XPATH = "//div[@class='T-I J-J5-Ji nu T-I-ax7 L3']";
        const string SITE_MASSAGE_EMAIL_XPATH = "//div[@class='T-I T-I-KE L3']";
        const string SITE_MASSAGE_WHOM_XPATH = "//input[@peoplekit-id='BbVjBd']";
        const string SITE_ACCOUNT_TERM_XPATH = "//input[@name='subjectbox']";
        const string SITE_NEW_LETTER_TEXT_XPATH = "//div[@class='Am Al editable LW-avf tS-tW']";
        const string SITE_SEND_MASSAGE_XPATH = "//td[@class='gU Up']";
        const string SITE_ACCOUNT_BUTTON_XPATH = "//a[@class='gb_e gb_1a gb_s']";
        const string SITE_ACCOUNT_OPEN_LETTER_XPATH = "//tr[@role='row']";
        const string SITE_ACCOUNT_OPEN_TERM_XPATH = "//h2[@class='hP']";
        const string SITE_ACCOUNT_OPEN_TEXT_XPATH = "//div[@class='a3s aiL ']/div[1]";
        const string SITE_LETTER_ANSWER_XPATH = "//span[@class='ams bkH']";
        const string SITE_LETTER_ANSWER_TEXT_XPATH = "//div[@class='Am aO9 Al editable LW-avf tS-tW']";
        const string SITE_SEND_ANSWER_LETTER_XPATH = "//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']";
        const string SITE_ACCOUNT_EXIT_XPATH = "//div[@class='SedFmc']";

        public MailPage(IWebDriver driverGoogle) : base(driverGoogle)
        {

        }

        public void NewWriteLetter()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(SITE_MASSAGE_EMAIL_XPATH)));
            _driverGoogle.FindElement(By.XPath(SITE_MASSAGE_EMAIL_XPATH)).Click();
        }

        public void NewWriteLetterWhom(string address)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_MASSAGE_WHOM_XPATH)));
            var addressLetter = _driverGoogle.FindElement(By.XPath(SITE_MASSAGE_WHOM_XPATH));
            addressLetter.SendKeys(address);
        }

        public void TheTermLetter(string term)
        {
            var termLetter = _driverGoogle.FindElement(By.XPath(SITE_ACCOUNT_TERM_XPATH));
            termLetter.SendKeys(term);
        }

        public void NewLetterText(string text)
        {
            _driverGoogle.FindElement(By.XPath(SITE_NEW_LETTER_TEXT_XPATH)).SendKeys(text);

        }

        public void SendLetter()
        {
            _driverGoogle.FindElement(By.XPath(SITE_SEND_MASSAGE_XPATH)).Click();
        }

        public void ReloadPage()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_RELOAD_XPATH)));
            _driverGoogle.FindElement(By.XPath(SITE_RELOAD_XPATH)).Click();
        }

        public void OpenFirstLetter()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_ACCOUNT_OPEN_LETTER_XPATH)));
            letter = _driverGoogle.FindElements(By.XPath(SITE_ACCOUNT_OPEN_LETTER_XPATH));
            letter[0].Click();
        }

        public string OpenTermLetter()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_ACCOUNT_OPEN_TERM_XPATH)));
            var termOpen = _driverGoogle.FindElement(By.XPath(SITE_ACCOUNT_OPEN_TERM_XPATH)).Text;
            return termOpen;
        }


        public string OpenTextLetter()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_ACCOUNT_OPEN_TEXT_XPATH)));
            var textOpen = _driverGoogle.FindElement(By.XPath(SITE_ACCOUNT_OPEN_TEXT_XPATH)).Text;
            return textOpen;

        }

        public void AnswerLetter()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(SITE_LETTER_ANSWER_XPATH)));
            _driverGoogle.FindElement(By.XPath(SITE_LETTER_ANSWER_XPATH)).Click();
        }

        public void PrintAnswerText(string text)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_LETTER_ANSWER_TEXT_XPATH)));
            _driverGoogle.FindElement(By.XPath(SITE_LETTER_ANSWER_TEXT_XPATH)).SendKeys(text);
        }

        public void SendAnswerLetter()
        {
            _driverGoogle.FindElement(By.XPath(SITE_SEND_ANSWER_LETTER_XPATH)).Click();
        }

        public void Exit()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SITE_ACCOUNT_BUTTON_XPATH)));
            _driverGoogle.FindElement(By.XPath(SITE_ACCOUNT_BUTTON_XPATH)).Click();

            _driverGoogle.SwitchTo().Frame("account");
            loginOut = _driverGoogle.FindElements(By.XPath(SITE_ACCOUNT_EXIT_XPATH));
            loginOut[1].Click();
        }
    }
}
