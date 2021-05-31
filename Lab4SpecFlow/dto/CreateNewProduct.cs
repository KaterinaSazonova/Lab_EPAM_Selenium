using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Lab4_SpecFlow.dto;
using OpenQA.Selenium.Support.UI;
using System;
using Lab4_SpecFlow.Fabric;

namespace Lab4_SpecFlow.dto
{
    class CreateNewProduct      
    {
        public static void  CreateNew(IWebElement pName, IWebElement category, IWebElement supplier, IWebElement uPrice, IWebElement qPerUnit, IWebElement uInStock, IWebElement uOnOrder, IWebElement rLevel)
        {
            SelectElement clickCategory = new SelectElement(category);
            SelectElement clickSupplier = new SelectElement(supplier);

            Product product = new Product();

            pName.SendKeys(product.PName);
            clickCategory.SelectByText(product.Category);
            clickSupplier.SelectByText(product.Supplier);
            uPrice.SendKeys(product.UPrice);
            qPerUnit.SendKeys(product.QPerUnit);
            uInStock.SendKeys(product.UInStock);
            uOnOrder.SendKeys(product.UOnOrder);
            rLevel.SendKeys(product.RLevel);            
        }
    }
}
