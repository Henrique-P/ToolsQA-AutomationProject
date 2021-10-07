#language: pt
Funcionalidade: Home

  Contexto: Estou no site DemoQA
    Dado que estou no website DemoQA
    Quando clico sobre Elements

  Esquema do Cenario: Clicar em todos os headers
     Quando clico em cada <header> um por um
     Entao devo ver suas <opcoes>

      Exemplos: 
      | header                   | opcoes                                                                                        |
      | "Forms"                  | "Practice Form"                                                                               |
      | "Alerts"                 | "Browser Windows,Alerts,Frames,Nested Frames, Modal Dialogs"                                  |
      | "Widgets"                | "Accordian,Auto Complete,Date Picker,Slider,Progress Bar,Tabs,Tool Tips,Menu,Select Menu"     |
      | "Interactions"           | ""                                                 |
      | "Book Store Application" | ""                                         |

   Cenario: Clicar em todos os headers (mesmo cenário)
     Quando clico em cada header um por um
     Entao devo ver suas opcoes