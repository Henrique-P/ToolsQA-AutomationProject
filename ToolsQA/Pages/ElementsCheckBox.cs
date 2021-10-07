using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ToolsQA.Pages
{
    public class ElementsCheckBox
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Home')]/../../button")]
        public IWebElement botaoExpandeHome;

        //[FindsBy(How = How.CssSelector, Using = "#tree-node > ol > li > span button")]
        //public IWebElement botaoExpandeHome;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Downloads')]/../../button")]
        public IWebElement botaoExpandeDownloads;

        [FindsBy(How = How.CssSelector, Using = "label[for='tree-node-excelFile']")]
        public IWebElement botaoExpandeFile;

        [FindsBy(How = How.ClassName, Using = "display-result")]
        public IWebElement respostaCheckBox;

        public ElementsCheckBox(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ClicaCheckBoxHome()
        {
            botaoExpandeHome.Click();
            //Thread.Sleep(500);
        }

        public void ClicaCheckBoxDocuments()
        {
            botaoExpandeDownloads.Click();
            //Thread.Sleep(500);
        }

        public void ClicaCheckBoxExcelFile()
        {
            botaoExpandeFile.Click();
        }

        public string ValidaCheckBox()
        {
            return respostaCheckBox.Text.Replace("\r\n", "");
        }
    }
}
