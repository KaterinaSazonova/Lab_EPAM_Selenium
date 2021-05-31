using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Lab4_SpecFlow.PageObject
{
    class HomePage : AbstractPage
    {
        public HomePage(IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div/a[@href='/Product']")]
        public IWebElement allProducts;
        [FindsBy(How = How.XPath, Using = "//a[@href='/Account/Logout']")]
        public IWebElement logout;

        public AllProductsPage ClickAllProducts()
        {
            allProducts.Click();
            return new AllProductsPage(driver);
        }
        public LoginPage ClickLogOut()
        {
            logout.Click();
            return new LoginPage(driver);
        }
    }
}
