using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace ToolsQA.Pages
{
    public class ElementsTextBox
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "#userName")]
        public IWebElement userName;

        [FindsBy(How = How.CssSelector, Using = "#userEmail")]
        public IWebElement userEmail;

        [FindsBy(How = How.CssSelector, Using = "#currentAddress")]
        public IWebElement currentAddress;

        [FindsBy(How = How.CssSelector, Using = "#permanentAddress")]
        public IWebElement permanentAddress;

        [FindsBy(How = How.CssSelector, Using = "#submit")]
        public IWebElement botaoEnviar;

        [FindsBy(How = How.CssSelector, Using = "div.border")]
        public IWebElement respostaFormulario;

        public ElementsTextBox(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void PreencheFormulario(string nome, string email, string endereco)
        {
            userName.SendKeys(nome);
            userEmail.SendKeys(email);
            currentAddress.SendKeys(endereco);
            permanentAddress.SendKeys(endereco);
        }

        public void ClicaEnviarFormulario()
        {
            botaoEnviar.Click();
        }

        public string ValidarResposta()
        {
            //string name = respostaFormulario.FindElement(By.CssSelector("#name")).Text;
            return respostaFormulario.Text;
        }
    }
}
