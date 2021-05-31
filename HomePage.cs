using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Selenium_WD_Lab2
{
    class HomePage : AbstractPage
    {
        public HomePage (IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div/a[@href='/Product']")]
        public IWebElement allProducts;
        [FindsBy(How = How.XPath, Using = "//a[@href='/Account/Logout']")]
        public IWebElement logout;

        public AllProductsPage Products()
        {
            allProducts.Click();
            return new AllProductsPage(driver);
        }
        public LoginPage LogOut()
        {
            logout.Click();
            return new LoginPage(driver);
        }
    }
}
