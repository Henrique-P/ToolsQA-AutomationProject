#language: pt

Funcionalidade: Interagir com elementos

  Contexto: Estou no site DemoQA
      Dado que estou no website DemoQA
      Quando clico no card "Elements"
  
    @textbox
    Cenario: Fazer o preenchimento de caixa de texto
      Quando clico sobre "Text Box"
      E preencho as caixas de texto com "Pedro H", "pedro@teste.com" e "Av. Paulista"
      E clico sobre Submit
      Entao devo visualizar os dados enviados
  
    @checkbox
    Cenario: Interagir com checkbox
      Quando clico sobre "Check Box"
      E em seguida clico no icone para extender Home
      E em seguida clico no icone para extender Documents
      E em seguida seleciono Excel
      Entao devo visualizar "You have selected :excelFile"
  
    @buttons
    Esquema do Cenario: Interagir com botoes
      Quando clico sobre "Buttons"
      E em seguida clico em <botao>
      Entao devo visualizar <mensagem>
  
      Exemplos:
      | botao             | mensagem                        |
      | "Double Click Me" | "You have done a double click"  |
      | "Right Click Me"  | "You have done a right click"   |
      | "Click Me"        | "You have done a dynamic click" |
  
    @radiobutton
    Esquema do Cenario: Interagir com botao Radio
      Quando clico sobre "Radio Button"
      E em seguida clico em <botao>
      Entao devo visualizar <mensagem>
  
      Exemplos:
      | botao        | mensagem                       |
      | "Yes"        | "You have selected Yes"        |
      | "Impressive" | "You have selected Impressive" |

    @dynamicproperties
    Esquema do Cenario: Interagir com elementos dinamicos
      Quando clico sobre "Dynamic Properties"
      E se necessario aguardo até que <elemento> mude suas propriedades
      Entao devo visualizar a mudanca
      
      Exemplos:
      | elemento                  |
      | "Will enable 5 seconds"   |
      | "Color change"            |
      | "Visible after 5 seconds" |
      | "This text has random Id" |