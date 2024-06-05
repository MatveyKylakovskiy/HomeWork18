using PageObjLib.Page;
using PageObjLib.Factories;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace HomeWork18.WebElements
{
    internal static class AddRemoveElements
    {
        private const string _url = "https://the-internet.herokuapp.com/add_remove_elements/";
        private const string _DeleteXpath = "//button[text()='Delete']";


        private static IWebElement AddElementButton() => Page.GetElement(By.XPath("//button[text()='Add Element']"));
        private static IWebElement DeleteButton() => Page.GetElement(By.XPath(_DeleteXpath));
        private static Array CountOfDelete() => Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(_DeleteXpath))).ToArray();


        public static int GetCountOfElements()
        {
            Page.GoUrl(_url);

            AddElementButton().Click();
            AddElementButton().Click();
            DeleteButton().Click();

            return CountOfDelete().Length;
        }
    }
}
