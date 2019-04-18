
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

        public void ShowAllVerification(int pCountToVerify)
        {
            LoginActivity();

            //Links can be found by Text
            driver.FindElement(By.Id("lnkShowAll")).Click();


            var elemFound = driver.FindElements(By.CssSelector(".prodbox")).Count;

            if(elemFound == pCountToVerify)
            {
                Console.WriteLine("Correct Count");
            }
            

        }

        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
