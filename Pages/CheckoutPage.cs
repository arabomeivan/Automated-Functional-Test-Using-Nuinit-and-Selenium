using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qa_Assesments.Pages
{
    internal class CheckoutPage
    {
        IWebDriver WebDriver { get; }

        public CheckoutPage(IWebDriver webDriver) 
        {
            WebDriver = webDriver;
        }

        public IWebElement CheckoutInformationPage => WebDriver.FindElement(By.ClassName("checkout_info"));

        public IWebElement FirstName => WebDriver.FindElement(By.CssSelector("[data-test='firstName']"));
        public IWebElement LastName => WebDriver.FindElement(By.CssSelector("[data-test='lastName']"));
        public IWebElement PostalCode => WebDriver.FindElement(By.CssSelector("[data-test='postalCode']"));

        public IWebElement ContinueBtn => WebDriver.FindElement(By.CssSelector("[data-test='continue']"));

        public IWebElement CheckoutSummary => WebDriver.FindElement(By.Id("checkout_summary_container"));

        public IWebElement OrderTotalPrice => WebDriver.FindElement(By.XPath("//*[@id=\"checkout_summary_container\"]/div/div[2]/div[8]"));

        public IWebElement CompleteOrder => WebDriver.FindElement(By.CssSelector("[data-test='finish']"));


        public IWebElement OrderSuccessfull => WebDriver.FindElement(By.ClassName("complete-header"));
            public void Continue_to_Order_Page() 
        {
            FirstName.SendKeys("Ivan");
            LastName.SendKeys("Arabome");
            PostalCode.SendKeys("90001");
            ContinueBtn.Click();
        }

        public string Order_Total_Price() 
        {
            string order_total_price = OrderTotalPrice.Text;

            return order_total_price;
        }

        public string Order_Successfull()
        {
            string ordersuccessfull = OrderSuccessfull.Text;

            return ordersuccessfull;
        }
    }
}
