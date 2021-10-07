using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace ToolsQA.Pages
{
    public class Home
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "//h5[contains(text(), 'Elements')]")]
        public IWebElement botaoElementos;

        [FindsBy(How = How.CssSelector, Using = "div.accordion")]
        public IWebElement painelEsquerda;

        [FindsBy(How = How.CssSelector, Using = "div.element-group div.show")]
        public IWebElement opcoesVisiveis;

        [FindsBy(How = How.CssSelector, Using = "#close-fixedban")]
        public IWebElement botaoFecharAnuncio;

        [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']/../span")]
        public IWebElement headerAberto;

        [FindsBy(How = How.CssSelector, Using = "div.category-cards")]
        public IWebElement quadroDeCardsHome;

        //div[@class = 'category-cards']/div/div/div/h5[text()='Elements']

        // //div[contains(text(), 'Forms')] Seleciona qualquer collection
        // //li/span[contains(text(), 'Text Box')] Seleciona qualquer botao dentro da collection

        public Home(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ClicaEmElementos()
        {
            botaoElementos.Click();
        }

        public void ClicaCard(string card)
        {
            IWebElement XPath = quadroDeCardsHome.FindElement(By.XPath($"//h5[text()='{card}']"));
            XPath.Click();
        }

        public void PaginaInicial()
        {
            webDriver.Navigate().GoToUrl("https://www.demoqa.com/");
            botaoFecharAnuncio.Click();
        }

        public void SelecionaHeader(string header)
        {
            /*if (header.Equals("Book Store Application"))
            {
                painelEsquerda.FindElement(By.XPath($"//div[contains(text(), 'Interactions')]")).Click();
                Thread.Sleep(500);
            }*/
            headerAberto.Click();
            Thread.Sleep(500);
            IWebElement xPath = painelEsquerda.FindElement(By.XPath($"//div[contains(text(), '{header}')]"));
            ScrollToView(xPath);
            xPath.Click();
        }

        public void SelecionaOpcao(string opcao)
        {
            IWebElement xPath = opcoesVisiveis.FindElement(By.XPath($"//li/span[contains(text(), '{opcao}')]"));
            ScrollToView(xPath);
            xPath.Click();
        }

        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver; 
            js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", xPosition, yPosition));
        }

        public IWebElement ScrollToView(By selector)
        {
            var element = webDriver.FindElement(selector);
            ScrollToView(element);
            return element;
        }

        public void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(0, element.Location.Y - 100);
            }

        }
    }
}
