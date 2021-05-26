using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WD_Lab2.Fabric
{
    public class Product
    {
        
        public String PName { get; set; }
        public String Category { get; set; }
        public String Supplier { get; set; }
        public String UPrice { get; set; }
        public String QPerUnit { get; set; }
        public String UInStock { get; set; }
        public String UOnOrder { get; set; }
        public String RLevel { get; set; }

        public Product()
        {
            PName = "Cake";
            Category = "Confections";
            Supplier = "Pavlova, Ltd.";
            UPrice = "70";
            QPerUnit = "10 boxes * 5 pc";
            UInStock = "32";
            UOnOrder = "5";
            RLevel = "0";
        }        
    }
}
