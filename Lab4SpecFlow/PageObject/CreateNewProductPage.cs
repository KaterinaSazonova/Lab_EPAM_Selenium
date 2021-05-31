using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Lab4_SpecFlow.dto;
using Lab4_SpecFlow.Fabric;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab4_SpecFlow.PageObject
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

        
        public CreateNewProductPage CreateNewPr()
        {
            CreateNewProduct.CreateNew(productName, categoryId, supplierId, unitPrice, quantityPerUnit, unitsInStock, unitsOnOrder, reorderLevel);
            return new CreateNewProductPage(driver);

        }
        public AllProductsPage ClickSend()
        {
            submitSend.Click();
            return new AllProductsPage(driver);
        }
    }
}