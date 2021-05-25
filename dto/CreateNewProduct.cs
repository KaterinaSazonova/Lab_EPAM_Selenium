using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WD_Lab2.dto
{
    class CreateNewProduct      
    {
        public static void  CreateNew(String pName, String category, String supplier, String uPrice, String qPerUnit, String uInStock, String uOnOrder, String rLevel)
        {
            SelectElement clickCategory = new SelectElement(CreateNewProductPage.categoryId);
            SelectElement clickSupplier = new SelectElement(CreateNewProductPage.supplierId);

            CreateNewProductPage.productName.SendKeys(pName);
            clickCategory.SelectByText(category);
            clickSupplier.SelectByText(supplier);
            CreateNewProductPage.unitPrice.SendKeys(uPrice);
            CreateNewProductPage.quantityPerUnit.SendKeys(qPerUnit);
            CreateNewProductPage.unitsInStock.SendKeys(uInStock);
            CreateNewProductPage.unitsOnOrder.SendKeys(uOnOrder);
            CreateNewProductPage.reorderLevel.SendKeys(rLevel);
            CreateNewProductPage.submitSend.Click();
        }
    }
}
