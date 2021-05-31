using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Lab4_SpecFlow.PageObject
{
    class AllProductsPage : AbstractPage
    {
        public AllProductsPage(IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Create new')]")]
        private IWebElement createNew;
        [FindsBy(How = How.XPath, Using = "//td[a[text()='Cake']] / following-sibling::td [a[text()='Edit']]")]
        private IWebElement product;
        [FindsBy(How = How.XPath, Using = "//td[a[text()='Cake']] / following-sibling::td [a[text()='Remove']]")]
        private IWebElement productRemove;
        [FindsBy(How = How.XPath, Using = "//h2")]
        public IWebElement resultCreate;
        [FindsBy(How = How.XPath, Using = "//a[@href='/Account/Logout']")]
        public IWebElement logout;

        public CreateNewProductPage ClickCreateNewProduct()
        {
            createNew.Click();
            return new CreateNewProductPage(driver);
        }
        public ProductPage ClickProductPage()
        {
            product.Click();
            return new ProductPage(driver);
        }
        public AllProductsPage ClickProductRemove()
        {
            productRemove.Click();
            driver.SwitchTo().Alert().Accept();
            return new AllProductsPage(driver);
        }

        public LoginPage LogOut()
        {
            logout.Click();
            return new LoginPage(driver);
        }
    }
}
