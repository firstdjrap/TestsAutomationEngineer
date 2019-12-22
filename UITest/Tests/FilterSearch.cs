using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using UITest.Helpers;

namespace UITest.Tests
{
    class FilterSearch
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
        public void FilterSearchTest()
        {
            var element = _driver.FindElement(By.XPath("//input[@id='ss']"));
            element.Click();
            Thread.Sleep(100);
            element.SendKeys("NYC");

            Thread.Sleep(1000);

            element = _driver.FindElement(By.XPath("//li[@data-i='0']"));
            element.Click();

            Thread.Sleep(100);

            var timeNow = DateTime.Now;
            int dayCheckIn = timeNow.Day + 7;
            element = _driver.FindElement(By.XPath("//td[@data-date='" + timeNow.Year + "-" + timeNow.Month + "-" + dayCheckIn + "']"));
            element.Click();

            Thread.Sleep(100);

            int dayDeparture = dayCheckIn + 2;
            element = _driver.FindElement(By.XPath("//td[@data-date='" + timeNow.Year + "-" + timeNow.Month + "-" + dayDeparture + "']"));
            element.Click();

            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//label[@id='xp__guests__toggle']"));
            element.Click();

            Thread.Sleep(100);

            element = _driver.FindElement(By.XPath("//div[@class='sb-group__field sb-group-children ']/div/div/button[@data-bui-ref='input-stepper-add-button']"));
            element.Click();

            Thread.Sleep(100);
            element = _driver.FindElement(By.XPath("//button[@class='sb-searchbox__button ']"));
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