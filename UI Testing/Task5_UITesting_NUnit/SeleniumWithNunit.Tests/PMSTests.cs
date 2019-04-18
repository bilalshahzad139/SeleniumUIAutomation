using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWithNunit.Tests
{
    [TestFixture]
    public class PMSTests
    {
        IWebDriver driver;
        String url = "http://localhost:59773/";

        [SetUp]
        public void Setup()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            driver = new ChromeDriver(option);
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }

        private void LoginActivity()
        {

            driver.Navigate().GoToUrl(url);

            String loginSelector = "input[name=login]";
            var loginField = driver.FindElement(By.CssSelector(loginSelector));
            loginField.Clear();
            loginField.SendKeys("admin");

            var passField = driver.FindElement(By.CssSelector("input[name=password]"));
            passField.Clear();
            passField.SendKeys("admin");

            driver.FindElement(By.CssSelector("input[value=Login]")).Click();
        }

        [Test]
        public void LoginVerification()
        {
            LoginActivity();
            var welMsg = driver.FindElement(By.Id("welmsg"));
            Assert.IsNotNull(welMsg);
        }

        [Test]
        public void LoginAndAdminUserVerification()
        {
            LoginActivity();

            var lnkFound = driver.FindElement(By.LinkText("New Product"));
            Assert.IsNotNull(lnkFound);
        }

        [Test]
        public void NewProductVerification()
        {
            LoginActivity();

            //Links can be found by Text
            driver.FindElement(By.LinkText("New Product")).Click();

            //Provide Input Data
            driver.FindElement(By.CssSelector("input[name=Name]")).SendKeys("New Product 1");
            driver.FindElement(By.CssSelector("input[name=Price]")).SendKeys("50");

            driver.FindElement(By.Id("fileInput")).SendKeys(@"D:\Trainings\Selenium\test.png");

            driver.FindElement(By.CssSelector("input[name=btnSave]")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(500));
            wait.Until(ExpectedConditions.ElementExists(By.Id("spMsg")));

            //Check Current URL 
            var isCorrectUrl = driver.Url.Contains("Product/ShowAll");
            //Check Message
            var welMsgText = driver.FindElement(By.Id("spMsg")).Text;

            Assert.AreEqual(isCorrectUrl, true);
            Assert.AreEqual(welMsgText, "Record is saved!");
        }

        [Test]
        public void ShowAllVerification()
        {
            LoginActivity();

            //Links can be found by Text
            driver.FindElement(By.Id("lnkShowAll")).Click();

            var elemFound = driver.FindElements(By.CssSelector(".prodbox")).Count;

            Assert.Greater(elemFound, 0);
        }
    }
}
