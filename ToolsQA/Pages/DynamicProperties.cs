using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ToolsQA.Pages
{
    class DynamicProperties
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "enableAfter")]
        public IWebElement botaoEnableAfter;

        [FindsBy(How = How.Id, Using = "colorChange")]
        public IWebElement botaoColorChange;

        [FindsBy(How = How.Id, Using = "visibleAfter")]
        public IWebElement botaoVisibleAfter;

        [FindsBy(How = How.XPath, Using = "//p[text()='This text has random Id']")]
        public IWebElement textoIdRandomica;

        public DynamicProperties(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }
        public IWebElement ValidaBotaoVisivel()
        {
            while (!botaoVisibleAfter.Displayed)
            {
                Thread.Sleep(200);
            }
            return botaoVisibleAfter;
        }

        public IWebElement ValidaBotaoColorido()
        {
            while (!(botaoColorChange.GetAttribute("class").Contains("text-danger")))
            {
                Thread.Sleep(200);
            }
            return botaoColorChange;
        }

        public string ValidaTextoIdRandomica()
        {
            return textoIdRandomica.Text;
        }

        public IWebElement ValidaDesativado()
        {
            while (!(botaoEnableAfter.Enabled))
            {
                Thread.Sleep(200);
            }
            return botaoEnableAfter;
        }
    }

}
