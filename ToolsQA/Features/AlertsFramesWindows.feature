#language: pt

Funcionalidade: Interagir com elementos

  Contexto: Estou no site DemoQA
      Dado que estou no website DemoQA
      Quando clico no card "Alerts, Frame & Windows"
  
    Cenario: Validar um aviso na tela
      Quando clico sobre "Alerts"
      E em seguida clico em "{botao}"