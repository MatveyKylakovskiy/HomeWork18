using PageObjLib.Factories;
using PageObjLib.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using HomeWork18.Helpers;

namespace HomeWork18.WebElements
{
    internal static class Typos
    {
        private const string _url = "https://the-internet.herokuapp.com/typos";
        private static IWebElement webText = Page.GetElement(By.XPath("//div//p[2]"));

        public static bool SpellCheck()
        {   
            Page.GoUrl(_url);

            return CheckerTypos.IsDispayed("Sometimes you'll see a typo, other times you won't.");
        }
    }
}
