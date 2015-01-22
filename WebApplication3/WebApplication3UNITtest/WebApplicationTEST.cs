using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3;
using System.Collections.Generic;   
using System.Web.UI.WebControls;

namespace WebApplication3UNITtest
{
     [TestClass]
     public class WebApplicationTEST
     {
          [TestMethod]
          public void TestMethod1()
          {
              Dictionary<string, int> ExpectValues = new Dictionary<string,int>()
              {
                    {"Red",3},
                    {"Turnquoise", 17},
                    {"Grey", 5},
                    {"Indigo",6}
              };
              WebApplication3.PaintTable test;
              test

              

              }
          }
     }
}
