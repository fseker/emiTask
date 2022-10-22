using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.DefaultWaitHelpers;
using emitask.pages;

namespace emitask.tests;

public class Tests : DriverHelper
{
    string url = "https://www.emsisoft.com/en/anti-malware-home";

    // Initialize Pages

    HomePage home = new HomePage();
    InstallationPAge installationPage = new InstallationPAge();

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArguments("--safebrowsing-disable-download-protection", "--disable-gpu", "--headless");
        options.AddUserProfilePreference("safebrowsing", "enabled");
        
        //enable file download in headless mode
        var downloadPath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
        options.AddUserProfilePreference("download.default_directory", downloadPath);
        options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
        
        Driver = new ChromeDriver(options);
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(url);
    }

    [Test]
    public void downloadWebInstallerTest()
    {
        Driver.WaitUntil(ExpectedConditionsSearchContext.ElementExists(By.LinkText(home.downloadPageLinkText)));
        home.goToDownloadPage(Driver, home.downloadPageLinkText);

        Driver.WaitUntil(ExpectedConditionsSearchContext.ElementExists(By.LinkText(installationPage.webInstallerLinkText)));
        installationPage.downloadWebInstaller(Driver, installationPage.webInstallerLinkText);

        Assert.That(InstallationPAge.CheckFileDownloaded("EmsisoftAntiMalwareWebSetup.exe"), Is.True);

    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}