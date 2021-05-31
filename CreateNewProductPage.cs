using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
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
        private IWebElement productName;
        [FindsBy(How = How.Id, Using = "CategoryId")]
        private IWebElement categoryId;
        [FindsBy(How = How.Id, Using = "SupplierId")]
        private IWebElement supplierId;
        [FindsBy(How = How.Id, Using = "UnitPrice")]
        private IWebElement unitPrice;
        [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
        private IWebElement quantityPerUnit;
        [FindsBy(How = How.Id, Using = "UnitsInStock")]
        private IWebElement unitsInStock;
        [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
        private IWebElement unitsOnOrder;
        [FindsBy(How = How.Id, Using = "ReorderLevel")]
        private IWebElement reorderLevel;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submitSend;

        public AllProductsPage CreateNewProduct(String pName, String category, String supplier, String uPrice, String qPerUnit, String uInStock, String uOnOrder, String rLevel)
        {
            SelectElement clickCategory = new SelectElement(categoryId);
            SelectElement clickSupplier = new SelectElement(supplierId);
            productName.SendKeys(pName);
            clickCategory.SelectByText(category);
            clickSupplier.SelectByText(supplier);
            unitPrice.SendKeys(uPrice);
            quantityPerUnit.SendKeys(qPerUnit);
            unitsInStock.SendKeys(uInStock);
            unitsOnOrder.SendKeys(uOnOrder);
            reorderLevel.SendKeys(rLevel);
            submitSend.Click();
            return new AllProductsPage(driver);
        }
    }
}