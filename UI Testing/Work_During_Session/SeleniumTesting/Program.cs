using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var driver =new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");

            //Wait

            //var elem = driver.FindElement(By.CssSelector("input[name=q]"));

            var elem = driver.FindElement(By.Name("q"));

            elem.Clear();

            elem.SendKeys("bilalshahzad139" + Keys.Enter);

            //elem.SendKeys("bilalshahzad139");
            //driver.FindElement(By.Name("btnK")).Click();


            var elements = driver.FindElements(By.CssSelector("div.rc"));

            //foreach(var elem1 in elements)
            for(int i=0;i<elements.Count;i++)
            {
                var elem1 = elements[i];
                var h3 = elem1.FindElement(By.CssSelector("h3.LC20lb")).Text;
                var link = elem1.FindElement(By.CssSelector("cite.iUh30")).Text;
                var desc = elem1.FindElement(By.CssSelector("span.st")).Text;

                System.Console.WriteLine("H3" + h3);
                System.Console.WriteLine("Link" + link);
                System.Console.WriteLine("Desc" + desc);
            }
            */

            /*
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pakistanistores.com/");

            var elem = driver.FindElement(By.Id ("searchInput"));
            elem.Clear();
            elem.SendKeys("laptop");

            driver.FindElement(By.CssSelector("button[type=submit]")).Click();


            var elements = driver.FindElements(By.CssSelector("div.product"));

            foreach(var elem1 in elements)
            //for (int i = 0; i < elements.Count; i++)
            {
                var imgUrl = elem1.FindElement(By.CssSelector("div.img-holder img")).GetAttribute("src");
                var desc = elem1.FindElement(By.CssSelector("div.description-holder h5")).Text;
                var price = elem1.FindElement(By.CssSelector("div.price")).Text;
                var sitename = elem1.FindElement(By.CssSelector("div.sitename")).Text;


                System.Console.WriteLine("imgUrl:" + imgUrl);
                System.Console.WriteLine("desc:" + desc);
                System.Console.WriteLine("price:" + price);
                System.Console.WriteLine("sitename:" + sitename);
            }
            
        */


            //LoginVerification();

            //AdminLoginVerification();

            NewProductVerification();





            System.Console.ReadKey();

            
        }

        private static void LoginVerification() {

            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://10.80.10.189:8087/");
            var elem = driver.FindElement(By.CssSelector("input[name=login]"));
            elem.Clear();
            elem.SendKeys("admin");

            var elem1 = driver.FindElement(By.CssSelector("input[name=password]"));
            elem1.Clear();
            elem1.SendKeys("admin");

            driver.FindElement(By.CssSelector("input[value=Login][type=submit]")).Click();

            var lnk = driver.FindElement(By.LinkText("Logout"));
            if (lnk != null)
            {
                Console.WriteLine("Login successfull");
            }

            System.Console.ReadKey();

            driver.Close();
            driver.Quit();
        }

        private static void AdminLoginVerification()
        {

            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://10.80.10.189:8087/");
            var elem = driver.FindElement(By.CssSelector("input[name=login]"));
            elem.Clear();
            elem.SendKeys("admin");

            var elem1 = driver.FindElement(By.CssSelector("input[name=password]"));
            elem1.Clear();
            elem1.SendKeys("admin");

            driver.FindElement(By.CssSelector("input[value=Login][type=submit]")).Click();

            var correctURL = driver.Url.Contains("Home/Admin");
            
            var lnk = driver.FindElement(By.LinkText("New Product"));
            if (correctURL && lnk != null)
            {
                Console.WriteLine("Admin Login successfull");
            }

            System.Console.ReadKey();

            driver.Close();
            driver.Quit();
        }

        private static void NewProductVerification()
        {

            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://10.80.10.189:8087/");
            var elem = driver.FindElement(By.CssSelector("input[name=login]"));
            elem.Clear();
            elem.SendKeys("admin");

            var elem1 = driver.FindElement(By.CssSelector("input[name=password]"));
            elem1.Clear();
            elem1.SendKeys("admin");

            driver.FindElement(By.CssSelector("input[value=Login][type=submit]")).Click();

            driver.FindElement(By.LinkText("New Product")).Click();

            driver.FindElement(By.CssSelector("input[name=Name]")).SendKeys("p1");
            driver.FindElement(By.CssSelector("input[name=Price]")).SendKeys("1000");
            driver.FindElement(By.CssSelector("input#fileInput")).SendKeys(@"D:\test.png");

            driver.FindElement(By.CssSelector("input[name=btnSave]")).Click();

            var correctURL = driver.Url.Contains("Product/ShowAll");

            var lnk = driver.FindElement(By.Id("spMsg"));
            if (correctURL == true && lnk.Text == "Record is saved!")
            {
                Console.WriteLine("New producted created successfully");
            }

            System.Console.ReadKey();

            driver.Close();
            driver.Quit();
        }
    }
}
