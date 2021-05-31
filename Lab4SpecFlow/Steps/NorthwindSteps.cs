using System;
using TechTalk.SpecFlow;
using Lab4_SpecFlow.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Lab4_SpecFlow.Fabric;
using NUnit.Framework;

namespace Lab4_SpecFlow.Steps
{
    [Binding]
    public class NorthwindSteps
    {
        private static IWebDriver driver;

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.Navigate().GoToUrl(url);
        }
        
        [When(@"I login with name ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithNameAndPassword(string name, string password)
        {
            new LoginPage(driver).Login(name, password);
        }
        
        [When(@"I click on button send")]
        public void WhenIClickOnButtonSend()
        {
            new LoginPage(driver).ClickSend();
        }
        
        [When(@"I click on button All Products")]
        public void WhenIClickOnButtonAllProducts()
        {
            new HomePage(driver).ClickAllProducts();
        }
        
        [When(@"I click on button Create New")]
        public void WhenIClickOnButtonCreateNew()
        {
            new AllProductsPage(driver).ClickCreateNewProduct();
        }
        
        [When(@"I fill field for create new product")]
        public void WhenIFillFieldForCreateNewProduct()
        {
            new CreateNewProductPage(driver).CreateNewPr();
        }
        
        [When(@"I click on button send product")]
        public void WhenIClickOnButtonSendProduct()
        {
            new CreateNewProductPage(driver).ClickSend();
        }
        
        [When(@"I click on new product")]
        public void WhenIClickOnNewProduct()
        {
            new AllProductsPage(driver).ClickProductPage();
        }
        
        [Then(@"all field should be filled correct")]
        public void ThenAllFieldShouldBeFilledCorrect()
        {
            ProductPage productPage = new ProductPage(driver);
            Product product = new Product();
            Assert.AreEqual(product.PName, productPage.productName.GetAttribute("value"));
            Assert.AreEqual(product.Category, productPage.categoryId.Text);
            Assert.AreEqual(product.Supplier, productPage.supplierId.Text);
            Assert.AreEqual(product.UPrice + ",0000", productPage.unitPrice.GetAttribute("value"));
            Assert.AreEqual(product.QPerUnit, productPage.quantityPerUnit.GetAttribute("value"));
            Assert.AreEqual(product.UInStock, productPage.unitsInStock.GetAttribute("value"));
            Assert.AreEqual(product.UOnOrder, productPage.unitsOnOrder.GetAttribute("value"));
            Assert.AreEqual(product.RLevel, productPage.reorderLevel.GetAttribute("value"));

            driver.Quit();
        }

        [When(@"I click on button Remove test product")]
        public void WhenIClickOnButtonRemoveTestProduct()
        {
            new AllProductsPage(driver).ClickProductRemove();
        }

        [Then(@"test product should be remove")]
        public void ThenTestProductShouldBeRemove()
        {
            Assert.AreEqual(true, isElementsNotPresent());

            driver.Quit();
        }
        public static bool isElementsNotPresent()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr/td/a[text()='Cake']")).Count != 0;
        }
    }
}
