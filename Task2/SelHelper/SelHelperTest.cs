
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelHelper
{
    public class SelHelperTest
    {
        IWebDriver driver;
        public SelHelperTest()
        {
            driver = new ChromeDriver();

            
        }
        public void Start()
        {
            String url = "https://www.google.com";
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public void Search(String pSearchString)
        {
            var queryField = driver.FindElement(By.CssSelector("input[name=q]"));
            queryField.Clear();
            queryField.SendKeys(pSearchString + Keys.Enter);

            //driver.FindElement(By.CssSelector("input[name=btnK]")).Click();

        }

        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
