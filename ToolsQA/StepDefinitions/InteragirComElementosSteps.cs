using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using ToolsQA.Pages;

namespace ToolsQA.StepDefinitions
{
    [Binding]
    public class InteragirComElementosSteps
    {
        private ScenarioContext context;
        private ElementsTextBox elementsTextBox;
        private Home home;
        private IWebDriver webDriver;
        private ElementsCheckBox elementsCheckBox;
        private ElementsRadioButton elementsRadioButton;
        private ElementsButtons elementsButtons;
        private DynamicProperties dynamicProperties;

        public InteragirComElementosSteps(ScenarioContext context)
        {
            this.context = context;
            webDriver = this.context["WEB_DRIVER"] as IWebDriver;
            home = new Home(webDriver);
            elementsTextBox = new ElementsTextBox(webDriver);
            elementsCheckBox = new ElementsCheckBox(webDriver);
            elementsRadioButton = new ElementsRadioButton(webDriver);
            elementsButtons = new ElementsButtons(webDriver);
            dynamicProperties = new DynamicProperties(webDriver);
        }

        [Given(@"que estou no website DemoQA")]
        public void DadoQueEstouNoWebsiteDemoQA()
        {
            home.PaginaInicial();
        }

        [When(@"clico no card ""(.*)""")]
        public void QuandoClicoNoCard(string card)
        {
            home.ClicaCard(card);
        }


        [When(@"clico sobre ""(.*)""")]
        public void QuandoEmSeguidaClicoSobre(string opcao)
        {
            home.SelecionaOpcao(opcao);
        }

        [When(@"preencho as caixas de texto com ""(.*)"", ""(.*)"" e ""(.*)""")]
        public void QuandoPreenchoAsCaixasDeTextoComE(string p0, string p1, string p2)
        {
            elementsTextBox.PreencheFormulario(p0, p1, p2);
        }

        [When(@"clico sobre Submit")]
        public void QuandoClicoSobreSubmit()
        {
            elementsTextBox.ClicaEnviarFormulario();
        }
        
        [Then(@"devo visualizar os dados enviados")]
        public void EntaoDevoVisualizarOsDadosEnviados()
        {
            string respostaEsperada = "Name:Pedro H\r\nEmail:pedro@teste.com\r\nCurrent Address :Av. Paulista\r\nPermananet Address :Av. Paulista";
            Assert.IsTrue(elementsTextBox.ValidarResposta().Equals(respostaEsperada));
        }

        [When(@"em seguida clico no icone para extender Home")]
        public void QuandoEmSeguidaClicoNoIconeParaExtenderHome()
        {
            elementsCheckBox.ClicaCheckBoxHome();
        }

        [When(@"em seguida clico no icone para extender Documents")]
        public void QuandoEmSeguidaClicoNoIconeParaExtenderDocuments()
        {
            elementsCheckBox.ClicaCheckBoxDocuments();
        }

        [When(@"em seguida seleciono Excel")]
        public void QuandoEmSeguidaSelecionoExcel()
        {
            elementsCheckBox.ClicaCheckBoxExcelFile();
        }

        [Then(@"devo visualizar ""(.*)""")]
        public void EntaoDevoVisualizar(string mensagemEsperada)
        {
            switch (mensagemEsperada)
            {
                case "You have selected :excelFile":
                    Assert.IsTrue(elementsCheckBox.ValidaCheckBox().Equals(mensagemEsperada));
                    break;
                case "You have selected Impressive":
                    Assert.IsTrue(elementsRadioButton.ValidarResposta().Equals(mensagemEsperada));
                    break;
                case "You have selected Yes":
                    Assert.IsTrue(elementsRadioButton.ValidarResposta().Equals(mensagemEsperada));
                    break;
                default:
                    Assert.IsTrue(elementsButtons.ValidarBotoes(mensagemEsperada).Equals(mensagemEsperada));
                    break;

            }
        }

        [When(@"em seguida clico em ""(.*)""")]
        public void QuandoEmSeguidaClicoEm(string botao)
        {
            if (botao.Equals("Yes") || botao.Equals("Impressive"))
                elementsRadioButton.ClicarBotaoRadio(botao);
            else
                elementsButtons.ClicaBotao(botao);
        }

        [When(@"se necessario aguardo até que ""(.*)"" mude suas propriedades")]
        public void QuandoSeNecessarioAguardoAteQueMudeSuasPropriedades(string elemento)
        {
            /*switch (elemento)
            {
                case "Will enable 5 seconds":
                    break;
                case "Color change":
                    break;
                case "Visible after 5 seconds":
                    break;
                case "This text has random Id":
                    break;
            }*/
        }

        [Then(@"devo visualizar a mudanca")]
        public void EntaoDevoVisualizarAMudanca()
        {
            Assert.IsTrue(dynamicProperties.ValidaBotaoVisivel().Displayed);
            Assert.IsTrue(dynamicProperties.ValidaTextoIdRandomica().Equals("This text has random Id"));
            Assert.IsTrue(dynamicProperties.ValidaBotaoColorido().GetAttribute("class").Contains("text-danger"));
            Assert.IsTrue(dynamicProperties.ValidaDesativado().Enabled);
        }



    }
}
