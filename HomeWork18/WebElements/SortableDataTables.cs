using PageObjLib.Factories;
using PageObjLib.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace HomeWork18.WebElements
{
    internal static class SortableDataTables
    {
        private const string _url = "https://the-internet.herokuapp.com/tables";
        private const string _headersXpath = "//table[@id='table{0}']//th";
        private const string _collumsXpath = "//table[@id='table{0}']//tbody//tr//td[{1}]";
        private const string _someElement = "//table[{0}]//tbody[{1}]//tr[{2}]//td[{3}]";
        private const string _editButton = "//td//a[@href='#edit']";

        private static IWebElement ElementOfTable(int table, int body, int tr, int td) => Page.GetElement(By.XPath(string.Format(_someElement, table, body, tr, td)));
        private static List<IWebElement> ListOfHeaders(int tableNumber) => Page.GetListOfElements(By.XPath(string.Format(_headersXpath, tableNumber)));
        private static List<IWebElement> ListOfCollum(int tableNumber, int collumNumber) => Page.GetListOfElements(By.XPath(string.Format(_collumsXpath, tableNumber, collumNumber)));

        public static bool IsCorrectElement(string value, int table, int body, int tr, int td)
        {
            Page.GoUrl(_url);

            return value == ElementOfTable(table, body, tr, td).Text;
        }

        public static bool IsSortableOrder(int tableNumber, int collumNumber)
        {
            Page.GoUrl(_url);

            var elements = ListOfCollum(tableNumber, collumNumber).Select(e => e.Text).OrderBy(el => el).ToList();

            ListOfHeaders(tableNumber)[collumNumber - 1].Click();

            var sortableElements = ListOfCollum(tableNumber, collumNumber).Select(s => s.Text).ToList();

            return sortableElements.FirstOrDefault() == elements.FirstOrDefault();
        }

        public static bool IsSortableDescending(int tableNumber, int collumNumber)
        {
            Page.GoUrl(_url);

            var elements = ListOfCollum(tableNumber, collumNumber).Select(e => e.Text).OrderByDescending(el => el).ToList();

            ListOfHeaders(tableNumber)[collumNumber - 1].Click();
            ListOfHeaders(tableNumber)[collumNumber - 1].Click();

            var sortableElements = ListOfCollum(tableNumber, collumNumber).Select(s => s.Text).ToList();

            return sortableElements.LastOrDefault() == elements.LastOrDefault();
        }

        public static bool IsUnSortable(int tableNumber, int collumNumber)
        {
            Page.GoUrl(_url);

            var elements = ListOfCollum(tableNumber, collumNumber).Select(e => e.Text).ToList();

            ListOfHeaders(tableNumber)[collumNumber - 1].Click();
            ListOfHeaders(tableNumber)[collumNumber - 1].Click();

            Driver.GetDriver().Navigate().Refresh();

            var UnSortableElements = ListOfCollum(tableNumber, collumNumber).Select(s => s.Text).ToList();

            return UnSortableElements.LastOrDefault() == elements.LastOrDefault();
        }

        public static bool ClickEdit()
        {
            Page.GoUrl(_url);

            Page.GetElement(By.XPath(_editButton)).Click();

            return Driver.GetDriver().Url.Contains("edit");
        }
    }
}
