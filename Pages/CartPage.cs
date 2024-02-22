using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qa_Assesments.Pages
{
    internal class CartPage
    {
        IWebDriver WebDriver { get; }

        public CartPage (IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement cartPage => WebDriver.FindElement(By.Id("cart_contents_container"));
        public IWebElement TshirtDescription => WebDriver.FindElement(By.ClassName("inventory_item_desc"));

        public IWebElement TshirtName => WebDriver.FindElement(By.ClassName("inventory_item_name"));
        public IWebElement TshirtPrice => WebDriver.FindElement(By.ClassName("inventory_item_price"));

        public IWebElement Checkout => WebDriver.FindElement(By.CssSelector("[data-test='checkout']"));
        
        public string SelectedTshirtPrice()
        {
            string selectedtshritprice = TshirtPrice.Text;

            return selectedtshritprice;

        }
        public string SelectedTshirtDescription()
        {
            string selectedtshritdescription = TshirtDescription.Text;

            return selectedtshritdescription;

        }



        public string SelectedTshirtName()
        {
            string selectedtshritname = TshirtName.Text;

            return selectedtshritname;

        }
    }
}
