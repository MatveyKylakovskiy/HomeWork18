using OpenQA.Selenium;
using PageObjLib.Factories;
using PageObjLib.Page;
using SeleniumExtras.WaitHelpers;

namespace HomeWork18.WebElements
{
    internal static class Checkboxes
    {
        private static string _url = "https://the-internet.herokuapp.com/checkboxes";
        private static string _CheckBoxXpath = "//input[@type='checkbox']";

        private static List<IWebElement> ListOFCheckBox()
        {
            var elements = Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(_CheckBoxXpath)));
            return elements.ToList();
        }

        private static bool IsChecked(int itemNumber)
        {
            if (IsCheckedHelper(itemNumber) == "null")
            {
                return false;
            }

            else if (IsCheckedHelper(itemNumber) == "true")
            {
                return true;
            }

            else 
            {
                return false; 
            }
        }
        private static string IsCheckedHelper(int itemNumber) => ListOFCheckBox()[itemNumber - 1].GetAttribute("checked");

        
        public static bool GetStatus(int itemNumber)
        {
            Page.GoUrl(_url);
            return IsChecked(itemNumber);
        }

        public static bool GetSatusAfterClick(int itemNumber)
        {
            Page.GoUrl(_url);
            ListOFCheckBox()[itemNumber-1].Click();
            return IsChecked(itemNumber);
        }
    }
}
