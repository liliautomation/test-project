using OpenQA.Selenium;

namespace todos.tests.Drivers
{
    public class DriverContext
    {
        public static IWebDriver Driver { get; set; }
        public static Browser Browser { get; set; }
    }
}
