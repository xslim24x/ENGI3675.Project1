using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace WebApplication3UNITtest
{
    [TestClass]
    public class WebApplicationTEST
    {

        public void Dictest(Dictionary<string, int> indict)
        {
            Dictionary<string, int> ExpectValues = new Dictionary<string, int>()
            {
                {"Red",3},
                {"Turquoise", 17},
                {"Grey", 5},
                {"Indigo",6}
            };


            Assert.IsFalse(indict.Count == 0);
            if (indict.Count == 0)
                Console.WriteLine("Tested table is either empty or there is a connection problem");

            foreach (KeyValuePair<string, int> entry in indict)
            {
                if (ExpectValues.ContainsKey(entry.Key))
                {
                    if (entry.Value != ExpectValues[entry.Key])
                    {
                        Console.WriteLine("Tested table contains {1} for the expected value of {2} for: {0}", entry.Key, entry.Value, ExpectValues[entry.Key]);
                        Assert.AreEqual(ExpectValues[entry.Key], entry.Value);
                    }
                    ExpectValues.Remove(entry.Key);
                }
                else
                {
                    Console.WriteLine("Tested table contains an extra row: {0} {1}", entry.Key, entry.Value);
                    Assert.IsTrue(ExpectValues.ContainsKey(entry.Key));
                }
            }

            foreach (KeyValuePair<string, int> entry in ExpectValues)
            {
                Console.WriteLine("Expected value was missing: {0} {1}", entry.Key, entry.Value);
                Assert.IsNull(entry.Key);
            }

            return;

        }



        [TestMethod]
        public void DatabaseTest()
        {

            WebApplication3.PaintTable test = new PaintTable();
            Dictionary<string, int> DatabaseValues = test.DataDict();

            Dictest(DatabaseValues);


        }



        public void BrowserTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:2428/PaintTable.aspx");

            IList<IWebElement> rows = driver.FindElements(By.TagName("tr"));
            Dictionary<string, int> newtable = new Dictionary<string, int>();

            foreach (IWebElement r in rows)
            {
                String[] cell = r.Text.Split(" ".ToCharArray());
                if (cell[0].Contains("Paint")) // both "Paints" and "Paint Name"
                    break;
                newtable.Add(cell[0], Convert.ToInt32(cell[1]));
            }
            Dictest(newtable);

        }

        [TestMethod]
        public void chromeTest()
        {
            ChromeDriver chrome = new ChromeDriver();
            BrowserTest(chrome);
        }

        [TestMethod]
        public void ieTest()
        {
            InternetExplorerDriver ie = new InternetExplorerDriver();
            BrowserTest(ie);
        }
        [TestMethod]
        public void firefoxTest()
        {
            FirefoxDriver ffox = new FirefoxDriver();
            BrowserTest(ffox);
        }
    }


}
