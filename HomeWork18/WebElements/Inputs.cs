using PageObjLib.Factories;
using PageObjLib.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace HomeWork18.WebElements
{
    internal static class Inputs
    {
        private const string _url = "https://the-internet.herokuapp.com/inputs";

        private static IWebElement _input = Page.GetElement(By.XPath("//input"));
        private static string GetResult() => _input.GetAttribute("valueAsNumber");

        private static void DoArrowUp(int arrowUpCount)
        {
            for (int i = 0; i < arrowUpCount; i++)
            {
                _input.SendKeys(Keys.ArrowUp);
            }
        }
        private static void DoArrowDown(int arrouDownCount)
        {
            for(int i = 0;i < arrouDownCount; i++)
            {
                _input.SendKeys(Keys.ArrowDown);
            }
            
        }
        private static void InputStr(string str) => _input.SendKeys(str);

        public static bool IsInputting(int digit, int arrowUpCount, int arrouDownCount)
        {
            Page.GoUrl(_url);

            InputStr(digit.ToString());
            DoArrowUp(arrowUpCount);
            DoArrowDown(arrouDownCount);

            var expected = digit + arrowUpCount - arrouDownCount;

            return GetResult().Equals(expected.ToString());
        }

        public static bool IsInputting(string str, int arrowUpCount, int arrouDownCount)
        {
            Page.GoUrl(_url);

            if (arrowUpCount == 0 && arrouDownCount == 0)
            {
                InputStr(str);

                return GetResult().Equals("NaN");
            }

            else
            {
                DoArrowUp(arrowUpCount);
                DoArrowDown(arrouDownCount);
                var expected = (arrowUpCount - arrouDownCount).ToString();
                return GetResult().Equals(expected);
            }
        }

        public static bool InputE(int number, int exponent, int arrowUpCount, int arrouDownCount)
        {
            Page.GoUrl(_url);

            InputStr($"{number}e{exponent}");
            DoArrowUp(arrowUpCount);
            DoArrowDown(arrouDownCount);
            var expected = (number * Math.Pow(10, exponent) + arrowUpCount - arrouDownCount).ToString();
            return GetResult().Equals(expected);

        }

        public static bool InputBoundaryValue(string value, int arrowUpCount, int arrouDownCount)
        {
            Page.GoUrl(_url);

            InputStr(value);

            DoArrowUp(arrowUpCount);
            DoArrowDown(arrouDownCount);

            var expected = (arrowUpCount - arrouDownCount).ToString();
            return GetResult().Equals(expected);
        }

        public static bool InputToLongValue(int arrowUpCount, int arrouDownCount)
        {
            Page.GoUrl(_url);

            for (int i = 0; i < 19; i++)
            {
                InputStr(long.MaxValue.ToString());
            }
            
            DoArrowUp(arrowUpCount);
            DoArrowDown(arrouDownCount);

            var expected = (arrowUpCount - arrouDownCount).ToString();
            return GetResult().Equals(expected);
        }
    }
}
