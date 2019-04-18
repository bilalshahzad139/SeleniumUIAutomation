﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SelinumTest
{
    class Program
    {
        static void Main(string[] args)
        {

            SelHelper.SelHelperTest helperObj = new SelHelper.SelHelperTest();
            helperObj.Start();

            var queryText = "bilalshahzad139";

            helperObj.Search(queryText);

            helperObj.ScrapResults();

            System.Console.ReadKey();

            helperObj.Close();


        }
    }
}
