using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            String log = "user";
            String pass = "user";

            LoginPage loginPage = new LoginPage(driver);

            HomePage homePage = loginPage.Login(log, pass);

            Assert.AreEqual("Logout", homePage.logout.Text);
        }

        [Test]
        public void Test2_CreateNewProduct()
        {
            String pName = "Cake";
            String category = "Confections";
            String supplier = "Pavlova, Ltd.";
            String uPrice = "70";
            String qPerUnit = "10 boxes * 5 pc";
            String uInStock = "32";
            String uOnOrder = "5";
            String rLevel = "0";

            HomePage homePage = new HomePage(driver);

            AllProductsPage allProducts = homePage.Products();

            CreateNewProductPage createNewProduct = allProducts.NewProduct();

            AllProductsPage allProducts1 = createNewProduct.CreateNewProduct(pName, category, supplier, uPrice, qPerUnit, uInStock, uOnOrder, rLevel);
            
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