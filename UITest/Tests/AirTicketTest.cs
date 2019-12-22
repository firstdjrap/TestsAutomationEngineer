using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using UITest.Helpers;

namespace UITest.Tests
{
    class AirTicketTest
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
        public void BuyingTicketsTest()
        {
            var element = _driver.FindElement(By.XPath("//a[@data-decider-header='flights']"));
            element.Click();

            Thread.Sleep(1000);

            element = _driver.FindElement(By.XPath("//label[@class='r9-radiobuttonset-label']"));
            element.Click();
            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//input[@name='origin']"));
            element.Click();
            Thread.Sleep(100);
            element.SendKeys("WAW");

            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//input[@name='destination']"));
            element.Click();
            Thread.Sleep(100);
            element.SendKeys("NYC");

            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//div[@class='keel-container form-container s-t-bp']"));
            element.Click();
            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//div[@class='dateInput size-l input-flat']"));
            element.Click();
            Thread.Sleep(100);
            element.SendKeys("01.01.2020");
            Thread.Sleep(100);
            element.SendKeys(Keys.Enter);

            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//div[@class='col col-button right']"));
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