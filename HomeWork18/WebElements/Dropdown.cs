using PageObjLib.Factories;
using PageObjLib.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace HomeWork18.WebElements
{
    internal static class Dropdown
    {
        private const string _url = "https://the-internet.herokuapp.com/dropdown";
        private static string _dropXpath = "//option[@value]";

        private static string[] drops = {
            "Please select an option",
            "Option 1",
            "Option 2"
        };

        private static List<IWebElement> elements()
        {
            var elements = Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(_dropXpath)));
            return elements.ToList();
        }
        private static bool IsSelectedHelper(int itemNumber) => elements()[itemNumber - 1].Text == drops[itemNumber-1];

        public static bool IsSelected()
        {
            Page.GoUrl(_url);

            if (IsSelectedHelper(1) && IsSelectedHelper(2) && IsSelectedHelper(3))
            {
                return true;
            }
            else
            { 
                return false;
            }
        }


    }
}
