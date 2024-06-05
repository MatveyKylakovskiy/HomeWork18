using PageObjLib.Page;
using PageObjLib.Factories;
using OpenQA.Selenium;

namespace HomeWork18.WebElements
{
    internal static class AddRemoveElements
    {
        private const string _url = "https://the-internet.herokuapp.com/add_remove_elements/";

        public static IWebElement AddElementButton() => Page.GetElement(By.XPath("//button[text()='Add Element']"));
        public static IWebElement DeleteButton() => Page.GetElement(By.XPath("//button[text()='Delete']"));
        public static int GetCountOfElements()
        {
            Page.GoUrl(_url);

            AddElementButton().Click();
            AddElementButton().Click();
            DeleteButton().Click();

        }
    }
}
