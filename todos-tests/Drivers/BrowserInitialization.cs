using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace todos.tests.Drivers
{
    public class BrowserInitialization
    {
        public static void OpenBrowser(BrowserType browserType = BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType,
                        "Browser isn't initialized");
            }
        }

        public void NavigateToSite(string url)
        {
            OpenBrowser(BrowserType.Chrome);
            DriverContext.Driver.Manage().Window.Maximize();
            //url is given in the feature file
            DriverContext.Browser.GoToUrl(url);
        }
    }
}
