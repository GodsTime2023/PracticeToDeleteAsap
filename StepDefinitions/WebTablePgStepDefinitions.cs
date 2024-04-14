namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public class WebTablePgStepDefinitions
{
    IWebDriver driver;
    DqaWebTablePg wTablePg;
    public WebTablePgStepDefinitions(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        wTablePg = new DqaWebTablePg(driver);
    }
    [Then(@"I will arrive on the Web Tables page")]
    public void ThenIWillArriveOnTheWebTablesPage()
    {
        Assert.True(wTablePg.WebTableDisplayed());
    }

    [When(@"I click on the Add button")]
    public void WhenIClickOnTheAddButton()
    { 
        wTablePg.ClickAddButton();
    }

    [Then(@"the Registration form window will appear on the screen")]
    public void ThenTheRegistrationFormWindowWillAppearOnTheScreen()
    {
        Assert.That(wTablePg.RegistrationFormDisplayed().Contains("Registration Form"), Is.EqualTo(true));
    }

    [When(@"I complete the Registration form with the following data")]
    public void WhenICompleteTheRegistrationFormWithTheFollowingData(Table table)
    {
        wTablePg.AddTableData0(table.Rows[0]["Firstname"].AddRandomDigit(), 
            table.Rows[0]["Lastname"], table.Rows[0]["Email"], 
            table.Rows[0]["Age"],
            table.Rows[0]["Salary"], table.Rows[0]["Department"]);
    }

    [When(@"I click on the submit button")]
    public void WhenIClickOnTheSubmitButton()
    {
       wTablePg.ClickSubmitButton();
    }

        [Then(@"the entry will be displayed on the list")]
        public void ThenTheEntryWillBeDisplayedOnTheList()
        {
            var entryNameIsDisplayed = wTablePg.CaptureBenText();
            Assert.That(entryNameIsDisplayed, Is.EqualTo(true));
        }

    [When(@"I complete the Registration form with a new set of data")]
    public void WhenICompleteTheRegistrationFormWithANewSetOfData(Table table)
    {
        wTablePg.AddTableData1(table.Rows[0]["Firstname"], table.Rows[0]["Lastname"], 
          table.Rows[0]["Email"], table.Rows[0]["Age"],
          table.Rows[0]["Salary"], table.Rows[0]["Department"]);
    }

    [When(@"I click on the edit button next to the entry")]
    public void WhenIClickOnTheEditButtonNextToTheEntry()
    {
        wTablePg.ClickEditSecondEntryButton();
    }

    [When(@"I change the lastname field to '(.*)'")]
    public void WhenEditAnyOfTheFields(string value)
    {
        wTablePg.EditSecondEntryName(value);
    }

        [Then(@"the newly edited data '(.*)' will be displayed on the list")]
        public void ThenTheNewlyEditedDataWillBeDisplayedOnTheList(string value)
        {
            var newlyEditedText = wTablePg.EditedLastnameFieldIsDisplayed(value);
            Assert.That(newlyEditedText == value);
        }

    [When(@"I complete the Registration form with new data")]
    public void WhenICompleteTheRegistrationFormWithNewData(Table table)
    {
        wTablePg.AddTableData2(table.Rows[0]["Firstname"], table.Rows[0]["Lastname"], 
            table.Rows[0]["Email"], table.Rows[0]["Age"],
            table.Rows[0]["Salary"], table.Rows[0]["Department"]);
    }

    [When(@"I click on the delete button next to the entry")]
    public void WhenIClickOnTheDeleteButtonNextToTheEntry()
    {
        wTablePg.ClickDeleteForThirdEntryButton();
    }

    [Then(@"the entry will be no longer be available on the list")]
    public void ThenTheEntryWillBeNoLongerBeAvailableOnTheList()
    {
        Assert.False(wTablePg.DeletedEntryIsNotDisplayed());
    }
}
        [Then(@"the entry will be no longer be available on the list")]
        public void ThenTheEntryWillBeNoLongerBeAvailableOnTheList()
        {
            Assert.That(wTablePg.DeletedEntryIsNotDisplayed(), Is.EqualTo(true));
        }
    }
}
