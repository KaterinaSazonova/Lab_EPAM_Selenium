using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Lab_Epam_Selenium
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();
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
            IWebElement login = driver.FindElement(By.Id("Name"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement submitInp = driver.FindElement(By.XPath("//input [@type='submit']"));

            login.SendKeys("user");
            password.SendKeys("user");
            submitInp.Click();

            IWebElement result = driver.FindElement(By.XPath("//a [@href='/Account/Logout']"));

            Assert.AreEqual("Logout", result.Text);
        }



        [Test]
        public void Test2_CreateNewProduct()
        {
            IWebElement allProducts = driver.FindElement(By.XPath("//body/div//a[@href = '/Product']"));
            allProducts.Click();
            Thread.Sleep(5000);

            IWebElement createNew = driver.FindElement(By.XPath("//a[contains(.,'Create new')]"));      
            createNew.Click();
            

            IWebElement productName = driver.FindElement(By.Id("ProductName"));
            IWebElement categoryId = driver.FindElement(By.Id("CategoryId"));
            IWebElement supplierId = driver.FindElement(By.Id("SupplierId"));
            IWebElement unitPrice = driver.FindElement(By.Id("UnitPrice"));
            IWebElement quantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit"));
            IWebElement unitsInStock = driver.FindElement(By.Id("UnitsInStock"));
            IWebElement unitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder"));
            IWebElement reorderLevel = driver.FindElement(By.Id("ReorderLevel"));

            SelectElement clickCategory = new SelectElement(categoryId);
            SelectElement clickSupplier = new SelectElement(supplierId);

            productName.SendKeys("Cake");
            clickCategory.SelectByText("Confections");
            clickSupplier.SelectByText("Pavlova, Ltd.");
            unitPrice.SendKeys("70");
            quantityPerUnit.SendKeys("10 boxes * 5 pc");
            unitsInStock.SendKeys("32");
            unitsOnOrder.SendKeys("5");
            reorderLevel.SendKeys("0");

            IWebElement submitSend = driver.FindElement(By.XPath("//input[@type='submit']"));
            submitSend.Click();

            IWebElement resultTest = driver.FindElement(By.XPath("//h2"));
            Assert.AreEqual("All Products", resultTest.Text);
        }

        [Test]
        public void Test3_CheckNewProduct()
        {
            IWebElement editProduct = driver.FindElement(By.XPath("//td[a[text()='Cake']] / following-sibling::td [a[text()='Edit']]"));
            editProduct.Click();

            IWebElement productName = driver.FindElement(By.Id("ProductName"));
            IWebElement categoryId = driver.FindElement(By.XPath("//select[@id='CategoryId']//option[@selected='selected']"));
            IWebElement supplierId = driver.FindElement(By.XPath("//select[@id='SupplierId']//option[@selected='selected']"));
            IWebElement unitPrice = driver.FindElement(By.Id("UnitPrice"));
            IWebElement quantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit"));
            IWebElement unitsInStock = driver.FindElement(By.Id("UnitsInStock"));
            IWebElement unitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder"));
            IWebElement reorderLevel = driver.FindElement(By.Id("ReorderLevel"));

            Assert.AreEqual("Cake", productName.GetAttribute("value"));
            Assert.AreEqual("Confections", categoryId.Text);
            Assert.AreEqual("Pavlova, Ltd.", supplierId.Text);
            Assert.AreEqual("70,0000", unitPrice.GetAttribute("value"));
            Assert.AreEqual("10 boxes * 5 pc", quantityPerUnit.GetAttribute("value"));
            Assert.AreEqual("32", unitsInStock.GetAttribute("value"));
            Assert.AreEqual("5", unitsOnOrder.GetAttribute("value"));
            Assert.AreEqual("0", reorderLevel.GetAttribute("value"));
        

            
            IWebElement backProducts = driver.FindElement(By.XPath("//a[text() = 'Products']"));
            backProducts.Click();

        }

        // [Test]
        // public void Test4_RemoveProduct()
        //{
        //    IWebElement removeProduct = driver.FindElement(By.XPath("//td[a[text()='Cake']] / following-sibling::td [a[text()='Remove']]"));
        //   removeProduct.Click();

        //IWebElement removeOK = driver.FindElement(By.XPath("//script[@src = '/node_modules/jquery-validation/dist/jquery.validate.js']"));
        //removeOK.Click();

        //  }


        [Test]
        public void Test5_Logout()
        {
            IWebElement logout = driver.FindElement(By.XPath("//a[@href='/Account/Logout']"));
            logout.Click();
            IWebElement resultTest5 = driver.FindElement(By.XPath("//h2"));
            Assert.AreEqual("Login", resultTest5.Text);
        }

    }
}