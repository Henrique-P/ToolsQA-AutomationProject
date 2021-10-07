using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolsQA.Pages
{
    class ElementsButtons
    {
        private IWebDriver webDriver;

        public ElementsButtons(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#doubleClickBtn")]
        public IWebElement botaoCliqueDuplo;

        [FindsBy(How = How.CssSelector, Using = "#rightClickBtn")]
        public IWebElement botaoCliqueDireito;

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Click Me']")]
        public IWebElement botaoDinamico;

        [FindsBy(How = How.CssSelector, Using = "p#doubleClickMessage")]
        public IWebElement respostaBotaoCliqueDuplo;

        [FindsBy(How = How.CssSelector, Using = "p#rightClickMessage")]
        public IWebElement respostaBotaoCliqueDireito;

        [FindsBy(How = How.CssSelector, Using = "p#dynamicClickMessage")]
        public IWebElement respostaBotaoCliqueDinamico;

        public void ClicarDuasVezes()
        {
            Actions act = new Actions(webDriver);
            act.DoubleClick(botaoCliqueDuplo).Perform();
        }
        public void CliqueComDireito()
        {
            Actions act = new Actions(webDriver);
            act.ContextClick(botaoCliqueDireito).Perform();
        }

        public void CliqueBotaoDinamico()
        {
            botaoDinamico.Click();
        }

        public void ClicaBotao(string botao)
        {
            switch (botao)
            {
                case "Double Click Me":
                    ClicarDuasVezes();
                    break;
                case "Right Click Me":
                    CliqueComDireito();
                    break;
                case "Click Me":
                    CliqueBotaoDinamico();
                    break;
            }
        }

        public string ValidarBotoes(string mensagem = "")
        {
            //string[] respostas = {respostaBotaoCliqueDuplo.Text.ToString(), respostaBotaoCliqueDireito.Text.ToString(), respostaBotaoCliqueDinamico.Text.ToString()};
            //return String.Join(";", respostas);
            switch (mensagem)
            {
                case "You have done a double click":
                    return respostaBotaoCliqueDuplo.Text;
                case "You have done a right click":
                    return respostaBotaoCliqueDireito.Text;
                case "You have done a dynamic click":
                    return respostaBotaoCliqueDinamico.Text;
                default:
                    string[] respostas = { respostaBotaoCliqueDuplo.Text.ToString(), respostaBotaoCliqueDireito.Text.ToString(), respostaBotaoCliqueDinamico.Text.ToString() };
                    return String.Join(";", respostas);
            }
        }
    }
}