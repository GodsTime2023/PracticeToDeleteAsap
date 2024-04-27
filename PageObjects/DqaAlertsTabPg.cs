namespace PracticeToDeleteAsap.PageObjects;

public class DqaAlertsTabPg
{
    private IWebDriver driver;
    WaitMethod waitMethod;
    public DqaAlertsTabPg(IWebDriver driverCon)
    {
        driver = driverCon;
        waitMethod = new WaitMethod(driver);
    }

    private IWebElement Alertstabvisible => driver.S_E_By(By.XPath("//*[@id='javascriptAlertsWrapper']/h1"));

    private IWebElement AlertsBtn => driver.S_E_By(By.CssSelector("#timerAlertButton"));
    private IWebElement Clickme => driver.S_E_By(By.CssSelector("#promtButton"));
    private IWebElement AlertMessageDisplayed => driver.S_E_By(By.CssSelector("#promptResult"));


    public bool AlertstabDisplayed() => Alertstabvisible.S_E_Displayed();

    public void ClickAlertBtn2()
    {
        driver.UseIJavaScroll(Clickme);
        Clickme.S_E_ClickByJs(driver);
        waitMethod.WaitForAlertToBeDisplayed();
        IAlert alert = driver.SwitchTo().Alert();
    }

    public void ClickAlertBtn() => AlertsBtn.S_E_Click();

    public void IsAlertMessageDisplayed()
    {
        waitMethod.WaitForAlertToBeDisplayed();
        IAlert alert = driver.SwitchTo().Alert();
        alert.Accept();
    }

    public void EnterAlertValue(string value)
    {
        waitMethod.WaitForAlertToBeDisplayed();
        IAlert alert = driver.SwitchTo().Alert();
        alert.SendKeys(value);
        alert.Accept();
    }

    public string GetAlertValueDisplayed()
    {
        driver.UseIJavaScroll(AlertMessageDisplayed);
        return AlertMessageDisplayed.S_E_GetText();
    }
}
