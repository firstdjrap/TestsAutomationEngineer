using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using UITest.Helpers;

namespace UITest.Tests
{
    class IndexPageTest
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
        public void ChangeLanguageTest()
        {
            foreach (string dataLang in _indexPage.DataLang)
            {
                var element = _driver.FindElement(By.XPath("//li[@data-id='language_selector']"));
                element.Click();

                Thread.Sleep(1000);

                element = _driver.FindElement(By.XPath("//li[@data-lang='" + dataLang + "']"));
                element.Click();

                Thread.Sleep(1000);
            }
        }

        [Test]
        public void ChangeCurrenciesTest()
        {
            foreach (string dataCurr in _indexPage.DataCurr)
            {
                var element = _driver.FindElement(By.XPath("//li[@data-id='currency_selector']"));
                element.Click();

                Thread.Sleep(1000);

                element = _driver.FindElement(By.XPath("//li[@data-lang='" + dataCurr + "']"));
                element.Click();

                Thread.Sleep(1000);
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}