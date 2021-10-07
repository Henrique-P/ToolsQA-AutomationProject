using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using ToolsQA.Pages;

namespace ToolsQA.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        private IWebDriver webDriver;
        ScenarioContext context;
        private Home home;
        public HomeSteps(ScenarioContext context)
        {
            this.context = context;
            webDriver = this.context["WEB_DRIVER"] as IWebDriver;
            home = new Home(webDriver);
        }

        [When(@"clico em cada ""(.*)"" um por um")]
        public void QuandoClicoEmCadaUmPorUm(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"devo ver suas ""(.*)""")]
        public void EntaoDevoVerSuas(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"clico em cada header um por um")]
        public void QuandoClicoEmCadaHeaderUmPorUm()
        {
            string[] headers = { "Forms","Alerts","Widgets","Interactions","Book Store Application"};
            foreach (string header in headers)
            {
                home.SelecionaHeader(header);
                Thread.Sleep(600);
            }
        }

        [Then(@"devo ver suas opcoes")]
        public void EntaoDevoVerSuasOpcoes()
        {
            ScenarioContext.Current.Pending();
        }

    }
}

