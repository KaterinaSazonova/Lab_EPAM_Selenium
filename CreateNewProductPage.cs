using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenium_WD_Lab2.dto;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium_WD_Lab2
{
    class CreateNewProductPage : AbstractPage
    {
        public CreateNewProductPage(IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ProductName")]
        public IWebElement productName;
        [FindsBy(How = How.Id, Using = "CategoryId")]
        public IWebElement categoryId;
        [FindsBy(How = How.Id, Using = "SupplierId")]
        public IWebElement supplierId;
        [FindsBy(How = How.Id, Using = "UnitPrice")]
        public IWebElement unitPrice;
        [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
        public IWebElement quantityPerUnit;
        [FindsBy(How = How.Id, Using = "UnitsInStock")]
        public IWebElement unitsInStock;
        [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
        public IWebElement unitsOnOrder;
        [FindsBy(How = How.Id, Using = "ReorderLevel")]
        public IWebElement reorderLevel;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement submitSend;

        public AllProductsPage CreateNew()
        {
            CreateNewProduct.CreateNew(productName, categoryId, supplierId, unitPrice, quantityPerUnit, unitsInStock, unitsOnOrder, reorderLevel);
            
            submitSend.Click();
            return new AllProductsPage(driver);
        }
    }
}