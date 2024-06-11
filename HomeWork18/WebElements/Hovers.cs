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
        private const string _userXpath = "(//*[@alt='User Avatar'])[{0}]";
        private const string _profileXpath = "//*[text()='View profile']";
        private const string _userLink = "//a[@href='/users/{0}']";

        private static IWebElement ErrorText() => Page.GetElement(By.XPath("//*[text()='Not Found']"));

        private static IWebElement GetUser(string numberOfUser) => Page.GetElement(By.XPath(string.Format(_userXpath, numberOfUser)));
        public static bool MoveToItem(string numberOfUser)
        {
            Page.GoUrl(_url);

            Page.GetActions().MoveToElement(GetUser(numberOfUser)).Click().Build().Perform();

            Page.GetElement(By.XPath(string.Format(_userLink, numberOfUser))).Click();
            
            return ErrorText().Text == "Not Found" && Driver.GetDriver().Url == $"https://the-internet.herokuapp.com/users/{numberOfUser}";
        }

        //public static int GetStatusCode()
        //{
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MoveToItem());
        //        request.Method = WebRequestMethods.Http.Head;
        //        request.AllowAutoRedirect = false;
        //        request.Accept = @"*/*";
        //        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //        {
        //            return (int)response.StatusCode;
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        if (ex.Response == null)
        //            throw;
        //        return (int)((HttpWebResponse)ex.Response).StatusCode;
        //    }
        //}
    }
}