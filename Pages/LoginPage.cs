using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qa_Assesments.Pages
{
    internal class LoginPage
    {
        IWebDriver WebDriver { get; }

        public LoginPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;

        }

        public IWebElement username => WebDriver.FindElement(By.CssSelector("[data-test='username']"));
        public IWebElement password => WebDriver.FindElement(By.CssSelector("[data-test='password']"));

        public IWebElement SideBarBtn => WebDriver.FindElement(By.Id("react-burger-menu-btn"));

        public IWebElement logout => WebDriver.FindElement(By.Id("logout_sidebar_link"));
        public IWebElement login => WebDriver.FindElement(By.CssSelector("[data-test='login-button']"));

        public void Login()
        {
            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            login.SendKeys(Keys.Enter);

            Thread.Sleep(5000);

        }

        public void Logout() 
        {
            SideBarBtn.Click();
            logout.Click();
        }

    }
}
