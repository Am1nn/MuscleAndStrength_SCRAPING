using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace MuscleAndStrength_SCRAPING.Services;

public class ProductUrlGenerator
{
    public ProductUrlGenerator() { }
    public ICollection<string> GenerateProductUrl(int urlcount = 10)
    {
        ICollection<string> ProductsUrl = new HashSet<string>();
        int counter = 0;
        if (counter != urlcount)
        {
            // Open Google Page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.muscleandstrength.com/store/");

            // find no-reviews tags
            IReadOnlyCollection<IWebElement> productsDiv = driver.FindElements(By.ClassName("no-reviews"));

            foreach (IWebElement productDiv in productsDiv)
            {
                try
                {
                    if(counter==urlcount)
                    {
                        driver.Quit();
                        break;
                    }
                    // find a tag into no-reviews div
                    IWebElement productTagA = productDiv.FindElement(By.TagName("a"));

                    // claim href value into a tag
                    string productHrefValue = productTagA.GetAttribute("href");

                    // add url
                    ProductsUrl.Add(productHrefValue);
                    counter++;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            driver.Quit();
        }

        return ProductsUrl;
    }
}
