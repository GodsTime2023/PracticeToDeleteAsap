namespace PracticeToDeleteAsap.PageObjects;

public class DqaAlertsFrameWindowsPg
{
    private IWebDriver driver;
    WaitMethod waitMethod;
    public DqaAlertsFrameWindowsPg(IWebDriver driverCon)
    {
        driver = driverCon;
        waitMethod = new WaitMethod(driver);
    }

    private IWebElement Alertstab => driver.S_E_By(By.XPath("(//li[@id='item-1'])[2]"));
    private IWebElement AlertsFrameWindowsTitle
        => driver.S_E_By(By.XPath("(//div[@class='header-text'])[.='Alerts, Frame & Windows']"));
    
    
    public bool AlertsFrameWindowsTitleIsDisplayed()
        => waitMethod.WaitForAlertsFrameWindowsTitleDisplayed(AlertsFrameWindowsTitle).S_E_Displayed();

    public void ClickAlerttab()
    {
        waitMethod.WaitForAlertsFrameWindowsTitleDisplayed(Alertstab);
        Alertstab.S_E_ClickByJs(driver);

    }
}