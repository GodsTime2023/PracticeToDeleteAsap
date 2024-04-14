namespace PracticeToDeleteAsap.PageElements;

public static class ElementsExtensions
{
    public static IWebElement S_E_By(this IWebDriver driver, By by) =>
        driver.FindElement(by);

    public static IList<IWebElement> S_Es_By(this IWebDriver driver, By by) =>
        driver.FindElements(by);

    public static void S_E_Click(this IWebElement element)
        => element.Click();

    public static void S_E_EnterText(this IWebElement element, string text)
        => element.SendKeys(text);

    public static string S_E_GetText(this IWebElement element)
        => element.Text;

    public static bool S_E_Displayed(this IWebElement element)
        => element.Displayed;

    public static string S_E_GetTextByValueAttribute(this IWebElement element)
        => element.GetAttribute("value");

    public static IReadOnlyCollection<string> S_E_GetAllText(this IList<IWebElement> elements)
    {
        List<string> datas = new List<string>();
        foreach (var element in elements)
        { datas.Add(element.Text); }
        return datas;
    }

    public static IReadOnlyCollection<string> S_E_GetAllTextByLinqs(this IList<IWebElement> elements)
    {
        List<string> datas = new List<string>();
        elements.ToList().ForEach(x => datas.Add(x.Text));
        return datas;
    }

    public static void S_E_SelectByTextFromDropDown(this IWebElement element, string text)
        => new SelectElement(element).SelectByText(text);

    public static void S_E_SelectByValueFromDropDown(this IWebElement element, string text)
        => new SelectElement(element).SelectByValue(text);

    public static void S_E_SelectByIndexFromDropDown(this IWebElement element, int index)
        => new SelectElement(element).SelectByIndex(index);

    public static void S_E_GetOptionsFromDropDown(this IWebElement element, int index)
        => new SelectElement(element).Options.ToList();

    public static IWebElement S_E_ClickByJs(this IWebElement element, IWebDriver driver)
        => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);

    public static string AddRandomDigit(this string text) => text + new Random().Next(1, 999).ToString();

    public static void S_E_ClickDropDownByActionsMethod(this IWebElement element, IWebDriver driver)
    {
        Actions action = new Actions(driver);
        action.MoveToElement(element).Perform();
        action.Click(element).Perform();
    }
}