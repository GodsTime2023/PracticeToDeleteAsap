namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public class PracticeFormsStepDefinitions
{
    private IWebDriver driver;
    private PracticeFormsPage practiceFormsPage;
    public PracticeFormsStepDefinitions(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        practiceFormsPage = new PracticeFormsPage(driver);
    }

    [When(@"I click on Practice form")]
    public void WhenIClickOnPracticeForm()
    {
        practiceFormsPage.ClickPracticeForm();
    }

    [Then(@"I verify that (.*) is visible")]
    public void ThenIVerifyThatStudentRegistrationFormIsVisible(string hText)
    {
        driver.Url.Should().Contain(hText.Split(" ")[2].ToLower());

        var formheaderText = practiceFormsPage.IsFormHeaderTextDisplayed();
        Assert.That(formheaderText, Is.EqualTo(hText));
    }

    [When(@"I have filled out the Registration form with the following data")]
    public void WhenIHaveFilledOutTheRegistrationFormWithTheFollowingData(Table table)
    {
        practiceFormsPage.AddRegistrationDetails(table.Rows[0]["FirstName"],
         table.Rows[0]["LastName"], table.Rows[0]["Email"], table.Rows[0]["PhoneNumber"], table.Rows[0]["DateOfBirth"],
         table.Rows[0]["File"], table.Rows[0]["CurrentAddress"], table.Rows[0]["State"], table.Rows[0]["City"]);
    }

    [When(@"I click Gender Option '([^']*)'")]
    public void WhenIClickGenderOption(string female)
    {
        practiceFormsPage.ClickGenderButton(female);
    }

    [When(@"I click on submit button")]
    public void WhenIClickOnSubmitButton()
    {
        practiceFormsPage.ClickSubmit();
    }

    [Then(@"all the details entered should be displayed")]
    public void ThenAllTheDetailsEnteredShouldBeDisplayedAndValidated()
    {
        var result = practiceFormsPage.IsAllDataDisplayed();
        Assert.That(result, Is.EqualTo(true));
    }

    [Then(@"the data should be successfully submitted and retrieved")]
    public void ThenTheDataShouldBeSuccessfullySubmittedAndRetrieved(Table table)
    {
        string phone = practiceFormsPage.retrieveOutPutDatas(6);
        Assert.Multiple(() =>
        {
            Assert.That(table.Rows[0]["FirstName"] == practiceFormsPage.retrieveOutPutDatas(2).Split(" ")[0]);
            Assert.That(table.Rows[0]["LastName"] == practiceFormsPage.retrieveOutPutDatas(2).Split(" ")[1]);
            Assert.That(table.Rows[0]["Email"] == practiceFormsPage.retrieveOutPutDatas(4));
            Assert.That(table.Rows[0]["PhoneNumber"] == practiceFormsPage.retrieveOutPutDatas(8));
            Assert.That(table.Rows[0]["DateOfBirth"] == practiceFormsPage.retrieveOutPutDatas(10));
            Assert.That(table.Rows[0]["File"] == practiceFormsPage.retrieveOutPutDatas(16));
            Assert.That(table.Rows[0]["CurrentAddress"] == practiceFormsPage.retrieveOutPutDatas(18));
            Assert.That(table.Rows[0]["State"] == practiceFormsPage.retrieveOutPutDatas(20).Split(" ")[0]);
            Assert.That(table.Rows[0]["City"] == practiceFormsPage.retrieveOutPutDatas(20).Split(" ")[1]);
        }); 
    }
}