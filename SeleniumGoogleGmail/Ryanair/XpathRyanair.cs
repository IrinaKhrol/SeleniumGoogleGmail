namespace Ryanair
{
    internal static class XpathRyanair
    {
        internal const string INPUT_DEPARTURE_STATION = "//input[@id='input-button__departure']",
                              AGREE_WITH_USING_COOKIES = "//button[@data-ref='cookie.accept-all']",
                              INPUT_DESTINATION_STATION = "//input[@id='input-button__destination']",
                              INPUT_CHOOSE_DESTINATION_STATION = "//span[@data-ref='airport-item__name' and contains(text(),' ",
                              OPEN_DATE_DEPART = "//div[@data-ref='input-button__dates-from']",
                              INPUT_DATE_DEPART = "//div[@data-id='",
                              ADD_PASSENGER = "//div[@data-ref='counter.counter__increment']",
                              CONFIRM_SELECTION = "//button[@class='flight-search-widget__start-search ng-tns-c83-3 ry-button--gradient-yellow']",
                              CHOICE_SELECT = "//div[contains(@class,'card-info__cols-container ng-tns-')]",
                              CHOICE_TYPE_VALUE = "//div[@class='fare-card fare-card--primary']",
                              CHOICE_TYPE_REGULAR = "//div[@class='fare-card fare-card--secondary']",
                              CHOICE_TYPE_PLUS = "//div[@class='fare-card fare-card--tertiary']",
                              CHOICE_TYPE_FLEXI_PLUS = "//div[@class='fare-card']",
                              CHOICE_TYPE_FAMILY_PLUS = "//div[@class='fare-card fare-card--secondary-dark']",
                              CONTINUE_VALUE = "//button[@class='fare-upgrade-footer-continue_button ry-button--outline-light-blue ry-button--full']",
                              INFORMATION_ABOUT_FLIGHT = "//flights-lazy-content[@class='ng-star-inserted']",
                              BUTTON_BASKET = "//header-basket[@class='basket app-basket']",
                              INFORMATION_ABOUT_FLIGHT_IN_THE_BASKET = "//div[@class='tooltip-inner']";
    }
}
