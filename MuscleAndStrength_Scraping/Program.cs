using MuscleAndStrength_SCRAPING.Services;
using MuscleAndStrength_SCRAPING.ViewModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace MuscleAndStrength_SCRAPING
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICollection<string> links = new List<string>();

            ICollection<ProductVM> products= new List<ProductVM>();


            ProductUrlGenerator urlGenerator = new ProductUrlGenerator();
            ProductInformationGenerator informationGenerator = new ProductInformationGenerator();
            links = urlGenerator.GenerateProductUrl(50);

            foreach (string link in links)
            {
                products.Add(informationGenerator.GenerateProductInformation(link));
            }

            foreach (ProductVM product in products)
            {
                Console.WriteLine("\nProduct Name:"+product.Name);
                Console.WriteLine("Product Description:" + product.Description);
                Console.WriteLine("Product Img:" + product.ImgUrl);
                Console.WriteLine("Product Price:" + product.Price+"\n\n");
                
            }
        }
    }
}