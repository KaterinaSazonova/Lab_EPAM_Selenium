using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WD_Lab2.Fabric
{
    public class Login
    {
        private object testsData;

        public String Log { get; set; }
        public String Pass { get; set; }
        
        public Login()
        {
            Log = "user";
            Pass = "user";
        }
    }    
}
