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
            //Seleção com ScenarioInfo e switch
            switch (context.ScenarioInfo.Title)
            {
                case "Interagir com botoes":
                    Assert.IsTrue(elementsButtons.ValidarBotoes().Equals(mensagemEsperada));
                    break;
                case "Interagir com botao Radio":
                    Assert.IsTrue(elementsRadioButton.ValidarResposta().Equals(mensagemEsperada));
                    break;
                case "Interagir com checkbox":
                    Assert.IsTrue(elementsCheckBox.ValidaCheckBox().Equals(mensagemEsperada));
                    break;
                default:
                    context.Pending();
                    break;
            }
            
            //Seleção com Ifs
            //if (mensagemEsperada.EndsWith("Yes") || mensagemEsperada.EndsWith("Impressive"))
            //    Assert.IsTrue(elementsRadioButton.ValidarResposta().Equals(mensagemEsperada));
            //if (mensagemEsperada.EndsWith("excelFile")) 
            //    Assert.IsTrue(elementsCheckBox.ValidaCheckBox().Equals(mensagemEsperada));
            //if (mensagemEsperada.EndsWith("Me"))
            //    Assert.IsTrue(elementsButtons.ValidarBotoes(mensagemEsperada).Equals(mensagemEsperada));
        }

        [When(@"em seguida clico em ""(.*)""")]
        public void QuandoEmSeguidaClicoEm(string botao)
        {
            if (botao.Equals("Yes") || botao.Equals("Impressive"))
                elementsRadioButton.ClicarBotaoRadio(botao);
            else
                elementsButtons.ClicaBotao(botao);
        }

        [When(@"visualizo o texto dinamico")]
        public void QuandoVisualizoOTextoDinamico()
        {
            Assert.IsTrue(dynamicProperties.ValidaTextoIdRandomica().Equals("This text has random Id"));
            Assert.IsFalse(dynamicProperties.botaoEnableAfter.Enabled);
            //Assert.IsFalse(dynamicProperties.botaoVisibleAfter.Displayed);
            Assert.IsFalse(dynamicProperties.botaoColorChange.GetAttribute("class").Contains("text-danger"));
        }

        [Then(@"aguardo até que dois botoes se tornem clicáveis e que um terceiro mude a cor")]
        public void EntaoAguardoAteQueDoisBotoesSeTornemClicaveisEQueUmTerceiroMudeACor()
        {
            Assert.IsTrue(dynamicProperties.ValidaBotaoVisivel().Displayed);
            Assert.IsTrue(dynamicProperties.ValidaBotaoColorido().GetAttribute("class").Contains("text-danger"));
            Assert.IsTrue(dynamicProperties.ValidaDesativado().Enabled);
        }

    }
}
