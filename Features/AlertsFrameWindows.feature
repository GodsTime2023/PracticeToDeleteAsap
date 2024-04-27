Feature: AlertsFrameWindows

As a user, I want to be able to receive alerts

@Demoqa @Alerts @ignore
Scenario: Click on the Alerts tab 
	Then I am on demoqa page
When I click on Alerts, Frame & Windows menu
    Then I land on the Alerts, Frame and Windows page
    When I click on the Alerts tab
    Then I land on the Alerts page
    When I click on second Click me button 
    Then I validate the displayed alert message
    When click on fourth Click me button 
    And I enter text in the text field displayed
Then the name appeared in green colour as 'You entered text'