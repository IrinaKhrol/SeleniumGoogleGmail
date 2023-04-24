using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGoogleGmail
{
    public class AccountMail : BasePage
        {
            IList<IWebElement> listLetters;
            const int STOPWATCH = 60000;

            public AccountMail(IWebDriver _driverGoogle) : base(_driverGoogle)
            {

            }
            public string GetUserName()
            {
                SwithToFrame();
                return FindElementWithWaiter(XPathGmail.SITE_USER_NAME_XPATH).Text;
            }

            public void OpenMoreMenu()
            {
                FindElementWithWaiter(XPathGmail.SITE_MENU_BUTTON_MORE_XPATH).Click();
            }

            public void OpenDraftPage()
            {
                FindElementsWithWaiter(XPathGmail.SITE_ALL_MENU_XPATH)[7].Click();
            }

            public void WaitLetterWithTermAndText(string termLetter, string textLetter)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while ((CHeckTermLetter() != termLetter && CheckTextLetter() != textLetter) | stopwatch.ElapsedMilliseconds > STOPWATCH)
                {
                    FindElementWithWaiter(XPathGmail.SITE_RELOAD_MAIL_XPATH).Click();
                }
                stopwatch.Stop();
            }

            public void WaitLetterWithTerm(string termLetter)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while (CHeckTermLetter() != termLetter | stopwatch.ElapsedMilliseconds > STOPWATCH)
                {
                    FindElementWithWaiter(XPathGmail.SITE_RELOAD_MAIL_XPATH).Click();
                }
                stopwatch.Stop();
            }

            public void OpenFirstLetter()
            {
                listLetters = FindElementsWithWaiter(XPathGmail.SITE_OPEN_FIRST_LETTER_XPATH);
                listLetters[0].Click();
            }

            public string CHeckTermLetter()
            {
                try { return FindElementWithWaiter(XPathGmail.CHECK_TERM_XPATH).Text; }
                catch { return "no letter"; }
            }

            public string CheckTextLetter()
            {
                try
                {
                    var textLetter = FindElementWithWaiter(XPathGmail.CHECK_TEXT_XPATH).Text;
                    return textLetter.Substring(5);
                }
                catch { return "no text"; }
            }

            public string GetTextDraftLetter()
            {
                return FindElementWithWaiter(XPathGmail.SITE_TERM_DREFT_LETTER).Text;
            }

            public int GetCounterNewLetter()
            {
                try
                {
                    var countOfNewLetter = FindElementWithWaiter(XPathGmail.SITE_EMAIL_COUNTER_NEW_LETTER_XPATH).Text;
                    int countNewletter = Int32.Parse(countOfNewLetter);
                    return countNewletter;
                }
                catch
                {
                    return 0;
                }
            }

            public Letter OpenNewLetter()
            {
                FindElementWithWaiter(XPathGmail.SITE_OPEN_NEW_LETTER_XPATH).Click();
                return new Letter(_driverGoogle);
            }

            public Letter OpenAnswerLetter()
            {
                FindElementWithWaiter(XPathGmail.SITE_LETTER_ANSWER_XPATH).Click();
                return new Letter(_driverGoogle);
            }

            public void Exit()
            {
                try
                {
                    _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(XPathGmail.SITE_CHECK_SEND_LETTER)));
                    SwithToFrame();
                    Thread.Sleep(800);
                    FindElementsWithWaiter(XPathGmail.SITE_ACCOUNT_EXIT_XPATH)[1].Click();
                }
                catch
                {
                    AcceptAlert();
                }
            }
        }
}
