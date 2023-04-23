using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Ryanair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebDriver driver = new ChromeDriver();
            LoggerService logger = LoggerService.GetLogger();

            HomePage home = new HomePage(driver, logger);
            home.AgreeWithUsingCookies();
            home.InputDepartureStation("Sofia");
            home.InputDestinationStation("Eindhoven");
            home.ChooseDayCurrentMonth("2023-04-30");
            home.ChooseDayCurrentMonth("2023-05-14");
            home.AddAdultPassenger(3);
            home.AddChildrenPassenger(2);
            home.ConfirmSelection();

            FlightSelect flightSelect = new FlightSelect(driver, logger);
            flightSelect.ChoiceSelectFrom();
            flightSelect.ChoiceSelectTo();
            flightSelect.ChoiceTypeFamilyPlus();
            flightSelect.GetInformationAboutFlight();
            flightSelect.ChoiceButtonBasket();
            flightSelect.GetInformationAboutFlightInTheBasket();

            driver.Close();
        }
    }
}