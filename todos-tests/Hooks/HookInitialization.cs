using System;
using TechTalk.SpecFlow;
using todos.tests.Drivers;

namespace todos.tests.Hooks
{
    [Binding]
    public class HookInitialization
    {
        [BeforeScenario]
        public static void BeforeFeature()
        {
            Console.WriteLine($"*******Start of scenario******");
        }

        [AfterScenario("webTest")]
        public static void AfterFeature()
        {
            DriverContext.Driver.Quit();
            Console.WriteLine($"*******End of scenario*******");
        }
    }
}
