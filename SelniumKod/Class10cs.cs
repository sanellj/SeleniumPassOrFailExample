using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SelniumKod
{
    class Class10cs
    {
        IWebDriver driver;

        [Test]
        public void TestUnos()
        {
            string txtMessage = "Ovo je neka poruka.";
            GoToWebsite("http://qa.todorowww.net/", true);
            IWebElement txtUnos = FindElement(By.Name("unos"));
            txtUnos?.SendKeys(txtMessage);
            Sleep(2);
            if (txtUnos.Text == txtMessage)
            {
                Assert.Fail("The text differs from requested.");
            }
            else
            {
                Assert.Pass("Entered text matches the requested one.");
            }
        }

      
        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        public void Sleep(int ms = 1000)
        {
            System.Threading.Thread.Sleep(ms);
        }

        public void GoToWebsite(string url, bool wait = false)
        {
            if (wait) { Sleep(); }
            driver.Navigate().GoToUrl(url);
            if (wait) { Sleep(); }
        }

        public IWebElement FindElement(By selector)
        {
            IWebElement elReturn = null;
            try
            {
                elReturn = driver.FindElement(selector);
            }
            catch (NoSuchElementException)
            {

            }
            catch (Exception e)
            {
                throw e;
            }

            return elReturn;
        }
    }
}