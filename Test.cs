using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_WD_Lab2.dto;
using Selenium_WD_Lab2.Fabric;
using System;

namespace Selenium_WD_Lab2
{
    [TestFixture]
    public class Test
    {
        public static IWebDriver driver = new ChromeDriver();

        [OneTimeSetUp]
        public void OneSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);            
        }

        [OneTimeTearDown]
        public void OneTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1_Login()
        {
            Login DataLog = new Login();

            LoginPage loginPage = new LoginPage(driver);

            HomePage homePage = loginPage.Login(DataLog.Log, DataLog.Pass);

            Assert.AreEqual("Logout", homePage.logout.Text);
        }

        [Test]
        public void Test2_CreateNewProduct()
        {
            HomePage homePage = new HomePage(driver);

            AllProductsPage allProducts = homePage.Products();

            CreateNewProductPage createNewProduct = allProducts.NewProduct();

            AllProductsPage allProducts1 = createNewProduct.CreateNew();
            
            Assert.AreEqual("All Products", allProducts1.resultCreate.Text);
        }

        [Test]
        public void Test3_CheckNewProduct()
        {
            AllProductsPage allProducts = new AllProductsPage(driver);

            ProductPage productPage = allProducts.ProductPage();

            Product product = new Product();

            Assert.AreEqual(product.PName, productPage.productName.GetAttribute("value"));
            Assert.AreEqual(product.Category, productPage.categoryId.Text);
            Assert.AreEqual(product.Supplier, productPage.supplierId.Text);
            Assert.AreEqual(product.UPrice + ",0000", productPage.unitPrice.GetAttribute("value"));
            Assert.AreEqual(product.QPerUnit, productPage.quantityPerUnit.GetAttribute("value"));
            Assert.AreEqual(product.UInStock, productPage.unitsInStock.GetAttribute("value"));
            Assert.AreEqual(product.UOnOrder, productPage.unitsOnOrder.GetAttribute("value"));
            Assert.AreEqual(product.RLevel, productPage.reorderLevel.GetAttribute("value"));

            AllProductsPage allProducts1 = productPage.ReturnToAllProductsPage();
        }

        [Test]
        public void Test4_RemoveProduct()
        {
            AllProductsPage allProducts = new AllProductsPage(driver);

            AllProductsPage allProducts1 = allProducts.ProductDelete();

            Assert.AreEqual(true, isElementsNotPresent());
        }
        public static bool isElementsNotPresent()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr/td/a[text()='Cake']")).Count != 0;
        }

        [Test]
        public void Test5_Logout()
        {
            AllProductsPage allProducts = new AllProductsPage(driver);

            LoginPage loginPage = allProducts.LogOut();
            Assert.AreEqual("Login", loginPage.resultLogout.Text);
        }
    }
}