
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
        public void LoginVerification()
        {

            LoginActivity();
            var welMsg = driver.FindElement(By.Id("welmsg"));
            if(welMsg != null)
            {
                Console.WriteLine("Login is working");
            }
            //var welMsg = driver.FindElement(By.LinkText("Home"));

        }
        
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
