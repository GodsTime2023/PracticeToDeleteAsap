namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public class AlertsFrameWindowsPgStepDefinitions
{
    IWebDriver driver;
    DqaAlertsFrameWindowsPg alertsFrameWindowsPg;
    public AlertsFrameWindowsPgStepDefinitions(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        alertsFrameWindowsPg = new DqaAlertsFrameWindowsPg(driver);
    }

    [Then(@"I land on the Alerts, Frame and Windows page")]
    public void ThenILandOnTheAlertsFrameAndWindowsPage()
    {
        var validateHeaderText2 = alertsFrameWindowsPg.AlertsFrameWindowsTitleIsDisplayed();
        Assert.That(validateHeaderText2, Is.EqualTo(true));
    }

    [When(@"I click on the Alerts tab")]
    public void WhenIClickOnTheAlertsTab()
    {
        alertsFrameWindowsPg.ClickAlerttab();
    }
}