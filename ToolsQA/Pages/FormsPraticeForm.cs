using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace ToolsQA.Pages
{
    public class FormsPraticeForm
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Home')]//..//..//button")]
        public IWebElement checkboxHome;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Downloads')]//..//..//button")]
        public IWebElement checkboxDownloads;

        [FindsBy(How = How.CssSelector, Using = "label[for='tree-node-excelFile']")]
        public IWebElement checkboxFile;

        [FindsBy(How = How.CssSelector, Using = "span.text-success")]
        public IWebElement respostaSelecao;

        public FormsPraticeForm(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }
    }
}
