
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


        public void ScrapResults()
        {

            var divs = driver.FindElements(By.CssSelector("div.rc"));

            foreach(var div in divs)
            {
                var text = div.FindElement(By.CssSelector("div.r h3.LC20lb")).Text;
                var url = div.FindElement(By.CssSelector("div.r cite.iUh30")).Text;
                var para = div.FindElement(By.CssSelector("span.st")).Text;

                Console.WriteLine("Link Text:{0}", text);
                Console.WriteLine("Link URL:{0}", url);
                Console.WriteLine("Para:{0}", para);
                Console.WriteLine("------------------");
            }
        }



        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
