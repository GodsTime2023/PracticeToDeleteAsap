using PracticeToDeleteAsap.Modules;

namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public class DemoqaStepDefinitions
{
    private readonly IWebDriver driver;
    private DemoQaHomePage? demoQaHomePage;
    private DemoqaBooksPage demoqaBooksPage;
    private DqaElementsPg demoQaElementPage;

    public DemoqaStepDefinitions(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        demoQaHomePage = new DemoQaHomePage(driver);
        demoqaBooksPage = new DemoqaBooksPage(driver);
        demoQaElementPage = new DqaElementsPg(driver);
    }

    [Then(@"I am on demoqa page")]
    public void GivenIAmOnDemoqaPage()
    {
        driver.Url.Should().Contain("demoqa");
        Assert.That(driver.Url.Contains("demoqa"), Is.EqualTo(true));
    }

    [When(@"I click elements")]
    public void WhenIClickElements()
    {
        demoQaHomePage?.ClickElementsWithElementCollections();
    }

    [Scope(Tag = "@Forms")]
    [When(@"I click on Forms menu")]
    public void WhenIClickOnFormsMenu()
    {
        demoQaHomePage?.ClickElementsWithFormCollections();
    }

    [Then(@"I am on elements page")]
    public void ThenIAmOnElementsPage()
    {
        driver.Url.Should().Contain("elements");
        Assert.That(driver.Url.Contains("elements"), Is.EqualTo(true));
    }

    [When(@"I click (.*) menu")]
    public void WhenIClickBookStoreApplication(string text)
    {
        demoQaHomePage?.ClickElementByName(text);
    }

    [When(@"I enter (.*) and (.*)")]
    public void WhenIEnterTestUserAndPassword(string user, string pass)
    {
        demoqaBooksPage.EnterUserNameAndPassword(user, pass);
    }

    [Then(@"I am loged in as (.*)")]
    public void ThenIAmLogedInAsTestUser(string user)
    {
        string userName = demoqaBooksPage.IsUserLoggedIn();
        Assert.That(user == userName, Is.EqualTo(true));
    }

    [When(@"I select BookStoreApplication menu")]
    public void WhenISelectBookStoreApplicationMenu(Library table)
    {
        demoQaHomePage?.
            ClickElementByName(table.BookStoreApplication);
    }

    [When(@"I input Username and Password:")]
    public void WhenIInputUsernameAndPassword(LoginCredentials tableData)
    {
        demoqaBooksPage.EnterUserNameAndPassword(
            tableData.UserName, tableData.Password);
    }

    [Then(@"I am loged in as:")]
    public void ThenIAmLogedInAs(LoginCredentials tableData)
    {
        string userName = demoqaBooksPage.IsUserLoggedIn();
        Assert.That(tableData.UserName == userName, Is.EqualTo(true));
    }

    [When(@"I input Username and Passwor and save username as '([^']*)'")]
    public void WhenIInputUsernameAndPassworAndSaveUsernameAs(
        string user, LoginCredentials tableData)
    {
        demoqaBooksPage.EnterUserNameAndPassword(
            tableData.UserName, tableData.Password);

        ScenarioContext.Current.Add(user, tableData.UserName);
    }

    [Then(@"user is logged in as '(.*)'")]
    public void ThenIAmLogedInAs(string expected)
    {
        string expectedValue = ScenarioContext.Current.Get<string>(expected);
        string actualValue = demoqaBooksPage.IsUserLoggedIn();
        Assert.That(expectedValue == actualValue, Is.EqualTo(true));
    }

    [When(@"I click on Text Box menu on elements page")]
    public void WhenIClickOnTextBoxMenu()
    {
        demoQaElementPage.ClickTextBoxTab();
    }

    [Scope(Tag = "@Alerts")]
    [When(@"I click on Alerts, Frame & Windows menu")]
    public void WhenIClickOnAlertsFrameWindowsMenu()
    {
        demoQaHomePage?.ClickAlertFrameAndWindowsWithElementCollections();
    }

    [When(@"I select BookStoreApplication menu from table")]
    public void WhenISelectBookStoreApplicationMenuFromTable(Library table)
    {
        demoQaHomePage?.
          ClickElementByName(table.BookStoreApplication);
    }
}