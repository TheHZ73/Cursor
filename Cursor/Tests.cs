using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Cursor
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

        [Test]
        public void TestCursor()
        {
            driver.Navigate().GoToUrl(@"http://way2automation.com/way2auto_jquery/menu.php");

            string login = "TheHZ";
            string password = "Wizard73";
            var loginForm = new LoginForm(driver);
            loginForm.Login(login, password);

            var page = new PageHelpers(driver);
            page.OpenMenu();
            Assert.True(page.OpenSubMenuItem());
        }
    }
}

