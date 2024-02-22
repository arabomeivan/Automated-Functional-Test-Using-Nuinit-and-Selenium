using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Qa_Assesments.Pages;

namespace Qa_Assesments
{
    [TestFixture]
    public class SauceLabTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProductPage productPage;
        private CartPage cartPage;
        private CheckoutPage checkoutPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            productPage = new ProductPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void Verify_User_is_LoggedIn()
        {
            loginPage.Login();
            Assert.That(productPage.ProductContainer.Displayed, Is.True, "Element is not displayed.");
        }

        [Test]
        public void Verify_User_is_Redirected_To_ProductsPage()
        {
            string productPageURL = "https://www.saucedemo.com/inventory.html";

          
            loginPage.Login();

            Assert.That(productPage.producstPageURL(), Is.EqualTo(productPageURL));
        }

        [Test]
        public void Verify_Tshirt_Details_Page_Is_Displayed()
        {

            
            loginPage.Login();
            productPage.SelectedTShirt.Click();

            Thread.Sleep(3000);

            string tshirt_url = "https://www.saucedemo.com/inventory-item.html?id=1";

            // checks if the currentUrl matches the variable to ensure product actually was displayed
            Assert.That(driver.Url, Is.EqualTo(tshirt_url));
            Assert.That(productPage.TshirtDetailsPage.Displayed, Is.True, "Product Details Page is not Displayed");
            
        
        }

        [Test]
        public void Verify_Tshirt_is_Added_To_Cart() 
        {
            loginPage.Login();
            productPage.SelectedTShirt.Click();
            Thread.Sleep(3000);
            productPage.AddToCart.Click();

            string cartURL = "https://www.saucedemo.com/cart.html";

            productPage.navigateToCart();
            //Verifies that we succesfully navigated to the cart page
            Assert.That(cartURL, Is.EqualTo(driver.Url));

            //Verifies if product is in the cart
            Assert.That(productPage.SelectedTshirtText, Is.EqualTo("Sauce Labs Bolt T-Shirt"));
            
        }

        [Test]
        public void Verify_Cart_Page_is_Displayed() 
        {
            loginPage.Login();
            productPage.navigateToCart();

            Assert.That(cartPage.cartPage.Displayed, Is.True, "Cart page is not displayed");
         
        }

        [Test]
        public void Verify_Item_Details_are_Displayed_Correctly_In_Cart()
        {
            loginPage.Login();
            productPage.SelectedTShirt.Click();

            Thread.Sleep(3000);

            productPage.AddToCart.Click();
            productPage.navigateToCart();


            string ItemDescription = "Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.";
            string ItemPrice = "$15.99";
            string ItemName = "Sauce Labs Bolt T-Shirt";

            Assert.That(cartPage.SelectedTshirtName, Is.EqualTo(ItemName));
            Assert.That(cartPage.SelectedTshirtPrice, Is.EqualTo(ItemPrice));
            Assert.That(cartPage.SelectedTshirtDescription, Is.EqualTo(ItemDescription));
        }

        [Test]
        public void Verify_Checkout_Page_Information_is_Displayed() 
        {
            loginPage.Login();
            productPage.SelectedTShirt.Click();

            Thread.Sleep(3000);

            productPage.AddToCart.Click();
            productPage.navigateToCart();
            cartPage.Checkout.Click();

            Thread.Sleep(5000);
            Assert.That(checkoutPage.CheckoutInformationPage.Displayed, Is.True, "Checkout Information is not Displayed");
        }

        [Test]
        public void Verify_Order_Summary_Page_is_Displayed()
        {
            loginPage.Login();
            productPage.SelectedTShirt.Click();

            Thread.Sleep(3000);

            productPage.AddToCart.Click();
            productPage.navigateToCart();
            cartPage.Checkout.Click();
            checkoutPage.Continue_to_Order_Page();

            Thread.Sleep(5000);
            string ItemDescription = "Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.";
            string ItemTotalPrice = "Total: $17.27";
            string ItemName = "Sauce Labs Bolt T-Shirt";

            Assert.That(checkoutPage.CheckoutSummary.Displayed, Is.True, "Checkout Summary is Displayed");
            Assert.That(cartPage.SelectedTshirtName, Is.EqualTo(ItemName));
            Assert.That(checkoutPage.Order_Total_Price, Is.EqualTo(ItemTotalPrice));
            Assert.That(cartPage.SelectedTshirtDescription, Is.EqualTo(ItemDescription));
        }

        [Test]
        public void Verify_Order_Confirmed()
        {
            string pageURL = "https://www.saucedemo.com/checkout-complete.html";
            loginPage.Login();
            productPage.SelectedTShirt.Click();

            Thread.Sleep(3000);

            productPage.AddToCart.Click();
            productPage.navigateToCart();
            cartPage.Checkout.Click();
            checkoutPage.Continue_to_Order_Page();

            Thread.Sleep(5000);
            checkoutPage.CompleteOrder.Click();

            Thread.Sleep(5000);

            
            Assert.That(checkoutPage.Order_Successfull, Is.EqualTo("Thank you for your order!"));
            Assert.That(driver.Url, Is.EqualTo(pageURL));
        }
        [Test]
        public void Verify_User_Logout()
        {
            string LoginPageURL = "https://www.saucedemo.com/";
            loginPage.Login();

            Thread.Sleep(5000);
            loginPage.Logout();

            // Verify user is logged out by visiting a protected route
            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");
            Assert.That(driver.Url, Is.EqualTo(LoginPageURL));

            
        }
    }
}
