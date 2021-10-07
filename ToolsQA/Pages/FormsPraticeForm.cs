using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace ToolsQA.Pages
{
    public class FormsPraticeForm
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement checkboxHome;

        public FormsPraticeForm(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }
    }
}
