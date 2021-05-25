using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_WD_Lab2.dto;
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
            LoginPage loginPage = new LoginPage(driver);

            HomePage homePage = loginPage.Login(Data.log, Data.pass);

            Assert.AreEqual("Logout", homePage.logout.Text);
        }

        [Test]
        public void Test2_CreateNewProduct()
        {
            HomePage homePage = new HomePage(driver);

            AllProductsPage allProducts = homePage.Products();

            CreateNewProductPage createNewProduct = allProducts.NewProduct();

            AllProductsPage allProducts1 = createNewProduct.CreateNew(Data.pName, Data.category, Data.supplier, Data.uPrice, Data.qPerUnit, Data.uInStock, Data.uOnOrder, Data.rLevel);
            
            Assert.AreEqual("All Products", allProducts1.resultCreate.Text);
        }

        [Test]
        public void Test3_CheckNewProduct()
        {
            AllProductsPage allProducts = new AllProductsPage(driver);

            ProductPage productPage = allProducts.ProductPage();

            Assert.AreEqual("Cake", productPage.productName.GetAttribute("value"));
            Assert.AreEqual("Confections", productPage.categoryId.Text);
            Assert.AreEqual("Pavlova, Ltd.", productPage.supplierId.Text);
            Assert.AreEqual("70,0000", productPage.unitPrice.GetAttribute("value"));
            Assert.AreEqual("10 boxes * 5 pc", productPage.quantityPerUnit.GetAttribute("value"));
            Assert.AreEqual("32", productPage.unitsInStock.GetAttribute("value"));
            Assert.AreEqual("5", productPage.unitsOnOrder.GetAttribute("value"));
            Assert.AreEqual("0", productPage.reorderLevel.GetAttribute("value"));

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