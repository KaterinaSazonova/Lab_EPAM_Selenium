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
        public static IWebElement productName;
        [FindsBy(How = How.Id, Using = "CategoryId")]
        public static IWebElement categoryId;
        [FindsBy(How = How.Id, Using = "SupplierId")]
        public static IWebElement supplierId;
        [FindsBy(How = How.Id, Using = "UnitPrice")]
        public static IWebElement unitPrice;
        [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
        public static IWebElement quantityPerUnit;
        [FindsBy(How = How.Id, Using = "UnitsInStock")]
        public static IWebElement unitsInStock;
        [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
        public static IWebElement unitsOnOrder;
        [FindsBy(How = How.Id, Using = "ReorderLevel")]
        public static IWebElement reorderLevel;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public static IWebElement submitSend;

        public AllProductsPage CreateNew(String pName, String category, String supplier, String uPrice, String qPerUnit, String uInStock, String uOnOrder, String rLevel)
        {
            CreateNewProduct.CreateNew(pName, category, supplier, uPrice, qPerUnit, uInStock, uOnOrder, rLevel);
            return new AllProductsPage(driver);
        }
    }
}