using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qa_Assesments.Pages
{
    internal class ProductPage
    {
        public IWebDriver WebDriver { get; }

        public ProductPage(IWebDriver driver)
        {
            WebDriver = driver;

        }
        public IWebElement ProductContainer => WebDriver.FindElement(By.Id("inventory_container"));

        public IWebElement SelectedTShirt => WebDriver.FindElement(By.Id("item_1_title_link"));

        public IWebElement TshirtDetailsPage => WebDriver.FindElement(By.ClassName("inventory_details"));

       
        public IWebElement AddToCart => WebDriver.FindElement(By.CssSelector("[data-test='add-to-cart-sauce-labs-bolt-t-shirt']"));

        public IWebElement CartLink => WebDriver.FindElement(By.ClassName("shopping_cart_link"));

        
        
        public string producstPageURL()
        {
            return WebDriver.Url;
        }

        public void navigateToCart() 
        {
            CartLink.Click();
            Thread.Sleep(2000);
        }

        public string SelectedTshirtText() 
        {
            string selectedtshrit = SelectedTShirt.Text;

            return selectedtshrit;

        }



    }
}
