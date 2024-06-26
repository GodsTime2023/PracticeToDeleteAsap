﻿namespace PracticeToDeleteAsap.Support;

public class WaitMethod
{
    IWebDriver driver;
    public WaitMethod(IWebDriver _driver)
    {
        driver = _driver;
    }

    private T WaitUntilAccepted<T>(Func<T> getResult, Func<T, bool> isResultAccepted) 
        where T : class
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        return wait.Until(x =>
        {
            var result = getResult();
            if (!isResultAccepted(result))
                return default;
            
            return result;
        })!;
    }

    private string WaitForElementAndGetText(Func<string> getResult, Func<string, bool> isResultAccepted)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        return wait.Until(driver =>
        {
            string result = getResult();

            if (!isResultAccepted(result))
                return null;

            return result;
        })!;
    }

    public string WaitAndGetResult(IWebElement element)
    {
        return WaitUntilAccepted(() => element.GetAttribute("value"),
            x => !string.IsNullOrEmpty(x));
    }

    public IWebElement WaitForElementDisplayed(IWebElement element)
    {
        return WaitUntilAccepted(() => element, x => element.Displayed);
    }

    public string WaitForAndGetText(IWebElement element)
    {
        return WaitForElementAndGetText(() => element.Text, 
            x => element.Text != null);
    }

    public IWebElement WaitForAlertsFrameWindowsTitleDisplayed(IWebElement alertsFrameWindowsTitle)
    {
        return WaitUntilAccepted(() => alertsFrameWindowsTitle, x => alertsFrameWindowsTitle.Displayed);
    }

    public WebDriverWait WaitForAlertToBeDisplayed()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.AlertIsPresent());
        return wait;
    }

    public WebDriverWait WaitForElement(IWebElement element)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        wait.Until(x => element.Displayed);
        return wait;
    }

    public WebDriverWait WaitForElementVisible(By locator)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        wait.Until(ExpectedConditions.ElementIsVisible(locator));
        return wait;
    }
}