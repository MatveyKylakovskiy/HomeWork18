using OpenQA.Selenium;
using PageObjLib.Factories;
using PageObjLib.Pages;
using SeleniumExtras.WaitHelpers;

namespace HomeWork18.Helpers
{
    internal static class CheckerTypos
    {
        private const string _url = "https://languagetool.org/ru";
        private static IWebElement _input = Page.GetElement(By.XPath("//div[@class='lt-textarea__textarea welcome-editor__textarea']"));
        public static bool IsDispayed(string text)
        {
            if (Result(text) == "")
            {
                return true;
            }

            else 
            {
                return false;
            }
        }

        public static string Result(string text)
        {
            Page.GoUrl(_url);
            _input.SendKeys(text);

            try
            {
                var element = Page.GetElement(By.XPath("//button[contains(@class, 'welcome-errors')]"));
                return element.Text;
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }
}
