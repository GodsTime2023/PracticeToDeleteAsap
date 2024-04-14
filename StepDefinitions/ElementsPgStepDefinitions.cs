namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public class ElementsPgStepDefinitions
{
    IWebDriver driver;
    DqaElementsPg elementsPg;
    public ElementsPgStepDefinitions(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        elementsPg = new DqaElementsPg(driver);
    }

    [Then(@"I will arrive on the Elements page")]
    public void ThenIWillArriveOnTheElementsPage()
    {
        var validateHeaderText = elementsPg.ElementsIsDisplayed();
        Assert.That(validateHeaderText, Is.EqualTo(true));
    }

    [When(@"I click on the Web Tables tab")]
    public void WhenIClickOnTheWebTablesTab()
    {
        elementsPg.ClickWebTablesTab();
    }
}