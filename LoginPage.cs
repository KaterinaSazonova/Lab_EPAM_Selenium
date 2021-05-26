using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;


namespace Selenium_WD_Lab2
{
    class LoginPage : AbstractPage
    {
        public LoginPage (IWebDriver driver)
        {
            AbstractPage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement login;
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//input [@type='submit']")]
        private IWebElement submitInp;
        [FindsBy(How = How.XPath, Using = "//h2")]
        public IWebElement resultLogout;

        public HomePage Login(String log, String pass)
        {
            login.SendKeys(log);
            password.SendKeys(pass);
            submitInp.Click();
            return new HomePage(driver);
        }
    }
}
