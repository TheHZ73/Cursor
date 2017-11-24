using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Cursor
{
    class PageHelpers
    {
        private IWebDriver driver;
        private By menu = By.XPath("//img[@src=\"images/menu.jpg\"]");
        private By menuWithSubMenu = By.XPath("//a[contains(text(),'Menu With Sub Menu')]");
        private By firstMenuWithSubMenu = By.Id("ui-id-2");
        private By childMenuWithSubMenu = By.Id("ui-id-3");

        public PageHelpers(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenMenu()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(menu));
            driver.FindElement(menu).Click();
        }

        public bool OpenSubMenuItem()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(menuWithSubMenu));
            driver.FindElement(menuWithSubMenu).Click();
            driver.SwitchTo().Frame(1);
            Actions actions = new Actions(driver);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(firstMenuWithSubMenu));
            actions.MoveToElement(driver.FindElement(firstMenuWithSubMenu)).Perform();
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(childMenuWithSubMenu));
            return driver.FindElement(childMenuWithSubMenu).Displayed;
        }
    }
}

 

