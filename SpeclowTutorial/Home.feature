Feature: Home

Background: 
 Given I navigate to URl
 And I click to Input form

 #Example as Scenario Outline
 Scenario Outline: Fill the Input form
 Given User is on the input form Page
 When User enter <Msg> in input
 And User click to Show button
 Then User can see the text
 Examples: 
 | Msg     |
 | Hello   |
 | Codebun |
 | CodeDec |

 #Example of Tables in Sepcflow
 Scenario: Fill the Input form using Table
 Given User is on the input form Page
 When User enter Msg in input
  | Msg     | msg2 |
  | Hello   |    fgfg  |
  | Codebun |     hg |
  | CodeDec |      hgh|
 And User click to Show button
 Then User can see the text

  #Example of Param in Sepcflow
 Scenario: Fill the Input form using Param
 Given User is on the input form Page
 When User enter "Hello Codebun" in input
 And User click to Show button
 Then User can see the text
