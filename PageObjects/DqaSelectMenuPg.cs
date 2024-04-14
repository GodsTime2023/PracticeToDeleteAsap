namespace PracticeToDeleteAsap.PageObjects;

public class DqaSelectMenuPg
{
    private IWebDriver driver;
    WaitMethod waitMethod;
    public DqaSelectMenuPg(IWebDriver _driver)
    {
        this.driver = _driver;
        waitMethod = new WaitMethod(driver);
    }


    private IWebElement widgets => driver.S_E_By(By.XPath("//h5[normalize-space()='Widgets']"));
    private IWebElement selectMenu => driver.S_E_By(By.XPath("//span[contains(text(),'Select Menu')]"));
    private IWebElement selectOption => driver.S_E_By(By.XPath("//*[@id='withOptGroup']/div/div[1]"));
    private IWebElement selectTitle => driver.S_E_By(By.CssSelector("div[id='selectOne'] div[class=' css-1hwfws3']"));
    private IWebElement oldStyleColour => driver.S_E_By(By.Id("oldSelectMenu"));
    private IWebElement multiColour => driver.S_E_By(By.XPath("//div[@id='selectMenuContainer']//div[@class='row']//div[contains(@class,'css-1hwfws3')]"));
    private IWebElement multiStandard => driver.S_E_By(By.Id("cars"));
    
    
    private IWebElement dropDownValue(int index0, int index1) => driver.FindElement(By.XPath($"//*[@id='react-select-2-option-{index0}-{index1}']"));
    private IWebElement dropDownSelectOne(int index2, int index3) => driver.FindElement(By.CssSelector($"#react-select-3-option-{index2}-{index3}"));
    private IWebElement dropDownSelectMultiColor(int index0) => driver.FindElement(By.CssSelector($"#react-select-4-option-{index0}"));
  
    public bool ElementsIsDisplayed() => waitMethod.WaitForElementDisplayed(widgets).S_E_Displayed();

    public void ClickWidgets()
    {
        driver.UseIJavaScroll(widgets);
        widgets.S_E_Click();
    }

    public bool PageIsDisplayed() => waitMethod.WaitForElementDisplayed(selectMenu).S_E_Displayed();

    public void ClickSelectMenu()
    {
        waitMethod.WaitForElementDisplayed(selectMenu);
        driver.UseIJavaScroll(selectMenu);
        selectMenu.S_E_Click();
    }

    public void SelectDrpdownOption(string option, string value)
    {
        driver.UseIJavaScroll(selectOption);
        if (selectOption.TagName.ToLower() == option.ToLower())
        {
            selectOption.S_E_SelectByTextFromDropDown(value);   
        }
        else
        {
            selectOption.S_E_ClickDropDownByActionsMethod(driver);
            dropDownValue(0,1).S_E_ClickDropDownByActionsMethod(driver);
            Console.WriteLine($"Selected option is: Group 1, option 2");
            ScenarioContext.Current.Add("SelectValueDropdown", selectOption.Text); 
        }
    }
    public void SelectDrpdownTitle(string option, string value)
    {
        driver.UseIJavaScroll(selectTitle);
        if (selectOption.TagName.ToLower() == option.ToLower())
        {
            selectTitle.S_E_SelectByTextFromDropDown(value);
        }
        else
        {
            selectTitle.S_E_ClickDropDownByActionsMethod(driver);
            dropDownSelectOne(0,0).S_E_ClickDropDownByActionsMethod(driver);
            Console.WriteLine($"Selected option is: Dr.");
            ScenarioContext.Current.Add("SelectOnedropDown", selectTitle.Text);
        }
    }

    public void SelectDrpdownStyleColour()
    {
        oldStyleColour.S_E_SelectByIndexFromDropDown(1);
        Console.WriteLine($"Selected option is: Blue");
        ScenarioContext.Current.Add("OldStyleSelectMenu", oldStyleColour.Text);
    }

    public void SelectDrpdownMultiColour(string option, string value)
    {
        driver.UseIJavaScroll(multiColour);
        if (selectOption.TagName.ToLower() == option.ToLower())
        {
            multiColour.S_E_SelectByValueFromDropDown(value);
        }
        else
        {
            multiColour.S_E_ClickDropDownByActionsMethod(driver);
            dropDownSelectMultiColor(0).S_E_ClickDropDownByActionsMethod(driver);
            dropDownSelectMultiColor(3).S_E_ClickDropDownByActionsMethod(driver);
            Console.WriteLine($"Selected option is: Green & Red");
            ScenarioContext.Current.Add("MultiColourSelectMenu", multiColour.Text);
        }
    }

    public void SelectDrpdownMultiStandard(string[] param)
    {
        waitMethod.WaitForElementDisplayed(multiStandard);
        SelectElement carmodels = new SelectElement(multiStandard);
        carmodels.SelectByValue(param[0]);
        carmodels.SelectByText(param[1]);
        carmodels.SelectByValue(param[2]);
        carmodels.SelectByText(param[3]);

        int index = 0;
        var selectedOptions = carmodels.AllSelectedOptions;
        foreach (var option in selectedOptions)
        {
            ScenarioContext.Current.Add($"MultiStandard{index}", option.Text);
            index++;
        }
    }
}