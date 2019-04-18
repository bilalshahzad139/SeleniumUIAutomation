
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SelHelper
{
    public class SelHelperTest
    {
        IWebDriver driver;
        String url = "http://localhost:59773/";

        public SelHelperTest()
        {
            driver = new ChromeDriver();
        }
        
        public void LoginActivity()
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

            //Verify if Product is Saved, How to do that?

            //Check Current URL 
            var isCorrectUrl = driver.Url.Contains("Product/ShowAll");

            if (isCorrectUrl)
            {
                //Check Message
                var welMsg = driver.FindElement(By.Id("spMsg"));
                if(welMsg.Text == "Record is saved!")
                {
                    Console.WriteLine("New Product Verification done");
                    //Check if page is showing the product

                }
            }


            
        }
        
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
