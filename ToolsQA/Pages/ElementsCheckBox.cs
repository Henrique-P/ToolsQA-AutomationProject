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

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Home')]//..//..//button")]
        public IWebElement checkboxHome;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Downloads')]//..//..//button")]
        public IWebElement checkboxDownloads;

        [FindsBy(How = How.CssSelector, Using = "label[for='tree-node-excelFile']")]
        public IWebElement checkboxFile;

        [FindsBy(How = How.XPath, Using = "//div[@id='result']")]
        public IWebElement respostaCheckBox;

        public ElementsCheckBox(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ClicaCheckBoxHome()
        {
            checkboxHome.Click();
            //Thread.Sleep(500);
        }

        public void ClicaCheckBoxDocuments()
        {
            checkboxDownloads.Click();
            //Thread.Sleep(500);
        }

        public void ClicaCheckBoxExcelFile()
        {
            checkboxFile.Click();
        }

        public string ValidaCheckBox()
        {
            return respostaCheckBox.Text.Replace("\r\n", "");
        }
    }
}
