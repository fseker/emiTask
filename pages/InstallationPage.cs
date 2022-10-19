using OpenQA.Selenium;

namespace emitask.pages;

public class InstallationPAge
{
    //selectos strings 
    public string webInstallerLinkText = "Web installer";

    public void downloadWebInstaller(IWebDriver Driver, string linkText)
    {
        Driver.FindElement(By.LinkText(linkText)).Click();
    }

    public static bool CheckFileDownloaded(string filename)
    {
        bool exist = false;
        string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
        string[] filePaths = Directory.GetFiles(Path);
        foreach (string p in filePaths)
        {
            if (p.Contains(filename))
            {
                exist = true;
                File.Delete(p);
                break;
            }
        }
        return exist;
    }
}