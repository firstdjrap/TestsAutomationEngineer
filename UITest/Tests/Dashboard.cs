using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using UITest.Helpers;

namespace UITest.Tests
{
    class Dashboard
    {
        private IWebDriver _driver;
        private IndexPageHelper _indexPage;

        [SetUp]
        public void Setup()
        {
            _indexPage = new IndexPageHelper();

            _driver = _indexPage.Setup();
        }

        [Test]
        public void CheckPersonalPanelTest()
        {
            var element = _driver.FindElement(By.XPath("//li[@id='current_account']"));
            element.Click();

            Thread.Sleep(1000);

            element = _driver.FindElement(By.XPath("//input[@id='username']"));
            element.Click();
            Thread.Sleep(100);
            element.SendKeys("username@domain.com");

            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//button[@type='submit']"));
            element.Click();

            Thread.Sleep(1000);

            element = _driver.FindElement(By.XPath("//input[@id='password']"));
            element.Click();
            Thread.Sleep(100);
            element.SendKeys("password");

            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//button[@type='submit']"));
            element.Click();

            Thread.Sleep(1000);

            element = _driver.FindElement(By.XPath("//li[@id='current_account']"));
            element.Click();

            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//a[@data-acc-aa-db='menu_dashboard']"));
            element.Click();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}