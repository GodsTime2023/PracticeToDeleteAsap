namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public class DqaSelectMenuSteps 
{
    IWebDriver driver;
    DqaSelectMenuPg selectMenuPg;
    public DqaSelectMenuSteps(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        selectMenuPg = new DqaSelectMenuPg(driver);
    }

    [Then(@"I verify that home page is displayed successfully")]
    public void ThenIVerifyThatHomePageIsDisplayedSuccessfully()
    {
      Assert.That(selectMenuPg.ElementsIsDisplayed(), Is.EqualTo(true));
    }

    [When(@"I validate the page is displayed")]
    public void WhenIValidateThePageIsDisplayed()
    {
        Assert.That(selectMenuPg.PageIsDisplayed(), Is.EqualTo(true));
    }

    [When(@"I click on select menu")]
    [Scope(Tag = "@Dropdown")]
    public void WhenIClickOnSelectMenu()
    {
        selectMenuPg.ClickSelectMenu();
    }

    [When(@"I click on dropdown to (.*) group (.*)")]
    public void WhenIClickOnDropdownToSelectOption(string option, string value)
    {
        selectMenuPg.SelectDrpdownOption(option, value);
    }

    [When(@"I click on dropdown to (.*) the (.*)")]
    public void WhenIClickOnDropdownToSelectTitle(string option, string value)
    {
        selectMenuPg.SelectDrpdownTitle(option, value);
    }

    [When(@"I click on dropdown to Select Old Style Colour")]
    public void WhenIClickOnDropdownToSelectOldStyleColour()
    {
        selectMenuPg.SelectDrpdownStyleColour();
    }

    [When(@"I click on dropdown to (.*) Multi (.*)")]
    public void WhenIClickOnDropdownToSelectMultiColour(string option, string value)
    {
        selectMenuPg.SelectDrpdownMultiColour(option, value);
    }

    [When(@"I click on dropdown to select multi standard")]
    public void WhenIClickOnDropdownToSelectMultiStandard(Table table)
    {
        var tableData = table.Rows.ToList();
        string[] param = 
            { tableData.First().Values.First(),
            tableData.ElementAt(1).Values.First(),
            tableData.ElementAt(2).Values.First(),
            tableData.Last().Values.First() };
        selectMenuPg.SelectDrpdownMultiStandard(param);
    }

    [Then(@"the selected menus should be validated")]
    public void ThenTheSelectedMenusShouldBeValidated()
    {
        string expectedSelectValueDropdown =
            ScenarioContext.Current.Get<string>("SelectValueDropdown");

        string expectedSelectOnedropDown =
            ScenarioContext.Current.Get<string>("SelectOnedropDown");

        string expectedOldstyleSelectMenu = 
            ScenarioContext.Current.Get<string>("OldStyleSelectMenu");

        string expectedMultiSelectDropdown =
            ScenarioContext.Current.Get<string>("MultiColourSelectMenu");

        string expectedStandardMultiSelect0 =
            ScenarioContext.Current.Get<string>("MultiStandard0");
        string expectedStandardMultiSelect1 =
            ScenarioContext.Current.Get<string>("MultiStandard1");
        string expectedStandardMultiSelect2 =
            ScenarioContext.Current.Get<string>("MultiStandard2");
        string expectedStandardMultiSelect3 =
            ScenarioContext.Current.Get<string>("MultiStandard3");

        Assert.That(expectedSelectValueDropdown.Equals("Group 1, option 2"), Is.EqualTo(true));
        Assert.That(expectedSelectOnedropDown.Equals("Dr."), Is.EqualTo(true));
        Assert.That(expectedOldstyleSelectMenu.Split("\r\n")[1].Equals("Blue"), Is.EqualTo(true));
        Assert.That(expectedMultiSelectDropdown.Contains("Green") && expectedMultiSelectDropdown.Contains("Red"), Is.EqualTo(true));
        Assert.Multiple(() =>
        {
            Assert.That(expectedStandardMultiSelect0.Equals("Volvo"), Is.EqualTo(true));
            Assert.That(expectedStandardMultiSelect1.Equals("Saab"), Is.EqualTo(true));
            Assert.That(expectedStandardMultiSelect2.Equals("Opel"), Is.EqualTo(true));
            Assert.That(expectedStandardMultiSelect3.Equals("Audi"), Is.EqualTo(true));
        });
    }
}