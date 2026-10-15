using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace WikipediaTests;

[TestFixture]
[AllureNUnit]
[AllureFeature("поиск в Wikipedia")]
[AllureStory("поиск статьи")]
public class SearchTest
{
    private IWebDriver driver = null!;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }

    [Test]
    [AllureName("поиск статьи 'Россия'")]
    public void Search()
    {
        AllureApi.Step("открыть сайт Wikipedia", () =>
        {
            driver.Navigate().GoToUrl("https://ru.wikipedia.org");
        });

        AllureApi.Step("Ввести в поиск 'Россия'", () =>
        {
            IWebElement search = driver.FindElement(By.Id("searchInput"));
            search.SendKeys("Россия");
        });

        AllureApi.Step("Нажать Enter", () =>
        {
            IWebElement search = driver.FindElement(By.Id("searchInput"));
            search.SendKeys(Keys.Enter);
        });

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        AllureApi.Step("проверить заголовок статьи", () =>
        {
            wait.Until(d => d.Url.Contains("/wiki/"));

            IWebElement heading = wait.Until(d =>
            {
                var el = d.FindElement(By.Id("firstHeading"));
                return string.IsNullOrEmpty(el.Text) ? null : el;
            });

            Assert.That(heading.Text, Does.Contain("Россия"));
        });

        AllureApi.Step("сделать скриншот", () =>
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = "screen.png";
            screenshot.SaveAsFile(path);

            AllureApi.AddAttachment(path, "скриншот страницы");
        });
    }
}