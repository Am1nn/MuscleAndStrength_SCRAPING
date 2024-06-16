using MuscleAndStrength_SCRAPING.ViewModels;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MuscleAndStrength_SCRAPING.Services
{
    public class ProductInformationGenerator
    {

        public ProductInformationGenerator() { }

        public ProductVM GenerateProductInformation(string productUrl)
        {
            ProductVM newProduct = new();

            IWebDriver driver = new ChromeDriver();
            try
            {
                // Open Product's Page
                driver.Navigate().GoToUrl(productUrl);

                // Find Product Title
                IWebElement productTitle = driver.FindElement(By.ClassName("product-title"));
                string productTitleText = productTitle.Text;
                newProduct.Name= productTitleText;
                //Console.WriteLine("Product Name: " + productTitleText);

                // Find Product Description
                IWebElement descriptionDiv = driver.FindElement(By.ClassName("tagline"));
                string descriptionText = descriptionDiv.Text;
                newProduct.Description = descriptionText;
                //Console.WriteLine("Description: " + descriptionText);

                // Find Product Image
                IWebElement imageElement = driver.FindElement(By.Id("image"));
                string imageSrc = imageElement.GetAttribute("src");
                newProduct.ImgUrl = imageSrc;
                //Console.WriteLine("Image Src: " + imageSrc);

                // Find Product Price
                IWebElement priceSpan = driver.FindElement(By.ClassName("price"));
                decimal price = decimal.Parse(Regex.Replace(priceSpan.Text, "[^0-9.]", ""));
                newProduct.Price = price;
                //Console.WriteLine("Price: " + price);

            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                driver.Quit();
            }
            return newProduct;
        }
    }
}
