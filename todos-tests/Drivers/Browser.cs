using OpenQA.Selenium;
using System;

namespace todos.tests.Drivers
{
    public class Browser
    {
        private IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
            Console.WriteLine($"test URL is {url}");
        }
    }

    public enum BrowserType
    {
        Chrome,
        InternetExplorer,
        Firefox
    }
}
