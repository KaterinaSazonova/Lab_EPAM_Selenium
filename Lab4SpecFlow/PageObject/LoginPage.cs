using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;


namespace Lab4_SpecFlow.PageObject
{
    class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver driver)
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

        public LoginPage Login(string name, string pass)
        {
            login.SendKeys(name);
            password.SendKeys(pass);
            return new LoginPage(driver);

        }
        public HomePage ClickSend()
        {
            submitInp.Click();
            return new HomePage(driver);
        }
    }
}
