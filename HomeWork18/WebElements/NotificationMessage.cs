using PageObjLib.Factories;
using PageObjLib.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace HomeWork18.WebElements
{
    internal static class NotificationMessage
    {
        private const string _url = "https://the-internet.herokuapp.com/notification_message_rendered";

        private static IWebElement ClicHereButton() => Page.GetElement(By.XPath("//a[text()='Click here']"));

        private static IWebElement NotifMess() => Page.GetElement(By.Id("flash"));


        public static bool CheckNotifation()
        {
            Page.GoUrl(_url);

            ClicHereButton().Click();

            return NotifMess().Text.Contains("successful");
        }
    }
}
