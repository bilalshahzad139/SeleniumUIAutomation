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



            System.Console.ReadKey();

            driver.Close();
            driver.Quit();
        }
    }
}
