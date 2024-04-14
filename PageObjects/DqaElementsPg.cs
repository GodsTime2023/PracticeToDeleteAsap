namespace PracticeToDeleteAsap.PageObjects;

public class DqaElementsPg
{
    private IWebDriver driver;
    WaitMethod waitMethod;
    public DqaElementsPg(IWebDriver driverRep)
    {
        driver = driverRep;
        waitMethod = new WaitMethod(driver);
    }

    private IWebElement elementsHeaderTest => driver.S_E_By(By.XPath("(//div[@class='header-text'])[.='Elements']"));
    private IWebElement webTablesTab => driver.S_E_By(By.CssSelector("#item-3"));
    private IWebElement TextBoxTab => driver.S_E_By(By.CssSelector("#item-0"));

    public bool ElementsIsDisplayed() => waitMethod.WaitForElementDisplayed(elementsHeaderTest).S_E_Displayed();
    
    public void ClickWebTablesTab() => webTablesTab.S_E_Click();
    public void ClickTextBoxTab() => TextBoxTab.S_E_Click();
        public bool ElementsIsDisplayed() => waitMethod.WaitForElementDisplayed(elementsHeaderTest).S_E_Displayed();
        public void ClickWebTablesTab() => webTablesTab.S_E_Click();
  
    }
}
