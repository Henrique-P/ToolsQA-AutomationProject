using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace ToolsQA.Pages
{
    public class ElementsRadioButton
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "label[for='impressiveRadio']")]
        public IWebElement botaoRadioImpressive;

        [FindsBy(How = How.CssSelector, Using = "label[for='yesRadio']")]
        public IWebElement botaoRadioYes;

        //[FindsBy(How = How.XPath, Using = "//p[text() = 'You have selected ']")]
        //public IWebElement confirmacaoBotaoRadio;

        [FindsBy(How = How.CssSelector, Using = "div p")]
        public IWebElement confirmacaoBotaoRadio;


        public ElementsRadioButton(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public string ValidarResposta()
        {
            return confirmacaoBotaoRadio.Text;
        }

        public void ClicarBotaoRadio(string botao)
        {
            if (botao.Equals("Yes")) 
                botaoRadioYes.Click();
            else
                botaoRadioImpressive.Click();
        }
    }
}
