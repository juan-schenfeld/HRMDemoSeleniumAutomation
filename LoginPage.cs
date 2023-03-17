using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace HRMDemoSeleniumAutomation
{
    internal class LoginPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement _usernamefield;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement _passwordfield;
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement _loginbutton;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        public LoginPage Login(string username, string password)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until(ExpectedConditions.ElementToBeClickable(_loginbutton));
            _usernamefield.SendKeys(username);
            _passwordfield.SendKeys(password);
            _loginbutton.Click();

            return this;
        }

        public bool IsLoged()
        {
            return _driver.Url.Contains("dashboard");
        }


    }

}
