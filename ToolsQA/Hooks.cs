using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace ToolsQA
{
    [Binding]
    public class Hooks
    {
        private IWebDriver webDriver;
        public IWebDriver CriaDriver(bool headless = false, int timeout = 10)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", true);
            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddArgument("--start-maximized");
            if (headless) chromeOptions.AddArgument("--headless"); //TODO: Headless quebra os testes que dependem do navegador maximizado
            webDriver = new ChromeDriver(chromeOptions);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            return webDriver;
        }
        [Before] //Before é sinonimo de BeforeScenario
        public void GetSessaoDriver(ScenarioContext context)
        {                
            context["WEB_DRIVER"] = CriaDriver();
        }

        [After] //After é sinonimo de AfterScenario
        public void FecharDriver()
        {
            webDriver.Close();
        }
    }
}
