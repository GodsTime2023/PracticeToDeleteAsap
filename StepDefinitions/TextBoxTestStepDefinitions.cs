namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public class TextBoxTestStepDefinitions
{
    private readonly IWebDriver driver;
    private TextBoxPage? textBoxPage;

    public TextBoxTestStepDefinitions(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        textBoxPage = new TextBoxPage(driver);
    }

    [When(@"I enter Full name (.*)")]
    public void WhenIEnterFullNameFullname(string fullname)
    {
        textBoxPage?.EnterFullName(fullname);
    }

    [When(@"I enter email address (.*)")]
    public void WhenIEnterEmailAddressEmail(string email)
    {
        textBoxPage?.EnterEmail(email);
    }

    [When(@"I enter Current address (.*)")]
    public void WhenIEnterCurrentAddressCurrentaddress(string currentAddress)
    {
        textBoxPage?.EnterCurrentAddress(currentAddress);
    }

    [When(@"I enter Permanent address (.*)")]
    public void WhenIEnterPermanentAddressPermanentaddress(string parmanentAddress)
    {
       textBoxPage?.EnterParmanentAddress(parmanentAddress);    
    }

    [When(@"I click on Submit button")]
    public void WhenIClickOnSubmitButton()
    {
      textBoxPage?.ClickSubmitButton();
    }

    [Then(@"all the details entered should be displayed")]
    public void ThenAllTheDetailsEnteredShouldBeDisplayed(Table table)
    {
        var outputValues = textBoxPage?.GetOutputValues();
        Assert.That(table.Rows[0]["fullname"] == outputValues?[0].Text.Split(":")[1]);
        Assert.That(table.Rows[0]["email"] == outputValues?[1].Text.Split(":")[1]);
        Assert.That(table.Rows[0]["currentaddress"] == outputValues?[2].Text.Split(":")[1]);
        Assert.That(table.Rows[0]["permanentaddress"] == outputValues?[3].Text.Split(":")[1]);
    }
}
