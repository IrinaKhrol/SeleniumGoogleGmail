using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumGoogleGmail;

namespace GoogleGmail
{
    public class Program
    {
        private static bool term;

        static void Main(string[] args)
        {

            WebDriver driverGoogle = new ChromeDriver();
            driverGoogle.Navigate().GoToUrl("https://www.google.com/intl/ru/gmail/about/");
            HomePage homePage = new HomePage(driverGoogle);
            homePage.OpenLoginPage();
            LoginPage loginPage = new LoginPage(driverGoogle);
            loginPage.InputEmailInLogin("TSelenium001");
            loginPage.InputPasswordInLogin("SELenium");

            MailPage mailPage = new MailPage(driverGoogle);
            mailPage.NewWriteLetter();
            mailPage.NewWriteLetterWhom("TSelenium007@gmail.com");
            mailPage.TheTermLetter("hello");
            mailPage.NewLetterText("How are you?");
            mailPage.SendLetter();

            Thread.Sleep(3000);
            mailPage.Exit();

            HomePage homePage1 = new HomePage(driverGoogle);
            homePage1.OpenLoginPage();
            loginPage.InputEmailInLogin("TSelenium007");
            loginPage.InputPasswordInLogin("SELenium");
            mailPage.ReloadPage();
            mailPage.OpenFirstLetter();
            Console.WriteLine(term);
            var textLetter = mailPage.OpenTextLetter();
            Console.WriteLine(textLetter);
            mailPage.AnswerLetter();
            mailPage.PrintAnswerText("bye");
            mailPage.SendAnswerLetter();

            Thread.Sleep(3000);
            mailPage.Exit();


            loginPage.InputEmailInLogin("TSelenium001");
            loginPage.InputPasswordInLogin("SELenium");
            mailPage.ReloadPage();
            mailPage.OpenFirstLetter();
            var term2 = mailPage.OpenTermLetter();
            mailPage.OpenTextLetter();

            Thread.Sleep(3000);
            mailPage.Exit();
            driverGoogle.Close();
        }
    }
}