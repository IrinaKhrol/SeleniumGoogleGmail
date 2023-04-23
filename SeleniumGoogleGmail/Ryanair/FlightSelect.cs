using static Ryanair.XpathRyanair;
using OpenQA.Selenium;

namespace Ryanair
{
    internal class FlightSelect : BasePage
    {
        public FlightSelect(IWebDriver driver, LoggerService logger) : base(driver, logger)
        {
        }

        public void ChoiceSelectFrom()
        {
            FindElementsWithWaiter(CHOICE_SELECT)[0].Click();
        }

        public void ChoiceSelectTo()
        {
            FindElementsWithWaiter(CHOICE_SELECT)[1].Click();
        }

        public void ChoiceTypeValue() 
        {
            FindElementWithWaiter(CHOICE_TYPE_VALUE).Click();
            FindElementWithWaiter(CONTINUE_VALUE).Click();
        }

        public void ChoiceTypeRegular() 
        {
            FindElementWithWaiter(CHOICE_TYPE_REGULAR).Click();
        }

        public void ChoiceTypePlus()
        {
            FindElementWithWaiter(CHOICE_TYPE_PLUS).Click();
        }

        public void ChoiceTypeFlexiPlus()
        {
            FindElementWithWaiter(CHOICE_TYPE_FLEXI_PLUS).Click();
        }

        public void ChoiceTypeFamilyPlus()
        {
            FindElementWithWaiter(CHOICE_TYPE_FAMILY_PLUS).Click();
        }

        public void GetInformationAboutFlight() 
        {
            _ = _logger.WriteLogAsync(FindElementWithWaiter(INFORMATION_ABOUT_FLIGHT).Text);
        }

        public void ChoiceButtonBasket() 
        {
            FindElementWithWaiter(BUTTON_BASKET).Click();
        }

        public void GetInformationAboutFlightInTheBasket() 
        {
            _ = _logger.WriteLogAsync(FindElementWithWaiter(INFORMATION_ABOUT_FLIGHT_IN_THE_BASKET).Text);
        }
    }
}
