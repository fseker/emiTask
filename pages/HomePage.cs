using OpenQA.Selenium;

namespace emitask.pages;

public class HomePage
{
    //selectos strings 
    public string downloadPageLinkText = "Alternative installation options";

    public void goToDownloadPage(IWebDriver Driver, string linkText)
    {
        Driver.FindElement(By.LinkText(linkText)).Click();
    }
}