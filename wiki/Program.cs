using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace wiki
{
    class Program
    {
        static void Main (string[] args)
        {
            // using (var driver = new ChromeDriver())
            var driver = new ChromeDriver();
            {
                try
                {
                    driver.Navigate().GoToUrl("https://www.wikipedia.org");
                    
                    var SeBox = driver.FindElement(By.Id("searchInput"));
                    SeBox.SendKeys("Россия");

                    SeBox.SendKeys(Keys.Enter);

                    var Way = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    var Head = Way.Until(drv => drv.FindElement(By.Id("firstHeading")));

                    if (Head.Text.Contains("Россия"))
                    {
                        Console.WriteLine("all good");
                    }
                    else{
                        Console.WriteLine($"Unlucky '{Head.Text}' not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"test failed {ex.Message}");
                }
                Console.WriteLine("\nPress any key to close");
                Console.ReadKey();

                driver.Quit();
               
            }
        }
    }
}