using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace HRMDemoSeleniumAutomation
{
    public class Tests
    {
        private IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        [Test]
        public void LoginTest()
        {
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            LoginPage ls = new LoginPage(_driver);
            ls.Login("Admin", "admin123");
            Assert.True(ls.IsLoged(), "Login failed. URL does not contain 'dashboard'.");
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }

}