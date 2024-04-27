namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public class AlertsPgStepDefinitions
{
    IWebDriver driver;
    DqaAlertsTabPg alertsPg;
    public AlertsPgStepDefinitions(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        alertsPg = container.Resolve<DqaAlertsTabPg>();
    }

    [Then(@"I land on the Alerts page")]
    public void ThenILandOnTheAlertsPage()
    {
        Assert.That(alertsPg.AlertstabDisplayed(), Is.EqualTo(true));
    }

    [When(@"I click on second Click me button")]
    public void WhenIClickOnSecondClickMeButton()
    {
        alertsPg.ClickAlertBtn();
    }

    [Then(@"I validate the displayed alert message")]
    public void ThenIValidateTheDisplayedAlertMessage()
    {
        alertsPg.IsAlertMessageDisplayed();
    }

    [When(@"click on fourth Click me button and enter '(.*)'")]
    public void WhenClickOnFourthClickMeButton(string text)
    {
       alertsPg.ClickAlertBtn2();
        WhenIEnterNameInTheTextFieldDisplayed(text);
    }

    [When(@"I enter (.*) in the text field displayed")]
    public void WhenIEnterNameInTheTextFieldDisplayed(string name)
    {
        alertsPg.EnterAlertValue(name);
    }

    [Then(@"the name appeared in green colour as '(.*)'")]
    public void ThenTheNameAppearedInGreenColourShouldValidated(string expectedValue)
    {
       string actualValue = alertsPg.GetAlertValueDisplayed();
        Assert.That(expectedValue == actualValue);
    }
}