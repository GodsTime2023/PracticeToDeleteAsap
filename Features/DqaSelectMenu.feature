Feature: DqaSelectMenu

As a user
I want to select option from DemoQa dropdown lists

@Demoqa
Scenario: Demoqa Select Menu
	Then I verify that home page is displayed successfully
When I click Widgets menu
    And I validate the page is displayed  
    And I click on select menu
    And I click on dropdown to Select group Option
    And I click on dropdown to Select the Title 
    And I click on dropdown to Select Old Style Colour
    And I click on dropdown to Select Multi Colour
    And I click on dropdown to select multi standard 
    | Cars  |
    | volvo |
    | Opel  |
    | audi  |
    | Saab  |
Then the selected menus should be validated