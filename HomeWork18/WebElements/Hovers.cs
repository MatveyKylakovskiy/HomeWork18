using PageObjLib.Factories;
using PageObjLib.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System.Net;

namespace HomeWork18.WebElements
{
    internal static class Hovers
    {
        private const string _url = "https://the-internet.herokuapp.com/hovers";
        private const string _userXpath = "//*[@alt='User Avatar']";
        private const string _profileXpath = "//*[text()='View profile']";
        private const string _user1 = "//a[@href='/users/1']";

        private static IWebElement GetUser() => Page.GetElement(By.XPath(_userXpath));
        public static string MoveToItem()
        {
            Page.GoUrl(_url);

            Page.GetActions().MoveToElement(GetUser()).Click().Build().Perform();

            Page.GetElement(By.XPath(_user1)).Click();

            return Driver.GetDriver().Url;
        }

        public static int GetStatusCode()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MoveToItem());
                request.Method = WebRequestMethods.Http.Head;
                request.AllowAutoRedirect = false;
                request.Accept = @"*/*";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return (int)response.StatusCode;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                    throw;
                return (int)((HttpWebResponse)ex.Response).StatusCode;
            }
        }

        public static void FK()
        {
            int a = GetStatusCode();
        }
    }
}